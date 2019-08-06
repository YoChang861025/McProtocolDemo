using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using MySql.Data.MySqlClient;

namespace McProtocolDemo
{
    public partial class Form2 : Form
    {
        ReportDocument cryrpt = new ReportDocument();
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();//產生Form1的物件，才可以使用它所提供的Method

            this.Visible = false;//將Form2隱藏。由於在Form2的程式碼內使用this，所以this為Form2的物件本身
            f.Visible = true;//顯示form1
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string dbHost = "127.0.0.1";//資料庫位址
            string dbUser = "root";//資料庫使用者帳號
            string dbPass = "";//資料庫使用者密碼
            string dbName = "test";//資料庫名稱

            string connStr = "server=" + dbHost + ";uid=" + dbUser + ";pwd=" + dbPass + ";database=" + dbName;

            MySqlConnection con = new MySqlConnection(connStr);
            //"Data Source =.;Initial Catalog =plc;Integrated Security=True;"

            MySqlDataAdapter sda = new MySqlDataAdapter("Select * from plc where StationState ='" + "Fail" + "'", con);
            DataSet dst = new DataSet();
            sda.Fill(dst,"plc");
            cryrpt.Load(@"D:\Users\USER\Desktop\McProtocolDemo-master\McProtocolDemo\CrystalReport1.rpt");
            //這行位置要改
            cryrpt.SetDataSource(dst);
            crystalReportViewer1.ReportSource = cryrpt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string dbHost = "127.0.0.1";//資料庫位址
            string dbUser = "root";//資料庫使用者帳號
            string dbPass = "";//資料庫使用者密碼
            string dbName = "test";//資料庫名稱

            string connStr = "server=" + dbHost + ";uid=" + dbUser + ";pwd=" + dbPass + ";database=" + dbName;

            MySqlConnection con = new MySqlConnection(connStr);
            //"Data Source =.;Initial Catalog =plc;Integrated Security=True;"

            MySqlDataAdapter sda = new MySqlDataAdapter("Select * from plc", con);
            DataSet dst = new DataSet();
            sda.Fill(dst, "plc");
            cryrpt.Load(@"D:\Users\USER\Desktop\McProtocolDemo-master\McProtocolDemo\CrystalReport1.rpt");
            //這行位置要改
            cryrpt.SetDataSource(dst);
            crystalReportViewer1.ReportSource = cryrpt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string dbHost = "127.0.0.1";//資料庫位址
            string dbUser = "root";//資料庫使用者帳號
            string dbPass = "";//資料庫使用者密碼
            string dbName = "test";//資料庫名稱

            string connStr = "server=" + dbHost + ";uid=" + dbUser + ";pwd=" + dbPass + ";database=" + dbName;

            MySqlConnection con = new MySqlConnection(connStr);
            //"Data Source =.;Initial Catalog =plc;Integrated Security=True;"

            MySqlDataAdapter sda = new MySqlDataAdapter("Select * from plc where Temperature >= " + textBox1.Text +" and Temperature <= " + textBox2.Text , con);
            DataSet dst = new DataSet();
            sda.Fill(dst, "plc");
            cryrpt.Load(@"D:\Users\USER\Desktop\McProtocolDemo-master\McProtocolDemo\CrystalReport1.rpt");
            //這行位置要改
            cryrpt.SetDataSource(dst);
            crystalReportViewer1.ReportSource = cryrpt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string dbHost = "127.0.0.1";//資料庫位址
            string dbUser = "root";//資料庫使用者帳號
            string dbPass = "";//資料庫使用者密碼
            string dbName = "test";//資料庫名稱

            string connStr = "server=" + dbHost + ";uid=" + dbUser + ";pwd=" + dbPass + ";database=" + dbName;

            MySqlConnection con = new MySqlConnection(connStr);
            //"Data Source =.;Initial Catalog =plc;Integrated Security=True;"

