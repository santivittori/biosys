using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace biosys
{
    public partial class Dashboard : Form
    {
        public string NombreUsuarioActual
        {
            get { return lblUsuario.Text.Replace("Usuario: ", ""); }
        }

        private string rol;

        public Dashboard(string rol, string nombreUsuario)
        {
            InitializeComponent();
            this.rol = rol;

            // Mostrar u ocultar botones según el rol del usuario
            if (rol == "Administrador")
            {
                SubmenuABM.Visible = true;
                SubmenuAltaProd.Visible = true;
            }
            else if (rol == "Empleado")
            {
                btnInformes.Enabled = false;
                SubmenuABM.Visible = true;
                SubmenuAltaProd.Visible = true;
                
            }

            // Asignar los valores de usuario y rol
            lblUsuario.Text = "Usuario: " + nombreUsuario;
            lblRol.Text = "Rol: " + rol;
        }

        // Sirve para poder mover la ventana con el mouse
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro/a que desea salir de la aplicación?", "Cerrar y Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Mostrar el formulario de inicio de sesión
                Login loginForm = new Login();
                loginForm.Show();

                // Cerrar el formulario actual
                this.Close();
            }
        }
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // Botón cerrar sesión
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Mostrar el formulario de inicio de sesión
            Login loginForm = new Login();
            loginForm.Show();

            // Cerrar el formulario actual
            this.Close();
        }

        // Método para abrir un formulario hijo dentro de un panel contenedor
        public void AbrirFormHijo(object formhijo)
        {
            if(PanelContenedor.Controls.Count > 0) 
            {
                this.PanelContenedor.Controls.RemoveAt(0);
            }
            Form fh = formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.PanelContenedor.Controls.Add(fh);
            this.PanelContenedor.Tag = fh;
            fh.Show();
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            Compras comprasForm = new Compras();
            comprasForm.DashboardInstance = this; // Establecer la instancia actual de Dashboard
            AbrirFormHijo(comprasForm);
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            AbrirFormHijo(new Inicio());
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            Proveedores provForm = new Proveedores();
            provForm.DashboardInstance = this;
            AbrirFormHijo(provForm);
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            Productos prodForm = new Productos();
            prodForm.DashboardInstance = this;
            AbrirFormHijo(prodForm);
        }

        private void btnInformes_Click(object sender, EventArgs e)
        {
            Informes informesForm = new Informes();
            informesForm.DashboardInstance = this;
            AbrirFormHijo(informesForm);
        }
    }
}
