using McProtocol_Ref.PLC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary5;
using System.Threading;

namespace McProtocolDemo
{
    public partial class Form1 : Form
    {
        public McProtocol mcProtocol;

        //測試insert資料庫
        private Database db = new Database("127.0.0.1", 3306, "root", "", "test");

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            connect();
          
        }

        protected override void OnClosed(EventArgs e)
        {
            if (mcProtocol != null)
                mcProtocol.Dispose();

            base.OnClosed(e);
        }
        public void connect()
        {
            string ip = "192.168.1.63";
            int port = 4000;

            mcProtocol = new McProtocol(ip, port);
            mcProtocol.Connect();

            if (mcProtocol.IsConnected)
                Text = "McProtocol connected.";
            else
                Text = "McProtocol disconnect";
        }

        private void read(int address)
        {

            if (mcProtocol == null || !mcProtocol.IsConnected)
                return;

            short[] readData = new short[1];
            var rtn = mcProtocol.ExecuteRead("D", address, 1, ref readData);

            if (rtn != 0)
                Console.WriteLine("Error code: " + rtn);
            else
            {
                Console.WriteLine("Read success.");
                // Data format convert. All convert function in McCommand
                string strData = McCommand.ShortArrayToASCIIString(false, readData[0]);
                //string intDataStr = McCommand.ShortArrayToInt16String(readData[1]);
                
            }
          
        }

        private void write(int address ,string input_data)
        {
            if (mcProtocol == null || !mcProtocol.IsConnected)
                return;

            short[] writeData = McCommand.Int16StringToShortArray(input_data);

            // 1 word = 16 bit = 2 character
            //short[] writeData = McCommand.ASCIIStringToShortArray("HI");

            int rtn = mcProtocol.ExecuteWrite("D", address, 1, writeData);

            if (rtn != 0)
                Console.WriteLine("Error code: " + rtn);
            else
                Console.WriteLine("Write success.");
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        int tem = 1;
        int input_address = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            SV report = new SV();
            DataTable table = new DataTable();
            //init columns
            table.Columns.Add("temperture", typeof(string));
            table.Columns.Add("pa", typeof(string));
            table.Columns.Add("rotationX", typeof(string));
            table.Columns.Add("rotationY", typeof(string));
            table.Columns.Add("rotationZ", typeof(string));

            //data type
            table.Columns.Add("Time", typeof(string));
            table.Columns.Add("SID", typeof(string));
            table.Columns.Add("ValueName", typeof(string));
            table.Columns.Add("BeforeValueName", typeof(string));
            table.Columns.Add("ValueType", typeof(string));
            table.Columns.Add("Value", typeof(string));

            while (tem == 1)
            {
                string s = "station1";
                string t = DateTime.Now.ToString();
                string state = "Normal";
                string tem = "50C";
                string pa = "1003pa";
                string valuetype = "0";
                string value = "000";
                string posi = "X_Y";
                string x = "17.58";
                string y = "20.1";
                db.InsertOneQuery(s, t, state, tem, pa, valuetype, value, posi, x, y, "0", "0", "0", "0");
                //成功insert進資料庫

                report.getVolue();
                label1.Text = report.temperatue.ToString();
                label2.Text = report.pa.ToString();
                label3.Text = report.rotationX.ToString();
                label4.Text = report.rotationY.ToString();
                label5.Text = report.rotationZ.ToString();

                Thread.Sleep(1000);
                label1.Update();
                label2.Update();
                label3.Update();
                label4.Update();
                label5.Update();

                //table.Rows.Add(label1.Text, label2.Text, label3.Text, label4.Text, label5.Text);

                //Datatable的部分目前可以做成二維陣列然後保持讀進狀態
                //也能成功保存下來 目前只差將input的部份抽出並把datatable連動
                DataRow dr = table.NewRow();
                dr["temperture"] = label1.Text;
                dr["pa"] = label2.Text;
                dr["rotationX"] = label3.Text;
                dr["rotationY"] = label4.Text;
                dr["rotationZ"] = label5.Text;
                table.Rows.Add(dr);

                /* write(input_address, label1.Text);
                 input_address++;
                 write(input_address, label2.Text);
                 input_address++;
                 write(input_address, label3.Text);
                 input_address++;
                 write(input_address, label4.Text);
                 input_address++;
                 write(input_address, label5.Text);
                 input_address++; */

                read(input_address);
                continue;
                //while迴圈修正，手動關閉
            }
        }
        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tem = 0;
        }


    }
}
