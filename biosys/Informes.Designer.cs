﻿namespace biosys
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
            this.btnDescargaGrafica = new biosys.RoundedButton();
            this.btnExportarPDF = new biosys.RoundedButton();
            this.btnInfEconomicos = new biosys.RoundedButton();
            this.btnInfReproduccion = new biosys.RoundedButton();
            this.btnInfCompras = new biosys.RoundedButton();
            this.btnInfVentas = new biosys.RoundedButton();
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
            this.labelTitulo.Location = new System.Drawing.Point(583, 34);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(211, 55);
            this.labelTitulo.TabIndex = 51;
            this.labelTitulo.Text = "Informes";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CantTotal
            // 
            chartArea1.Name = "ChartArea1";
            this.CantTotal.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.CantTotal.Legends.Add(legend1);
            this.CantTotal.Location = new System.Drawing.Point(856, 146);
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
            this.SemillasTipo.Location = new System.Drawing.Point(31, 146);
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
            this.ArbolesTipo.Location = new System.Drawing.Point(31, 441);
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
            this.TotalporDivision.Location = new System.Drawing.Point(856, 441);
            this.TotalporDivision.Name = "TotalporDivision";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.TotalporDivision.Series.Add(series4);
            this.TotalporDivision.Size = new System.Drawing.Size(333, 252);
            this.TotalporDivision.TabIndex = 55;
            this.TotalporDivision.Text = "chart1";
            // 
            // btnDescargaGrafica
            // 
            this.btnDescargaGrafica.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDescargaGrafica.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescargaGrafica.Location = new System.Drawing.Point(1238, 571);
            this.btnDescargaGrafica.Name = "btnDescargaGrafica";
            this.btnDescargaGrafica.Size = new System.Drawing.Size(119, 48);
            this.btnDescargaGrafica.TabIndex = 142;
            this.btnDescargaGrafica.Text = "Descargar gráficos";
            this.btnDescargaGrafica.UseVisualStyleBackColor = true;
            this.btnDescargaGrafica.Click += new System.EventHandler(this.btnDescargaGrafica_Click);
            // 
            // btnExportarPDF
            // 
            this.btnExportarPDF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportarPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarPDF.Location = new System.Drawing.Point(1238, 500);
            this.btnExportarPDF.Name = "btnExportarPDF";
            this.btnExportarPDF.Size = new System.Drawing.Size(119, 48);
            this.btnExportarPDF.TabIndex = 143;
            this.btnExportarPDF.Text = "Descargar informes";
            this.btnExportarPDF.UseVisualStyleBackColor = true;
            this.btnExportarPDF.Click += new System.EventHandler(this.btnExportarPDF_Click);
            // 
            // btnInfEconomicos
            // 
            this.btnInfEconomicos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInfEconomicos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInfEconomicos.Location = new System.Drawing.Point(1238, 359);
            this.btnInfEconomicos.Name = "btnInfEconomicos";
            this.btnInfEconomicos.Size = new System.Drawing.Size(119, 48);
            this.btnInfEconomicos.TabIndex = 144;
            this.btnInfEconomicos.Text = "Informes económicos";
            this.btnInfEconomicos.UseVisualStyleBackColor = true;
            this.btnInfEconomicos.Click += new System.EventHandler(this.btnInfEconomicos_Click);
            // 
            // btnInfReproduccion
            // 
            this.btnInfReproduccion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInfReproduccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInfReproduccion.Location = new System.Drawing.Point(1238, 289);
            this.btnInfReproduccion.Name = "btnInfReproduccion";
            this.btnInfReproduccion.Size = new System.Drawing.Size(119, 48);
            this.btnInfReproduccion.TabIndex = 145;
            this.btnInfReproduccion.Text = "Informes reproducción";
            this.btnInfReproduccion.UseVisualStyleBackColor = true;
            this.btnInfReproduccion.Click += new System.EventHandler(this.btnInfReproduccion_Click);
            // 
            // btnInfCompras
            // 
            this.btnInfCompras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInfCompras.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInfCompras.Location = new System.Drawing.Point(1238, 218);
            this.btnInfCompras.Name = "btnInfCompras";
            this.btnInfCompras.Size = new System.Drawing.Size(119, 48);
            this.btnInfCompras.TabIndex = 146;
            this.btnInfCompras.Text = "Informes compras";
            this.btnInfCompras.UseVisualStyleBackColor = true;
            this.btnInfCompras.Click += new System.EventHandler(this.btnInfCompras_Click);
            // 
            // btnInfVentas
            // 
            this.btnInfVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInfVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInfVentas.Location = new System.Drawing.Point(1238, 428);
            this.btnInfVentas.Name = "btnInfVentas";
            this.btnInfVentas.Size = new System.Drawing.Size(119, 48);
            this.btnInfVentas.TabIndex = 147;
            this.btnInfVentas.Text = "Informes ventas";
            this.btnInfVentas.UseVisualStyleBackColor = true;
            this.btnInfVentas.Click += new System.EventHandler(this.btnInfVentas_Click);
            // 
            // Informes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1400, 782);
            this.Controls.Add(this.btnInfVentas);
            this.Controls.Add(this.btnInfCompras);
            this.Controls.Add(this.btnInfReproduccion);
            this.Controls.Add(this.btnInfEconomicos);
            this.Controls.Add(this.btnExportarPDF);
            this.Controls.Add(this.btnDescargaGrafica);
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
        private RoundedButton btnDescargaGrafica;
        private RoundedButton btnExportarPDF;
        private RoundedButton btnInfEconomicos;
        private RoundedButton btnInfReproduccion;
        private RoundedButton btnInfCompras;
        private RoundedButton btnInfVentas;
    }
}