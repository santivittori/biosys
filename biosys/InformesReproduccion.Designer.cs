namespace biosys
{
    partial class InformesReproduccion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InformesReproduccion));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.pictureBack = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chartBajas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartBajasTotales = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnDescargaGrafica = new biosys.RoundedButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBajas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBajasTotales)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.Location = new System.Drawing.Point(359, 50);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(686, 55);
            this.labelTitulo.TabIndex = 53;
            this.labelTitulo.Text = "INFORMES REPRODUCCIÓN";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBack
            // 
            this.pictureBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBack.Image = ((System.Drawing.Image)(resources.GetObject("pictureBack.Image")));
            this.pictureBack.Location = new System.Drawing.Point(44, 12);
            this.pictureBack.Name = "pictureBack";
            this.pictureBack.Size = new System.Drawing.Size(50, 44);
            this.pictureBack.TabIndex = 55;
            this.pictureBack.TabStop = false;
            this.pictureBack.Click += new System.EventHandler(this.pictureBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(88, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 56;
            this.label1.Text = "Back";
            // 
            // chartBajas
            // 
            chartArea1.Name = "ChartArea1";
            this.chartBajas.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartBajas.Legends.Add(legend1);
            this.chartBajas.Location = new System.Drawing.Point(80, 209);
            this.chartBajas.Name = "chartBajas";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartBajas.Series.Add(series1);
            this.chartBajas.Size = new System.Drawing.Size(483, 386);
            this.chartBajas.TabIndex = 57;
            this.chartBajas.Text = "chart1";
            // 
            // chartBajasTotales
            // 
            chartArea2.Name = "ChartArea1";
            this.chartBajasTotales.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartBajasTotales.Legends.Add(legend2);
            this.chartBajasTotales.Location = new System.Drawing.Point(676, 209);
            this.chartBajasTotales.Name = "chartBajasTotales";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartBajasTotales.Series.Add(series2);
            this.chartBajasTotales.Size = new System.Drawing.Size(483, 386);
            this.chartBajasTotales.TabIndex = 58;
            this.chartBajasTotales.Text = "chart2";
            // 
            // btnDescargaGrafica
            // 
            this.btnDescargaGrafica.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDescargaGrafica.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescargaGrafica.Location = new System.Drawing.Point(1221, 373);
            this.btnDescargaGrafica.Name = "btnDescargaGrafica";
            this.btnDescargaGrafica.Size = new System.Drawing.Size(119, 48);
            this.btnDescargaGrafica.TabIndex = 144;
            this.btnDescargaGrafica.Text = "DESCARGA GRÁFICA";
            this.btnDescargaGrafica.UseVisualStyleBackColor = true;
            this.btnDescargaGrafica.Click += new System.EventHandler(this.btnDescargaGrafica_Click);
            // 
            // InformesReproduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1400, 782);
            this.Controls.Add(this.btnDescargaGrafica);
            this.Controls.Add(this.chartBajasTotales);
            this.Controls.Add(this.chartBajas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBack);
            this.Controls.Add(this.labelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InformesReproduccion";
            this.Text = "InformesReproduccion";
            this.Load += new System.EventHandler(this.InformesReproduccion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBajas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBajasTotales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.PictureBox pictureBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBajas;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBajasTotales;
        private RoundedButton btnDescargaGrafica;
    }
}