            MySqlDataAdapter sda = new MySqlDataAdapter("Select * from plc where Pa >= " + textBox3.Text +
                                                                         " and Pa <= " + textBox4.Text ,con);
            DataSet dst = new DataSet();
            sda.Fill(dst, "plc");
            cryrpt.Load(@"D:\Users\USER\Desktop\McProtocolDemo-master\McProtocolDemo\CrystalReport1.rpt");
            //這行位置要改
            cryrpt.SetDataSource(dst);
            crystalReportViewer1.ReportSource = cryrpt;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string dbHost = "127.0.0.1";//資料庫位址
            string dbUser = "root";//資料庫使用者帳號
            string dbPass = "";//資料庫使用者密碼
            string dbName = "test";//資料庫名稱

            string connStr = "server=" + dbHost + ";uid=" + dbUser + ";pwd=" + dbPass + ";database=" + dbName;

            MySqlConnection con = new MySqlConnection(connStr);
            //"Data Source =.;Initial Catalog =plc;Integrated Security=True;"

            MySqlDataAdapter sda = new MySqlDataAdapter("Select * from plc where X >= " + textBox5.Text +
                                                                         " and X <= " + textBox6.Text, con);
            DataSet dst = new DataSet();
            sda.Fill(dst, "plc");
            cryrpt.Load(@"D:\Users\USER\Desktop\McProtocolDemo-master\McProtocolDemo\CrystalReport1.rpt");
            //這行位置要改
            cryrpt.SetDataSource(dst);
            crystalReportViewer1.ReportSource = cryrpt;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string dbHost = "127.0.0.1";//資料庫位址
            string dbUser = "root";//資料庫使用者帳號
            string dbPass = "";//資料庫使用者密碼
            string dbName = "test";//資料庫名稱

            string connStr = "server=" + dbHost + ";uid=" + dbUser + ";pwd=" + dbPass + ";database=" + dbName;

            MySqlConnection con = new MySqlConnection(connStr);
            //"Data Source =.;Initial Catalog =plc;Integrated Security=True;"

            MySqlDataAdapter sda = new MySqlDataAdapter("Select * from plc where Y >= " + textBox7.Text +
                                                                         " and Y <= " + textBox8.Text, con);
            DataSet dst = new DataSet();
            sda.Fill(dst, "plc");
            cryrpt.Load(@"D:\Users\USER\Desktop\McProtocolDemo-master\McProtocolDemo\CrystalReport1.rpt");
            //這行位置要改
            cryrpt.SetDataSource(dst);
            crystalReportViewer1.ReportSource = cryrpt;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string dbHost = "127.0.0.1";//資料庫位址
            string dbUser = "root";//資料庫使用者帳號
            string dbPass = "";//資料庫使用者密碼
            string dbName = "test";//資料庫名稱

            string connStr = "server=" + dbHost + ";uid=" + dbUser + ";pwd=" + dbPass + ";database=" + dbName;

            MySqlConnection con = new MySqlConnection(connStr);
            //"Data Source =.;Initial Catalog =plc;Integrated Security=True;"

            MySqlDataAdapter sda = new MySqlDataAdapter("Select * from plc where Z >= " + textBox9.Text +
                                                                         " and Z <= " + textBox10.Text, con);
            DataSet dst = new DataSet();
            sda.Fill(dst, "plc");
            cryrpt.Load(@"D:\Users\USER\Desktop\McProtocolDemo-master\McProtocolDemo\CrystalReport1.rpt");
            //這行位置要改
            cryrpt.SetDataSource(dst);
            crystalReportViewer1.ReportSource = cryrpt;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string dbHost = "127.0.0.1";//資料庫位址
            string dbUser = "root";//資料庫使用者帳號
            string dbPass = "";//資料庫使用者密碼
            string dbName = "test";//資料庫名稱

            string connStr = "server=" + dbHost + ";uid=" + dbUser + ";pwd=" + dbPass + ";database=" + dbName;

            MySqlConnection con = new MySqlConnection(connStr);
            //"Data Source =.;Initial Catalog =plc;Integrated Security=True;"

