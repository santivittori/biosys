namespace biosys
{
    partial class RolesPermisos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RolesPermisos));
            this.labelTitulo = new System.Windows.Forms.Label();
            this.dataGridViewRoles = new System.Windows.Forms.DataGridView();
            this.txtNombreRol = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.lblErrorRol = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnLimpiarRol = new System.Windows.Forms.Button();
            this.btnGuardarRol = new System.Windows.Forms.Button();
            this.btnEliminarRol = new System.Windows.Forms.Button();
            this.btnCrearRol = new System.Windows.Forms.Button();
            this.checkedListBoxPermisos = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombrePermiso = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCrearPermiso = new System.Windows.Forms.Button();
            this.btnLimpiarPermiso = new System.Windows.Forms.Button();
            this.btnGuardarPermiso = new System.Windows.Forms.Button();
            this.btnEliminarPermiso = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lblErrorPermiso = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dataGridViewPermisos = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBack = new System.Windows.Forms.PictureBox();
            this.labelRol = new System.Windows.Forms.Label();
            this.btnPagSigRol = new System.Windows.Forms.Button();
            this.btnPagAntRol = new System.Windows.Forms.Button();
            this.labelPermiso = new System.Windows.Forms.Label();
            this.btnSigPermiso = new System.Windows.Forms.Button();
            this.btnAntPermiso = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPermisos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBack)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.Location = new System.Drawing.Point(340, 50);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(793, 55);
            this.labelTitulo.TabIndex = 51;
            this.labelTitulo.Text = "GESTIONAR ROLES Y PERMISOS";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dataGridViewRoles
            // 
            this.dataGridViewRoles.AllowUserToAddRows = false;
            this.dataGridViewRoles.AllowUserToDeleteRows = false;
            this.dataGridViewRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRoles.Location = new System.Drawing.Point(178, 512);
            this.dataGridViewRoles.Name = "dataGridViewRoles";
            this.dataGridViewRoles.ReadOnly = true;
            this.dataGridViewRoles.Size = new System.Drawing.Size(405, 200);
            this.dataGridViewRoles.TabIndex = 52;
            this.dataGridViewRoles.SelectionChanged += new System.EventHandler(this.dataGridViewRoles_SelectionChanged);
            // 
            // txtNombreRol
            // 
            this.txtNombreRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreRol.Location = new System.Drawing.Point(247, 179);
            this.txtNombreRol.Name = "txtNombreRol";
            this.txtNombreRol.Size = new System.Drawing.Size(336, 26);
            this.txtNombreRol.TabIndex = 86;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(433, 353);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(15, 20);
            this.label15.TabIndex = 89;
            this.label15.Text = "*";
            // 
            // lblErrorRol
            // 
            this.lblErrorRol.AutoSize = true;
            this.lblErrorRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorRol.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblErrorRol.Image = ((System.Drawing.Image)(resources.GetObject("lblErrorRol.Image")));
            this.lblErrorRol.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblErrorRol.Location = new System.Drawing.Point(140, 395);
            this.lblErrorRol.Name = "lblErrorRol";
            this.lblErrorRol.Size = new System.Drawing.Size(122, 18);
            this.lblErrorRol.TabIndex = 88;
            this.lblErrorRol.Text = "Mensaje de Error";
            this.lblErrorRol.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(257, 353);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(299, 16);
            this.label13.TabIndex = 87;
            this.label13.Text = "Los campos con asteriscos (      ) son obligatorios";
            // 
            // btnLimpiarRol
            // 
            this.btnLimpiarRol.BackColor = System.Drawing.Color.White;
            this.btnLimpiarRol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiarRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarRol.Location = new System.Drawing.Point(26, 578);
            this.btnLimpiarRol.Name = "btnLimpiarRol";
            this.btnLimpiarRol.Size = new System.Drawing.Size(127, 48);
            this.btnLimpiarRol.TabIndex = 111;
            this.btnLimpiarRol.Text = "LIMPIAR CAMPOS";
            this.btnLimpiarRol.UseVisualStyleBackColor = false;
            this.btnLimpiarRol.Click += new System.EventHandler(this.btnLimpiarRol_Click);
            // 
            // btnGuardarRol
            // 
            this.btnGuardarRol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnGuardarRol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarRol.Location = new System.Drawing.Point(26, 512);
            this.btnGuardarRol.Name = "btnGuardarRol";
            this.btnGuardarRol.Size = new System.Drawing.Size(127, 48);
            this.btnGuardarRol.TabIndex = 110;
            this.btnGuardarRol.Text = "GUARDAR EDICIÓN";
            this.btnGuardarRol.UseVisualStyleBackColor = false;
            this.btnGuardarRol.Click += new System.EventHandler(this.btnGuardarRol_Click);
            // 
            // btnEliminarRol
            // 
            this.btnEliminarRol.BackColor = System.Drawing.Color.Red;
            this.btnEliminarRol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarRol.Location = new System.Drawing.Point(26, 643);
            this.btnEliminarRol.Name = "btnEliminarRol";
            this.btnEliminarRol.Size = new System.Drawing.Size(127, 48);
            this.btnEliminarRol.TabIndex = 109;
            this.btnEliminarRol.Text = "ELIMINAR";
            this.btnEliminarRol.UseVisualStyleBackColor = false;
            this.btnEliminarRol.Click += new System.EventHandler(this.btnEliminarRol_Click);
            // 
            // btnCrearRol
            // 
            this.btnCrearRol.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnCrearRol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrearRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearRol.Location = new System.Drawing.Point(350, 435);
            this.btnCrearRol.Name = "btnCrearRol";
            this.btnCrearRol.Size = new System.Drawing.Size(119, 48);
            this.btnCrearRol.TabIndex = 112;
            this.btnCrearRol.Text = "CREAR";
            this.btnCrearRol.UseVisualStyleBackColor = false;
            this.btnCrearRol.Click += new System.EventHandler(this.btnCrearRol_Click);
            // 
            // checkedListBoxPermisos
            // 
            this.checkedListBoxPermisos.FormattingEnabled = true;
            this.checkedListBoxPermisos.Location = new System.Drawing.Point(247, 245);
            this.checkedListBoxPermisos.Name = "checkedListBoxPermisos";
            this.checkedListBoxPermisos.Size = new System.Drawing.Size(336, 94);
            this.checkedListBoxPermisos.TabIndex = 113;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 20);
            this.label2.TabIndex = 84;
            this.label2.Text = "Nombre del Rol:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(172, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 20);
            this.label7.TabIndex = 85;
            this.label7.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(199, 245);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 20);
            this.label1.TabIndex = 115;
            this.label1.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(43, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 20);
            this.label3.TabIndex = 114;
            this.label3.Text = "Permisos admitidos:";
            // 
            // txtNombrePermiso
            // 
            this.txtNombrePermiso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombrePermiso.Location = new System.Drawing.Point(938, 179);
            this.txtNombrePermiso.Name = "txtNombrePermiso";
            this.txtNombrePermiso.Size = new System.Drawing.Size(336, 26);
            this.txtNombrePermiso.TabIndex = 153;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(895, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 20);
            this.label4.TabIndex = 152;
            this.label4.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(734, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 20);
            this.label5.TabIndex = 151;
            this.label5.Text = "Nombre del Permiso:";
            // 
            // btnCrearPermiso
            // 
            this.btnCrearPermiso.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnCrearPermiso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrearPermiso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearPermiso.Location = new System.Drawing.Point(1051, 304);
            this.btnCrearPermiso.Name = "btnCrearPermiso";
            this.btnCrearPermiso.Size = new System.Drawing.Size(119, 48);
            this.btnCrearPermiso.TabIndex = 161;
            this.btnCrearPermiso.Text = "CREAR";
            this.btnCrearPermiso.UseVisualStyleBackColor = false;
            this.btnCrearPermiso.Click += new System.EventHandler(this.btnCrearPermiso_Click);
            // 
            // btnLimpiarPermiso
            // 
            this.btnLimpiarPermiso.BackColor = System.Drawing.Color.White;
            this.btnLimpiarPermiso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiarPermiso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarPermiso.Location = new System.Drawing.Point(1245, 578);
            this.btnLimpiarPermiso.Name = "btnLimpiarPermiso";
            this.btnLimpiarPermiso.Size = new System.Drawing.Size(127, 48);
            this.btnLimpiarPermiso.TabIndex = 160;
            this.btnLimpiarPermiso.Text = "LIMPIAR CAMPOS";
            this.btnLimpiarPermiso.UseVisualStyleBackColor = false;
            this.btnLimpiarPermiso.Click += new System.EventHandler(this.btnLimpiarPermiso_Click);
            // 
            // btnGuardarPermiso
            // 
            this.btnGuardarPermiso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnGuardarPermiso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarPermiso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarPermiso.Location = new System.Drawing.Point(1245, 512);
            this.btnGuardarPermiso.Name = "btnGuardarPermiso";
            this.btnGuardarPermiso.Size = new System.Drawing.Size(127, 48);
            this.btnGuardarPermiso.TabIndex = 159;
            this.btnGuardarPermiso.Text = "GUARDAR EDICIÓN";
            this.btnGuardarPermiso.UseVisualStyleBackColor = false;
            this.btnGuardarPermiso.Click += new System.EventHandler(this.btnGuardarPermiso_Click);
            // 
            // btnEliminarPermiso
            // 
            this.btnEliminarPermiso.BackColor = System.Drawing.Color.Red;
            this.btnEliminarPermiso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarPermiso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarPermiso.Location = new System.Drawing.Point(1245, 643);
            this.btnEliminarPermiso.Name = "btnEliminarPermiso";
            this.btnEliminarPermiso.Size = new System.Drawing.Size(127, 48);
            this.btnEliminarPermiso.TabIndex = 158;
            this.btnEliminarPermiso.Text = "ELIMINAR";
            this.btnEliminarPermiso.UseVisualStyleBackColor = false;
            this.btnEliminarPermiso.Click += new System.EventHandler(this.btnEliminarPermiso_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(1134, 222);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 20);
            this.label8.TabIndex = 157;
            this.label8.Text = "*";
            // 
            // lblErrorPermiso
            // 
            this.lblErrorPermiso.AutoSize = true;
            this.lblErrorPermiso.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorPermiso.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblErrorPermiso.Image = ((System.Drawing.Image)(resources.GetObject("lblErrorPermiso.Image")));
            this.lblErrorPermiso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblErrorPermiso.Location = new System.Drawing.Point(850, 264);
            this.lblErrorPermiso.Name = "lblErrorPermiso";
            this.lblErrorPermiso.Size = new System.Drawing.Size(122, 18);
            this.lblErrorPermiso.TabIndex = 156;
            this.lblErrorPermiso.Text = "Mensaje de Error";
            this.lblErrorPermiso.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(958, 222);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(299, 16);
            this.label10.TabIndex = 155;
            this.label10.Text = "Los campos con asteriscos (      ) son obligatorios";
            // 
            // dataGridViewPermisos
            // 
            this.dataGridViewPermisos.AllowUserToAddRows = false;
            this.dataGridViewPermisos.AllowUserToDeleteRows = false;
            this.dataGridViewPermisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPermisos.Location = new System.Drawing.Point(807, 512);
            this.dataGridViewPermisos.Name = "dataGridViewPermisos";
            this.dataGridViewPermisos.ReadOnly = true;
            this.dataGridViewPermisos.Size = new System.Drawing.Size(405, 200);
            this.dataGridViewPermisos.TabIndex = 154;
            this.dataGridViewPermisos.SelectionChanged += new System.EventHandler(this.dataGridViewPermisos_SelectionChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(64, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 20);
            this.label6.TabIndex = 166;
            this.label6.Text = "Back";
            // 
            // pictureBack
            // 
            this.pictureBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBack.Image = ((System.Drawing.Image)(resources.GetObject("pictureBack.Image")));
            this.pictureBack.Location = new System.Drawing.Point(17, 9);
            this.pictureBack.Name = "pictureBack";
            this.pictureBack.Size = new System.Drawing.Size(50, 44);
            this.pictureBack.TabIndex = 165;
            this.pictureBack.TabStop = false;
            this.pictureBack.Click += new System.EventHandler(this.pictureBack_Click);
            // 
            // labelRol
            // 
            this.labelRol.AutoSize = true;
            this.labelRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRol.Location = new System.Drawing.Point(332, 736);
            this.labelRol.Name = "labelRol";
            this.labelRol.Size = new System.Drawing.Size(62, 16);
            this.labelRol.TabIndex = 169;
            this.labelRol.Text = "LabelRol";
            // 
            // btnPagSigRol
            // 
            this.btnPagSigRol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPagSigRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagSigRol.Location = new System.Drawing.Point(253, 726);
            this.btnPagSigRol.Name = "btnPagSigRol";
            this.btnPagSigRol.Size = new System.Drawing.Size(50, 34);
            this.btnPagSigRol.TabIndex = 168;
            this.btnPagSigRol.Text = ">";
            this.btnPagSigRol.UseVisualStyleBackColor = true;
            this.btnPagSigRol.Click += new System.EventHandler(this.btnPagSigRol_Click);
            // 
            // btnPagAntRol
            // 
            this.btnPagAntRol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPagAntRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagAntRol.Location = new System.Drawing.Point(178, 726);
            this.btnPagAntRol.Name = "btnPagAntRol";
            this.btnPagAntRol.Size = new System.Drawing.Size(50, 34);
            this.btnPagAntRol.TabIndex = 167;
            this.btnPagAntRol.Text = "<";
            this.btnPagAntRol.UseVisualStyleBackColor = true;
            this.btnPagAntRol.Click += new System.EventHandler(this.btnPagAntRol_Click);
            // 
            // labelPermiso
            // 
            this.labelPermiso.AutoSize = true;
            this.labelPermiso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPermiso.Location = new System.Drawing.Point(960, 736);
            this.labelPermiso.Name = "labelPermiso";
            this.labelPermiso.Size = new System.Drawing.Size(91, 16);
            this.labelPermiso.TabIndex = 172;
            this.labelPermiso.Text = "LabelPermiso";
            // 
            // btnSigPermiso
            // 
            this.btnSigPermiso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSigPermiso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSigPermiso.Location = new System.Drawing.Point(881, 726);
            this.btnSigPermiso.Name = "btnSigPermiso";
            this.btnSigPermiso.Size = new System.Drawing.Size(50, 34);
            this.btnSigPermiso.TabIndex = 171;
            this.btnSigPermiso.Text = ">";
            this.btnSigPermiso.UseVisualStyleBackColor = true;
            this.btnSigPermiso.Click += new System.EventHandler(this.btnSigPermiso_Click);
            // 
            // btnAntPermiso
            // 
            this.btnAntPermiso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAntPermiso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAntPermiso.Location = new System.Drawing.Point(806, 726);
            this.btnAntPermiso.Name = "btnAntPermiso";
            this.btnAntPermiso.Size = new System.Drawing.Size(50, 34);
            this.btnAntPermiso.TabIndex = 170;
            this.btnAntPermiso.Text = "<";
            this.btnAntPermiso.UseVisualStyleBackColor = true;
            this.btnAntPermiso.Click += new System.EventHandler(this.btnAntPermiso_Click);
            // 
            // RolesPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1400, 782);
            this.Controls.Add(this.labelPermiso);
            this.Controls.Add(this.btnSigPermiso);
            this.Controls.Add(this.btnAntPermiso);
            this.Controls.Add(this.labelRol);
            this.Controls.Add(this.btnPagSigRol);
            this.Controls.Add(this.btnPagAntRol);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBack);
            this.Controls.Add(this.btnCrearPermiso);
            this.Controls.Add(this.btnLimpiarPermiso);
            this.Controls.Add(this.btnGuardarPermiso);
            this.Controls.Add(this.btnEliminarPermiso);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblErrorPermiso);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dataGridViewPermisos);
            this.Controls.Add(this.txtNombrePermiso);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkedListBoxPermisos);
            this.Controls.Add(this.btnCrearRol);
            this.Controls.Add(this.btnLimpiarRol);
            this.Controls.Add(this.btnGuardarRol);
            this.Controls.Add(this.btnEliminarRol);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lblErrorRol);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtNombreRol);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewRoles);
            this.Controls.Add(this.labelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RolesPermisos";
            this.Text = "RolesPermisos";
            this.Load += new System.EventHandler(this.RolesPermisos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPermisos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.DataGridView dataGridViewRoles;
        private System.Windows.Forms.TextBox txtNombreRol;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblErrorRol;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnLimpiarRol;
        private System.Windows.Forms.Button btnGuardarRol;
        private System.Windows.Forms.Button btnEliminarRol;
        private System.Windows.Forms.Button btnCrearRol;
        private System.Windows.Forms.CheckedListBox checkedListBoxPermisos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombrePermiso;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCrearPermiso;
        private System.Windows.Forms.Button btnLimpiarPermiso;
        private System.Windows.Forms.Button btnGuardarPermiso;
        private System.Windows.Forms.Button btnEliminarPermiso;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblErrorPermiso;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dataGridViewPermisos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBack;
        private System.Windows.Forms.Label labelRol;
        private System.Windows.Forms.Button btnPagSigRol;
        private System.Windows.Forms.Button btnPagAntRol;
        private System.Windows.Forms.Label labelPermiso;
        private System.Windows.Forms.Button btnSigPermiso;
        private System.Windows.Forms.Button btnAntPermiso;
    }
}