using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using McProtocol_Ref.PLC;

namespace McProtocolDemo.MC
{
    public class MCP
    {
        private const string TAG = "MCHandshake";
        private object locker = new object();
        private Thread thread;

        public McProtocol McProtocol;

        public List<MCMValue> MInList = new List<MCMValue>();
        public List<MCMValue> MOutList = new List<MCMValue>();
        public List<MCDValue> DInList = new List<MCDValue>();
        public List<MCDValue> DOutList = new List<MCDValue>();

        public bool Inline = false;

        public int InputMAddress = -1;
        public int InputMCount = -1;
        public int InputMAddressMin = -1;
        public int InputMAddressMax = -1;

        public int InputDAddress = -1;
        public int InputDCount = -1;
        public int InputDAddressMin = -1;
        public int InputDAddressMax = -1;

        public void CheckAddress()
        {
            this.InputMAddressMin = this.MInList.Min(x => x.Address);
            this.InputMAddressMax = this.MInList.Max(x => x.Address);
            this.InputMAddress = this.InputMAddressMin;
            this.InputMCount = this.InputMAddressMax - this.InputMAddressMin + 1;

            this.InputDAddressMin = this.DInList.Min(x => x.Address);
            this.InputDAddressMax = this.DInList.Max(x => x.AddressEnd);
            this.InputDAddress = this.InputDAddressMin;
            this.InputDCount = this.InputDAddressMax - this.InputDAddressMin + 1;
        }


        public void SetMInputAddress()
        {
            if (this.InputMAddressMax >= 0 && this.InputMAddressMin >= 0)
            {
                this.InputMAddress = this.InputMAddressMin;
                this.InputMCount = this.InputMAddressMax - this.InputMAddressMin + 1;
            }
            else
            {
                this.InputMAddress = -1;
                this.InputMCount = -1;
            }
        }

