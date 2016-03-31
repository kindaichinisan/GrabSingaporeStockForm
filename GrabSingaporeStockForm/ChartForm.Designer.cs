namespace GrabSingaporeStockForm
{
    partial class ChartForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.stockchart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.StartdateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EnddateTimePicker = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.stockchart)).BeginInit();
            this.SuspendLayout();
            // 
            // stockchart
            // 
            this.stockchart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.Name = "ChartArea1";
            this.stockchart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.stockchart.Legends.Add(legend3);
            this.stockchart.Location = new System.Drawing.Point(12, 12);
            this.stockchart.Name = "stockchart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.stockchart.Series.Add(series3);
            this.stockchart.Size = new System.Drawing.Size(772, 300);
            this.stockchart.TabIndex = 0;
            this.stockchart.Text = "chart1";
            // 
            // StartdateTimePicker
            // 
            this.StartdateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StartdateTimePicker.Location = new System.Drawing.Point(107, 327);
            this.StartdateTimePicker.Name = "StartdateTimePicker";
            this.StartdateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.StartdateTimePicker.TabIndex = 1;
            this.StartdateTimePicker.CloseUp += new System.EventHandler(this.StartdateTimePicker_CloseUp);
            this.StartdateTimePicker.ValueChanged += new System.EventHandler(this.StartdateTimePicker_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 333);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start date";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 359);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "End date";
            // 
            // EnddateTimePicker
            // 
            this.EnddateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EnddateTimePicker.Location = new System.Drawing.Point(107, 353);
            this.EnddateTimePicker.Name = "EnddateTimePicker";
            this.EnddateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.EnddateTimePicker.TabIndex = 3;
            // 
            // ChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 418);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.EnddateTimePicker);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartdateTimePicker);
            this.Controls.Add(this.stockchart);
            this.Name = "ChartForm";
            this.Text = "ChartForm";
            this.Load += new System.EventHandler(this.ChartForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stockchart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart stockchart;
        private System.Windows.Forms.DateTimePicker StartdateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker EnddateTimePicker;

    }
}