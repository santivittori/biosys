namespace biosys
{
    partial class Productos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Productos));
            this.labelTitulo = new System.Windows.Forms.Label();
            this.txtNombreProd = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewProductos = new System.Windows.Forms.DataGridView();
            this.comboTipoEspecifico = new System.Windows.Forms.ComboBox();
            this.comboTipoProducto = new System.Windows.Forms.ComboBox();
            this.lblError = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxOrdenar = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.labelPaginacion = new System.Windows.Forms.Label();
            this.btnPaginaSiguiente = new System.Windows.Forms.Button();
            this.btnPaginaAnterior = new System.Windows.Forms.Button();
            this.btnQuitarFiltros = new biosys.RoundedButton();
            this.btnEliminarProd = new biosys.RoundedButton();
            this.btnCancelar = new biosys.RoundedButton();
            this.btnLimpiar = new biosys.RoundedButton();
            this.btnGuardarProd = new biosys.RoundedButton();
            this.btnCargarExcel = new biosys.RoundedButton();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTamSemilla = new System.Windows.Forms.Label();
            this.comboTamSemilla = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.Location = new System.Drawing.Point(540, 50);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(331, 55);
            this.labelTitulo.TabIndex = 51;
            this.labelTitulo.Text = "PRODUCTOS";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtNombreProd
            // 
            this.txtNombreProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreProd.Location = new System.Drawing.Point(550, 183);
            this.txtNombreProd.Name = "txtNombreProd";
            this.txtNombreProd.Size = new System.Drawing.Size(336, 24);
            this.txtNombreProd.TabIndex = 95;
            this.txtNombreProd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreProd_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(738, 419);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 20);
            this.label9.TabIndex = 94;
            this.label9.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(481, 283);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 20);
            this.label7.TabIndex = 92;
            this.label7.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(482, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 20);
            this.label6.TabIndex = 90;
            this.label6.Text = "*";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(562, 419);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(299, 16);
            this.label13.TabIndex = 89;
            this.label13.Text = "Los campos con asteriscos (      ) son obligatorios";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(432, 286);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 18);
            this.label3.TabIndex = 87;
            this.label3.Text = "Tipos:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(415, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 18);
            this.label1.TabIndex = 85;
            this.label1.Text = "Nombre:";
            // 
            // dataGridViewProductos
            // 
            this.dataGridViewProductos.AllowUserToAddRows = false;
            this.dataGridViewProductos.AllowUserToDeleteRows = false;
            this.dataGridViewProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProductos.Location = new System.Drawing.Point(438, 510);
            this.dataGridViewProductos.Name = "dataGridViewProductos";
            this.dataGridViewProductos.ReadOnly = true;
            this.dataGridViewProductos.Size = new System.Drawing.Size(623, 211);
            this.dataGridViewProductos.TabIndex = 102;
            this.dataGridViewProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProductos_CellClick);
            // 
            // comboTipoEspecifico
            // 
            this.comboTipoEspecifico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTipoEspecifico.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboTipoEspecifico.FormattingEnabled = true;
            this.comboTipoEspecifico.Location = new System.Drawing.Point(550, 320);
            this.comboTipoEspecifico.Name = "comboTipoEspecifico";
            this.comboTipoEspecifico.Size = new System.Drawing.Size(336, 26);
            this.comboTipoEspecifico.TabIndex = 100;
            // 
            // comboTipoProducto
            // 
            this.comboTipoProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTipoProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboTipoProducto.FormattingEnabled = true;
            this.comboTipoProducto.Location = new System.Drawing.Point(550, 259);
            this.comboTipoProducto.Name = "comboTipoProducto";
            this.comboTipoProducto.Size = new System.Drawing.Size(336, 26);
            this.comboTipoProducto.TabIndex = 101;
            this.comboTipoProducto.SelectedIndexChanged += new System.EventHandler(this.comboTipoProducto_SelectedIndexChanged);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblError.Image = ((System.Drawing.Image)(resources.GetObject("lblError.Image")));
            this.lblError.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblError.Location = new System.Drawing.Point(503, 465);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(122, 18);
            this.lblError.TabIndex = 103;
            this.lblError.Text = "Mensaje de Error";
            this.lblError.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(34, 567);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 37);
            this.pictureBox2.TabIndex = 119;
            this.pictureBox2.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(80, 573);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 18);
            this.label11.TabIndex = 118;
            this.label11.Text = "Ordenar por";
            // 
            // comboBoxOrdenar
            // 
            this.comboBoxOrdenar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOrdenar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxOrdenar.FormattingEnabled = true;
            this.comboBoxOrdenar.Location = new System.Drawing.Point(34, 610);
            this.comboBoxOrdenar.Name = "comboBoxOrdenar";
            this.comboBoxOrdenar.Size = new System.Drawing.Size(336, 26);
            this.comboBoxOrdenar.TabIndex = 117;
            this.comboBoxOrdenar.SelectedIndexChanged += new System.EventHandler(this.comboBoxOrdenar_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(34, 475);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 43);
            this.pictureBox1.TabIndex = 116;
            this.pictureBox1.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(80, 487);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(342, 18);
            this.label10.TabIndex = 115;
            this.label10.Text = "Filtrar por Nombre, TipoProducto o TipoEspecifico";
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusqueda.Location = new System.Drawing.Point(34, 524);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(336, 24);
            this.txtBusqueda.TabIndex = 114;
            this.txtBusqueda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);
            this.txtBusqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBusqueda_KeyPress);
            // 
            // labelPaginacion
            // 
            this.labelPaginacion.AutoSize = true;
            this.labelPaginacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPaginacion.Location = new System.Drawing.Point(555, 735);
            this.labelPaginacion.Name = "labelPaginacion";
            this.labelPaginacion.Size = new System.Drawing.Size(109, 16);
            this.labelPaginacion.TabIndex = 147;
            this.labelPaginacion.Text = "LabelPaginacion";
            // 
            // btnPaginaSiguiente
            // 
            this.btnPaginaSiguiente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPaginaSiguiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaginaSiguiente.Location = new System.Drawing.Point(483, 727);
            this.btnPaginaSiguiente.Name = "btnPaginaSiguiente";
            this.btnPaginaSiguiente.Size = new System.Drawing.Size(40, 30);
            this.btnPaginaSiguiente.TabIndex = 146;
            this.btnPaginaSiguiente.Text = ">";
            this.btnPaginaSiguiente.UseVisualStyleBackColor = true;
            this.btnPaginaSiguiente.Click += new System.EventHandler(this.btnPaginaSiguiente_Click);
            // 
            // btnPaginaAnterior
            // 
            this.btnPaginaAnterior.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPaginaAnterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaginaAnterior.Location = new System.Drawing.Point(437, 727);
            this.btnPaginaAnterior.Name = "btnPaginaAnterior";
            this.btnPaginaAnterior.Size = new System.Drawing.Size(40, 30);
            this.btnPaginaAnterior.TabIndex = 145;
            this.btnPaginaAnterior.Text = "<";
            this.btnPaginaAnterior.UseVisualStyleBackColor = true;
            this.btnPaginaAnterior.Click += new System.EventHandler(this.btnPaginaAnterior_Click);
            // 
            // btnQuitarFiltros
            // 
            this.btnQuitarFiltros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitarFiltros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarFiltros.Location = new System.Drawing.Point(127, 683);
            this.btnQuitarFiltros.Name = "btnQuitarFiltros";
            this.btnQuitarFiltros.Size = new System.Drawing.Size(119, 48);
            this.btnQuitarFiltros.TabIndex = 148;
            this.btnQuitarFiltros.Text = "QUITAR FILTROS";
            this.btnQuitarFiltros.UseVisualStyleBackColor = true;
            this.btnQuitarFiltros.Click += new System.EventHandler(this.btnQuitarFiltros_Click);
            // 
            // btnEliminarProd
            // 
            this.btnEliminarProd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarProd.Location = new System.Drawing.Point(1105, 630);
            this.btnEliminarProd.Name = "btnEliminarProd";
            this.btnEliminarProd.Size = new System.Drawing.Size(119, 48);
            this.btnEliminarProd.TabIndex = 149;
            this.btnEliminarProd.Text = "ELIMINAR PRODUCTO";
            this.btnEliminarProd.UseVisualStyleBackColor = true;
            this.btnEliminarProd.Click += new System.EventHandler(this.btnEliminarProd_Click);
            this.btnEliminarProd.MouseEnter += new System.EventHandler(this.btnEliminarProd_MouseEnter);
            this.btnEliminarProd.MouseLeave += new System.EventHandler(this.btnEliminarProd_MouseLeave);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(964, 364);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(119, 48);
            this.btnCancelar.TabIndex = 150;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            this.btnCancelar.MouseEnter += new System.EventHandler(this.btnCancelar_MouseEnter);
            this.btnCancelar.MouseLeave += new System.EventHandler(this.btnCancelar_MouseLeave);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(964, 292);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(119, 48);
            this.btnLimpiar.TabIndex = 151;
            this.btnLimpiar.Text = "LIMPIAR CAMPOS";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnGuardarProd
            // 
            this.btnGuardarProd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarProd.Location = new System.Drawing.Point(964, 221);
            this.btnGuardarProd.Name = "btnGuardarProd";
            this.btnGuardarProd.Size = new System.Drawing.Size(119, 48);
            this.btnGuardarProd.TabIndex = 152;
            this.btnGuardarProd.Text = "GUARDAR PRODUCTO";
            this.btnGuardarProd.UseVisualStyleBackColor = true;
            this.btnGuardarProd.Click += new System.EventHandler(this.btnGuardarProd_Click);
            this.btnGuardarProd.MouseEnter += new System.EventHandler(this.btnGuardarProd_MouseEnter);
            this.btnGuardarProd.MouseLeave += new System.EventHandler(this.btnGuardarProd_MouseLeave);
            // 
            // btnCargarExcel
            // 
            this.btnCargarExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCargarExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarExcel.Location = new System.Drawing.Point(1105, 543);
            this.btnCargarExcel.Name = "btnCargarExcel";
            this.btnCargarExcel.Size = new System.Drawing.Size(119, 48);
            this.btnCargarExcel.TabIndex = 153;
            this.btnCargarExcel.Text = "CARGAR EXCEL CON PRODUCTOS";
            this.btnCargarExcel.UseVisualStyleBackColor = true;
            this.btnCargarExcel.Click += new System.EventHandler(this.btnCargarExcel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(489, 374);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 20);
            this.label2.TabIndex = 156;
            this.label2.Text = "*";
            // 
            // lblTamSemilla
            // 
            this.lblTamSemilla.AutoSize = true;
            this.lblTamSemilla.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTamSemilla.Location = new System.Drawing.Point(342, 375);
            this.lblTamSemilla.Name = "lblTamSemilla";
            this.lblTamSemilla.Size = new System.Drawing.Size(139, 18);
            this.lblTamSemilla.TabIndex = 155;
            this.lblTamSemilla.Text = "Tamaño de Semilla:";
            // 
            // comboTamSemilla
            // 
            this.comboTamSemilla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTamSemilla.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboTamSemilla.FormattingEnabled = true;
            this.comboTamSemilla.Location = new System.Drawing.Point(550, 372);
            this.comboTamSemilla.Name = "comboTamSemilla";
            this.comboTamSemilla.Size = new System.Drawing.Size(336, 26);
            this.comboTamSemilla.TabIndex = 157;
            // 
            // Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1400, 782);
            this.Controls.Add(this.comboTamSemilla);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTamSemilla);
            this.Controls.Add(this.btnCargarExcel);
            this.Controls.Add(this.btnGuardarProd);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEliminarProd);
            this.Controls.Add(this.btnQuitarFiltros);
            this.Controls.Add(this.labelPaginacion);
            this.Controls.Add(this.btnPaginaSiguiente);
            this.Controls.Add(this.btnPaginaAnterior);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.comboBoxOrdenar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.dataGridViewProductos);
            this.Controls.Add(this.comboTipoProducto);
            this.Controls.Add(this.comboTipoEspecifico);
            this.Controls.Add(this.txtNombreProd);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Productos";
            this.Text = "Productos";
            this.Load += new System.EventHandler(this.Productos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.TextBox txtNombreProd;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewProductos;
        private System.Windows.Forms.ComboBox comboTipoEspecifico;
        private System.Windows.Forms.ComboBox comboTipoProducto;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBoxOrdenar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Label labelPaginacion;
        private System.Windows.Forms.Button btnPaginaSiguiente;
        private System.Windows.Forms.Button btnPaginaAnterior;
        private RoundedButton btnQuitarFiltros;
        private RoundedButton btnEliminarProd;
        private RoundedButton btnCancelar;
        private RoundedButton btnLimpiar;
        private RoundedButton btnGuardarProd;
        private RoundedButton btnCargarExcel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTamSemilla;
        private System.Windows.Forms.ComboBox comboTamSemilla;
    }
}