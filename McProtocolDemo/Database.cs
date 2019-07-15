using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;
using Z.BulkOperations;


namespace McProtocolDemo
{
    public class Database
    {
        private string DataIP;
        private int Port;
        private string UserName;
        private string Password;
        private string DatabaseName;
        private object DBlock;

        public Database(string _dataIP, int _port, string _userName, string _password, string _databasename)
        {
            this.DataIP = _dataIP;
            this.Port = _port;
            this.UserName = _userName;
            this.Password = _password;
            this.DatabaseName = _databasename;
            this.DBlock = new object();
        }

        private MySqlConnection establishConnection()
        {
            MySqlConnection connection;
            String MySQLConnectionString = "server=" + DataIP + ";port=" + Port + ";user=" + UserName + ";password=" + Password + ";database=" + DatabaseName + ";character set=utf8;";
            connection = new MySqlConnection(MySQLConnectionString);
            return connection;
        }

        /*
        public string dbHost;
        public string dbUser;
        public string dbPass;
        public string dbName;

        public Database()
        {
            this.dbHost = "127.0.0.1";//資料庫位址
            this.dbUser = "root";//資料庫使用者帳號
            this.dbPass = "";//資料庫使用者密碼
            this.dbName = "test";//資料庫名稱
        }
        public Database(string dbHost, string dbUser, string dbPass, string dbName)
        {
            this.dbHost = dbHost;//資料庫位址
            this.dbUser = dbUser;//資料庫使用者帳號
            this.dbPass = dbPass;//資料庫使用者密碼
            this.dbName = dbName;//資料庫名稱
        }
        //建立連線
        private MySqlConnection establishConnection()
        {
            MySqlConnection connection;
            String MySQLConnectionString = "server=" + dbHost + ";uid=" + dbUser + ";pwd=" + dbPass + ";database=" + dbName;
            connection = new MySqlConnection(MySQLConnectionString);
            return connection;
        }
        */

        //public void CreateTable(string name)
        

        //檢驗輸入是否合法，是否為D區或M區，以及開始位置是否不為正數
        public bool Valid(string name, ref short[] value, int size, int startaddress)
        {
            bool isOk = true;
            if (name != "D" && name != "M")
                isOk = false;
            for (int i = 0; i < size; i++)
            {
                if (startaddress < 0 || startaddress == 0)
                {
                    isOk = false;
                    break;
                }
                startaddress++;
            }
            return isOk;
        }
        //還不確定如果在isOk為false的情況下怎麼將insert中止

        //還沒修改
        public void Insert(string name, ref short[] value, int size, int startaddress)
        {
            String query;
            if (Valid(name, ref value, size, startaddress) == false)
            {
                Console.WriteLine("The input data is valid, so the insert is deleted.");

            }
            for (int i = 0; i < size; i++)
            {
                var startaddress_string = Convert.ToString(startaddress + i);
                string index = name + startaddress_string;
                query = "INSERT INTO d(address,num) values('" + index + "','" + value[i] + ")";
                MySqlConnection connection = establishConnection();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.CommandTimeout = 60;

                try
                {
                    connection.Open();

                    command.CommandText = "INSERT INTO d(address,num) values('" + index + "'," + value[i] + ")";
                    command.ExecuteNonQuery();

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        //insert一列資料到Database
        public void InsertOneQuery(string _stationID, string _dateTime, string _stationState, string _temperature, string _pa, string _valuetype, string _value, string _positionState, string _x, string _y, string _z, string _a, string _b, string _c)
        {
            lock(DBlock)
            {
                //String query = "INSERT INTO PLC VALUE(\'" + _stationID + "\',\'" + _dateTime + "\',\'" +_stationState + "\',\'" + _temperature + "\',\'" + _pa + "\',\'" + _valuetype + "\',\'" + _value + "\',\'" + _positionState + "\',\'" + _x + "\',\'" + _y + "\',\'" +_z + "\',\'" + _a + "\',\'" + _b + "\',\'" + _c + "'" + ')';
                String query = "INSERT INTO PLC (StationID,DateTime,StationState,Temperature,Pa,ValueType,Value,PositionState,X,Y,Z,A,B,C) values(@StationID,@DateTime,@StationState,@Temperature,@Pa,@ValueType,@Value,@PositionState,@X,@Y,@Z,@A,@B,@C)";
                MySqlConnection connection = establishConnection();
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.CommandTimeout = 60;

                    command.Parameters.AddWithValue("@StationID", _stationID);
                    command.Parameters.AddWithValue("@DateTime", _dateTime);
                    command.Parameters.AddWithValue("@StationState", _stationState);
                    command.Parameters.AddWithValue("@Temperature", _temperature);
                    command.Parameters.AddWithValue("@Pa", _pa);
                    command.Parameters.AddWithValue("@ValueType", _valuetype);
                    command.Parameters.AddWithValue("@Value", _value);
                    command.Parameters.AddWithValue("@PositionState", _positionState);
                    command.Parameters.AddWithValue("@X", _x);
                    command.Parameters.AddWithValue("@Y", _y);
                    command.Parameters.AddWithValue("@Z", _z);
                    command.Parameters.AddWithValue("@A", _a);
                    command.Parameters.AddWithValue("@B", _b);
                    command.Parameters.AddWithValue("@C", _c);

                    command.ExecuteNonQuery();
                    //try
                    //{
                    //    MySqlDataReader reader = command.ExecuteReader();
                    //    if (reader.HasRows)
                    //    {
                    //        while (reader.Read())
                    //        {
                    //            reader.Close();
                    //        }
                    //    }
                    //    connection.Close();
                    //}
                    //catch (Exception ex)
                    //{
                    //    Console.WriteLine(ex.Message);
                    //    //報錯
                    //}
                }
                connection.Close();
            }
        }

        //一次更新整個Datatable到Database
        public void InsertDatatable(DataTable _dataTable)
        {
            lock(DBlock)
            {
                MySqlConnection connection = establishConnection();
                connection.Open();
                //輸入bulkcopy之前轉換connection型別
                //using (var sqlBulkCopy = new SqlBulkCopy(connection))
                {
                    
                }


                
            }
        }
    }
}