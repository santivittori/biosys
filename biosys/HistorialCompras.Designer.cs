namespace biosys
{
    partial class HistorialCompras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistorialCompras));
            this.labelTitulo = new System.Windows.Forms.Label();
            this.dataGridViewHistorialCompras = new System.Windows.Forms.DataGridView();
            this.labelHistorialCompras = new System.Windows.Forms.Label();
            this.btnSigCompras = new System.Windows.Forms.Button();
            this.btnAntCompras = new System.Windows.Forms.Button();
            this.btnAplicarFiltro = new biosys.RoundedButton();
            this.dateInicio = new System.Windows.Forms.DateTimePicker();
            this.dateFin = new System.Windows.Forms.DateTimePicker();
            this.btnQuitarFiltro = new biosys.RoundedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBack = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistorialCompras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBack)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.Location = new System.Drawing.Point(388, 49);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(613, 55);
            this.labelTitulo.TabIndex = 50;
            this.labelTitulo.Text = "HISTORIAL DE COMPRAS";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dataGridViewHistorialCompras
            // 
            this.dataGridViewHistorialCompras.AllowUserToAddRows = false;
            this.dataGridViewHistorialCompras.AllowUserToDeleteRows = false;
            this.dataGridViewHistorialCompras.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewHistorialCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHistorialCompras.Location = new System.Drawing.Point(55, 140);
            this.dataGridViewHistorialCompras.Name = "dataGridViewHistorialCompras";
            this.dataGridViewHistorialCompras.ReadOnly = true;
            this.dataGridViewHistorialCompras.Size = new System.Drawing.Size(1020, 550);
            this.dataGridViewHistorialCompras.TabIndex = 51;
            // 
            // labelHistorialCompras
            // 
            this.labelHistorialCompras.AutoSize = true;
            this.labelHistorialCompras.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHistorialCompras.Location = new System.Drawing.Point(161, 715);
            this.labelHistorialCompras.Name = "labelHistorialCompras";
            this.labelHistorialCompras.Size = new System.Drawing.Size(145, 16);
            this.labelHistorialCompras.TabIndex = 175;
            this.labelHistorialCompras.Text = "LabelHistorialCompras";
            // 
            // btnSigCompras
            // 
            this.btnSigCompras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSigCompras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSigCompras.Location = new System.Drawing.Point(101, 707);
            this.btnSigCompras.Name = "btnSigCompras";
            this.btnSigCompras.Size = new System.Drawing.Size(40, 30);
            this.btnSigCompras.TabIndex = 174;
            this.btnSigCompras.Text = ">";
            this.btnSigCompras.UseVisualStyleBackColor = true;
            this.btnSigCompras.Click += new System.EventHandler(this.btnSigCompras_Click);
            // 
            // btnAntCompras
            // 
            this.btnAntCompras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAntCompras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAntCompras.Location = new System.Drawing.Point(54, 707);
            this.btnAntCompras.Name = "btnAntCompras";
            this.btnAntCompras.Size = new System.Drawing.Size(40, 30);
            this.btnAntCompras.TabIndex = 173;
            this.btnAntCompras.Text = "<";
            this.btnAntCompras.UseVisualStyleBackColor = true;
            this.btnAntCompras.Click += new System.EventHandler(this.btnAntCompras_Click);
            // 
            // btnAplicarFiltro
            // 
            this.btnAplicarFiltro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAplicarFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicarFiltro.Location = new System.Drawing.Point(1177, 365);
            this.btnAplicarFiltro.Name = "btnAplicarFiltro";
            this.btnAplicarFiltro.Size = new System.Drawing.Size(119, 48);
            this.btnAplicarFiltro.TabIndex = 176;
            this.btnAplicarFiltro.Text = "APLICAR FILTRO";
            this.btnAplicarFiltro.UseVisualStyleBackColor = true;
            this.btnAplicarFiltro.Click += new System.EventHandler(this.btnAplicarFiltro_Click);
            // 
            // dateInicio
            // 
            this.dateInicio.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateInicio.Location = new System.Drawing.Point(1105, 246);
            this.dateInicio.Name = "dateInicio";
            this.dateInicio.Size = new System.Drawing.Size(266, 24);
            this.dateInicio.TabIndex = 177;
            // 
            // dateFin
            // 
            this.dateFin.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFin.Location = new System.Drawing.Point(1105, 310);
            this.dateFin.Name = "dateFin";
            this.dateFin.Size = new System.Drawing.Size(266, 24);
            this.dateFin.TabIndex = 178;
            // 
            // btnQuitarFiltro
            // 
            this.btnQuitarFiltro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitarFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarFiltro.Location = new System.Drawing.Point(1177, 452);
            this.btnQuitarFiltro.Name = "btnQuitarFiltro";
            this.btnQuitarFiltro.Size = new System.Drawing.Size(119, 48);
            this.btnQuitarFiltro.TabIndex = 179;
            this.btnQuitarFiltro.Text = "QUITAR FILTRO";
            this.btnQuitarFiltro.UseVisualStyleBackColor = true;
            this.btnQuitarFiltro.Click += new System.EventHandler(this.btnQuitarFiltro_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1144, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 18);
            this.label1.TabIndex = 180;
            this.label1.Text = "Filtro por rango de fechas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1210, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 18);
            this.label2.TabIndex = 181;
            this.label2.Text = "Desde";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1213, 289);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 18);
            this.label3.TabIndex = 182;
            this.label3.Text = "Hasta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(88, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 184;
            this.label4.Text = "Back";
            // 
            // pictureBack
            // 
            this.pictureBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBack.Image = ((System.Drawing.Image)(resources.GetObject("pictureBack.Image")));
            this.pictureBack.Location = new System.Drawing.Point(44, 12);
            this.pictureBack.Name = "pictureBack";
            this.pictureBack.Size = new System.Drawing.Size(50, 44);
            this.pictureBack.TabIndex = 183;
            this.pictureBack.TabStop = false;
            this.pictureBack.Click += new System.EventHandler(this.pictureBack_Click);
            // 
            // HistorialCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1400, 782);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBack);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnQuitarFiltro);
            this.Controls.Add(this.dateFin);
            this.Controls.Add(this.dateInicio);
            this.Controls.Add(this.btnAplicarFiltro);
            this.Controls.Add(this.labelHistorialCompras);
            this.Controls.Add(this.btnSigCompras);
            this.Controls.Add(this.btnAntCompras);
            this.Controls.Add(this.dataGridViewHistorialCompras);
            this.Controls.Add(this.labelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HistorialCompras";
            this.Text = "HistorialCompras";
            this.Load += new System.EventHandler(this.HistorialCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistorialCompras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.DataGridView dataGridViewHistorialCompras;
        private System.Windows.Forms.Label labelHistorialCompras;
        private System.Windows.Forms.Button btnSigCompras;
        private System.Windows.Forms.Button btnAntCompras;
        private System.Windows.Forms.DateTimePicker fechaInicioFiltro;
        private RoundedButton btnAplicarFiltro;
        private System.Windows.Forms.DateTimePicker dateInicio;
        private System.Windows.Forms.DateTimePicker dateFin;
        private RoundedButton btnQuitarFiltro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBack;
    }
}