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

            IComponenteSeguridad btnInformesSeguridad = new BotonSeguridad(btnInformes);
            IComponenteSeguridad btnGestionarUsuarioSeguridad = new BotonSeguridad(btnGestionarUsuario);
            IComponenteSeguridad submenuABMSeguridad = new PanelSeguridad(SubmenuABM);
            IComponenteSeguridad submenuAltaProdSeguridad = new PanelSeguridad(SubmenuAltaProd);

            btnInformesSeguridad.MostrarElemento(rol);
            btnGestionarUsuarioSeguridad.MostrarElemento(rol);
            submenuABMSeguridad.MostrarElemento(rol);
            submenuAltaProdSeguridad.MostrarElemento(rol);

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
            // Primero preguntar si está seguro de cerrar sesión
            DialogResult result = MessageBox.Show("¿Está seguro/a que desea cerrar sesión?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
            // Si la respuesta es correcta , cerrar sesión
            if (result == DialogResult.Yes)
            {
                // Mostrar el formulario de inicio de sesión
                Login loginForm = new Login();
                loginForm.Show();

                // Cerrar el formulario actual
                this.Close();
            }
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

        public interface IComponenteSeguridad
        {
            void MostrarElemento(string rol);
        }

        public class BotonSeguridad : Button, IComponenteSeguridad
        {
            private Button boton;

            public BotonSeguridad(Button boton)
            {
                this.boton = boton;
            }

            public void MostrarElemento(string rol)
            {
                // Lógica para mostrar/ocultar el botón según el rol
                if (rol == "Administrador")
                {
                    boton.Visible = true;
                }
                else
                {
                    boton.Enabled = false;
                }
            }
        }


        public class PanelSeguridad : Panel, IComponenteSeguridad
        {
            private Panel panel;

            public PanelSeguridad(Panel panel)
            {
                this.panel = panel;
            }

            public void MostrarElemento(string rol)
            {
                // Lógica para mostrar/ocultar el panel según el rol
                if (rol == "Administrador" || rol == "Empleado")
                {
                    panel.Visible = true;
                }
                else
                {
                    panel.Enabled = false;
                }
            }
        }

        private void btnDonacion_Click(object sender, EventArgs e)
        {
            Donaciones donacionForm = new Donaciones();
            donacionForm.DashboardInstance = this;
            AbrirFormHijo(donacionForm);
        }

        private void btnRecoleccion_Click(object sender, EventArgs e)
        {
            Recolecciones recoleccionForm = new Recolecciones();
            recoleccionForm.DashboardInstance = this;
            AbrirFormHijo(recoleccionForm);
        }

        private void btnGestionarUsuario_Click(object sender, EventArgs e)
        {
            GestionarUsuario gestusuarioForm = new GestionarUsuario();
            gestusuarioForm.DashboardInstance = this;
            AbrirFormHijo(gestusuarioForm);
        }

        private void btnReproduccion_Click(object sender, EventArgs e)
        {
            Reproduccion reproduccionForm = new Reproduccion();
            reproduccionForm.DashboardInstance = this;
            AbrirFormHijo(reproduccionForm);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            Clientes clientesForm = new Clientes();
            clientesForm.DashboardInstance = this;
            AbrirFormHijo(clientesForm);
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            Ventas ventasForm = new Ventas();
            ventasForm.DashboardInstance = this;
            AbrirFormHijo(ventasForm);
        }
    }
}
