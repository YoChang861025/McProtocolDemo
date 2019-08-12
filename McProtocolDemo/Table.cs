using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace McProtocolDemo
{
    public class Table
    {
        public static DataTable AllData;
        public static DataTable MonitorData;

        //取用總Datatable
        public static DataTable GetAllData()
        {
            if (AllData == null)
            {
                //此處的AllData是區域變數 (資料表)
                DataTable AllData = new DataTable();
                AllData.Columns.Add("StationID");   //機器ID
                AllData.Columns.Add("DateTime");    //時間戳記
                AllData.Columns.Add("ValueName");
                AllData.Columns.Add("Value");
                AllData.Columns.Add("ValueFormat");
                AllData.Columns.Add("Type");
                
                
            }
            //這裡回傳的AllData會是靜態資料表
            return AllData;
        }

        //取用監控用的Datatable
        public static DataTable GetMonitorData()
        {
            if(MonitorData == null)
            {
                //此處的MonitorData是區域變數 (資料表)
                MonitorData.Columns.Add("StationID");
                MonitorData.Columns.Add("DateTime");
                MonitorData.Columns.Add("StationState");
                MonitorData.Columns.Add("Temperture");
                MonitorData.Columns.Add("Pa");
            }
            //這裡回傳的MonitorData會是靜態資料表
            return MonitorData;
        }
    }
}
