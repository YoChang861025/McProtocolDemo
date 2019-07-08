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
                AllData.Columns.Add("StationState");//機器狀態       0:Normal、1:Warning
                AllData.Columns.Add("Temperature");  //偵測溫度
                AllData.Columns.Add("Pa");          //偵測氣壓
                AllData.Columns.Add("ValueType");   //預存值型別     0:D區、1:M區的值、2:例外
                AllData.Columns.Add("Value");       //儲存的值       
                AllData.Columns.Add("PositionState");//位置狀態      0:XYZ軸正常啟用、1:例外
                AllData.Columns.Add("RotationX");   
                AllData.Columns.Add("RotationY");
                AllData.Columns.Add("RotationZ");
                AllData.Columns.Add("RotationA");   //以下為預留空間
                AllData.Columns.Add("RotationB");
                AllData.Columns.Add("RotationC");

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
