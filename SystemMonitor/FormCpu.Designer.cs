namespace SystemMonitor
{
    partial class FormCpu
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
            this.label1 = new System.Windows.Forms.Label();
            this.progressBarFormCpu = new System.Windows.Forms.ProgressBar();
            this.labelFormCpu = new System.Windows.Forms.Label();
            this.chartFormCpu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartFormCpu)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(33, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "CPU:";
            // 
            // progressBarFormCpu
            // 
            this.progressBarFormCpu.Location = new System.Drawing.Point(91, 76);
            this.progressBarFormCpu.Name = "progressBarFormCpu";
            this.progressBarFormCpu.Size = new System.Drawing.Size(227, 23);
            this.progressBarFormCpu.TabIndex = 2;
            // 
            // labelFormCpu
            // 
            this.labelFormCpu.AutoSize = true;
            this.labelFormCpu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelFormCpu.Location = new System.Drawing.Point(346, 83);
            this.labelFormCpu.Name = "labelFormCpu";
            this.labelFormCpu.Size = new System.Drawing.Size(28, 16);
            this.labelFormCpu.TabIndex = 3;
            this.labelFormCpu.Text = "%0";
            // 
            // chartFormCpu
            // 
            chartArea1.Name = "ChartArea1";
            this.chartFormCpu.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartFormCpu.Legends.Add(legend1);
            this.chartFormCpu.Location = new System.Drawing.Point(36, 151);
            this.chartFormCpu.Name = "chartFormCpu";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartFormCpu.Series.Add(series1);
            this.chartFormCpu.Size = new System.Drawing.Size(338, 193);
            this.chartFormCpu.TabIndex = 4;
            // 
            // FormCpu
            // 
            this.ClientSize = new System.Drawing.Size(424, 373);
            this.Controls.Add(this.chartFormCpu);
            this.Controls.Add(this.labelFormCpu);
            this.Controls.Add(this.progressBarFormCpu);
            this.Controls.Add(this.label1);
            this.Name = "FormCpu";
            ((System.ComponentModel.ISupportInitialize)(this.chartFormCpu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBarFormCpu;
        private System.Windows.Forms.Label labelFormCpu;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartFormCpu;
    }
}