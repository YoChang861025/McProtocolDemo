using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using McProtocol_Ref.PLC;

namespace McProtocolDemo.MC
{
    public class MCDValue
    {
        private const string TAG = "MCDValue";
        
        public MCDValue(string ip, int port, int address, int size)
        {
            this.IP = ip;
            this.Port = port;
            this.AddressName = "D";
            this.Address = address;
            this.Long = size;
            this.RawValue = new short[this.Long];
            this.BuildRawValue();
        }

        public MCDValue(string ip, int port, string addressName, int address, int size)
        {
            this.IP = ip;
            this.Port = port;
            this.AddressName = addressName;
            this.Address = address;
            this.Long = size;
            this.RawValue = new short[this.Long];
            this.BuildRawValue();
        }

        public bool BuildRawValue()
        {
            bool isOk = this.Long > 0;
            if (isOk)
            {
                this.RawValue = new short[this.Long];
            }
            return isOk;
        }

        public bool Valid
        {
            get
            {
                return !string.IsNullOrWhiteSpace(this.IP) && this.Port > 0 && !string.IsNullOrWhiteSpace(this.AddressName) && this.Address > 0 && this.Long > 0 && !double.IsNaN(this.DoubleRate) && !double.IsInfinity(this.DoubleRate) && this.DoubleRate != 0.0;
            }
        }

        public short[] RawValue;

        public double DoubleRate = 1.0;
        public double DoubleOffset = 0.0;

        public double DoubleValue
        {
            get
            {
                double data = double.NaN;
                if (this.DoubleRate != 0.0 && this.RawValue != null)
                {
                    if (this.RawValue.Length == 1)
                    {
                        data = Convert.ToDouble(McCommand.ShortArrayToInt16(this.RawValue)) / this.DoubleRate;
                    }
                    else if (this.RawValue.Length == 2)
                    {
                        data = Convert.ToDouble(McCommand.ShortArrayToInt32(this.RawValue)) / this.DoubleRate;
                    }
                    else if (this.RawValue.Length == 4)
                    {
                        data = Convert.ToDouble(McCommand.ShortArrayToInt64(this.RawValue)) / this.DoubleRate;
                    }
                }
                if (!double.IsNaN(data))
                {
                    data -= this.DoubleOffset;
                }
                return data;
            }
            set
            {
                if (this.DoubleRate != 0.0 && !double.IsNaN(value) && !double.IsInfinity(value))
                {
                    if (this.RawValue.Length == 1)
                    {
                        this.RawValue = McCommand.Int16ToShortArray(Convert.ToInt16(Math.Round((value + this.DoubleOffset) * this.DoubleRate, 0, MidpointRounding.AwayFromZero)));
                        //Logger.I(TAG, string.Format("Address: {0}. Length: {1}. RawData: {2}", Address, Long, string.Join(",", RawValue)));
                    }
                    else if (this.RawValue.Length == 2)
                    {
                        this.RawValue = McCommand.Int32ToShortArray(Convert.ToInt32(Math.Round((value + this.DoubleOffset) * this.DoubleRate, 0, MidpointRounding.AwayFromZero)));
                        //Logger.I(TAG, string.Format("Address: {0}. Length: {1}. RawData: {2}", Address, Long, string.Join(",", RawValue)));
                    }
                    else if (this.RawValue.Length == 4)
                    {
                        this.RawValue = McCommand.Int64ToShortArray(Convert.ToInt64(Math.Round((value + this.DoubleOffset) * this.DoubleRate, 0, MidpointRounding.AwayFromZero)));
                        //Logger.I(TAG, string.Format("Address: {0}. Length: {1}. RawData: {2}", Address, Long, string.Join(",", RawValue)));
                    }
                }
            }
        }

        public string GetASCIIString(bool reverse)
        {
            return McCommand.ShortArrayToASCIIString(reverse, this.RawValue);
        }

        public string GetRCodeString()
        {
            return string.Format("{0:0000}{1:00}{2:00}{3:00}{4:00}{5:00}", RawValue[0], RawValue[1], RawValue[2], RawValue[3], RawValue[4], RawValue[5]);
        }

        public bool SetASCIIString(string ASCIIString, bool reverse)
        {
            bool isOk = !string.IsNullOrWhiteSpace(ASCIIString);
            if (isOk)
            {
                this.RawValue = McCommand.ASCIIStringToShortArray(ASCIIString, reverse);
            }
            return isOk;
        }

        public string IP = "";

        public int Port = 0;

        public string AddressName = "D";

        public int Address = -1;

        public int Long = 0;

        public MCP MCP;

        public int AddressEnd
        {
            get
            {
                return this.Address + this.Long - 1;
            }
        }

        public bool SetToMC()
        {
            return this.MCP.SetDOutput(this.AddressName, this.Address, this.Long, this.RawValue);
        }

        public bool GetFormMC()
        {
            return this.MCP.GetDInput(this.AddressName, this.Address, this.Long, ref this.RawValue);
        }
    }
}
