﻿namespace biosys
{
    partial class Donaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Donaciones));
            this.labelTitulo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDonante = new System.Windows.Forms.TextBox();
            this.comboProductos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fechaDonacion = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericCantidad = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.listDetalleDonacion = new System.Windows.Forms.ListBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.comboUnidadMedida = new System.Windows.Forms.ComboBox();
            this.labelkilogramo = new System.Windows.Forms.Label();
            this.labelgramo = new System.Windows.Forms.Label();
            this.btnHistorialDonaciones = new biosys.RoundedButton();
            this.btnRegistrarDonacion = new biosys.RoundedButton();
            this.btnGuardarDetalle = new biosys.RoundedButton();
            this.btnLimpiar = new biosys.RoundedButton();
            this.btnCancelar = new biosys.RoundedButton();
            ((System.ComponentModel.ISupportInitialize)(this.numericCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.Location = new System.Drawing.Point(550, 50);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(279, 55);
            this.labelTitulo.TabIndex = 50;
            this.labelTitulo.Text = "Donaciones";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(202, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 20);
            this.label6.TabIndex = 62;
            this.label6.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(84, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 18);
            this.label1.TabIndex = 61;
            this.label1.Text = "Entidad donante:";
            // 
            // txtDonante
            // 
            this.txtDonante.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDonante.Location = new System.Drawing.Point(293, 199);
            this.txtDonante.Name = "txtDonante";
            this.txtDonante.Size = new System.Drawing.Size(336, 24);
            this.txtDonante.TabIndex = 63;
            this.txtDonante.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDonante_KeyPress);
            // 
            // comboProductos
            // 
            this.comboProductos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboProductos.FormattingEnabled = true;
            this.comboProductos.Location = new System.Drawing.Point(293, 265);
            this.comboProductos.Name = "comboProductos";
            this.comboProductos.Size = new System.Drawing.Size(336, 26);
            this.comboProductos.TabIndex = 64;
            this.comboProductos.SelectedIndexChanged += new System.EventHandler(this.comboProductos_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(155, 265);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 20);
            this.label2.TabIndex = 66;
            this.label2.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(84, 268);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 18);
            this.label3.TabIndex = 65;
            this.label3.Text = "Producto:";
            // 
            // fechaDonacion
            // 
            this.fechaDonacion.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaDonacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaDonacion.Location = new System.Drawing.Point(293, 328);
            this.fechaDonacion.Name = "fechaDonacion";
            this.fechaDonacion.Size = new System.Drawing.Size(336, 24);
            this.fechaDonacion.TabIndex = 73;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(84, 333);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 18);
            this.label4.TabIndex = 74;
            this.label4.Text = "Fecha:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(136, 333);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 20);
            this.label5.TabIndex = 75;
            this.label5.Text = "*";
            // 
            // numericCantidad
            // 
            this.numericCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericCantidad.Location = new System.Drawing.Point(419, 441);
            this.numericCantidad.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericCantidad.Name = "numericCantidad";
            this.numericCantidad.Size = new System.Drawing.Size(90, 24);
            this.numericCantidad.TabIndex = 76;
            this.numericCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(88, 443);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 18);
            this.label7.TabIndex = 77;
            this.label7.Text = "Cantidad:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(158, 443);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 20);
            this.label8.TabIndex = 78;
            this.label8.Text = "*";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(305, 479);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(299, 16);
            this.label13.TabIndex = 79;
            this.label13.Text = "Los campos con asteriscos (      ) son obligatorios";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(481, 476);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 20);
            this.label9.TabIndex = 80;
            this.label9.Text = "*";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblError.Image = ((System.Drawing.Image)(resources.GetObject("lblError.Image")));
            this.lblError.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblError.Location = new System.Drawing.Point(163, 521);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(122, 18);
            this.lblError.TabIndex = 81;
            this.lblError.Text = "Mensaje de Error";
            this.lblError.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(979, 156);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(178, 24);
            this.label10.TabIndex = 86;
            this.label10.Text = "Detalle de donación";
            // 
            // listDetalleDonacion
            // 
            this.listDetalleDonacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listDetalleDonacion.FormattingEnabled = true;
            this.listDetalleDonacion.ItemHeight = 18;
            this.listDetalleDonacion.Location = new System.Drawing.Point(759, 198);
            this.listDetalleDonacion.Name = "listDetalleDonacion";
            this.listDetalleDonacion.Size = new System.Drawing.Size(610, 310);
            this.listDetalleDonacion.TabIndex = 85;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(213, 389);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(15, 20);
            this.label17.TabIndex = 152;
            this.label17.Text = "*";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(84, 391);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(130, 18);
            this.label16.TabIndex = 151;
            this.label16.Text = "Unidad de medida:";
            // 
            // comboUnidadMedida
            // 
            this.comboUnidadMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboUnidadMedida.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboUnidadMedida.FormattingEnabled = true;
            this.comboUnidadMedida.Location = new System.Drawing.Point(293, 387);
            this.comboUnidadMedida.Name = "comboUnidadMedida";
            this.comboUnidadMedida.Size = new System.Drawing.Size(336, 26);
            this.comboUnidadMedida.TabIndex = 150;
            this.comboUnidadMedida.SelectedIndexChanged += new System.EventHandler(this.comboUnidadMedida_SelectedIndexChanged);
            // 
            // labelkilogramo
            // 
            this.labelkilogramo.AutoSize = true;
            this.labelkilogramo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelkilogramo.Location = new System.Drawing.Point(515, 444);
            this.labelkilogramo.Name = "labelkilogramo";
            this.labelkilogramo.Size = new System.Drawing.Size(24, 18);
            this.labelkilogramo.TabIndex = 153;
            this.labelkilogramo.Text = "kg";
            // 
            // labelgramo
            // 
            this.labelgramo.AutoSize = true;
            this.labelgramo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelgramo.Location = new System.Drawing.Point(518, 444);
            this.labelgramo.Name = "labelgramo";
            this.labelgramo.Size = new System.Drawing.Size(21, 18);
            this.labelgramo.TabIndex = 154;
            this.labelgramo.Text = "gr";
            // 
            // btnHistorialDonaciones
            // 
            this.btnHistorialDonaciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistorialDonaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistorialDonaciones.Location = new System.Drawing.Point(1005, 532);
            this.btnHistorialDonaciones.Name = "btnHistorialDonaciones";
            this.btnHistorialDonaciones.Size = new System.Drawing.Size(119, 48);
            this.btnHistorialDonaciones.TabIndex = 147;
            this.btnHistorialDonaciones.Text = "Historial de donaciones";
            this.btnHistorialDonaciones.UseVisualStyleBackColor = true;
            this.btnHistorialDonaciones.Click += new System.EventHandler(this.btnHistorialDonaciones_Click);
            // 
            // btnRegistrarDonacion
            // 
            this.btnRegistrarDonacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarDonacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarDonacion.Location = new System.Drawing.Point(582, 606);
            this.btnRegistrarDonacion.Name = "btnRegistrarDonacion";
            this.btnRegistrarDonacion.Size = new System.Drawing.Size(119, 48);
            this.btnRegistrarDonacion.TabIndex = 144;
            this.btnRegistrarDonacion.Text = "Registrar donación";
            this.btnRegistrarDonacion.UseVisualStyleBackColor = true;
            this.btnRegistrarDonacion.Click += new System.EventHandler(this.btnRegistrarDonacion_Click);
            this.btnRegistrarDonacion.MouseEnter += new System.EventHandler(this.btnRegistrarDonacion_MouseEnter);
            this.btnRegistrarDonacion.MouseLeave += new System.EventHandler(this.btnRegistrarDonacion_MouseLeave);
            // 
            // btnGuardarDetalle
            // 
            this.btnGuardarDetalle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarDetalle.Location = new System.Drawing.Point(417, 606);
            this.btnGuardarDetalle.Name = "btnGuardarDetalle";
            this.btnGuardarDetalle.Size = new System.Drawing.Size(119, 48);
            this.btnGuardarDetalle.TabIndex = 143;
            this.btnGuardarDetalle.Text = "Guardar detalle";
            this.btnGuardarDetalle.UseVisualStyleBackColor = true;
            this.btnGuardarDetalle.Click += new System.EventHandler(this.btnGuardarDetalle_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(252, 606);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(119, 48);
            this.btnLimpiar.TabIndex = 142;
            this.btnLimpiar.Text = "Limpiar campos";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(87, 606);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(119, 48);
            this.btnCancelar.TabIndex = 141;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            this.btnCancelar.MouseEnter += new System.EventHandler(this.btnCancelar_MouseEnter);
            this.btnCancelar.MouseLeave += new System.EventHandler(this.btnCancelar_MouseLeave);
            // 
            // Donaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1400, 782);
            this.Controls.Add(this.labelgramo);
            this.Controls.Add(this.labelkilogramo);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.comboUnidadMedida);
            this.Controls.Add(this.btnHistorialDonaciones);
            this.Controls.Add(this.btnRegistrarDonacion);
            this.Controls.Add(this.btnGuardarDetalle);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.listDetalleDonacion);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numericCantidad);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fechaDonacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboProductos);
            this.Controls.Add(this.txtDonante);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Donaciones";
            this.Text = "Donaciones";
            this.Load += new System.EventHandler(this.Donaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericCantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDonante;
        private System.Windows.Forms.ComboBox comboProductos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker fechaDonacion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericCantidad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox listDetalleDonacion;
        private RoundedButton btnCancelar;
        private RoundedButton btnLimpiar;
        private RoundedButton btnGuardarDetalle;
        private RoundedButton btnRegistrarDonacion;
        private RoundedButton btnHistorialDonaciones;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox comboUnidadMedida;
        private System.Windows.Forms.Label labelkilogramo;
        private System.Windows.Forms.Label labelgramo;
    }
}