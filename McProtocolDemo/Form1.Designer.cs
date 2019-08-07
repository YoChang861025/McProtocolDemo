namespace McProtocolDemo
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Temperature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rotationX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rotationY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rotationZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();


            this.button3 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart4 = new System.Windows.Forms.DataVisualization.Charting.Chart();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Temperature,
            this.PA,
            this.rotationX,
            this.rotationY,
            this.rotationZ});
            this.dataGridView1.Location = new System.Drawing.Point(65, 59);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(547, 94);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Temperature
            // 
            this.Temperature.HeaderText = "Temperature";
            this.Temperature.Name = "Temperature";
            this.Temperature.ReadOnly = true;
            // 
            // PA
            // 
            this.PA.HeaderText = "PA";
            this.PA.Name = "PA";
            this.PA.ReadOnly = true;
            // 
            // rotationX
            // 
            this.rotationX.HeaderText = "rotationX";
            this.rotationX.Name = "rotationX";
            this.rotationX.ReadOnly = true;
            // 
            // rotationY
            // 
            this.rotationY.HeaderText = "rotationY";
            this.rotationY.Name = "rotationY";
            this.rotationY.ReadOnly = true;
            // 
            // rotationZ
            // 
            this.rotationZ.HeaderText = "rotationZ";
            this.rotationZ.Name = "rotationZ";
            this.rotationZ.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button1.Location = new System.Drawing.Point(677, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 53);
            this.button1.TabIndex = 6;
            this.button1.Text = "Press to start";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(122, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 7;
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 12);
            this.label2.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(323, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 12);
            this.label3.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(425, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 12);
            this.label4.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(523, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 12);
            this.label5.TabIndex = 11;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(677, 102);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 51);
            this.button2.TabIndex = 12;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 

            // button3
            // 
            this.button3.Location = new System.Drawing.Point(65, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(108, 48);
            this.button3.TabIndex = 13;
            this.button3.Text = "Report";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // chart1
            // 
            chartArea1.AxisX.ScaleView.MinSizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisX.ScaleView.SizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.Name = "temperature";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.ItemColumnSeparatorColor = System.Drawing.SystemColors.ActiveCaptionText;
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend1.Name = "Legend1";
            legend1.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Wide;
            legend1.Title = "data type";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(158, 177);
            this.chart1.Name = "chart1";
            series1.ChartArea = "temperature";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "temperature (℃)";
            series2.ChartArea = "temperature";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "PA (pa)";
            series3.ChartArea = "temperature";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Legend = "Legend1";
            series3.Name = "rotationX (mm)";
            series4.ChartArea = "temperature";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.Legend = "Legend1";
            series4.Name = "rotationY (mm)";
            series5.ChartArea = "temperature";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series5.Legend = "Legend1";
            series5.Name = "rotationZ (mm)";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Series.Add(series5);
            this.chart1.Size = new System.Drawing.Size(634, 270);
            this.chart1.TabIndex = 14;
            this.chart1.Text = "chart1";
            title1.Name = "Temperature";
            this.chart1.Titles.Add(title1);
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button4.Location = new System.Drawing.Point(65, 177);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(87, 43);
            this.button4.TabIndex = 15;
            this.button4.Text = "Temperature";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button5.Location = new System.Drawing.Point(65, 226);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(87, 43);
            this.button5.TabIndex = 16;
            this.button5.Text = "PA";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button6.Location = new System.Drawing.Point(65, 275);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(87, 43);
            this.button6.TabIndex = 17;
            this.button6.Text = "Rotations";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(65, 324);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(87, 43);
            this.button7.TabIndex = 18;
            this.button7.Text = "ALL";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // chart2
            // 
            chartArea2.AxisX.ScaleView.MinSizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.AxisX.ScaleView.SizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.Name = "temperature";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.ItemColumnSeparatorColor = System.Drawing.SystemColors.ActiveCaptionText;
            legend2.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend2.Name = "Legend1";
            legend2.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Wide;
            legend2.Title = "data type";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(158, 177);
            this.chart2.Name = "chart2";
            series6.ChartArea = "temperature";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series6.Legend = "Legend1";
            series6.Name = "temperature (℃)";
            this.chart2.Series.Add(series6);
            this.chart2.Size = new System.Drawing.Size(634, 270);
            this.chart2.TabIndex = 19;
            this.chart2.Text = "chart2";
            title2.Name = "Temperature";
            this.chart2.Titles.Add(title2);
            // 
            // chart3
            // 
            chartArea3.AxisX.ScaleView.MinSizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea3.AxisX.ScaleView.SizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea3.Name = "temperature";
            this.chart3.ChartAreas.Add(chartArea3);
            legend3.ItemColumnSeparatorColor = System.Drawing.SystemColors.ActiveCaptionText;
            legend3.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend3.Name = "Legend1";
            legend3.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Wide;
            legend3.Title = "data type";
            this.chart3.Legends.Add(legend3);
            this.chart3.Location = new System.Drawing.Point(158, 177);
            this.chart3.Name = "chart3";
            series7.ChartArea = "temperature";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series7.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series7.Legend = "Legend1";
            series7.Name = "PA (pa)";
            this.chart3.Series.Add(series7);
            this.chart3.Size = new System.Drawing.Size(634, 270);
            this.chart3.TabIndex = 20;
            this.chart3.Text = "chart3";
            title3.Name = "Temperature";
            this.chart3.Titles.Add(title3);
            // 
            // chart4
            // 
            chartArea4.AxisX.ScaleView.MinSizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea4.AxisX.ScaleView.SizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea4.Name = "temperature";
            this.chart4.ChartAreas.Add(chartArea4);
            legend4.ItemColumnSeparatorColor = System.Drawing.SystemColors.ActiveCaptionText;
            legend4.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend4.Name = "Legend1";
            legend4.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Wide;
            legend4.Title = "data type";
            this.chart4.Legends.Add(legend4);
            this.chart4.Location = new System.Drawing.Point(158, 177);
            this.chart4.Name = "chart4";
            series8.ChartArea = "temperature";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series8.Color = System.Drawing.Color.Red;
            series8.Legend = "Legend1";
            series8.MarkerColor = System.Drawing.Color.White;
            series8.Name = "rotationX (mm)";
            series9.ChartArea = "temperature";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series9.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            series9.Legend = "Legend1";
            series9.Name = "rotationY (mm)";
            series10.ChartArea = "temperature";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series10.Color = System.Drawing.Color.Gray;
            series10.Legend = "Legend1";
            series10.Name = "rotationZ (mm)";
            this.chart4.Series.Add(series8);
            this.chart4.Series.Add(series9);
            this.chart4.Series.Add(series10);
            this.chart4.Size = new System.Drawing.Size(634, 270);
            this.chart4.TabIndex = 21;
            this.chart4.Text = "chart4";
            title4.Name = "Temperature";
            this.chart4.Titles.Add(title4);

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          

            this.ClientSize = new System.Drawing.Size(852, 483);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);

            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.chart4);
            this.Controls.Add(this.chart3);
            this.Controls.Add(this.chart2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Temperature;
        private System.Windows.Forms.DataGridViewTextBoxColumn PA;
        private System.Windows.Forms.DataGridViewTextBoxColumn rotationX;
        private System.Windows.Forms.DataGridViewTextBoxColumn rotationY;
        private System.Windows.Forms.DataGridViewTextBoxColumn rotationZ;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart4;

    }
}

