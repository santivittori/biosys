﻿namespace biosys
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
            this.label1 = new System.Windows.Forms.Label();
            this.comborol = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridViewUsuarios = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.labelPaginacion = new System.Windows.Forms.Label();
            this.btnAltaUsuario = new biosys.RoundedButton();
            this.btnEliminarUsuario = new biosys.RoundedButton();
            this.btnGuardarEdicion = new biosys.RoundedButton();
            this.btnLimpiarCampos = new biosys.RoundedButton();
            this.btnRolesyPermisos = new biosys.RoundedButton();
            this.btnHabilitarUsuario = new biosys.RoundedButton();
            this.btnPaginaSiguiente = new System.Windows.Forms.PictureBox();
            this.btnPaginaAnterior = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPaginaSiguiente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPaginaAnterior)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.Location = new System.Drawing.Point(450, 50);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(427, 55);
            this.labelTitulo.TabIndex = 50;
            this.labelTitulo.Text = "Gestionar usuarios";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(363, 414);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 18);
            this.label1.TabIndex = 57;
            this.label1.Text = "Seleccione el rol";
            // 
            // comborol
            // 
            this.comborol.BackColor = System.Drawing.Color.White;
            this.comborol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comborol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comborol.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comborol.ForeColor = System.Drawing.Color.DimGray;
            this.comborol.FormattingEnabled = true;
            this.comborol.Location = new System.Drawing.Point(266, 437);
            this.comborol.Name = "comborol";
            this.comborol.Size = new System.Drawing.Size(314, 26);
            this.comborol.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(84, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 18);
            this.label2.TabIndex = 61;
            this.label2.Text = "Nombre usuario:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(84, 341);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 18);
            this.label4.TabIndex = 63;
            this.label4.Text = "Email:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(272, 496);
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
            this.lblError.Location = new System.Drawing.Point(155, 543);
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
            this.label15.Location = new System.Drawing.Point(448, 496);
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
            this.label5.Location = new System.Drawing.Point(133, 341);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 20);
            this.label5.TabIndex = 80;
            this.label5.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(213, 258);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 20);
            this.label7.TabIndex = 82;
            this.label7.Text = "*";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(257, 256);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(336, 24);
            this.txtUsuario.TabIndex = 83;
            this.txtUsuario.TextChanged += new System.EventHandler(this.txtUsuario_TextChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(257, 339);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(336, 24);
            this.txtEmail.TabIndex = 85;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(480, 412);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 20);
            this.label8.TabIndex = 87;
            this.label8.Text = "*";
            // 
            // dataGridViewUsuarios
            // 
            this.dataGridViewUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsuarios.Location = new System.Drawing.Point(710, 254);
            this.dataGridViewUsuarios.Name = "dataGridViewUsuarios";
            this.dataGridViewUsuarios.Size = new System.Drawing.Size(444, 200);
            this.dataGridViewUsuarios.TabIndex = 88;
            this.dataGridViewUsuarios.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewUsuarios_CellFormatting);
            this.dataGridViewUsuarios.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewUsuarios_DataBindingComplete);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(814, 162);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 43);
            this.pictureBox1.TabIndex = 112;
            this.pictureBox1.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(860, 173);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(178, 18);
            this.label10.TabIndex = 111;
            this.label10.Text = "Filtrar por nombre o email";
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusqueda.Location = new System.Drawing.Point(770, 211);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(336, 24);
            this.txtBusqueda.TabIndex = 110;
            this.txtBusqueda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);
            // 
            // labelPaginacion
            // 
            this.labelPaginacion.AutoSize = true;
            this.labelPaginacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPaginacion.Location = new System.Drawing.Point(811, 472);
            this.labelPaginacion.Name = "labelPaginacion";
            this.labelPaginacion.Size = new System.Drawing.Size(109, 16);
            this.labelPaginacion.TabIndex = 147;
            this.labelPaginacion.Text = "LabelPaginacion";
            // 
            // btnAltaUsuario
            // 
            this.btnAltaUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAltaUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAltaUsuario.Location = new System.Drawing.Point(341, 596);
            this.btnAltaUsuario.Name = "btnAltaUsuario";
            this.btnAltaUsuario.Size = new System.Drawing.Size(119, 48);
            this.btnAltaUsuario.TabIndex = 153;
            this.btnAltaUsuario.Text = "Dar de alta usuario";
            this.btnAltaUsuario.UseVisualStyleBackColor = true;
            this.btnAltaUsuario.Click += new System.EventHandler(this.btnAltaUsuario_Click);
            this.btnAltaUsuario.MouseEnter += new System.EventHandler(this.btnAltaUsuario_MouseEnter);
            this.btnAltaUsuario.MouseLeave += new System.EventHandler(this.btnAltaUsuario_MouseLeave);
            // 
            // btnEliminarUsuario
            // 
            this.btnEliminarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarUsuario.Location = new System.Drawing.Point(1192, 426);
            this.btnEliminarUsuario.Name = "btnEliminarUsuario";
            this.btnEliminarUsuario.Size = new System.Drawing.Size(119, 48);
            this.btnEliminarUsuario.TabIndex = 152;
            this.btnEliminarUsuario.Text = "Eliminar";
            this.btnEliminarUsuario.UseVisualStyleBackColor = true;
            this.btnEliminarUsuario.Click += new System.EventHandler(this.btnEliminarUsuario_Click);
            this.btnEliminarUsuario.MouseEnter += new System.EventHandler(this.btnEliminarUsuario_MouseEnter);
            this.btnEliminarUsuario.MouseLeave += new System.EventHandler(this.btnEliminarUsuario_MouseLeave);
            // 
            // btnGuardarEdicion
            // 
            this.btnGuardarEdicion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarEdicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarEdicion.Location = new System.Drawing.Point(1192, 228);
            this.btnGuardarEdicion.Name = "btnGuardarEdicion";
            this.btnGuardarEdicion.Size = new System.Drawing.Size(119, 48);
            this.btnGuardarEdicion.TabIndex = 151;
            this.btnGuardarEdicion.Text = "Guardar edición";
            this.btnGuardarEdicion.UseVisualStyleBackColor = true;
            this.btnGuardarEdicion.Click += new System.EventHandler(this.btnGuardarEdicion_Click);
            this.btnGuardarEdicion.MouseEnter += new System.EventHandler(this.btnGuardarEdicion_MouseEnter);
            this.btnGuardarEdicion.MouseLeave += new System.EventHandler(this.btnGuardarEdicion_MouseLeave);
            // 
            // btnLimpiarCampos
            // 
            this.btnLimpiarCampos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiarCampos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarCampos.Location = new System.Drawing.Point(1192, 294);
            this.btnLimpiarCampos.Name = "btnLimpiarCampos";
            this.btnLimpiarCampos.Size = new System.Drawing.Size(119, 48);
            this.btnLimpiarCampos.TabIndex = 150;
            this.btnLimpiarCampos.Text = "Limpiar campos";
            this.btnLimpiarCampos.UseVisualStyleBackColor = true;
            this.btnLimpiarCampos.Click += new System.EventHandler(this.btnLimpiarCampos_Click);
            // 
            // btnRolesyPermisos
            // 
            this.btnRolesyPermisos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRolesyPermisos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRolesyPermisos.Location = new System.Drawing.Point(1192, 496);
            this.btnRolesyPermisos.Name = "btnRolesyPermisos";
            this.btnRolesyPermisos.Size = new System.Drawing.Size(119, 48);
            this.btnRolesyPermisos.TabIndex = 149;
            this.btnRolesyPermisos.Text = "Gestionar roles y permisos";
            this.btnRolesyPermisos.UseVisualStyleBackColor = true;
            this.btnRolesyPermisos.Click += new System.EventHandler(this.btnRolesyPermisos_Click);
            // 
            // btnHabilitarUsuario
            // 
            this.btnHabilitarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHabilitarUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHabilitarUsuario.Location = new System.Drawing.Point(1192, 361);
            this.btnHabilitarUsuario.Name = "btnHabilitarUsuario";
            this.btnHabilitarUsuario.Size = new System.Drawing.Size(119, 48);
            this.btnHabilitarUsuario.TabIndex = 179;
            this.btnHabilitarUsuario.Text = "Habilitar o deshabilitar";
            this.btnHabilitarUsuario.UseVisualStyleBackColor = true;
            this.btnHabilitarUsuario.Click += new System.EventHandler(this.btnHabilitarUsuario_Click);
            this.btnHabilitarUsuario.MouseEnter += new System.EventHandler(this.btnHabilitarUsuario_MouseEnter);
            this.btnHabilitarUsuario.MouseLeave += new System.EventHandler(this.btnHabilitarUsuario_MouseLeave);
            // 
            // btnPaginaSiguiente
            // 
            this.btnPaginaSiguiente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPaginaSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("btnPaginaSiguiente.Image")));
            this.btnPaginaSiguiente.Location = new System.Drawing.Point(756, 460);
            this.btnPaginaSiguiente.Name = "btnPaginaSiguiente";
            this.btnPaginaSiguiente.Size = new System.Drawing.Size(39, 43);
            this.btnPaginaSiguiente.TabIndex = 181;
            this.btnPaginaSiguiente.TabStop = false;
            this.btnPaginaSiguiente.Click += new System.EventHandler(this.btnPaginaSiguiente_Click);
            // 
            // btnPaginaAnterior
            // 
            this.btnPaginaAnterior.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPaginaAnterior.Image = ((System.Drawing.Image)(resources.GetObject("btnPaginaAnterior.Image")));
            this.btnPaginaAnterior.Location = new System.Drawing.Point(711, 460);
            this.btnPaginaAnterior.Name = "btnPaginaAnterior";
            this.btnPaginaAnterior.Size = new System.Drawing.Size(39, 43);
            this.btnPaginaAnterior.TabIndex = 180;
            this.btnPaginaAnterior.TabStop = false;
            this.btnPaginaAnterior.Click += new System.EventHandler(this.btnPaginaAnterior_Click);
            // 
            // GestionarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1400, 782);
            this.Controls.Add(this.btnPaginaSiguiente);
            this.Controls.Add(this.btnPaginaAnterior);
            this.Controls.Add(this.btnHabilitarUsuario);
            this.Controls.Add(this.btnAltaUsuario);
            this.Controls.Add(this.btnEliminarUsuario);
            this.Controls.Add(this.btnGuardarEdicion);
            this.Controls.Add(this.btnLimpiarCampos);
            this.Controls.Add(this.btnRolesyPermisos);
            this.Controls.Add(this.labelPaginacion);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.dataGridViewUsuarios);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comborol);
            this.Controls.Add(this.labelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GestionarUsuario";
            this.Text = "GestionarUsuario";
            this.Load += new System.EventHandler(this.GestionarUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPaginaSiguiente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPaginaAnterior)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox comborol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridViewUsuarios;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Label labelPaginacion;
        private RoundedButton btnRolesyPermisos;
        private RoundedButton btnLimpiarCampos;
        private RoundedButton btnGuardarEdicion;
        private RoundedButton btnEliminarUsuario;
        private RoundedButton btnAltaUsuario;
        private RoundedButton btnHabilitarUsuario;
        private System.Windows.Forms.PictureBox btnPaginaSiguiente;
        private System.Windows.Forms.PictureBox btnPaginaAnterior;
    }
}