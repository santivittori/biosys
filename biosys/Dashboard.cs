using Entidad;
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
        private Control[] controles;

        public Dashboard(string rol, string nombreUsuario)
        {
            InitializeComponent();
            this.rol = rol;
            lblUsuario.Text = "Usuario: " + nombreUsuario;
            lblRol.Text = "Rol: " + rol;
            controles = GetAllControls(this);

            // Habilitar o deshabilitar los controles según los permisos del usuario
            HabilitarControlesSegunPermisos();
        }

        // Sirve para poder mover la ventana con el mouse
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private Control[] GetAllControls(Control control)
        {
            var controlsList = new List<Control>();

            foreach (Control ctrl in control.Controls)
            {
                controlsList.Add(ctrl);
                controlsList.AddRange(GetAllControls(ctrl));
            }

            return controlsList.ToArray();
        }

        private void HabilitarControlesSegunPermisos()
        {
            var permisosUsuario = Controladora.Controladora.ObtenerPermisosPorRol(rol);

            foreach (var control in controles)
            {
                // Habilitar todos los controles por defecto
                control.Enabled = true;

                // Verificar si el control tiene un tag y si el tag no está presente en los permisos del usuario
                if (control.Tag != null && !permisosUsuario.Contains(control.Tag.ToString()))
                {
                    // Si el tag del control no está presente en los permisos del usuario, deshabilitar el control
                    control.Enabled = false;
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea salir de la aplicación?", "Cerrar y Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Controladora.Controladora.RegistrarAuditoria(UsuarioActual.UsuarioLogueado.NombreUsuario, "Cerró sesión");

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
            DialogResult result = MessageBox.Show("¿Desea cerrar sesión?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
            // Si la respuesta es correcta , cerrar sesión
            if (result == DialogResult.Yes)
            {
                // Registrar cierre de sesión en la auditoría
                Controladora.Controladora.RegistrarAuditoria(UsuarioActual.UsuarioLogueado.NombreUsuario, "Cerró sesión");

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

            // Verificar si el usuario es administrador y ha pasado una semana desde el último respaldo
            if (UsuarioActual.UsuarioLogueado.NombreUsuario == "admin" && Controladora.Controladora.HaPasadoUnaSemanaDesdeUltimoRespaldo())
            {
                // Esperar hasta que el formulario Dashboard se muestre completamente
                this.Shown += (s, ev) =>
                {
                    // Mostrar mensaje emergente instando al usuario a realizar el respaldo
                    DialogResult result = MessageBox.Show("¡Es hora de realizar un respaldo del sistema!\n\n¿Desea realizarlo ahora?",
                                                           "Recordatorio de respaldo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    // Si el usuario confirma, abrir el formulario de respaldo
                    if (result == DialogResult.Yes)
                    {
                        Backup backupForm = new Backup();
                        backupForm.DashboardInstance = this;
                        AbrirFormHijo(backupForm);
                    }
                };
            }
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

        private void btnBajaProductos_Click(object sender, EventArgs e)
        {
            BajaProductos bajaProdForm = new BajaProductos();
            bajaProdForm.DashboardInstance = this;
            AbrirFormHijo(bajaProdForm);
        }

        private void btnGestionarPrecios_Click(object sender, EventArgs e)
        {
            GestionarPrecios gestionarPreciosForm = new GestionarPrecios();
            gestionarPreciosForm.DashboardInstance = this;
            AbrirFormHijo(gestionarPreciosForm);
        }

        private void btnAuditoria_Click(object sender, EventArgs e)
        {
            Auditoria auditoriaForm = new Auditoria();
            auditoriaForm.DashboardInstance = this;
            AbrirFormHijo(auditoriaForm);
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            Backup backupForm = new Backup();
            backupForm.DashboardInstance = this;
            AbrirFormHijo(backupForm);
        }
    }
}
