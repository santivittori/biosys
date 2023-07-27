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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InformesEconomicos));
            this.labelTitulo = new System.Windows.Forms.Label();
            this.CompraTotal = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pictureBack = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CompraTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBack)).BeginInit();
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
            chartArea1.Name = "ChartArea1";
            this.CompraTotal.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.CompraTotal.Legends.Add(legend1);
            this.CompraTotal.Location = new System.Drawing.Point(76, 144);
            this.CompraTotal.Name = "CompraTotal";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.CompraTotal.Series.Add(series1);
            this.CompraTotal.Size = new System.Drawing.Size(497, 327);
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
            // InformesEconomicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1400, 782);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.DataVisualization.Charting.Chart CompraTotal;
        private System.Windows.Forms.PictureBox pictureBack;
        private System.Windows.Forms.Label label1;
    }
}