        public bool SetMOutput(int address, bool state, bool showSuccessLog = true)
        {
            lock (locker)
            {
                try
                {
                    if (this.McProtocol.IsConnected)
                    {
                        short[] bits = new short[1] { (short)(state ? 1 : 0) };
                        int errcode = this.McProtocol.ExecuteWrite("M", address, 1, bits, showSuccessLog);
                        if (errcode == 0)
                            return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    //Logger.E(TAG, ex.Message);
                    return false;
                }
            }
        }

        public bool GetMInput(int address, ref bool state)
        {
            bool isOk = false;
            if (address >= 0 && this.InputMAddress >= 0 && this.InputMCount > 0)
            {
                this.updateInputBuffer_M();

                int index = address - this.InputMAddress;
                if (this.inputBuffer_M != null && this.inputBuffer_M.Length > index)
                {
                    state = this.inputBuffer_M[index];
                    isOk = true;
                }
            }
            return isOk;
        }

        public bool GetMInput(int address)
        {
            bool state = false;
            bool isOK = this.GetMInput(address, ref state);
            return state;
        }

        public bool SetDOutput(string name, int address, int size, short[] data)
        {
            lock (locker)
            {
            try
            {
                if (this.McProtocol.IsConnected)
                {
                    int errcode = this.McProtocol.ExecuteWrite(name, address, size, data);
                    if (errcode == 0)
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                //Logger.E(TAG, ex.Message);
                return false;
            }
            }
        }

        public bool GetDInput(int address, ref short[] state)
        {

            bool isOk = false;
            if (address >= 0 && this.InputDAddress >= 0 && this.InputDCount > 0)
            {
                this.updateInputBuffer_D();

                int index = address - this.InputDAddress;
                if (this.inputBuffer_D != null && this.inputBuffer_D.Length > index)
                {
                    string strdata = McCommand.ShortArrayToASCIIString(false,inputBuffer_D);
                    state = McCommand.ASCIIStringToShortArray(strdata,false);
                    isOk = true;
                }
            }
            return isOk;
        }

        public bool ManualMode = true;
        public List<int> WatchdogOutAddress = new List<int>();
        public List<int> NormalOutAddress = new List<int>();
        public List<int> AlarmOutAddress = new List<int>();
        public List<int> WarningOutAddress = new List<int>();
        public List<int> ManualSafetyInAddress = new List<int>();
        public List<int> ManualStopInAddress = new List<int>();
        private bool watchdogType = false;
        private DateTime watchdogTime = DateTime.Now;
        private double watchdogDelayMS = 1000.0;
        private void runWatchdog()
        {
            //if (Monitor.TryEnter(locker))
            //{
            if (DateTime.Now.Subtract(watchdogTime).TotalMilliseconds >= this.watchdogDelayMS)
            {
                watchdogType = !watchdogType;
                foreach (int address in WatchdogOutAddress)
                {
                    this.Inline = this.SetMOutput(address, watchdogType, false);
                }
                watchdogTime = DateTime.Now;
            }
            //    Monitor.Exit(locker);
            //}
        }

        private bool[] inputBuffer_M = null;
        private short[] inputBuffer_D = new short[1];
        private DateTime inputBufferTime = DateTime.Now;
        private double inputBufferDelayMS = 50.0;
        private void updateInputBuffer_M()
        {
            if (DateTime.Now.Subtract(this.inputBufferTime).TotalMilliseconds >= this.inputBufferDelayMS)
            {
                lock (locker)
                {
                    try
                    {
                        if (this.McProtocol.IsConnected)
                        {
                            short[] bits = null;
                            int errcode = this.McProtocol.ExecuteRead("M", this.InputMAddress, this.InputMCount, ref bits, false);
                            if (errcode != 0)
                            {
                                //Logger.E(TAG, "Error:" + errcode);
                            }
                            else
                            {
                                this.inputBuffer_M = Array.ConvertAll(bits, x => x != 0);
                            }

                            inputBufferTime = DateTime.Now;
                        }
                        else
                        {
                            //Logger.E(TAG, "No connection");
                        }
                    }
                    catch (Exception ex)
                    {
                        //Logger.E(TAG, ex.Message);
                    }
                }
            }
        }
        private void updateInputBuffer_D()
        {
            if (DateTime.Now.Subtract(this.inputBufferTime).TotalMilliseconds >= this.inputBufferDelayMS)
            {
                lock (locker)
                {
                    try
                    {
                        if (this.McProtocol.IsConnected)
                        {
                            
                            var errcode = this.McProtocol.ExecuteRead("D", this.InputDAddress, this.InputDCount, ref inputBuffer_D);
                            if (errcode != 0)
                            {
                                //Logger.E(TAG, "Error:" + errcode);
                            }
                            else
                            {
                            
                            }

                            inputBufferTime = DateTime.Now;
                        }
                        else
                        {
                            //Logger.E(TAG, "No connection");
                        }
                    }
                    catch (Exception ex)
                    {
                        //Logger.E(TAG, ex.Message);
                    }
                }
            }
        }

        private bool backgroup = false;

        private void runBackgroup()
        {
            while (backgroup)
            {
                this.runWatchdog();
                Thread.Sleep(100);
            }
        }

        public bool WatchdogStart()
        {
            bool isOK = thread == null || thread.ThreadState != System.Threading.ThreadState.Running;

            if (isOK)
            {
                this.thread = new Thread(new ThreadStart(this.runBackgroup));
                this.backgroup = true;
                this.thread.Priority = ThreadPriority.Lowest;
                this.thread.Name = "MCHandshake Work";
                this.thread.Start();
            }
            return isOK;
        }

        public bool WatchdogStop()
        {
            bool isOK = this.thread != null && this.thread.ThreadState != System.Threading.ThreadState.Unstarted;
            if (isOK)
            {
                backgroup = false;
                this.thread.Join();
            }
            return isOK;
        }
    }
}
