﻿namespace biosys
{
    partial class HistorialDonaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistorialDonaciones));
            this.labelTitulo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnQuitarFiltro = new biosys.RoundedButton();
            this.dateFin = new System.Windows.Forms.DateTimePicker();
            this.dateInicio = new System.Windows.Forms.DateTimePicker();
            this.btnAplicarFiltro = new biosys.RoundedButton();
            this.labelHistorialDonaciones = new System.Windows.Forms.Label();
            this.dataGridViewHistorialDonaciones = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBack = new System.Windows.Forms.PictureBox();
            this.btnSigDonaciones = new System.Windows.Forms.PictureBox();
            this.btnAntDonaciones = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistorialDonaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSigDonaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAntDonaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.Location = new System.Drawing.Point(430, 26);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(523, 55);
            this.labelTitulo.TabIndex = 51;
            this.labelTitulo.Text = "Historial de donaciones";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1213, 289);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 18);
            this.label3.TabIndex = 193;
            this.label3.Text = "Hasta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1210, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 18);
            this.label2.TabIndex = 192;
            this.label2.Text = "Desde";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1144, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 18);
            this.label1.TabIndex = 191;
            this.label1.Text = "Filtro por rango de fechas";
            // 
            // btnQuitarFiltro
            // 
            this.btnQuitarFiltro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitarFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarFiltro.Location = new System.Drawing.Point(1177, 452);
            this.btnQuitarFiltro.Name = "btnQuitarFiltro";
            this.btnQuitarFiltro.Size = new System.Drawing.Size(119, 48);
            this.btnQuitarFiltro.TabIndex = 190;
            this.btnQuitarFiltro.Text = "Quitar filtro";
            this.btnQuitarFiltro.UseVisualStyleBackColor = true;
            this.btnQuitarFiltro.Click += new System.EventHandler(this.btnQuitarFiltro_Click);
            // 
            // dateFin
            // 
            this.dateFin.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFin.Location = new System.Drawing.Point(1105, 310);
            this.dateFin.Name = "dateFin";
            this.dateFin.Size = new System.Drawing.Size(266, 24);
            this.dateFin.TabIndex = 189;
            // 
            // dateInicio
            // 
            this.dateInicio.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateInicio.Location = new System.Drawing.Point(1105, 246);
            this.dateInicio.Name = "dateInicio";
            this.dateInicio.Size = new System.Drawing.Size(266, 24);
            this.dateInicio.TabIndex = 188;
            // 
            // btnAplicarFiltro
            // 
            this.btnAplicarFiltro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAplicarFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicarFiltro.Location = new System.Drawing.Point(1177, 365);
            this.btnAplicarFiltro.Name = "btnAplicarFiltro";
            this.btnAplicarFiltro.Size = new System.Drawing.Size(119, 48);
            this.btnAplicarFiltro.TabIndex = 187;
            this.btnAplicarFiltro.Text = "Aplicar filtro";
            this.btnAplicarFiltro.UseVisualStyleBackColor = true;
            this.btnAplicarFiltro.Click += new System.EventHandler(this.btnAplicarFiltro_Click);
            // 
            // labelHistorialDonaciones
            // 
            this.labelHistorialDonaciones.AutoSize = true;
            this.labelHistorialDonaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHistorialDonaciones.Location = new System.Drawing.Point(157, 708);
            this.labelHistorialDonaciones.Name = "labelHistorialDonaciones";
            this.labelHistorialDonaciones.Size = new System.Drawing.Size(163, 16);
            this.labelHistorialDonaciones.TabIndex = 186;
            this.labelHistorialDonaciones.Text = "LabelHistorialDonaciones";
            // 
            // dataGridViewHistorialDonaciones
            // 
            this.dataGridViewHistorialDonaciones.AllowUserToAddRows = false;
            this.dataGridViewHistorialDonaciones.AllowUserToDeleteRows = false;
            this.dataGridViewHistorialDonaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewHistorialDonaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHistorialDonaciones.Location = new System.Drawing.Point(55, 140);
            this.dataGridViewHistorialDonaciones.Name = "dataGridViewHistorialDonaciones";
            this.dataGridViewHistorialDonaciones.ReadOnly = true;
            this.dataGridViewHistorialDonaciones.Size = new System.Drawing.Size(1020, 550);
            this.dataGridViewHistorialDonaciones.TabIndex = 183;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(88, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 20);
            this.label4.TabIndex = 195;
            this.label4.Text = "Atrás";
            // 
            // pictureBack
            // 
            this.pictureBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBack.Image = ((System.Drawing.Image)(resources.GetObject("pictureBack.Image")));
            this.pictureBack.Location = new System.Drawing.Point(44, 12);
            this.pictureBack.Name = "pictureBack";
            this.pictureBack.Size = new System.Drawing.Size(50, 44);
            this.pictureBack.TabIndex = 194;
            this.pictureBack.TabStop = false;
            this.pictureBack.Click += new System.EventHandler(this.pictureBack_Click);
            // 
            // btnSigDonaciones
            // 
            this.btnSigDonaciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSigDonaciones.Image = ((System.Drawing.Image)(resources.GetObject("btnSigDonaciones.Image")));
            this.btnSigDonaciones.Location = new System.Drawing.Point(101, 696);
            this.btnSigDonaciones.Name = "btnSigDonaciones";
            this.btnSigDonaciones.Size = new System.Drawing.Size(39, 43);
            this.btnSigDonaciones.TabIndex = 197;
            this.btnSigDonaciones.TabStop = false;
            this.btnSigDonaciones.Click += new System.EventHandler(this.btnSigDonaciones_Click);
            // 
            // btnAntDonaciones
            // 
            this.btnAntDonaciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAntDonaciones.Image = ((System.Drawing.Image)(resources.GetObject("btnAntDonaciones.Image")));
            this.btnAntDonaciones.Location = new System.Drawing.Point(56, 696);
            this.btnAntDonaciones.Name = "btnAntDonaciones";
            this.btnAntDonaciones.Size = new System.Drawing.Size(39, 43);
            this.btnAntDonaciones.TabIndex = 196;
            this.btnAntDonaciones.TabStop = false;
            this.btnAntDonaciones.Click += new System.EventHandler(this.btnAntDonaciones_Click);
            // 
            // HistorialDonaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1400, 782);
            this.Controls.Add(this.btnSigDonaciones);
            this.Controls.Add(this.btnAntDonaciones);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBack);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnQuitarFiltro);
            this.Controls.Add(this.dateFin);
            this.Controls.Add(this.dateInicio);
            this.Controls.Add(this.btnAplicarFiltro);
            this.Controls.Add(this.labelHistorialDonaciones);
            this.Controls.Add(this.dataGridViewHistorialDonaciones);
            this.Controls.Add(this.labelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HistorialDonaciones";
            this.Text = "HistorialDonaciones";
            this.Load += new System.EventHandler(this.HistorialDonaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistorialDonaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSigDonaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAntDonaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private RoundedButton btnQuitarFiltro;
        private System.Windows.Forms.DateTimePicker dateFin;
        private System.Windows.Forms.DateTimePicker dateInicio;
        private RoundedButton btnAplicarFiltro;
        private System.Windows.Forms.Label labelHistorialDonaciones;
        private System.Windows.Forms.DataGridView dataGridViewHistorialDonaciones;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBack;
        private System.Windows.Forms.PictureBox btnSigDonaciones;
        private System.Windows.Forms.PictureBox btnAntDonaciones;
    }
}