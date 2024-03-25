namespace biosys
{
    partial class Auditoria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Auditoria));
            this.labelTitulo = new System.Windows.Forms.Label();
            this.dgvIniciarCerrarSesion = new System.Windows.Forms.DataGridView();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPaginaSiguiente = new System.Windows.Forms.PictureBox();
            this.btnPaginaAnterior = new System.Windows.Forms.PictureBox();
            this.labelPaginacion = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnPagAntProductos = new System.Windows.Forms.PictureBox();
            this.labelPaginacionProductos = new System.Windows.Forms.Label();
            this.btnInfAuditorias = new biosys.RoundedButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIniciarCerrarSesion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPaginaSiguiente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPaginaAnterior)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPagAntProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.Location = new System.Drawing.Point(590, 26);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(237, 55);
            this.labelTitulo.TabIndex = 51;
            this.labelTitulo.Text = "Auditorías";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dgvIniciarCerrarSesion
            // 
            this.dgvIniciarCerrarSesion.AllowUserToAddRows = false;
            this.dgvIniciarCerrarSesion.AllowUserToDeleteRows = false;
            this.dgvIniciarCerrarSesion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIniciarCerrarSesion.Location = new System.Drawing.Point(157, 189);
            this.dgvIniciarCerrarSesion.Name = "dgvIniciarCerrarSesion";
            this.dgvIniciarCerrarSesion.ReadOnly = true;
            this.dgvIniciarCerrarSesion.Size = new System.Drawing.Size(957, 199);
            this.dgvIniciarCerrarSesion.TabIndex = 52;
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(157, 501);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.Size = new System.Drawing.Size(957, 199);
            this.dgvProductos.TabIndex = 53;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(552, 152);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(197, 24);
            this.label10.TabIndex = 93;
            this.label10.Text = "Inicio/Cierre de sesión";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(599, 463);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 24);
            this.label1.TabIndex = 94;
            this.label1.Text = "Productos";
            // 
            // btnPaginaSiguiente
            // 
            this.btnPaginaSiguiente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPaginaSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("btnPaginaSiguiente.Image")));
            this.btnPaginaSiguiente.Location = new System.Drawing.Point(202, 394);
            this.btnPaginaSiguiente.Name = "btnPaginaSiguiente";
            this.btnPaginaSiguiente.Size = new System.Drawing.Size(39, 43);
            this.btnPaginaSiguiente.TabIndex = 208;
            this.btnPaginaSiguiente.TabStop = false;
            this.btnPaginaSiguiente.Click += new System.EventHandler(this.btnPaginaSiguiente_Click);
            // 
            // btnPaginaAnterior
            // 
            this.btnPaginaAnterior.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPaginaAnterior.Image = ((System.Drawing.Image)(resources.GetObject("btnPaginaAnterior.Image")));
            this.btnPaginaAnterior.Location = new System.Drawing.Point(157, 394);
            this.btnPaginaAnterior.Name = "btnPaginaAnterior";
            this.btnPaginaAnterior.Size = new System.Drawing.Size(39, 43);
            this.btnPaginaAnterior.TabIndex = 207;
            this.btnPaginaAnterior.TabStop = false;
            this.btnPaginaAnterior.Click += new System.EventHandler(this.btnPaginaAnterior_Click);
            // 
            // labelPaginacion
            // 
            this.labelPaginacion.AutoSize = true;
            this.labelPaginacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPaginacion.Location = new System.Drawing.Point(256, 406);
            this.labelPaginacion.Name = "labelPaginacion";
            this.labelPaginacion.Size = new System.Drawing.Size(109, 16);
            this.labelPaginacion.TabIndex = 206;
            this.labelPaginacion.Text = "LabelPaginacion";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(202, 706);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 43);
            this.pictureBox1.TabIndex = 211;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnPagAntProductos
            // 
            this.btnPagAntProductos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPagAntProductos.Image = ((System.Drawing.Image)(resources.GetObject("btnPagAntProductos.Image")));
            this.btnPagAntProductos.Location = new System.Drawing.Point(157, 706);
            this.btnPagAntProductos.Name = "btnPagAntProductos";
            this.btnPagAntProductos.Size = new System.Drawing.Size(39, 43);
            this.btnPagAntProductos.TabIndex = 210;
            this.btnPagAntProductos.TabStop = false;
            this.btnPagAntProductos.Click += new System.EventHandler(this.btnPagAntProductos_Click);
            // 
            // labelPaginacionProductos
            // 
            this.labelPaginacionProductos.AutoSize = true;
            this.labelPaginacionProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPaginacionProductos.Location = new System.Drawing.Point(256, 718);
            this.labelPaginacionProductos.Name = "labelPaginacionProductos";
            this.labelPaginacionProductos.Size = new System.Drawing.Size(170, 16);
            this.labelPaginacionProductos.TabIndex = 209;
            this.labelPaginacionProductos.Text = "LabelPaginacionProductos";
            // 
            // btnInfAuditorias
            // 
            this.btnInfAuditorias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInfAuditorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInfAuditorias.Location = new System.Drawing.Point(1183, 424);
            this.btnInfAuditorias.Name = "btnInfAuditorias";
            this.btnInfAuditorias.Size = new System.Drawing.Size(119, 48);
            this.btnInfAuditorias.TabIndex = 212;
            this.btnInfAuditorias.Text = "Informes auditorías";
            this.btnInfAuditorias.UseVisualStyleBackColor = true;
            this.btnInfAuditorias.Click += new System.EventHandler(this.btnInfAuditorias_Click);
            // 
            // Auditoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1400, 782);
            this.Controls.Add(this.btnInfAuditorias);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnPagAntProductos);
            this.Controls.Add(this.labelPaginacionProductos);
            this.Controls.Add(this.btnPaginaSiguiente);
            this.Controls.Add(this.btnPaginaAnterior);
            this.Controls.Add(this.labelPaginacion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.dgvIniciarCerrarSesion);
            this.Controls.Add(this.labelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Auditoria";
            this.Text = "Auditoria";
            this.Load += new System.EventHandler(this.Auditoria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIniciarCerrarSesion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPaginaSiguiente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPaginaAnterior)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPagAntProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.DataGridView dgvIniciarCerrarSesion;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox btnPaginaSiguiente;
        private System.Windows.Forms.PictureBox btnPaginaAnterior;
        private System.Windows.Forms.Label labelPaginacion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox btnPagAntProductos;
        private System.Windows.Forms.Label labelPaginacionProductos;
        private RoundedButton btnInfAuditorias;
    }
}