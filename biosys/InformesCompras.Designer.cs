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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.labelTitulo.Location = new System.Drawing.Point(512, 26);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(409, 55);
            this.labelTitulo.TabIndex = 53;
            this.labelTitulo.Text = "Informes compras";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(88, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 57;
            this.label1.Text = "Atrás";
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
            chartArea5.Name = "ChartArea1";
            this.chartSemillas.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chartSemillas.Legends.Add(legend5);
            this.chartSemillas.Location = new System.Drawing.Point(93, 151);
            this.chartSemillas.Name = "chartSemillas";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.chartSemillas.Series.Add(series5);
            this.chartSemillas.Size = new System.Drawing.Size(497, 262);
            this.chartSemillas.TabIndex = 145;
            this.chartSemillas.Text = "chart1";
            // 
            // chartArboles
            // 
            chartArea6.Name = "ChartArea1";
            this.chartArboles.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chartArboles.Legends.Add(legend6);
            this.chartArboles.Location = new System.Drawing.Point(665, 151);
            this.chartArboles.Name = "chartArboles";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.chartArboles.Series.Add(series6);
            this.chartArboles.Size = new System.Drawing.Size(497, 262);
            this.chartArboles.TabIndex = 146;
            this.chartArboles.Text = "chart1";
            // 
            // chartComprasPorProveedor
            // 
            chartArea7.Name = "ChartArea1";
            this.chartComprasPorProveedor.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.chartComprasPorProveedor.Legends.Add(legend7);
            this.chartComprasPorProveedor.Location = new System.Drawing.Point(93, 451);
            this.chartComprasPorProveedor.Name = "chartComprasPorProveedor";
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            this.chartComprasPorProveedor.Series.Add(series7);
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
            this.btnDescargaGrafica.Text = "Descargar";
            this.btnDescargaGrafica.UseVisualStyleBackColor = true;
            this.btnDescargaGrafica.Click += new System.EventHandler(this.btnDescargaGrafica_Click);
            // 
            // chartPreciosUnitarios
            // 
            chartArea8.Name = "ChartArea1";
            this.chartPreciosUnitarios.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.chartPreciosUnitarios.Legends.Add(legend8);
            this.chartPreciosUnitarios.Location = new System.Drawing.Point(665, 451);
            this.chartPreciosUnitarios.Name = "chartPreciosUnitarios";
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "Series1";
            this.chartPreciosUnitarios.Series.Add(series8);
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