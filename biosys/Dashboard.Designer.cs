namespace biosys
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.BarraTitulo = new System.Windows.Forms.Panel();
            this.btnMinimizar = new System.Windows.Forms.PictureBox();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.MenuVertical = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblRol = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.Menu = new System.Windows.Forms.Panel();
            this.SubmenuABM = new System.Windows.Forms.Panel();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnProveedores = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.SubmenuAltaProd = new System.Windows.Forms.Panel();
            this.btnCompras = new System.Windows.Forms.Button();
            this.btnRecoleccion = new System.Windows.Forms.Button();
            this.btnDonacion = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnABM = new System.Windows.Forms.Button();
            this.btnAltaProducto = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReproduccion = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnInformes = new System.Windows.Forms.Button();
            this.btnVentas = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.PanelContenedor = new System.Windows.Forms.Panel();
            this.BarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.MenuVertical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Menu.SuspendLayout();
            this.SubmenuABM.SuspendLayout();
            this.SubmenuAltaProd.SuspendLayout();
            this.SuspendLayout();
            // 
            // BarraTitulo
            // 
            this.BarraTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BarraTitulo.Controls.Add(this.btnMinimizar);
            this.BarraTitulo.Controls.Add(this.btnCerrar);
            this.BarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.BarraTitulo.Location = new System.Drawing.Point(0, 0);
            this.BarraTitulo.Name = "BarraTitulo";
            this.BarraTitulo.Size = new System.Drawing.Size(1680, 38);
            this.BarraTitulo.TabIndex = 0;
            this.BarraTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BarraTitulo_MouseDown);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimizar.Image")));
            this.btnMinimizar.Location = new System.Drawing.Point(1615, 7);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(25, 25);
            this.btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimizar.TabIndex = 2;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(1646, 10);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(20, 20);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // MenuVertical
            // 
            this.MenuVertical.BackColor = System.Drawing.Color.Teal;
            this.MenuVertical.Controls.Add(this.pictureBox1);
            this.MenuVertical.Controls.Add(this.lblRol);
            this.MenuVertical.Controls.Add(this.lblUsuario);
            this.MenuVertical.Controls.Add(this.Menu);
            this.MenuVertical.Controls.Add(this.btnCerrarSesion);
            this.MenuVertical.Controls.Add(this.panel6);
            this.MenuVertical.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuVertical.Location = new System.Drawing.Point(0, 38);
            this.MenuVertical.Name = "MenuVertical";
            this.MenuVertical.Size = new System.Drawing.Size(280, 782);
            this.MenuVertical.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 59);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(94, 95);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRol.Location = new System.Drawing.Point(106, 118);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(31, 16);
            this.lblRol.TabIndex = 18;
            this.lblRol.Text = "Rol";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(106, 88);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(61, 16);
            this.lblUsuario.TabIndex = 17;
            this.lblUsuario.Text = "Usuario";
            // 
            // Menu
            // 
            this.Menu.Controls.Add(this.SubmenuABM);
            this.Menu.Controls.Add(this.SubmenuAltaProd);
            this.Menu.Controls.Add(this.panel2);
            this.Menu.Controls.Add(this.btnABM);
            this.Menu.Controls.Add(this.btnAltaProducto);
            this.Menu.Controls.Add(this.panel3);
            this.Menu.Controls.Add(this.panel1);
            this.Menu.Controls.Add(this.btnReproduccion);
            this.Menu.Controls.Add(this.panel5);
            this.Menu.Controls.Add(this.panel4);
            this.Menu.Controls.Add(this.btnInformes);
            this.Menu.Controls.Add(this.btnVentas);
            this.Menu.Location = new System.Drawing.Point(0, 239);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(277, 418);
            this.Menu.TabIndex = 16;
            // 
            // SubmenuABM
            // 
            this.SubmenuABM.Controls.Add(this.btnProductos);
            this.SubmenuABM.Controls.Add(this.btnProveedores);
            this.SubmenuABM.Controls.Add(this.btnClientes);
            this.SubmenuABM.Location = new System.Drawing.Point(51, 301);
            this.SubmenuABM.Name = "SubmenuABM";
            this.SubmenuABM.Size = new System.Drawing.Size(226, 112);
            this.SubmenuABM.TabIndex = 15;
            this.SubmenuABM.Visible = false;
            // 
            // btnProductos
            // 
            this.btnProductos.BackColor = System.Drawing.Color.Teal;
            this.btnProductos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProductos.FlatAppearance.BorderSize = 0;
            this.btnProductos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.btnProductos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductos.ForeColor = System.Drawing.Color.Black;
            this.btnProductos.Image = ((System.Drawing.Image)(resources.GetObject("btnProductos.Image")));
            this.btnProductos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductos.Location = new System.Drawing.Point(0, 76);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(237, 32);
            this.btnProductos.TabIndex = 17;
            this.btnProductos.Text = "PRODUCTOS";
            this.btnProductos.UseVisualStyleBackColor = false;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // btnProveedores
            // 
            this.btnProveedores.BackColor = System.Drawing.Color.Teal;
            this.btnProveedores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProveedores.FlatAppearance.BorderSize = 0;
            this.btnProveedores.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.btnProveedores.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnProveedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProveedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProveedores.ForeColor = System.Drawing.Color.Black;
            this.btnProveedores.Image = ((System.Drawing.Image)(resources.GetObject("btnProveedores.Image")));
            this.btnProveedores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProveedores.Location = new System.Drawing.Point(0, 38);
            this.btnProveedores.Name = "btnProveedores";
            this.btnProveedores.Size = new System.Drawing.Size(237, 32);
            this.btnProveedores.TabIndex = 17;
            this.btnProveedores.Text = "PROVEEDORES";
            this.btnProveedores.UseVisualStyleBackColor = false;
            this.btnProveedores.Click += new System.EventHandler(this.btnProveedores_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.Color.Teal;
            this.btnClientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClientes.FlatAppearance.BorderSize = 0;
            this.btnClientes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.btnClientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientes.ForeColor = System.Drawing.Color.Black;
            this.btnClientes.Image = ((System.Drawing.Image)(resources.GetObject("btnClientes.Image")));
            this.btnClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.Location = new System.Drawing.Point(0, 0);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(237, 32);
            this.btnClientes.TabIndex = 15;
            this.btnClientes.Text = "CLIENTES";
            this.btnClientes.UseVisualStyleBackColor = false;
            // 
            // SubmenuAltaProd
            // 
            this.SubmenuAltaProd.Controls.Add(this.btnCompras);
            this.SubmenuAltaProd.Controls.Add(this.btnRecoleccion);
            this.SubmenuAltaProd.Controls.Add(this.btnDonacion);
            this.SubmenuAltaProd.Location = new System.Drawing.Point(51, 34);
            this.SubmenuAltaProd.Name = "SubmenuAltaProd";
            this.SubmenuAltaProd.Size = new System.Drawing.Size(226, 112);
            this.SubmenuAltaProd.TabIndex = 29;
            this.SubmenuAltaProd.Visible = false;
            // 
            // btnCompras
            // 
            this.btnCompras.BackColor = System.Drawing.Color.Teal;
            this.btnCompras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompras.FlatAppearance.BorderSize = 0;
            this.btnCompras.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.btnCompras.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnCompras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompras.ForeColor = System.Drawing.Color.Black;
            this.btnCompras.Image = ((System.Drawing.Image)(resources.GetObject("btnCompras.Image")));
            this.btnCompras.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompras.Location = new System.Drawing.Point(3, 3);
            this.btnCompras.Name = "btnCompras";
            this.btnCompras.Size = new System.Drawing.Size(234, 32);
            this.btnCompras.TabIndex = 23;
            this.btnCompras.Text = "COMPRAS";
            this.btnCompras.UseVisualStyleBackColor = false;
            this.btnCompras.Click += new System.EventHandler(this.btnCompras_Click);
            // 
            // btnRecoleccion
            // 
            this.btnRecoleccion.BackColor = System.Drawing.Color.Teal;
            this.btnRecoleccion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRecoleccion.FlatAppearance.BorderSize = 0;
            this.btnRecoleccion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.btnRecoleccion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnRecoleccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecoleccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecoleccion.ForeColor = System.Drawing.Color.Black;
            this.btnRecoleccion.Image = ((System.Drawing.Image)(resources.GetObject("btnRecoleccion.Image")));
            this.btnRecoleccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecoleccion.Location = new System.Drawing.Point(3, 76);
            this.btnRecoleccion.Name = "btnRecoleccion";
            this.btnRecoleccion.Size = new System.Drawing.Size(234, 32);
            this.btnRecoleccion.TabIndex = 27;
            this.btnRecoleccion.Text = "RECOLECCIÓN";
            this.btnRecoleccion.UseVisualStyleBackColor = false;
            this.btnRecoleccion.Click += new System.EventHandler(this.btnRecoleccion_Click);
            // 
            // btnDonacion
            // 
            this.btnDonacion.BackColor = System.Drawing.Color.Teal;
            this.btnDonacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDonacion.FlatAppearance.BorderSize = 0;
            this.btnDonacion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.btnDonacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnDonacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDonacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDonacion.ForeColor = System.Drawing.Color.Black;
            this.btnDonacion.Image = ((System.Drawing.Image)(resources.GetObject("btnDonacion.Image")));
            this.btnDonacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDonacion.Location = new System.Drawing.Point(3, 40);
            this.btnDonacion.Name = "btnDonacion";
            this.btnDonacion.Size = new System.Drawing.Size(234, 32);
            this.btnDonacion.TabIndex = 25;
            this.btnDonacion.Text = "DONACIÓN";
            this.btnDonacion.UseVisualStyleBackColor = false;
            this.btnDonacion.Click += new System.EventHandler(this.btnDonacion_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CadetBlue;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(8, 32);
            this.panel2.TabIndex = 17;
            // 
            // btnABM
            // 
            this.btnABM.BackColor = System.Drawing.Color.Teal;
            this.btnABM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnABM.FlatAppearance.BorderSize = 0;
            this.btnABM.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.btnABM.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnABM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnABM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnABM.ForeColor = System.Drawing.Color.Black;
            this.btnABM.Image = ((System.Drawing.Image)(resources.GetObject("btnABM.Image")));
            this.btnABM.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnABM.Location = new System.Drawing.Point(6, 263);
            this.btnABM.Name = "btnABM";
            this.btnABM.Size = new System.Drawing.Size(271, 32);
            this.btnABM.TabIndex = 13;
            this.btnABM.Text = "ABM\'s";
            this.btnABM.UseVisualStyleBackColor = false;
            // 
            // btnAltaProducto
            // 
            this.btnAltaProducto.BackColor = System.Drawing.Color.Teal;
            this.btnAltaProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAltaProducto.FlatAppearance.BorderSize = 0;
            this.btnAltaProducto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.btnAltaProducto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnAltaProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAltaProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAltaProducto.ForeColor = System.Drawing.Color.Black;
            this.btnAltaProducto.Image = ((System.Drawing.Image)(resources.GetObject("btnAltaProducto.Image")));
            this.btnAltaProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAltaProducto.Location = new System.Drawing.Point(6, 0);
            this.btnAltaProducto.Name = "btnAltaProducto";
            this.btnAltaProducto.Size = new System.Drawing.Size(271, 32);
            this.btnAltaProducto.TabIndex = 3;
            this.btnAltaProducto.Text = "ALTA PRODUCTO";
            this.btnAltaProducto.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.CadetBlue;
            this.panel3.Location = new System.Drawing.Point(0, 149);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(8, 32);
            this.panel3.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CadetBlue;
            this.panel1.Location = new System.Drawing.Point(0, 263);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(8, 32);
            this.panel1.TabIndex = 14;
            // 
            // btnReproduccion
            // 
            this.btnReproduccion.BackColor = System.Drawing.Color.Teal;
            this.btnReproduccion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReproduccion.FlatAppearance.BorderSize = 0;
            this.btnReproduccion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.btnReproduccion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnReproduccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReproduccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReproduccion.ForeColor = System.Drawing.Color.Black;
            this.btnReproduccion.Image = ((System.Drawing.Image)(resources.GetObject("btnReproduccion.Image")));
            this.btnReproduccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReproduccion.Location = new System.Drawing.Point(6, 149);
            this.btnReproduccion.Name = "btnReproduccion";
            this.btnReproduccion.Size = new System.Drawing.Size(271, 32);
            this.btnReproduccion.TabIndex = 5;
            this.btnReproduccion.Text = "REPRODUCCIÓN";
            this.btnReproduccion.UseVisualStyleBackColor = false;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.CadetBlue;
            this.panel5.Location = new System.Drawing.Point(0, 225);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(8, 32);
            this.panel5.TabIndex = 10;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.CadetBlue;
            this.panel4.Location = new System.Drawing.Point(0, 187);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(8, 32);
            this.panel4.TabIndex = 8;
            // 
            // btnInformes
            // 
            this.btnInformes.BackColor = System.Drawing.Color.Teal;
            this.btnInformes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInformes.FlatAppearance.BorderSize = 0;
            this.btnInformes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.btnInformes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnInformes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInformes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInformes.ForeColor = System.Drawing.Color.Black;
            this.btnInformes.Image = ((System.Drawing.Image)(resources.GetObject("btnInformes.Image")));
            this.btnInformes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInformes.Location = new System.Drawing.Point(6, 225);
            this.btnInformes.Name = "btnInformes";
            this.btnInformes.Size = new System.Drawing.Size(271, 32);
            this.btnInformes.TabIndex = 9;
            this.btnInformes.Text = "INFORMES";
            this.btnInformes.UseVisualStyleBackColor = false;
            this.btnInformes.Click += new System.EventHandler(this.btnInformes_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.BackColor = System.Drawing.Color.Teal;
            this.btnVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVentas.FlatAppearance.BorderSize = 0;
            this.btnVentas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.btnVentas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentas.ForeColor = System.Drawing.Color.Black;
            this.btnVentas.Image = ((System.Drawing.Image)(resources.GetObject("btnVentas.Image")));
            this.btnVentas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentas.Location = new System.Drawing.Point(6, 187);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(271, 32);
            this.btnVentas.TabIndex = 7;
            this.btnVentas.Text = "VENTAS";
            this.btnVentas.UseVisualStyleBackColor = false;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCerrarSesion.BackColor = System.Drawing.Color.Teal;
            this.btnCerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarSesion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.btnCerrarSesion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.Black;
            this.btnCerrarSesion.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrarSesion.Image")));
            this.btnCerrarSesion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarSesion.Location = new System.Drawing.Point(6, 738);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(271, 32);
            this.btnCerrarSesion.TabIndex = 11;
            this.btnCerrarSesion.Text = "CERRAR SESIÓN";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel6.BackColor = System.Drawing.Color.CadetBlue;
            this.panel6.Location = new System.Drawing.Point(0, 738);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(8, 32);
            this.panel6.TabIndex = 12;
            // 
            // PanelContenedor
            // 
            this.PanelContenedor.BackColor = System.Drawing.Color.CadetBlue;
            this.PanelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelContenedor.Location = new System.Drawing.Point(280, 38);
            this.PanelContenedor.Name = "PanelContenedor";
            this.PanelContenedor.Size = new System.Drawing.Size(1400, 782);
            this.PanelContenedor.TabIndex = 3;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(1680, 820);
            this.Controls.Add(this.PanelContenedor);
            this.Controls.Add(this.MenuVertical);
            this.Controls.Add(this.BarraTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.BarraTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.MenuVertical.ResumeLayout(false);
            this.MenuVertical.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Menu.ResumeLayout(false);
            this.SubmenuABM.ResumeLayout(false);
            this.SubmenuAltaProd.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.PictureBox btnMinimizar;
        private System.Windows.Forms.Panel BarraTitulo;
        private System.Windows.Forms.Panel MenuVertical;
        private System.Windows.Forms.Button btnABM;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnInformes;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnReproduccion;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAltaProducto;
        private System.Windows.Forms.Panel Menu;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Panel SubmenuABM;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnProveedores;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Panel PanelContenedor;
        private System.Windows.Forms.Button btnRecoleccion;
        private System.Windows.Forms.Button btnDonacion;
        private System.Windows.Forms.Button btnCompras;
        public System.Windows.Forms.Panel SubmenuAltaProd;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}