            MySqlDataAdapter sda = new MySqlDataAdapter("Select * from plc where A >= " + textBox11.Text +
                                                                         " and A <= " + textBox12.Text, con);
            DataSet dst = new DataSet();
            sda.Fill(dst, "plc");
            cryrpt.Load(@"D:\Users\USER\Desktop\McProtocolDemo-master\McProtocolDemo\CrystalReport1.rpt");
            //這行位置要改
            cryrpt.SetDataSource(dst);
            crystalReportViewer1.ReportSource = cryrpt;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string dbHost = "127.0.0.1";//資料庫位址
            string dbUser = "root";//資料庫使用者帳號
            string dbPass = "";//資料庫使用者密碼
            string dbName = "test";//資料庫名稱

            string connStr = "server=" + dbHost + ";uid=" + dbUser + ";pwd=" + dbPass + ";database=" + dbName;

            MySqlConnection con = new MySqlConnection(connStr);
            //"Data Source =.;Initial Catalog =plc;Integrated Security=True;"

            MySqlDataAdapter sda = new MySqlDataAdapter("Select * from plc where B >= " + textBox13.Text +
                                                                         " and B <= " + textBox14.Text, con);
            DataSet dst = new DataSet();
            sda.Fill(dst, "plc");
            cryrpt.Load(@"D:\Users\USER\Desktop\McProtocolDemo-master\McProtocolDemo\CrystalReport1.rpt");
            //這行位置要改
            cryrpt.SetDataSource(dst);
            crystalReportViewer1.ReportSource = cryrpt;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string dbHost = "127.0.0.1";//資料庫位址
            string dbUser = "root";//資料庫使用者帳號
            string dbPass = "";//資料庫使用者密碼
            string dbName = "test";//資料庫名稱

            string connStr = "server=" + dbHost + ";uid=" + dbUser + ";pwd=" + dbPass + ";database=" + dbName;

            MySqlConnection con = new MySqlConnection(connStr);
            //"Data Source =.;Initial Catalog =plc;Integrated Security=True;"

            MySqlDataAdapter sda = new MySqlDataAdapter("Select * from plc where C >= " + textBox15.Text +
                                                                         " and C <= " + textBox16.Text, con);
            DataSet dst = new DataSet();
            sda.Fill(dst, "plc");
            cryrpt.Load(@"D:\Users\USER\Desktop\McProtocolDemo-master\McProtocolDemo\CrystalReport1.rpt");
            //這行位置要改
            cryrpt.SetDataSource(dst);
            crystalReportViewer1.ReportSource = cryrpt;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string dbHost = "127.0.0.1";//資料庫位址
            string dbUser = "root";//資料庫使用者帳號
            string dbPass = "";//資料庫使用者密碼
            string dbName = "test";//資料庫名稱

            string connStr = "server=" + dbHost + ";uid=" + dbUser + ";pwd=" + dbPass + ";database=" + dbName;

            MySqlConnection con = new MySqlConnection(connStr);
            //"Data Source =.;Initial Catalog =plc;Integrated Security=True;"

            MySqlDataAdapter sda = new MySqlDataAdapter("Select * from plc where C >= " + textBox15.Text +
                                                                         " and C <= " + textBox16.Text +
                                                                         " and Temperature >= " + textBox1.Text +
                                                                         " and Temperature <= " + textBox2.Text +
                                                                         " and Pa >= " + textBox3.Text +
                                                                         " and Pa <= " + textBox4.Text +
                                                                         " and X >= " + textBox5.Text +
                                                                         " and X <= " + textBox6.Text +
                                                                         " and Y >= " + textBox7.Text +
                                                                         " and Y <= " + textBox8.Text +
                                                                         " and Z >= " + textBox9.Text +
                                                                         " and Z <= " + textBox10.Text +
                                                                         " and A >= " + textBox11.Text +
                                                                         " and A <= " + textBox12.Text +
                                                                         " and B >= " + textBox13.Text +
                                                                         " and B <= " + textBox14.Text
                                                                         , con);
            DataSet dst = new DataSet();
            sda.Fill(dst, "plc");
            cryrpt.Load(@"D:\Users\USER\Desktop\McProtocolDemo-master\McProtocolDemo\CrystalReport1.rpt");
            //這行位置要改
            cryrpt.SetDataSource(dst);
            crystalReportViewer1.ReportSource = cryrpt;
        }
    }
}
