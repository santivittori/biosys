namespace biosys
{
    partial class InformesAuditoria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InformesAuditoria));
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
            this.chartProductosUltimoMes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartUsuariosSesionNocturna = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartUsuariosMasProductosAgregaron = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartUsuariosMasIniciaronSesion = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnDescargaGrafica = new biosys.RoundedButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartProductosUltimoMes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartUsuariosSesionNocturna)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartUsuariosMasProductosAgregaron)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartUsuariosMasIniciaronSesion)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.Location = new System.Drawing.Point(443, 37);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(432, 55);
            this.labelTitulo.TabIndex = 54;
            this.labelTitulo.Text = "Informes auditorías";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(88, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 58;
            this.label1.Text = "Atrás";
            // 
            // pictureBack
            // 
            this.pictureBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBack.Image = ((System.Drawing.Image)(resources.GetObject("pictureBack.Image")));
            this.pictureBack.Location = new System.Drawing.Point(44, 12);
            this.pictureBack.Name = "pictureBack";
            this.pictureBack.Size = new System.Drawing.Size(50, 44);
            this.pictureBack.TabIndex = 57;
            this.pictureBack.TabStop = false;
            this.pictureBack.Click += new System.EventHandler(this.pictureBack_Click);
            // 
            // chartProductosUltimoMes
            // 
            chartArea1.Name = "ChartArea1";
            this.chartProductosUltimoMes.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartProductosUltimoMes.Legends.Add(legend1);
            this.chartProductosUltimoMes.Location = new System.Drawing.Point(665, 451);
            this.chartProductosUltimoMes.Name = "chartProductosUltimoMes";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartProductosUltimoMes.Series.Add(series1);
            this.chartProductosUltimoMes.Size = new System.Drawing.Size(497, 262);
            this.chartProductosUltimoMes.TabIndex = 153;
            this.chartProductosUltimoMes.Text = "chart1";
            // 
            // chartUsuariosSesionNocturna
            // 
            chartArea2.Name = "ChartArea1";
            this.chartUsuariosSesionNocturna.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartUsuariosSesionNocturna.Legends.Add(legend2);
            this.chartUsuariosSesionNocturna.Location = new System.Drawing.Point(93, 451);
            this.chartUsuariosSesionNocturna.Name = "chartUsuariosSesionNocturna";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartUsuariosSesionNocturna.Series.Add(series2);
            this.chartUsuariosSesionNocturna.Size = new System.Drawing.Size(497, 262);
            this.chartUsuariosSesionNocturna.TabIndex = 152;
            this.chartUsuariosSesionNocturna.Text = "chart1";
            // 
            // chartUsuariosMasProductosAgregaron
            // 
            chartArea3.Name = "ChartArea1";
            this.chartUsuariosMasProductosAgregaron.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartUsuariosMasProductosAgregaron.Legends.Add(legend3);
            this.chartUsuariosMasProductosAgregaron.Location = new System.Drawing.Point(665, 151);
            this.chartUsuariosMasProductosAgregaron.Name = "chartUsuariosMasProductosAgregaron";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartUsuariosMasProductosAgregaron.Series.Add(series3);
            this.chartUsuariosMasProductosAgregaron.Size = new System.Drawing.Size(497, 262);
            this.chartUsuariosMasProductosAgregaron.TabIndex = 151;
            this.chartUsuariosMasProductosAgregaron.Text = "chart1";
            // 
            // chartUsuariosMasIniciaronSesion
            // 
            chartArea4.Name = "ChartArea1";
            this.chartUsuariosMasIniciaronSesion.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartUsuariosMasIniciaronSesion.Legends.Add(legend4);
            this.chartUsuariosMasIniciaronSesion.Location = new System.Drawing.Point(93, 151);
            this.chartUsuariosMasIniciaronSesion.Name = "chartUsuariosMasIniciaronSesion";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartUsuariosMasIniciaronSesion.Series.Add(series4);
            this.chartUsuariosMasIniciaronSesion.Size = new System.Drawing.Size(497, 262);
            this.chartUsuariosMasIniciaronSesion.TabIndex = 150;
            this.chartUsuariosMasIniciaronSesion.Text = "chart1";
            // 
            // btnDescargaGrafica
            // 
            this.btnDescargaGrafica.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDescargaGrafica.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescargaGrafica.Location = new System.Drawing.Point(1227, 410);
            this.btnDescargaGrafica.Name = "btnDescargaGrafica";
            this.btnDescargaGrafica.Size = new System.Drawing.Size(119, 48);
            this.btnDescargaGrafica.TabIndex = 149;
            this.btnDescargaGrafica.Text = "Descargar";
            this.btnDescargaGrafica.UseVisualStyleBackColor = true;
            this.btnDescargaGrafica.Click += new System.EventHandler(this.btnDescargaGrafica_Click);
            // 
            // InformesAuditoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1400, 782);
            this.Controls.Add(this.chartProductosUltimoMes);
            this.Controls.Add(this.chartUsuariosSesionNocturna);
            this.Controls.Add(this.chartUsuariosMasProductosAgregaron);
            this.Controls.Add(this.chartUsuariosMasIniciaronSesion);
            this.Controls.Add(this.btnDescargaGrafica);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBack);
            this.Controls.Add(this.labelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InformesAuditoria";
            this.Text = "InformesAuditoria";
            this.Load += new System.EventHandler(this.InformesAuditoria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartProductosUltimoMes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartUsuariosSesionNocturna)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartUsuariosMasProductosAgregaron)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartUsuariosMasIniciaronSesion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBack;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartProductosUltimoMes;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartUsuariosSesionNocturna;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartUsuariosMasProductosAgregaron;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartUsuariosMasIniciaronSesion;
        private RoundedButton btnDescargaGrafica;
    }
}