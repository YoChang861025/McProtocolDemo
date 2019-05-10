using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalist
{
    public class Datatable
    {
        public string StationName { get; set; }
        public string StationIP { get; set; }
        public string StationProtocolPort { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
        public int Longint { get; set; }
        public bool Comment { get; set; }

        List<Datatable> datatables = new List<Datatable>();

        public void GetName(string station_Name)
        {
            datatables.Add(new Datatable() { StationName = station_Name });
        }
        public void GetIP(string station_IP)
        {
            datatables.Add(new Datatable() { StationIP = station_IP });
        }
        public void GetPort(string port)
        {
            datatables.Add(new Datatable() { StationProtocolPort = port });
        }
        public void Getaddress(string address)
        {
            datatables.Add(new Datatable() { Address = address });
        }
        public void GetType(string type)
        {
            datatables.Add(new Datatable() { Type = type });
        }
        public void Getlongth(int longth)
        {
            datatables.Add(new Datatable() { Longint = longth });
        }
        public void GetComment(bool comment)
        {
            datatables.Add(new Datatable() { Comment = comment });
        }

    }

    public class Process
    {
        
    }
}
