namespace SystemMonitor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.progressBarCpu = new System.Windows.Forms.ProgressBar();
            this.progressBarRam = new System.Windows.Forms.ProgressBar();
            this.progressBarDisk = new System.Windows.Forms.ProgressBar();
            this.progressBarNetwork = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelCpu = new System.Windows.Forms.Label();
            this.labelRam = new System.Windows.Forms.Label();
            this.labelDisk = new System.Windows.Forms.Label();
            this.labelNetwork = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridViewServices = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServices)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBarCpu
            // 
            this.progressBarCpu.Location = new System.Drawing.Point(169, 72);
            this.progressBarCpu.Name = "progressBarCpu";
            this.progressBarCpu.Size = new System.Drawing.Size(334, 23);
            this.progressBarCpu.TabIndex = 0;
            // 
            // progressBarRam
            // 
            this.progressBarRam.Location = new System.Drawing.Point(169, 151);
            this.progressBarRam.Name = "progressBarRam";
            this.progressBarRam.Size = new System.Drawing.Size(334, 23);
            this.progressBarRam.TabIndex = 1;
            // 
            // progressBarDisk
            // 
            this.progressBarDisk.Location = new System.Drawing.Point(169, 233);
            this.progressBarDisk.Name = "progressBarDisk";
            this.progressBarDisk.Size = new System.Drawing.Size(334, 23);
            this.progressBarDisk.TabIndex = 2;
            // 
            // progressBarNetwork
            // 
            this.progressBarNetwork.Location = new System.Drawing.Point(169, 322);
            this.progressBarNetwork.Name = "progressBarNetwork";
            this.progressBarNetwork.Size = new System.Drawing.Size(334, 23);
            this.progressBarNetwork.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(53, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "CPU:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(53, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "RAM:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(53, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Disk:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(53, 332);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ağ:";
            // 
            // labelCpu
            // 
            this.labelCpu.AutoSize = true;
            this.labelCpu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelCpu.Location = new System.Drawing.Point(572, 82);
            this.labelCpu.Name = "labelCpu";
            this.labelCpu.Size = new System.Drawing.Size(28, 16);
            this.labelCpu.TabIndex = 8;
            this.labelCpu.Text = "%0";
            // 
            // labelRam
            // 
            this.labelRam.AutoSize = true;
            this.labelRam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelRam.Location = new System.Drawing.Point(572, 158);
            this.labelRam.Name = "labelRam";
            this.labelRam.Size = new System.Drawing.Size(28, 16);
            this.labelRam.TabIndex = 9;
            this.labelRam.Text = "%0";
            // 
            // labelDisk
            // 
            this.labelDisk.AutoSize = true;
            this.labelDisk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelDisk.Location = new System.Drawing.Point(572, 243);
            this.labelDisk.Name = "labelDisk";
            this.labelDisk.Size = new System.Drawing.Size(28, 16);
            this.labelDisk.TabIndex = 10;
            this.labelDisk.Text = "%0";
            // 
            // labelNetwork
            // 
            this.labelNetwork.AutoSize = true;
            this.labelNetwork.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelNetwork.Location = new System.Drawing.Point(572, 332);
            this.labelNetwork.Name = "labelNetwork";
            this.labelNetwork.Size = new System.Drawing.Size(28, 16);
            this.labelNetwork.TabIndex = 11;
            this.labelNetwork.Text = "%0";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(169, 379);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "CPU";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "RAM";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "Disk";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "Network";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(334, 253);
            this.chart1.TabIndex = 12;
            this.chart1.Text = "chart1";
            // 
            // dataGridViewServices
            // 
            this.dataGridViewServices.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewServices.Location = new System.Drawing.Point(685, 46);
            this.dataGridViewServices.Name = "dataGridViewServices";
            this.dataGridViewServices.Size = new System.Drawing.Size(405, 299);
            this.dataGridViewServices.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 665);
            this.Controls.Add(this.dataGridViewServices);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.labelNetwork);
            this.Controls.Add(this.labelDisk);
            this.Controls.Add(this.labelRam);
            this.Controls.Add(this.labelCpu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBarNetwork);
            this.Controls.Add(this.progressBarDisk);
            this.Controls.Add(this.progressBarRam);
            this.Controls.Add(this.progressBarCpu);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBarCpu;
        private System.Windows.Forms.ProgressBar progressBarRam;
        private System.Windows.Forms.ProgressBar progressBarDisk;
        private System.Windows.Forms.ProgressBar progressBarNetwork;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelCpu;
        private System.Windows.Forms.Label labelRam;
        private System.Windows.Forms.Label labelDisk;
        private System.Windows.Forms.Label labelNetwork;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataGridView dataGridViewServices;
    }
}

