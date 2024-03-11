namespace biosys
{
    partial class InformesCompras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InformesCompras));
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
            this.chartSemillas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartArboles = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartComprasPorProveedor = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnDescargaGrafica = new biosys.RoundedButton();
            this.chartPreciosUnitarios = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSemillas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartArboles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartComprasPorProveedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPreciosUnitarios)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.Location = new System.Drawing.Point(429, 33);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(533, 55);
            this.labelTitulo.TabIndex = 53;
            this.labelTitulo.Text = "INFORMES COMPRAS";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(89, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 57;
            this.label1.Text = "Back";
            // 
            // pictureBack
            // 
            this.pictureBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBack.Image = ((System.Drawing.Image)(resources.GetObject("pictureBack.Image")));
            this.pictureBack.Location = new System.Drawing.Point(42, 12);
            this.pictureBack.Name = "pictureBack";
            this.pictureBack.Size = new System.Drawing.Size(50, 44);
            this.pictureBack.TabIndex = 56;
            this.pictureBack.TabStop = false;
            this.pictureBack.Click += new System.EventHandler(this.pictureBack_Click);
            // 
            // chartSemillas
            // 
            chartArea1.Name = "ChartArea1";
            this.chartSemillas.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartSemillas.Legends.Add(legend1);
            this.chartSemillas.Location = new System.Drawing.Point(93, 151);
            this.chartSemillas.Name = "chartSemillas";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartSemillas.Series.Add(series1);
            this.chartSemillas.Size = new System.Drawing.Size(497, 262);
            this.chartSemillas.TabIndex = 145;
            this.chartSemillas.Text = "chart1";
            // 
            // chartArboles
            // 
            chartArea2.Name = "ChartArea1";
            this.chartArboles.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartArboles.Legends.Add(legend2);
            this.chartArboles.Location = new System.Drawing.Point(665, 151);
            this.chartArboles.Name = "chartArboles";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartArboles.Series.Add(series2);
            this.chartArboles.Size = new System.Drawing.Size(497, 262);
            this.chartArboles.TabIndex = 146;
            this.chartArboles.Text = "chart1";
            // 
            // chartComprasPorProveedor
            // 
            chartArea3.Name = "ChartArea1";
            this.chartComprasPorProveedor.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartComprasPorProveedor.Legends.Add(legend3);
            this.chartComprasPorProveedor.Location = new System.Drawing.Point(93, 451);
            this.chartComprasPorProveedor.Name = "chartComprasPorProveedor";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartComprasPorProveedor.Series.Add(series3);
            this.chartComprasPorProveedor.Size = new System.Drawing.Size(497, 262);
            this.chartComprasPorProveedor.TabIndex = 147;
            this.chartComprasPorProveedor.Text = "chart1";
            // 
            // btnDescargaGrafica
            // 
            this.btnDescargaGrafica.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDescargaGrafica.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescargaGrafica.Location = new System.Drawing.Point(1227, 410);
            this.btnDescargaGrafica.Name = "btnDescargaGrafica";
            this.btnDescargaGrafica.Size = new System.Drawing.Size(119, 48);
            this.btnDescargaGrafica.TabIndex = 144;
            this.btnDescargaGrafica.Text = "DESCARGA GRÁFICA";
            this.btnDescargaGrafica.UseVisualStyleBackColor = true;
            this.btnDescargaGrafica.Click += new System.EventHandler(this.btnDescargaGrafica_Click);
            // 
            // chartPreciosUnitarios
            // 
            chartArea4.Name = "ChartArea1";
            this.chartPreciosUnitarios.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartPreciosUnitarios.Legends.Add(legend4);
            this.chartPreciosUnitarios.Location = new System.Drawing.Point(665, 451);
            this.chartPreciosUnitarios.Name = "chartPreciosUnitarios";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartPreciosUnitarios.Series.Add(series4);
            this.chartPreciosUnitarios.Size = new System.Drawing.Size(497, 262);
            this.chartPreciosUnitarios.TabIndex = 148;
            this.chartPreciosUnitarios.Text = "chart1";
            // 
            // InformesCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1400, 782);
            this.Controls.Add(this.chartPreciosUnitarios);
            this.Controls.Add(this.chartComprasPorProveedor);
            this.Controls.Add(this.chartArboles);
            this.Controls.Add(this.chartSemillas);
            this.Controls.Add(this.btnDescargaGrafica);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBack);
            this.Controls.Add(this.labelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InformesCompras";
            this.Text = "InformesCompras";
            this.Load += new System.EventHandler(this.InformesCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSemillas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartArboles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartComprasPorProveedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPreciosUnitarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBack;
        private RoundedButton btnDescargaGrafica;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSemillas;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartArboles;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartComprasPorProveedor;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPreciosUnitarios;
    }
}