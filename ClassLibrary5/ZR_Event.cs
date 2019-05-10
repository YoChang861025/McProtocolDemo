using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datalist;

namespace ZR
{
    public class ZR_Event
    {
        bool PLC_to_PC = true;
        string Link_Address;
        string Singal_Name;
        bool Comment = false;
        int Size = 1;

        Datatable datatable = new Datatable();
        
        //存取要讀取的ZR位置
        public string Address(string address)
        {
            this.Link_Address = address;
            datatable.Getaddress(address);
            return Link_Address;
        }

        //判斷PLC到PC還是PC到PLC傳指令
        public void Judge(bool PLCtoPC)
        {
            if (PLCtoPC == true)
            {
                this.PLC_to_PC = PLCtoPC;
                Event_PLC(this.Link_Address, this.Comment);
                Console.WriteLine(this.Singal_Name);
            }
            else if(PLCtoPC==false)
            {
                this.PLC_to_PC = false;
                Event_PLC(this.Link_Address, this.Comment);
                Console.WriteLine(this.Singal_Name);
            }
        }


        //判斷PLC到PC的事件
        public void Event_PLC(string linkaddress,bool comment)
        {
            this.Link_Address = linkaddress;
            this.Comment = comment;

            if (comment == false)
                Console.WriteLine("The address of " + this.Link_Address + "is Off.");

            //判斷表 ZR20000~ZR20042
            switch(this.Link_Address)
            {
                case "ZR20000":
                    this.Singal_Name = "Watch Dog (Request)";
                    break;
                case "ZR20001":
                    this.Singal_Name = "EQ Mode (Request)";
                    break;
                case "ZR20002":
                    this.Singal_Name = "BC Network Control Data (Request)";
                    break;
                case "ZR20003":
                    this.Singal_Name = "PLC Alarm/Warning Status 發生 (Request)";
                    break;
                case "ZR20004":
                    this.Singal_Name = "PLC Alarm/Warning Status 解除 (Request)";
                    break;
                case "ZR20005":
                    this.Singal_Name = "PC  Alarm/Warning 發出  (Reply)";
                    break;





                default:
                    Console.WriteLine("It is not in the table.");
                    break;
            }
           
        }

        //判斷PC到PLC的事件
        public void Event_PC(string linkaddress, bool comment)
        {

        }
    }
}
