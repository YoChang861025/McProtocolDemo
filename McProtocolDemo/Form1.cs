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
            timer1.Start();
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

        int i = 0;
        int input_address = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();//產生Form2的物件，才可以使用它所提供的Method

            this.Visible = false;//將Form1隱藏。由於在Form1的程式碼內使用this，所以this為Form1的物件本身
            f.Visible = true;//顯示form2
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e) //目前clock為1000毫秒
        {
            SV report = new SV(); 

            report.getVolue();//產生資料

            label1.Text = report.temperatue.ToString();
            label2.Text = report.pa.ToString();
            label3.Text = report.rotationX.ToString();
            label4.Text = report.rotationY.ToString();
            label5.Text = report.rotationZ.ToString();//顯示最新一筆資料在表格中


            label1.Update();
            label2.Update();
            label3.Update();
            label4.Update();
            label5.Update();


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

            //read(input_address);

            if (i <= 20)
            {
                chart1.Series[0].Points.AddXY(i, report.temperatue);
                chart1.Series[1].Points.AddXY(i, report.pa);
                chart1.Series[2].Points.AddXY(i, report.rotationX);
                chart1.Series[3].Points.AddXY(i, report.rotationY);
                chart1.Series[4].Points.AddXY(i, report.rotationZ);//更新圖ALL

                chart2.Series[0].Points.AddXY(i, report.temperatue);//更新圖temperature
                            
                chart3.Series[0].Points.AddXY(i, report.pa);//更新圖PA

                chart4.Series[0].Points.AddXY(i, report.rotationX);
                chart4.Series[1].Points.AddXY(i, report.rotationY);
                chart4.Series[2].Points.AddXY(i, report.rotationZ);//更新圖Rotations

                chart2.ChartAreas["temperature"].AxisY.Maximum = 40;
                chart2.ChartAreas["temperature"].AxisY.Minimum = 30;
                chart3.ChartAreas["temperature"].AxisY.Maximum = 350;
                chart3.ChartAreas["temperature"].AxisY.Minimum = 300;//限制y軸長度
            }
            else if (i >= 21) {
                chart1.Series[0].Points.AddXY(i, report.temperatue);
                chart1.Series[1].Points.AddXY(i, report.pa);
                chart1.Series[2].Points.AddXY(i, report.rotationX);
                chart1.Series[3].Points.AddXY(i, report.rotationY);
                chart1.Series[4].Points.AddXY(i, report.rotationZ);//更新圖ALL

                chart2.Series[0].Points.AddXY(i, report.temperatue);//更新圖temperature

                chart3.Series[0].Points.AddXY(i, report.pa);//更新圖PA

                chart4.Series[0].Points.AddXY(i, report.rotationX);
                chart4.Series[1].Points.AddXY(i, report.rotationY);
                chart4.Series[2].Points.AddXY(i, report.rotationZ);//更新圖Rotations

                chart1.ChartAreas["temperature"].AxisX.Maximum = i;
                chart1.ChartAreas["temperature"].AxisX.Minimum = i - 20;
                chart2.ChartAreas["temperature"].AxisX.Maximum = i;
                chart2.ChartAreas["temperature"].AxisX.Minimum = i - 20;
                chart3.ChartAreas["temperature"].AxisX.Maximum = i;
                chart3.ChartAreas["temperature"].AxisX.Minimum = i - 20;
                chart4.ChartAreas["temperature"].AxisX.Maximum = i;
                chart4.ChartAreas["temperature"].AxisX.Minimum = i - 20;//限制x軸長度

                chart2.ChartAreas["temperature"].AxisY.Maximum = 40;
                chart2.ChartAreas["temperature"].AxisY.Minimum = 30;
                chart3.ChartAreas["temperature"].AxisY.Maximum = 350;
                chart3.ChartAreas["temperature"].AxisY.Minimum = 300;//限制y軸長度

            }

            i++;



            //Thread.Sleep(1000);
            //continue;                

            //while迴圈修正，手動關閉

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e) //temperature
        {
            chart1.Visible = false;
            chart2.Visible = true;
            chart3.Visible = false;
            chart4.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e) //PA
        {
            chart1.Visible = false;
            chart2.Visible = false;
            chart3.Visible = true;
            chart4.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e) //Rotations
        {
            chart1.Visible = false;
            chart2.Visible = false;
            chart3.Visible = false;
            chart4.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e) //ALL
        {
            chart1.Visible = true;
            chart2.Visible = false;
            chart3.Visible = false;
            chart4.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }
    }
}
