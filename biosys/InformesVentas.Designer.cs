namespace biosys
{
    partial class InformesVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InformesVentas));
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
            this.labelTitulo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBack = new System.Windows.Forms.PictureBox();
            this.chartVentasPorProducto = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartVentasPorCliente = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartMediosPago = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartArbolesMasVendidos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnDescargaGrafica = new biosys.RoundedButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentasPorProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentasPorCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMediosPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartArbolesMasVendidos)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.Location = new System.Drawing.Point(411, 29);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(482, 55);
            this.labelTitulo.TabIndex = 54;
            this.labelTitulo.Text = "INFORMES VENTAS";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(88, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 59;
            this.label1.Text = "Back";
            // 
            // pictureBack
            // 
            this.pictureBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBack.Image = ((System.Drawing.Image)(resources.GetObject("pictureBack.Image")));
            this.pictureBack.Location = new System.Drawing.Point(42, 12);
            this.pictureBack.Name = "pictureBack";
            this.pictureBack.Size = new System.Drawing.Size(50, 44);
            this.pictureBack.TabIndex = 58;
            this.pictureBack.TabStop = false;
            this.pictureBack.Click += new System.EventHandler(this.pictureBack_Click);
            // 
            // chartVentasPorProducto
            // 
            chartArea1.Name = "ChartArea1";
            this.chartVentasPorProducto.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartVentasPorProducto.Legends.Add(legend1);
            this.chartVentasPorProducto.Location = new System.Drawing.Point(665, 451);
            this.chartVentasPorProducto.Name = "chartVentasPorProducto";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartVentasPorProducto.Series.Add(series1);
            this.chartVentasPorProducto.Size = new System.Drawing.Size(497, 262);
            this.chartVentasPorProducto.TabIndex = 153;
            this.chartVentasPorProducto.Text = "chart1";
            // 
            // chartVentasPorCliente
            // 
            chartArea2.Name = "ChartArea1";
            this.chartVentasPorCliente.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartVentasPorCliente.Legends.Add(legend2);
            this.chartVentasPorCliente.Location = new System.Drawing.Point(93, 451);
            this.chartVentasPorCliente.Name = "chartVentasPorCliente";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartVentasPorCliente.Series.Add(series2);
            this.chartVentasPorCliente.Size = new System.Drawing.Size(497, 262);
            this.chartVentasPorCliente.TabIndex = 152;
            this.chartVentasPorCliente.Text = "chart1";
            // 
            // chartMediosPago
            // 
            chartArea3.Name = "ChartArea1";
            this.chartMediosPago.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartMediosPago.Legends.Add(legend3);
            this.chartMediosPago.Location = new System.Drawing.Point(665, 151);
            this.chartMediosPago.Name = "chartMediosPago";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartMediosPago.Series.Add(series3);
            this.chartMediosPago.Size = new System.Drawing.Size(497, 262);
            this.chartMediosPago.TabIndex = 151;
            this.chartMediosPago.Text = "chart1";
            // 
            // chartArbolesMasVendidos
            // 
            chartArea4.Name = "ChartArea1";
            this.chartArbolesMasVendidos.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartArbolesMasVendidos.Legends.Add(legend4);
            this.chartArbolesMasVendidos.Location = new System.Drawing.Point(93, 151);
            this.chartArbolesMasVendidos.Name = "chartArbolesMasVendidos";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartArbolesMasVendidos.Series.Add(series4);
            this.chartArbolesMasVendidos.Size = new System.Drawing.Size(497, 262);
            this.chartArbolesMasVendidos.TabIndex = 150;
            this.chartArbolesMasVendidos.Text = "chart1";
            // 
            // btnDescargaGrafica
            // 
            this.btnDescargaGrafica.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDescargaGrafica.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescargaGrafica.Location = new System.Drawing.Point(1227, 410);
            this.btnDescargaGrafica.Name = "btnDescargaGrafica";
            this.btnDescargaGrafica.Size = new System.Drawing.Size(119, 48);
            this.btnDescargaGrafica.TabIndex = 149;
            this.btnDescargaGrafica.Text = "DESCARGA GRÁFICA";
            this.btnDescargaGrafica.UseVisualStyleBackColor = true;
            this.btnDescargaGrafica.Click += new System.EventHandler(this.btnDescargaGrafica_Click);
            // 
            // InfrormesVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1400, 782);
            this.Controls.Add(this.chartVentasPorProducto);
            this.Controls.Add(this.chartVentasPorCliente);
            this.Controls.Add(this.chartMediosPago);
            this.Controls.Add(this.chartArbolesMasVendidos);
            this.Controls.Add(this.btnDescargaGrafica);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBack);
            this.Controls.Add(this.labelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InfrormesVentas";
            this.Text = "InfrormesVentas";
            this.Load += new System.EventHandler(this.InfrormesVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentasPorProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentasPorCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMediosPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartArbolesMasVendidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBack;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVentasPorProducto;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVentasPorCliente;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMediosPago;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartArbolesMasVendidos;
        private RoundedButton btnDescargaGrafica;
    }
}