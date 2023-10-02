namespace biosys
{
    partial class GestionarUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionarUsuario));
            this.labelTitulo = new System.Windows.Forms.Label();
            this.btnOjo = new System.Windows.Forms.PictureBox();
            this.btnOjoCerrado = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comborol = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnAltaUsuario = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridViewUsuarios = new System.Windows.Forms.DataGridView();
            this.btnEliminarUsuario = new System.Windows.Forms.Button();
            this.btnGuardarEdicion = new System.Windows.Forms.Button();
            this.btnLimpiarCampos = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnOjo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOjoCerrado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.Location = new System.Drawing.Point(470, 50);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(570, 55);
            this.labelTitulo.TabIndex = 50;
            this.labelTitulo.Text = "GESTIONAR USUARIOS";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnOjo
            // 
            this.btnOjo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOjo.Image = ((System.Drawing.Image)(resources.GetObject("btnOjo.Image")));
            this.btnOjo.Location = new System.Drawing.Point(592, 229);
            this.btnOjo.Name = "btnOjo";
            this.btnOjo.Size = new System.Drawing.Size(32, 34);
            this.btnOjo.TabIndex = 60;
            this.btnOjo.TabStop = false;
            this.btnOjo.Click += new System.EventHandler(this.btnOjo_Click);
            // 
            // btnOjoCerrado
            // 
            this.btnOjoCerrado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOjoCerrado.Image = ((System.Drawing.Image)(resources.GetObject("btnOjoCerrado.Image")));
            this.btnOjoCerrado.Location = new System.Drawing.Point(592, 229);
            this.btnOjoCerrado.Name = "btnOjoCerrado";
            this.btnOjoCerrado.Size = new System.Drawing.Size(38, 34);
            this.btnOjoCerrado.TabIndex = 59;
            this.btnOjoCerrado.TabStop = false;
            this.btnOjoCerrado.Click += new System.EventHandler(this.btnOjoCerrado_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(331, 383);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 20);
            this.label1.TabIndex = 57;
            this.label1.Text = "SELECCIONE EL ROL";
            // 
            // comborol
            // 
            this.comborol.BackColor = System.Drawing.Color.White;
            this.comborol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comborol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comborol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comborol.ForeColor = System.Drawing.Color.DimGray;
            this.comborol.FormattingEnabled = true;
            this.comborol.Items.AddRange(new object[] {
            "Administrador",
            "Empleado"});
            this.comborol.Location = new System.Drawing.Point(259, 420);
            this.comborol.Name = "comborol";
            this.comborol.Size = new System.Drawing.Size(314, 28);
            this.comborol.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 20);
            this.label2.TabIndex = 61;
            this.label2.Text = "Nombre Usuario:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(46, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 62;
            this.label3.Text = "Contraseña:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(46, 309);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 20);
            this.label4.TabIndex = 63;
            this.label4.Text = "Email:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(167, 481);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(299, 16);
            this.label13.TabIndex = 75;
            this.label13.Text = "Los campos con asteriscos (      ) son obligatorios";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblError.Image = ((System.Drawing.Image)(resources.GetObject("lblError.Image")));
            this.lblError.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblError.Location = new System.Drawing.Point(87, 536);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(122, 18);
            this.lblError.TabIndex = 77;
            this.lblError.Text = "Mensaje de Error";
            this.lblError.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(343, 481);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(15, 20);
            this.label15.TabIndex = 79;
            this.label15.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(95, 309);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 20);
            this.label5.TabIndex = 80;
            this.label5.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(144, 240);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 20);
            this.label6.TabIndex = 81;
            this.label6.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(175, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 20);
            this.label7.TabIndex = 82;
            this.label7.Text = "*";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(250, 176);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(336, 26);
            this.txtUsuario.TabIndex = 83;
            this.txtUsuario.Click += new System.EventHandler(this.txtUsuario_Click);
            this.txtUsuario.TextChanged += new System.EventHandler(this.txtUsuario_TextChanged);
            // 
            // txtContraseña
            // 
            this.txtContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraseña.Location = new System.Drawing.Point(250, 237);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(336, 26);
            this.txtContraseña.TabIndex = 84;
            this.txtContraseña.Enter += new System.EventHandler(this.txtContraseña_Enter);
            this.txtContraseña.Leave += new System.EventHandler(this.txtContraseña_Leave);
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(250, 306);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(336, 26);
            this.txtEmail.TabIndex = 85;
            this.txtEmail.Click += new System.EventHandler(this.txtEmail_Click);
            // 
            // btnAltaUsuario
            // 
            this.btnAltaUsuario.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnAltaUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAltaUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAltaUsuario.Location = new System.Drawing.Point(148, 587);
            this.btnAltaUsuario.Name = "btnAltaUsuario";
            this.btnAltaUsuario.Size = new System.Drawing.Size(342, 48);
            this.btnAltaUsuario.TabIndex = 86;
            this.btnAltaUsuario.Text = "DAR DE ALTA USUARIO";
            this.btnAltaUsuario.UseVisualStyleBackColor = false;
            this.btnAltaUsuario.Click += new System.EventHandler(this.btnAltaUsuario_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(510, 383);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 20);
            this.label8.TabIndex = 87;
            this.label8.Text = "*";
            // 
            // dataGridViewUsuarios
            // 
            this.dataGridViewUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsuarios.Location = new System.Drawing.Point(683, 176);
            this.dataGridViewUsuarios.Name = "dataGridViewUsuarios";
            this.dataGridViewUsuarios.Size = new System.Drawing.Size(545, 321);
            this.dataGridViewUsuarios.TabIndex = 88;
            // 
            // btnEliminarUsuario
            // 
            this.btnEliminarUsuario.BackColor = System.Drawing.Color.Red;
            this.btnEliminarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarUsuario.Location = new System.Drawing.Point(1248, 212);
            this.btnEliminarUsuario.Name = "btnEliminarUsuario";
            this.btnEliminarUsuario.Size = new System.Drawing.Size(127, 48);
            this.btnEliminarUsuario.TabIndex = 106;
            this.btnEliminarUsuario.Text = "ELIMINAR USUARIO";
            this.btnEliminarUsuario.UseVisualStyleBackColor = false;
            this.btnEliminarUsuario.Click += new System.EventHandler(this.btnEliminarUsuario_Click);
            // 
            // btnGuardarEdicion
            // 
            this.btnGuardarEdicion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnGuardarEdicion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarEdicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarEdicion.Location = new System.Drawing.Point(1248, 295);
            this.btnGuardarEdicion.Name = "btnGuardarEdicion";
            this.btnGuardarEdicion.Size = new System.Drawing.Size(127, 48);
            this.btnGuardarEdicion.TabIndex = 107;
            this.btnGuardarEdicion.Text = "GUARDAR EDICIÓN";
            this.btnGuardarEdicion.UseVisualStyleBackColor = false;
            this.btnGuardarEdicion.Click += new System.EventHandler(this.btnGuardarEdicion_Click);
            // 
            // btnLimpiarCampos
            // 
            this.btnLimpiarCampos.BackColor = System.Drawing.Color.White;
            this.btnLimpiarCampos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiarCampos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarCampos.Location = new System.Drawing.Point(1248, 383);
            this.btnLimpiarCampos.Name = "btnLimpiarCampos";
            this.btnLimpiarCampos.Size = new System.Drawing.Size(127, 48);
            this.btnLimpiarCampos.TabIndex = 108;
            this.btnLimpiarCampos.Text = "LIMPIAR CAMPOS";
            this.btnLimpiarCampos.UseVisualStyleBackColor = false;
            this.btnLimpiarCampos.Click += new System.EventHandler(this.btnLimpiarCampos_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(806, 559);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 43);
            this.pictureBox1.TabIndex = 112;
            this.pictureBox1.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(852, 570);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(192, 20);
            this.label10.TabIndex = 111;
            this.label10.Text = "Filtrar por Nombre o Email";
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusqueda.Location = new System.Drawing.Point(785, 608);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(336, 26);
            this.txtBusqueda.TabIndex = 110;
            this.txtBusqueda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);
            // 
            // GestionarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1400, 782);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.btnLimpiarCampos);
            this.Controls.Add(this.btnGuardarEdicion);
            this.Controls.Add(this.btnEliminarUsuario);
            this.Controls.Add(this.dataGridViewUsuarios);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnAltaUsuario);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtContraseña);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOjo);
            this.Controls.Add(this.btnOjoCerrado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comborol);
            this.Controls.Add(this.labelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GestionarUsuario";
            this.Text = "GestionarUsuario";
            this.Load += new System.EventHandler(this.GestionarUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnOjo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOjoCerrado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.PictureBox btnOjo;
        private System.Windows.Forms.PictureBox btnOjoCerrado;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox comborol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnAltaUsuario;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridViewUsuarios;
        private System.Windows.Forms.Button btnEliminarUsuario;
        private System.Windows.Forms.Button btnGuardarEdicion;
        private System.Windows.Forms.Button btnLimpiarCampos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBusqueda;
    }
}