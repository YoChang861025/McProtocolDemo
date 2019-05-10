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
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            connect();
            read();
          
        }

        protected override void OnClosed(EventArgs e)
        {
            if (mcProtocol != null)
                mcProtocol.Dispose();

            base.OnClosed(e);
        }
        public void connect()
        {
            string ip = "192.168.2.12";
            int port = 3000;

            mcProtocol = new McProtocol(ip, port);
            mcProtocol.Connect();

            if (mcProtocol.IsConnected)
                Text = "McProtocol connected.";
            else
                Text = "McProtocol disconnect";
        }

        private void read()
        {

            if (mcProtocol == null || !mcProtocol.IsConnected)
                return;

            short[] readData = new short[1];
            var rtn = mcProtocol.ExecuteRead("D", 1000, 10, ref readData);

            if (rtn != 0)
                Console.WriteLine("Error code: " + rtn);
            else
            {
                Console.WriteLine("Read success.");
                // Data format convert. All convert function in McCommand
                string strData = McCommand.ShortArrayToASCIIString(false, readData[0]);
                string intDataStr = McCommand.ShortArrayToInt16String(readData[1]);
            }
        }

        private void write()
        {
            if (mcProtocol == null || !mcProtocol.IsConnected)
                return;

            short[] writeData = McCommand.Int16StringToShortArray("1");

            // 1 word = 16 bit = 2 character
            //short[] writeData = McCommand.ASCIIStringToShortArray("HI");

            int rtn = mcProtocol.ExecuteWrite("D", 1000, 1, writeData);

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

        private void button1_Click(object sender, EventArgs e)
        {
            SV report = new SV();
            
            while (tem == 1)

            {
                report.getVolue();
                label1.Text = report.temperatue.ToString("#0.00000");
                label2.Text = report.pa.ToString("#0.00000");
                label3.Text = report.rotationX.ToString();
                label4.Text = report.rotationY.ToString();
                label5.Text = report.rotationZ.ToString();

                Thread.Sleep(1000);
                label1.Update();
                label2.Update();
                label3.Update();
                label4.Update();
                label5.Update();

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
