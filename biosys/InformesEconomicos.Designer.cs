namespace biosys
{
    partial class InformesEconomicos
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InformesEconomicos));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.CompraTotal = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pictureBack = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.VentaTotal = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartSemillas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartArboles = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnDescargaGrafica = new biosys.RoundedButton();
            ((System.ComponentModel.ISupportInitialize)(this.CompraTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VentaTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSemillas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartArboles)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.Location = new System.Drawing.Point(400, 50);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(623, 55);
            this.labelTitulo.TabIndex = 52;
            this.labelTitulo.Text = "INFORMES ECONÓMICOS";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CompraTotal
            // 
            chartArea5.Name = "ChartArea1";
            this.CompraTotal.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.CompraTotal.Legends.Add(legend5);
            this.CompraTotal.Location = new System.Drawing.Point(76, 144);
            this.CompraTotal.Name = "CompraTotal";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.CompraTotal.Series.Add(series5);
            this.CompraTotal.Size = new System.Drawing.Size(497, 295);
            this.CompraTotal.TabIndex = 53;
            this.CompraTotal.Text = "chart1";
            // 
            // pictureBack
            // 
            this.pictureBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBack.Image = ((System.Drawing.Image)(resources.GetObject("pictureBack.Image")));
            this.pictureBack.Location = new System.Drawing.Point(44, 12);
            this.pictureBack.Name = "pictureBack";
            this.pictureBack.Size = new System.Drawing.Size(50, 44);
            this.pictureBack.TabIndex = 54;
            this.pictureBack.TabStop = false;
            this.pictureBack.Click += new System.EventHandler(this.pictureBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(91, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 55;
            this.label1.Text = "Back";
            // 
            // VentaTotal
            // 
            chartArea6.Name = "ChartArea1";
            this.VentaTotal.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.VentaTotal.Legends.Add(legend6);
            this.VentaTotal.Location = new System.Drawing.Point(649, 144);
            this.VentaTotal.Name = "VentaTotal";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.VentaTotal.Series.Add(series6);
            this.VentaTotal.Size = new System.Drawing.Size(497, 295);
            this.VentaTotal.TabIndex = 56;
            this.VentaTotal.Text = "chart1";
            // 
            // chartSemillas
            // 
            chartArea7.Name = "ChartArea1";
            this.chartSemillas.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.chartSemillas.Legends.Add(legend7);
            this.chartSemillas.Location = new System.Drawing.Point(76, 482);
            this.chartSemillas.Name = "chartSemillas";
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            this.chartSemillas.Series.Add(series7);
            this.chartSemillas.Size = new System.Drawing.Size(497, 262);
            this.chartSemillas.TabIndex = 57;
            this.chartSemillas.Text = "chart1";
            // 
            // chartArboles
            // 
            chartArea8.Name = "ChartArea1";
            this.chartArboles.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.chartArboles.Legends.Add(legend8);
            this.chartArboles.Location = new System.Drawing.Point(649, 482);
            this.chartArboles.Name = "chartArboles";
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "Series1";
            this.chartArboles.Series.Add(series8);
            this.chartArboles.Size = new System.Drawing.Size(497, 262);
            this.chartArboles.TabIndex = 58;
            this.chartArboles.Text = "chart1";
            // 
            // btnDescargaGrafica
            // 
            this.btnDescargaGrafica.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDescargaGrafica.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescargaGrafica.Location = new System.Drawing.Point(1208, 435);
            this.btnDescargaGrafica.Name = "btnDescargaGrafica";
            this.btnDescargaGrafica.Size = new System.Drawing.Size(119, 48);
            this.btnDescargaGrafica.TabIndex = 143;
            this.btnDescargaGrafica.Text = "DESCARGA GRÁFICA";
            this.btnDescargaGrafica.UseVisualStyleBackColor = true;
            this.btnDescargaGrafica.Click += new System.EventHandler(this.btnDescargaGrafica_Click);
            // 
            // InformesEconomicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1400, 782);
            this.Controls.Add(this.btnDescargaGrafica);
            this.Controls.Add(this.chartArboles);
            this.Controls.Add(this.chartSemillas);
            this.Controls.Add(this.VentaTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBack);
            this.Controls.Add(this.CompraTotal);
            this.Controls.Add(this.labelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InformesEconomicos";
            this.Text = "InformesEconomicos";
            this.Load += new System.EventHandler(this.InformesEconomicos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CompraTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VentaTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSemillas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartArboles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.DataVisualization.Charting.Chart CompraTotal;
        private System.Windows.Forms.PictureBox pictureBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart VentaTotal;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSemillas;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartArboles;
        private RoundedButton btnDescargaGrafica;
    }
}