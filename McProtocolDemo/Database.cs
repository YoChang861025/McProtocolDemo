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

        /*
        public int InsertDatatable(DataTable _dataTable)
        {
            lock(DBlock)
            {
                string sqlString = string.Format("SELECT * FROM {0} WHERE FALSE", _dataTable.TableName);

                using (MySqlConnection connection = establishConnection())
                {
                    using (MySqlCommand mySqlCommand = new MySqlCommand(sqlString, connection))
                    {
                        connection.Open();
                        MySqlTransaction mySqlTransaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                        try
                        {
                            int count = 0;
                            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                            dataAdapter.SelectCommand = new MySqlCommand(sqlString, connection);
                            MySqlCommandBuilder builder = new MySqlCommandBuilder(dataAdapter);
                            builder.ConflictOption = ConflictOption.OverwriteChanges;
                            builder.SetAllValues = true;
                            count = dataAdapter.Update(_dataTable);
                            mySqlTransaction.Commit();
                            _dataTable.AcceptChanges();
                            dataAdapter.Dispose();
                            builder.Dispose();

                            return count;
                        }
                        catch(Exception ex)
                        {
                            mySqlTransaction.Rollback();
                            Console.WriteLine(ex.Message);

                            return 0;
                        }
                    }
                }
                //以下是sqlBulkCopy 應用於SQL但不能用在MySQL
                using (var sqlBulkCopy = new SqlBulkCopy(connectionString(), SqlBulkCopyOptions.UseInternalTransaction))
                {
                    //設定批次量及逾時
                    sqlBulkCopy.BatchSize = 1000;
                    sqlBulkCopy.BulkCopyTimeout = 60;
                    //sqlBulkCopy.NotifyAfter = 10000;
                    //sqlBulkCopy.SqlRowsCopied += new SqlRowsCopiedEventHandler(OnSqlRowsCopied);

                    //資料庫內的資料表名
                    sqlBulkCopy.DestinationTableName = "plc";

                    sqlBulkCopy.ColumnMappings.Add("StationID", "StationID");
                    sqlBulkCopy.ColumnMappings.Add("DateTime", "DateTime");
                    sqlBulkCopy.ColumnMappings.Add("StationState", "StationState");
                    sqlBulkCopy.ColumnMappings.Add("Temperature", "Temperature");
                    sqlBulkCopy.ColumnMappings.Add("Pa", "Pa");
                    sqlBulkCopy.ColumnMappings.Add("ValueType", "ValueType");
                    sqlBulkCopy.ColumnMappings.Add("Value", "Value");
                    sqlBulkCopy.ColumnMappings.Add("PositionState", "PositionState");
                    sqlBulkCopy.ColumnMappings.Add("X", "X");
                    sqlBulkCopy.ColumnMappings.Add("Y", "Y");
                    sqlBulkCopy.ColumnMappings.Add("Z", "Z");
                    sqlBulkCopy.ColumnMappings.Add("A", "A");
                    sqlBulkCopy.ColumnMappings.Add("B", "B");
                    sqlBulkCopy.ColumnMappings.Add("C", "C");

                    //開始寫入
                    try
                    {
                        sqlBulkCopy.WriteToServer(_dataTable);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                connection.Dispose();
                */
        //將Datatable可以直接insert進Database
        //對於中斷點可以再處理得更好   目前的test寫成了10秒內會輸入30萬筆左右的測試資料進資料庫
        public void Inserttable(DataTable _datatable)
        {
            lock(DBlock)
            {
                MySqlConnection connection = establishConnection();
                connection.Open();
                DataTable dt = new DataTable("plc");
                dt = _datatable;
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM plc", connection);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                da.Fill(dt);

                var bulk = new BulkOperation(connection);
                bulk.DestinationTableName = "plc";
                bulk.BulkInsert(dt);
                connection.Close();

            }
        }
    }
}
