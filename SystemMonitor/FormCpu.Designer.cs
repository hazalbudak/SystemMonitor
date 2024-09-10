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
            this.labelCpu = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBarCpu = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // labelCpu
            // 
            this.labelCpu.AutoSize = true;
            this.labelCpu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelCpu.Location = new System.Drawing.Point(448, 86);
            this.labelCpu.Name = "labelCpu";
            this.labelCpu.Size = new System.Drawing.Size(28, 16);
            this.labelCpu.TabIndex = 11;
            this.labelCpu.Text = "%0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(25, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "CPU:";
            // 
            // progressBarCpu
            // 
            this.progressBarCpu.Location = new System.Drawing.Point(86, 79);
            this.progressBarCpu.Name = "progressBarCpu";
            this.progressBarCpu.Size = new System.Drawing.Size(334, 23);
            this.progressBarCpu.TabIndex = 9;
            // 
            // FormCpu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 195);
            this.Controls.Add(this.labelCpu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBarCpu);
            this.Name = "FormCpu";
            this.Text = "FormCpu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCpu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBarCpu;
    }
}