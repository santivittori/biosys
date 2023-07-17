namespace biosys
{
    partial class Informes
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Informes));
            this.labelTitulo = new System.Windows.Forms.Label();
            this.CantTotal = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.SemillasTipo = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ArbolesTipo = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.TotalporDivision = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.CantTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SemillasTipo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArbolesTipo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalporDivision)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.Location = new System.Drawing.Point(530, 50);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(277, 55);
            this.labelTitulo.TabIndex = 51;
            this.labelTitulo.Text = "INFORMES";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CantTotal
            // 
            chartArea1.Name = "ChartArea1";
            this.CantTotal.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.CantTotal.Legends.Add(legend1);
            this.CantTotal.Location = new System.Drawing.Point(950, 125);
            this.CantTotal.Name = "CantTotal";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.CantTotal.Series.Add(series1);
            this.CantTotal.Size = new System.Drawing.Size(333, 252);
            this.CantTotal.TabIndex = 52;
            this.CantTotal.Text = "chart1";
            // 
            // SemillasTipo
            // 
            chartArea2.Name = "ChartArea1";
            this.SemillasTipo.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.SemillasTipo.Legends.Add(legend2);
            this.SemillasTipo.Location = new System.Drawing.Point(97, 125);
            this.SemillasTipo.Name = "SemillasTipo";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.SemillasTipo.Series.Add(series2);
            this.SemillasTipo.Size = new System.Drawing.Size(763, 252);
            this.SemillasTipo.TabIndex = 53;
            this.SemillasTipo.Text = "chart1";
            // 
            // ArbolesTipo
            // 
            chartArea3.Name = "ChartArea1";
            this.ArbolesTipo.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.ArbolesTipo.Legends.Add(legend3);
            this.ArbolesTipo.Location = new System.Drawing.Point(97, 413);
            this.ArbolesTipo.Name = "ArbolesTipo";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.ArbolesTipo.Series.Add(series3);
            this.ArbolesTipo.Size = new System.Drawing.Size(763, 252);
            this.ArbolesTipo.TabIndex = 54;
            this.ArbolesTipo.Text = "chart2";
            // 
            // TotalporDivision
            // 
            chartArea4.Name = "ChartArea1";
            this.TotalporDivision.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.TotalporDivision.Legends.Add(legend4);
            this.TotalporDivision.Location = new System.Drawing.Point(950, 413);
            this.TotalporDivision.Name = "TotalporDivision";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.TotalporDivision.Series.Add(series4);
            this.TotalporDivision.Size = new System.Drawing.Size(333, 252);
            this.TotalporDivision.TabIndex = 55;
            this.TotalporDivision.Text = "chart1";
            // 
            // Informes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1384, 743);
            this.Controls.Add(this.TotalporDivision);
            this.Controls.Add(this.ArbolesTipo);
            this.Controls.Add(this.SemillasTipo);
            this.Controls.Add(this.CantTotal);
            this.Controls.Add(this.labelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Informes";
            this.Text = "Informes";
            this.Load += new System.EventHandler(this.Informes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CantTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SemillasTipo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArbolesTipo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalporDivision)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.DataVisualization.Charting.Chart CantTotal;
        private System.Windows.Forms.DataVisualization.Charting.Chart SemillasTipo;
        private System.Windows.Forms.DataVisualization.Charting.Chart ArbolesTipo;
        private System.Windows.Forms.DataVisualization.Charting.Chart TotalporDivision;
    }
}