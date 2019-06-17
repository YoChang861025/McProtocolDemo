using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McProtocolDemo.MC
{
    public class MCMValue
    {
        public MCMValue()
        {
        }

        public MCMValue(string ip, int port, int address)
        {
            this.IP = ip;
            this.Port = port;
            this.Address = address;
        }

        public bool Valid
        {
            get
            {
                return !string.IsNullOrWhiteSpace(this.IP) && this.Port > 0 && !string.IsNullOrWhiteSpace(this.AddressName) && this.Address > 0;
            }
        }

        public bool Value = false;

        public string IP = "";

        public int Port = 0;

        public string AddressName = "M";

        public int Address = -1;

        public MCP MCP;

        public bool SetToMC()
        {
            return this.MCP.SetMOutput(this.Address, this.Value);
        }

        public bool GetFormMC()
        {
            return this.MCP.GetMInput(this.Address, ref this.Value);
        }
    }
}
