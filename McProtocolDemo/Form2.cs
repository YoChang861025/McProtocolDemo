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
        private Database db = new Database("127.0.0.1", 3306, "root", "", "test");

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

            MySqlDataAdapter sda = new MySqlDataAdapter("Select * from plc where StationID ='" + "no data" + "'", con);
            DataSet dst = new DataSet();
            sda.Fill(dst,"plc");
            cryrpt.Load(@"D:\Users\USER\Desktop\McProtocolDemo-master\McProtocolDemo\CrystalReport3.rpt");
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
            cryrpt.Load(@"D:\Users\USER\Desktop\McProtocolDemo-master\McProtocolDemo\CrystalReport3.rpt");
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

            MySqlDataAdapter sda = new MySqlDataAdapter("Select * from plc where ValueName ='" + "Temperature" + "'"+
                                                                                 "and Value >= " + textBox1.Text +" and Value <= " + textBox2.Text , con);
            DataSet dst = new DataSet();
            sda.Fill(dst, "plc");
            cryrpt.Load(@"D:\Users\USER\Desktop\McProtocolDemo-master\McProtocolDemo\CrystalReport3.rpt");
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

            MySqlDataAdapter sda = new MySqlDataAdapter("Select * from plc where ValueName ='" + "Air pressure" + "'" +
                                                                                 "and Value >= " + textBox3.Text + " and Value <= " + textBox4.Text, con);
            DataSet dst = new DataSet();
            sda.Fill(dst, "plc");
            cryrpt.Load(@"D:\Users\USER\Desktop\McProtocolDemo-master\McProtocolDemo\CrystalReport3.rpt");
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

            MySqlDataAdapter sda = new MySqlDataAdapter("Select * from plc where ValueName ='" + "rotationX" + "'" +
                                                                                 "and Value >= " + textBox5.Text + " and Value <= " + textBox6.Text, con);
            DataSet dst = new DataSet();
            sda.Fill(dst, "plc");
            cryrpt.Load(@"D:\Users\USER\Desktop\McProtocolDemo-master\McProtocolDemo\CrystalReport3.rpt");
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

            MySqlDataAdapter sda = new MySqlDataAdapter("Select * from plc where ValueName ='" + "rotationY" + "'" +
                                                                                 "and Value >= " + textBox7.Text + " and Value <= " + textBox8.Text, con);
            DataSet dst = new DataSet();
            sda.Fill(dst, "plc");
            cryrpt.Load(@"D:\Users\USER\Desktop\McProtocolDemo-master\McProtocolDemo\CrystalReport3.rpt");
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

            MySqlDataAdapter sda = new MySqlDataAdapter("Select * from plc where ValueName ='" + "rotationZ" + "'" +
                                                                                 "and Value >= " + textBox9.Text + " and Value <= " + textBox10.Text, con);
            DataSet dst = new DataSet();
            sda.Fill(dst, "plc");
            cryrpt.Load(@"D:\Users\USER\Desktop\McProtocolDemo-master\McProtocolDemo\CrystalReport3.rpt");
            //這行位置要改
            cryrpt.SetDataSource(dst);
            crystalReportViewer1.ReportSource = cryrpt;
        }


    }
}
