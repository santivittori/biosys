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
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnAuditoria = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnGestionarPrecios = new System.Windows.Forms.Button();
            this.btnRecoleccion = new System.Windows.Forms.Button();
            this.btnProveedores = new System.Windows.Forms.Button();
            this.btnCompras = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnDonacion = new System.Windows.Forms.Button();
            this.btnBajaProductos = new System.Windows.Forms.Button();
            this.btnGestionarUsuario = new System.Windows.Forms.Button();
            this.btnABM = new System.Windows.Forms.Button();
            this.btnAltaProducto = new System.Windows.Forms.Button();
            this.btnReproduccion = new System.Windows.Forms.Button();
            this.btnInformes = new System.Windows.Forms.Button();
            this.btnVentas = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.PanelContenedor = new System.Windows.Forms.Panel();
            this.BarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.MenuVertical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // BarraTitulo
            // 
            this.BarraTitulo.BackColor = System.Drawing.Color.LemonChiffon;
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
            this.MenuVertical.BackColor = System.Drawing.Color.Beige;
            this.MenuVertical.Controls.Add(this.pictureBox1);
            this.MenuVertical.Controls.Add(this.lblRol);
            this.MenuVertical.Controls.Add(this.lblUsuario);
            this.MenuVertical.Controls.Add(this.Menu);
            this.MenuVertical.Controls.Add(this.btnCerrarSesion);
            this.MenuVertical.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuVertical.Location = new System.Drawing.Point(0, 38);
            this.MenuVertical.Name = "MenuVertical";
            this.MenuVertical.Size = new System.Drawing.Size(280, 782);
            this.MenuVertical.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(94, 95);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRol.Location = new System.Drawing.Point(106, 66);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(31, 16);
            this.lblRol.TabIndex = 18;
            this.lblRol.Text = "Rol";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(106, 36);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(61, 16);
            this.lblUsuario.TabIndex = 17;
            this.lblUsuario.Text = "Usuario";
            // 
            // Menu
            // 
            this.Menu.Controls.Add(this.pictureBox7);
            this.Menu.Controls.Add(this.pictureBox6);
            this.Menu.Controls.Add(this.pictureBox5);
            this.Menu.Controls.Add(this.pictureBox4);
            this.Menu.Controls.Add(this.pictureBox3);
            this.Menu.Controls.Add(this.pictureBox2);
            this.Menu.Controls.Add(this.btnBackup);
            this.Menu.Controls.Add(this.btnAuditoria);
            this.Menu.Controls.Add(this.btnProductos);
            this.Menu.Controls.Add(this.btnGestionarPrecios);
            this.Menu.Controls.Add(this.btnRecoleccion);
            this.Menu.Controls.Add(this.btnProveedores);
            this.Menu.Controls.Add(this.btnCompras);
            this.Menu.Controls.Add(this.btnClientes);
            this.Menu.Controls.Add(this.btnDonacion);
            this.Menu.Controls.Add(this.btnBajaProductos);
            this.Menu.Controls.Add(this.btnGestionarUsuario);
            this.Menu.Controls.Add(this.btnABM);
            this.Menu.Controls.Add(this.btnAltaProducto);
            this.Menu.Controls.Add(this.btnReproduccion);
            this.Menu.Controls.Add(this.btnInformes);
            this.Menu.Controls.Add(this.btnVentas);
            this.Menu.Location = new System.Drawing.Point(0, 112);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(277, 605);
            this.Menu.TabIndex = 16;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(44, 387);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(16, 22);
            this.pictureBox7.TabIndex = 42;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(44, 349);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(16, 22);
            this.pictureBox6.TabIndex = 41;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(44, 311);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(16, 22);
            this.pictureBox5.TabIndex = 40;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(44, 124);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(16, 22);
            this.pictureBox4.TabIndex = 1;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(44, 86);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(16, 22);
            this.pictureBox3.TabIndex = 39;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(44, 48);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 22);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // btnBackup
            // 
            this.btnBackup.BackColor = System.Drawing.Color.Beige;
            this.btnBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackup.FlatAppearance.BorderSize = 0;
            this.btnBackup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.btnBackup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackup.ForeColor = System.Drawing.Color.Black;
            this.btnBackup.Image = ((System.Drawing.Image)(resources.GetObject("btnBackup.Image")));
            this.btnBackup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBackup.Location = new System.Drawing.Point(0, 567);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(277, 32);
            this.btnBackup.TabIndex = 38;
            this.btnBackup.Tag = "Backup";
            this.btnBackup.Text = "        Resguardo y restauración";
            this.btnBackup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBackup.UseVisualStyleBackColor = false;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnAuditoria
            // 
            this.btnAuditoria.BackColor = System.Drawing.Color.Beige;
            this.btnAuditoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAuditoria.FlatAppearance.BorderSize = 0;
            this.btnAuditoria.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.btnAuditoria.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnAuditoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuditoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAuditoria.ForeColor = System.Drawing.Color.Black;
            this.btnAuditoria.Image = ((System.Drawing.Image)(resources.GetObject("btnAuditoria.Image")));
            this.btnAuditoria.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAuditoria.Location = new System.Drawing.Point(0, 529);
            this.btnAuditoria.Name = "btnAuditoria";
            this.btnAuditoria.Size = new System.Drawing.Size(277, 32);
            this.btnAuditoria.TabIndex = 36;
            this.btnAuditoria.Tag = "Auditoria";
            this.btnAuditoria.Text = "        Auditorías";
            this.btnAuditoria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAuditoria.UseVisualStyleBackColor = false;
            this.btnAuditoria.Click += new System.EventHandler(this.btnAuditoria_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.BackColor = System.Drawing.Color.Beige;
            this.btnProductos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProductos.FlatAppearance.BorderSize = 0;
            this.btnProductos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.btnProductos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductos.ForeColor = System.Drawing.Color.Black;
            this.btnProductos.Image = ((System.Drawing.Image)(resources.GetObject("btnProductos.Image")));
            this.btnProductos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductos.Location = new System.Drawing.Point(63, 377);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(214, 32);
            this.btnProductos.TabIndex = 17;
            this.btnProductos.Tag = "ABMs";
            this.btnProductos.Text = "        Productos";
            this.btnProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductos.UseVisualStyleBackColor = false;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // btnGestionarPrecios
            // 
            this.btnGestionarPrecios.BackColor = System.Drawing.Color.Beige;
            this.btnGestionarPrecios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGestionarPrecios.FlatAppearance.BorderSize = 0;
            this.btnGestionarPrecios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.btnGestionarPrecios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnGestionarPrecios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestionarPrecios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionarPrecios.ForeColor = System.Drawing.Color.Black;
            this.btnGestionarPrecios.Image = ((System.Drawing.Image)(resources.GetObject("btnGestionarPrecios.Image")));
            this.btnGestionarPrecios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGestionarPrecios.Location = new System.Drawing.Point(0, 491);
            this.btnGestionarPrecios.Name = "btnGestionarPrecios";
            this.btnGestionarPrecios.Size = new System.Drawing.Size(277, 32);
            this.btnGestionarPrecios.TabIndex = 34;
            this.btnGestionarPrecios.Tag = "Gestionar Precios";
            this.btnGestionarPrecios.Text = "        Gestionar precios";
            this.btnGestionarPrecios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGestionarPrecios.UseVisualStyleBackColor = false;
            this.btnGestionarPrecios.Click += new System.EventHandler(this.btnGestionarPrecios_Click);
            // 
            // btnRecoleccion
            // 
            this.btnRecoleccion.BackColor = System.Drawing.Color.Beige;
            this.btnRecoleccion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRecoleccion.FlatAppearance.BorderSize = 0;
            this.btnRecoleccion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.btnRecoleccion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnRecoleccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecoleccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecoleccion.ForeColor = System.Drawing.Color.Black;
            this.btnRecoleccion.Image = ((System.Drawing.Image)(resources.GetObject("btnRecoleccion.Image")));
            this.btnRecoleccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecoleccion.Location = new System.Drawing.Point(63, 114);
            this.btnRecoleccion.Name = "btnRecoleccion";
            this.btnRecoleccion.Size = new System.Drawing.Size(217, 32);
            this.btnRecoleccion.TabIndex = 27;
            this.btnRecoleccion.Tag = "Alta de Productos";
            this.btnRecoleccion.Text = "        Recolección";
            this.btnRecoleccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecoleccion.UseVisualStyleBackColor = false;
            this.btnRecoleccion.Click += new System.EventHandler(this.btnRecoleccion_Click);
            // 
            // btnProveedores
            // 
            this.btnProveedores.BackColor = System.Drawing.Color.Beige;
            this.btnProveedores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProveedores.FlatAppearance.BorderSize = 0;
            this.btnProveedores.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.btnProveedores.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnProveedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProveedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProveedores.ForeColor = System.Drawing.Color.Black;
            this.btnProveedores.Image = ((System.Drawing.Image)(resources.GetObject("btnProveedores.Image")));
            this.btnProveedores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProveedores.Location = new System.Drawing.Point(63, 339);
            this.btnProveedores.Name = "btnProveedores";
            this.btnProveedores.Size = new System.Drawing.Size(217, 32);
            this.btnProveedores.TabIndex = 17;
            this.btnProveedores.Tag = "ABMs";
            this.btnProveedores.Text = "        Proveedores";
            this.btnProveedores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProveedores.UseVisualStyleBackColor = false;
            this.btnProveedores.Click += new System.EventHandler(this.btnProveedores_Click);
            // 
            // btnCompras
            // 
            this.btnCompras.BackColor = System.Drawing.Color.Beige;
            this.btnCompras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompras.FlatAppearance.BorderSize = 0;
            this.btnCompras.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.btnCompras.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnCompras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompras.ForeColor = System.Drawing.Color.Black;
            this.btnCompras.Image = ((System.Drawing.Image)(resources.GetObject("btnCompras.Image")));
            this.btnCompras.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompras.Location = new System.Drawing.Point(63, 38);
            this.btnCompras.Name = "btnCompras";
            this.btnCompras.Size = new System.Drawing.Size(214, 32);
            this.btnCompras.TabIndex = 23;
            this.btnCompras.Tag = "Alta de Productos";
            this.btnCompras.Text = "        Compras";
            this.btnCompras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompras.UseVisualStyleBackColor = false;
            this.btnCompras.Click += new System.EventHandler(this.btnCompras_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.Color.Beige;
            this.btnClientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClientes.FlatAppearance.BorderSize = 0;
            this.btnClientes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.btnClientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientes.ForeColor = System.Drawing.Color.Black;
            this.btnClientes.Image = ((System.Drawing.Image)(resources.GetObject("btnClientes.Image")));
            this.btnClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.Location = new System.Drawing.Point(63, 301);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(217, 32);
            this.btnClientes.TabIndex = 15;
            this.btnClientes.Tag = "ABMs";
            this.btnClientes.Text = "        Clientes";
            this.btnClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.UseVisualStyleBackColor = false;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnDonacion
            // 
            this.btnDonacion.BackColor = System.Drawing.Color.Beige;
            this.btnDonacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDonacion.FlatAppearance.BorderSize = 0;
            this.btnDonacion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.btnDonacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnDonacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDonacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDonacion.ForeColor = System.Drawing.Color.Black;
            this.btnDonacion.Image = ((System.Drawing.Image)(resources.GetObject("btnDonacion.Image")));
            this.btnDonacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDonacion.Location = new System.Drawing.Point(63, 76);
            this.btnDonacion.Name = "btnDonacion";
            this.btnDonacion.Size = new System.Drawing.Size(214, 32);
            this.btnDonacion.TabIndex = 25;
            this.btnDonacion.Tag = "Alta de Productos";
            this.btnDonacion.Text = "        Donación";
            this.btnDonacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDonacion.UseVisualStyleBackColor = false;
            this.btnDonacion.Click += new System.EventHandler(this.btnDonacion_Click);
            // 
            // btnBajaProductos
            // 
            this.btnBajaProductos.BackColor = System.Drawing.Color.Beige;
            this.btnBajaProductos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBajaProductos.FlatAppearance.BorderSize = 0;
            this.btnBajaProductos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.btnBajaProductos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnBajaProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBajaProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBajaProductos.ForeColor = System.Drawing.Color.Black;
            this.btnBajaProductos.Image = ((System.Drawing.Image)(resources.GetObject("btnBajaProductos.Image")));
            this.btnBajaProductos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBajaProductos.Location = new System.Drawing.Point(0, 453);
            this.btnBajaProductos.Name = "btnBajaProductos";
            this.btnBajaProductos.Size = new System.Drawing.Size(277, 32);
            this.btnBajaProductos.TabIndex = 32;
            this.btnBajaProductos.Tag = "Baja de Productos";
            this.btnBajaProductos.Text = "        Baja de productos";
            this.btnBajaProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBajaProductos.UseVisualStyleBackColor = false;
            this.btnBajaProductos.Click += new System.EventHandler(this.btnBajaProductos_Click);
            // 
            // btnGestionarUsuario
            // 
            this.btnGestionarUsuario.BackColor = System.Drawing.Color.Beige;
            this.btnGestionarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGestionarUsuario.FlatAppearance.BorderSize = 0;
            this.btnGestionarUsuario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.btnGestionarUsuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnGestionarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestionarUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionarUsuario.ForeColor = System.Drawing.Color.Black;
            this.btnGestionarUsuario.Image = ((System.Drawing.Image)(resources.GetObject("btnGestionarUsuario.Image")));
            this.btnGestionarUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGestionarUsuario.Location = new System.Drawing.Point(0, 415);
            this.btnGestionarUsuario.Name = "btnGestionarUsuario";
            this.btnGestionarUsuario.Size = new System.Drawing.Size(277, 32);
            this.btnGestionarUsuario.TabIndex = 30;
            this.btnGestionarUsuario.Tag = "Gestionar Usuarios";
            this.btnGestionarUsuario.Text = "        Gestionar usuarios";
            this.btnGestionarUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGestionarUsuario.UseVisualStyleBackColor = false;
            this.btnGestionarUsuario.Click += new System.EventHandler(this.btnGestionarUsuario_Click);
            // 
            // btnABM
            // 
            this.btnABM.BackColor = System.Drawing.Color.Beige;
            this.btnABM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnABM.FlatAppearance.BorderSize = 0;
            this.btnABM.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.btnABM.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnABM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnABM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnABM.ForeColor = System.Drawing.Color.Black;
            this.btnABM.Image = ((System.Drawing.Image)(resources.GetObject("btnABM.Image")));
            this.btnABM.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnABM.Location = new System.Drawing.Point(0, 263);
            this.btnABM.Name = "btnABM";
            this.btnABM.Size = new System.Drawing.Size(277, 32);
            this.btnABM.TabIndex = 13;
            this.btnABM.Tag = "ABMs";
            this.btnABM.Text = "        Abm\'s";
            this.btnABM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnABM.UseVisualStyleBackColor = false;
            // 
            // btnAltaProducto
            // 
            this.btnAltaProducto.BackColor = System.Drawing.Color.Beige;
            this.btnAltaProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAltaProducto.FlatAppearance.BorderSize = 0;
            this.btnAltaProducto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.btnAltaProducto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnAltaProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAltaProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAltaProducto.ForeColor = System.Drawing.Color.Black;
            this.btnAltaProducto.Image = ((System.Drawing.Image)(resources.GetObject("btnAltaProducto.Image")));
            this.btnAltaProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAltaProducto.Location = new System.Drawing.Point(0, 0);
            this.btnAltaProducto.Name = "btnAltaProducto";
            this.btnAltaProducto.Size = new System.Drawing.Size(277, 32);
            this.btnAltaProducto.TabIndex = 3;
            this.btnAltaProducto.Tag = "Alta de Productos";
            this.btnAltaProducto.Text = "        Alta de productos";
            this.btnAltaProducto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAltaProducto.UseVisualStyleBackColor = false;
            // 
            // btnReproduccion
            // 
            this.btnReproduccion.BackColor = System.Drawing.Color.Beige;
            this.btnReproduccion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReproduccion.FlatAppearance.BorderSize = 0;
            this.btnReproduccion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.btnReproduccion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnReproduccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReproduccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReproduccion.ForeColor = System.Drawing.Color.Black;
            this.btnReproduccion.Image = ((System.Drawing.Image)(resources.GetObject("btnReproduccion.Image")));
            this.btnReproduccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReproduccion.Location = new System.Drawing.Point(0, 149);
            this.btnReproduccion.Name = "btnReproduccion";
            this.btnReproduccion.Size = new System.Drawing.Size(277, 32);
            this.btnReproduccion.TabIndex = 5;
            this.btnReproduccion.Tag = "Reproduccion";
            this.btnReproduccion.Text = "        Reproducción";
            this.btnReproduccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReproduccion.UseVisualStyleBackColor = false;
            this.btnReproduccion.Click += new System.EventHandler(this.btnReproduccion_Click);
            // 
            // btnInformes
            // 
            this.btnInformes.BackColor = System.Drawing.Color.Beige;
            this.btnInformes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInformes.FlatAppearance.BorderSize = 0;
            this.btnInformes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.btnInformes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnInformes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInformes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInformes.ForeColor = System.Drawing.Color.Black;
            this.btnInformes.Image = ((System.Drawing.Image)(resources.GetObject("btnInformes.Image")));
            this.btnInformes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInformes.Location = new System.Drawing.Point(0, 225);
            this.btnInformes.Name = "btnInformes";
            this.btnInformes.Size = new System.Drawing.Size(277, 32);
            this.btnInformes.TabIndex = 9;
            this.btnInformes.Tag = "Informes";
            this.btnInformes.Text = "        Informes";
            this.btnInformes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInformes.UseVisualStyleBackColor = false;
            this.btnInformes.Click += new System.EventHandler(this.btnInformes_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.BackColor = System.Drawing.Color.Beige;
            this.btnVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVentas.FlatAppearance.BorderSize = 0;
            this.btnVentas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.btnVentas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentas.ForeColor = System.Drawing.Color.Black;
            this.btnVentas.Image = ((System.Drawing.Image)(resources.GetObject("btnVentas.Image")));
            this.btnVentas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentas.Location = new System.Drawing.Point(0, 187);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(277, 32);
            this.btnVentas.TabIndex = 7;
            this.btnVentas.Tag = "Ventas";
            this.btnVentas.Text = "        Ventas";
            this.btnVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentas.UseVisualStyleBackColor = false;
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCerrarSesion.BackColor = System.Drawing.Color.Beige;
            this.btnCerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarSesion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.btnCerrarSesion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.Black;
            this.btnCerrarSesion.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrarSesion.Image")));
            this.btnCerrarSesion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarSesion.Location = new System.Drawing.Point(0, 741);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(277, 32);
            this.btnCerrarSesion.TabIndex = 11;
            this.btnCerrarSesion.Text = "        Cerrar sesión";
            this.btnCerrarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.PictureBox btnMinimizar;
        private System.Windows.Forms.Panel BarraTitulo;
        private System.Windows.Forms.Panel MenuVertical;
        private System.Windows.Forms.Button btnABM;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnInformes;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Button btnReproduccion;
        private System.Windows.Forms.Button btnAltaProducto;
        private System.Windows.Forms.Panel Menu;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnProveedores;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnRecoleccion;
        private System.Windows.Forms.Button btnDonacion;
        private System.Windows.Forms.Button btnCompras;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnGestionarUsuario;
        private System.Windows.Forms.Button btnBajaProductos;
        private System.Windows.Forms.Panel PanelContenedor;
        private System.Windows.Forms.Button btnGestionarPrecios;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnAuditoria;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
    }
}