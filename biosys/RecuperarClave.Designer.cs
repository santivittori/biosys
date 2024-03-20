namespace biosys
{
    partial class RecuperarClave
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecuperarClave));
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.btnMinimizar = new System.Windows.Forms.PictureBox();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.txtCodVerificacion = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.btnGuardarClave = new System.Windows.Forms.Button();
            this.btnVerificarCod = new System.Windows.Forms.Button();
            this.btnVerificarEmail = new System.Windows.Forms.Button();
            this.btnOjo = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtContraseñaNueva = new System.Windows.Forms.TextBox();
            this.btnOjoCerrado = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOjo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOjoCerrado)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(757, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(20, 20);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 10;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimizar.Image")));
            this.btnMinimizar.Location = new System.Drawing.Point(731, 0);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(20, 20);
            this.btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimizar.TabIndex = 9;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.ForeColor = System.Drawing.Color.DimGray;
            this.labelTitulo.Location = new System.Drawing.Point(260, 10);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(268, 31);
            this.labelTitulo.TabIndex = 0;
            this.labelTitulo.Text = "Olvidé mi contraseña";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.DimGray;
            this.txtEmail.Location = new System.Drawing.Point(213, 98);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(370, 19);
            this.txtEmail.TabIndex = 23;
            this.txtEmail.Text = "Email";
            this.txtEmail.Enter += new System.EventHandler(this.txtEmail_Enter);
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(173, 123);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(440, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(173, 202);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(440, 30);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 25;
            this.pictureBox3.TabStop = false;
            // 
            // txtCodVerificacion
            // 
            this.txtCodVerificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtCodVerificacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCodVerificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodVerificacion.ForeColor = System.Drawing.Color.DimGray;
            this.txtCodVerificacion.Location = new System.Drawing.Point(213, 176);
            this.txtCodVerificacion.Name = "txtCodVerificacion";
            this.txtCodVerificacion.Size = new System.Drawing.Size(370, 19);
            this.txtCodVerificacion.TabIndex = 24;
            this.txtCodVerificacion.Text = "Código de verificación";
            this.txtCodVerificacion.Enter += new System.EventHandler(this.txtCodVerificacion_Enter);
            this.txtCodVerificacion.Leave += new System.EventHandler(this.txtCodVerificacion_Leave);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.DimGray;
            this.lblError.Image = ((System.Drawing.Image)(resources.GetObject("lblError.Image")));
            this.lblError.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblError.Location = new System.Drawing.Point(170, 340);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(109, 16);
            this.lblError.TabIndex = 26;
            this.lblError.Text = "Mensaje de error";
            this.lblError.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblError.Visible = false;
            // 
            // btnGuardarClave
            // 
            this.btnGuardarClave.BackColor = System.Drawing.Color.Teal;
            this.btnGuardarClave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarClave.FlatAppearance.BorderSize = 0;
            this.btnGuardarClave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btnGuardarClave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.btnGuardarClave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarClave.ForeColor = System.Drawing.Color.LightGray;
            this.btnGuardarClave.Location = new System.Drawing.Point(213, 387);
            this.btnGuardarClave.Name = "btnGuardarClave";
            this.btnGuardarClave.Size = new System.Drawing.Size(370, 40);
            this.btnGuardarClave.TabIndex = 29;
            this.btnGuardarClave.Text = "Guardar contraseña";
            this.btnGuardarClave.UseVisualStyleBackColor = false;
            this.btnGuardarClave.Click += new System.EventHandler(this.btnGuardarClave_Click);
            // 
            // btnVerificarCod
            // 
            this.btnVerificarCod.BackColor = System.Drawing.Color.Teal;
            this.btnVerificarCod.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerificarCod.FlatAppearance.BorderSize = 0;
            this.btnVerificarCod.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btnVerificarCod.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.btnVerificarCod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerificarCod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerificarCod.ForeColor = System.Drawing.Color.LightGray;
            this.btnVerificarCod.Location = new System.Drawing.Point(645, 176);
            this.btnVerificarCod.Name = "btnVerificarCod";
            this.btnVerificarCod.Size = new System.Drawing.Size(108, 30);
            this.btnVerificarCod.TabIndex = 28;
            this.btnVerificarCod.Text = "Verificar";
            this.btnVerificarCod.UseVisualStyleBackColor = false;
            this.btnVerificarCod.Click += new System.EventHandler(this.btnVerificarCod_Click);
            // 
            // btnVerificarEmail
            // 
            this.btnVerificarEmail.BackColor = System.Drawing.Color.Teal;
            this.btnVerificarEmail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerificarEmail.FlatAppearance.BorderSize = 0;
            this.btnVerificarEmail.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btnVerificarEmail.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.btnVerificarEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerificarEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerificarEmail.ForeColor = System.Drawing.Color.LightGray;
            this.btnVerificarEmail.Location = new System.Drawing.Point(645, 98);
            this.btnVerificarEmail.Name = "btnVerificarEmail";
            this.btnVerificarEmail.Size = new System.Drawing.Size(108, 30);
            this.btnVerificarEmail.TabIndex = 1;
            this.btnVerificarEmail.Text = "Verificar";
            this.btnVerificarEmail.UseVisualStyleBackColor = false;
            this.btnVerificarEmail.Click += new System.EventHandler(this.btnVerificarEmail_Click);
            // 
            // btnOjo
            // 
            this.btnOjo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOjo.Image = ((System.Drawing.Image)(resources.GetObject("btnOjo.Image")));
            this.btnOjo.Location = new System.Drawing.Point(589, 252);
            this.btnOjo.Name = "btnOjo";
            this.btnOjo.Size = new System.Drawing.Size(32, 34);
            this.btnOjo.TabIndex = 32;
            this.btnOjo.TabStop = false;
            this.btnOjo.Click += new System.EventHandler(this.btnOjo_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(173, 285);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(440, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 31;
            this.pictureBox2.TabStop = false;
            // 
            // txtContraseñaNueva
            // 
            this.txtContraseñaNueva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtContraseñaNueva.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContraseñaNueva.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraseñaNueva.ForeColor = System.Drawing.Color.DimGray;
            this.txtContraseñaNueva.Location = new System.Drawing.Point(213, 260);
            this.txtContraseñaNueva.Name = "txtContraseñaNueva";
            this.txtContraseñaNueva.Size = new System.Drawing.Size(370, 19);
            this.txtContraseñaNueva.TabIndex = 30;
            this.txtContraseñaNueva.Text = "Contraseña nueva";
            this.txtContraseñaNueva.Enter += new System.EventHandler(this.txtContraseñaNueva_Enter);
            this.txtContraseñaNueva.Leave += new System.EventHandler(this.txtContraseñaNueva_Leave);
            // 
            // btnOjoCerrado
            // 
            this.btnOjoCerrado.Image = ((System.Drawing.Image)(resources.GetObject("btnOjoCerrado.Image")));
            this.btnOjoCerrado.Location = new System.Drawing.Point(589, 252);
            this.btnOjoCerrado.Name = "btnOjoCerrado";
            this.btnOjoCerrado.Size = new System.Drawing.Size(38, 34);
            this.btnOjoCerrado.TabIndex = 33;
            this.btnOjoCerrado.TabStop = false;
            this.btnOjoCerrado.Click += new System.EventHandler(this.btnOjoCerrado_Click);
            // 
            // RecuperarClave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(780, 500);
            this.Controls.Add(this.btnOjoCerrado);
            this.Controls.Add(this.btnOjo);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txtContraseñaNueva);
            this.Controls.Add(this.btnVerificarEmail);
            this.Controls.Add(this.btnVerificarCod);
            this.Controls.Add(this.btnGuardarClave);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.txtCodVerificacion);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnMinimizar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RecuperarClave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RecuperarClave";
            this.Load += new System.EventHandler(this.RecuperarClave_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RecuperarClave_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOjo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOjoCerrado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.PictureBox btnMinimizar;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox txtCodVerificacion;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnGuardarClave;
        private System.Windows.Forms.Button btnVerificarCod;
        private System.Windows.Forms.Button btnVerificarEmail;
        private System.Windows.Forms.PictureBox btnOjo;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtContraseñaNueva;
        private System.Windows.Forms.PictureBox btnOjoCerrado;
    }
}