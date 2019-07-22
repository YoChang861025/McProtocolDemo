using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using McProtocolDemo.MC;

namespace McProtocolDemo
{
    public class MCPBuild
    {
        public List<MCMValue> MInList = new List<MCMValue>();
        public List<MCMValue> MOutList = new List<MCMValue>();
        public List<MCDValue> DInList = new List<MCDValue>();
        public List<MCDValue> DOutList = new List<MCDValue>();
        public List<MCP> MCPList = new List<MCP>();

        public bool MInAdd(string ip, int port, int address)
        {
            return this.MAdd(ip, port, address, true);
        }
        public bool MOutAdd(string ip, int port, int address)
        {
            return this.MAdd(ip, port, address, false);
        }
        public bool MAdd(string ip, int port, int address,bool input)
        {
            MCMValue mcm = new MCMValue(ip, port, address);
            if (mcm.Valid)
            {
                if (input)
                {
                    this.MInList.Add(mcm);
                }
                else
                {
                    this.MOutList.Add(mcm);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DInAdd(string ip, int port, string addressName, int address, int size)
        {
            return this.DAdd(ip, port, addressName, address, size, true);
        }
        public bool DOutAdd(string ip, int port, string addressName, int address, int size)
        {
            return this.DAdd(ip, port, addressName, address, size, false);
        }
        public bool DAdd(string ip, int port,string addressName, int address,int size, bool input)
        {
            MCDValue mcd = new MCDValue(ip, port, addressName, address, size);
            if (mcd.Valid)
            {
                if (input)
                {
                    this.DInList.Add(mcd);
                }
                else
                {
                    this.DOutList.Add(mcd);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool BuildMCPList()
        {
            bool isOk = true;

            foreach (MCMValue mcm in MInList)
            {
                MCP mcp = this.MCPList.Find(x => x.McProtocol.HostIP == mcm.IP && x.McProtocol.HostPort == mcm.Port);
                if (mcp == null)
                {
                    mcp = new MCP();
                    mcp.McProtocol = new McProtocol_Ref.PLC.McProtocol(mcm.IP, mcm.Port);
                    this.MCPList.Add(mcp);
                }
                mcm.MCP = mcp;
                mcp.MInList.Add(mcm);
            }
            /////連線建好後，更新資料?
            foreach (MCMValue mcm in MOutList)
            {
                MCP mcp = this.MCPList.Find(x => x.McProtocol.HostIP == mcm.IP && x.McProtocol.HostPort == mcm.Port);
                if (mcp == null)
                {
                    mcp = new MCP();
                    mcp.McProtocol = new McProtocol_Ref.PLC.McProtocol(mcm.IP, mcm.Port);
                    this.MCPList.Add(mcp);
                }
                mcm.MCP = mcp;
                mcp.MOutList.Add(mcm);
            }

            foreach (MCDValue mcd in DInList)
            {
                MCP mcp = this.MCPList.Find(x => x.McProtocol.HostIP == mcd.IP && x.McProtocol.HostPort == mcd.Port);
                if (mcp == null)
                {
                    mcp = new MCP();
                    mcp.McProtocol = new McProtocol_Ref.PLC.McProtocol(mcd.IP, mcd.Port);
                    this.MCPList.Add(mcp);
                }
                mcd.MCP = mcp;
                mcp.DInList.Add(mcd);
            }

            foreach (MCDValue mcd in DOutList)
            {
                MCP mcp = this.MCPList.Find(x => x.McProtocol.HostIP == mcd.IP && x.McProtocol.HostPort == mcd.Port);
                if (mcp == null)
                {
                    mcp = new MCP();
                    mcp.McProtocol = new McProtocol_Ref.PLC.McProtocol(mcd.IP, mcd.Port);
                    this.MCPList.Add(mcp);
                }
                mcd.MCP = mcp;
                mcp.DOutList.Add(mcd);
            }

            foreach (MCP mcp in this.MCPList)
            {
                mcp.CheckAddress();
            }

            return isOk;
        }
    }
}
