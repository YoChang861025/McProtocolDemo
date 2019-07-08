using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;

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
        private string Datetime;

        public Database(string _dataIP, int _port, string _UserName, string _password, string _databasename)
        {
            this.DataIP = _dataIP;
            this.Port = _port;
            this.UserName = _UserName;
            this.Password = _password;
            this.DatabaseName = _databasename;
            DBlock = new object();
        }

        private MySqlConnection EstablishConnection()
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
        //還不確定如果在確定isOk為false的情況下怎麼將insert中止

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
                MySqlConnection connection = EstablishConnection();
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
        public void InsertOneQuery(string _stationID, string _dateTime, string _stationState, string _temperture, string _pa, string _valuetype, string _value, string _positionState, string _x, string _y, string _z, string _a, string _b, string _c)
        {
            lock(DBlock)
            {
                String query = "INSERT INTO PLC VALUE(\'" + _stationID + "\',\'" + _dateTime + "\',\'" +_stationState + "\',\'" + _temperture + "\',\'" + _pa + "\',\'" + _valuetype + "\',\'" + _value + "\',\'" + _positionState + "\',\'" + _x + "\',\'" + _y + "\',\'" +_z + "\',\'" + _a + "\',\'" + _b + "\',\'" + _c + "'" + ')';
                MySqlConnection connection = EstablishConnection();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.CommandTimeout = 60;

                try
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    if(reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            reader.Close();
                        }
                    }
                    connection.Close();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        //一次更新整個Datatable到Database
        public void Update(DataTable _dataTable)
        {

        }
    }
}