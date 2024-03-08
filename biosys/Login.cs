using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using biosys;
using Controladora;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using COMUN;
using System.Configuration;
using Entidad;

namespace biosys
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        // Diseño para nombrar los campos de Usurio y Contraseña
        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "CONTRASEÑA")
            {
                txtContraseña.Text = "";
                txtContraseña.ForeColor = Color.LightGray;
                txtContraseña.UseSystemPasswordChar = true;
            }
        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "")
            {
                txtContraseña.Text = "CONTRASEÑA";
                txtContraseña.ForeColor = Color.DimGray;
                txtContraseña.UseSystemPasswordChar = false;
            }
        }
        // Arrastrar y soltar para mover la ventana del form
        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // Cierra la aplicación
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Minimiza la aplicación
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Inicia sesión
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtUsuario.Text;
            string clave = txtContraseña.Text;

            // Cifrar la contraseña utilizando un algoritmo de cifrado seguro, como SHA256
            string claveCifrada = GetHash(clave);

            // Verificar la autenticación del usuario en la base de datos
            if (Controladora.Controladora.VerificarAutenticacion(nombreUsuario, claveCifrada))
            {
                // Obtener el rol y el correo electrónico del usuario desde la base de datos
                string rol = Controladora.Controladora.ObtenerRolUsuario(nombreUsuario);
                string correoElectronico = Controladora.Controladora.ObtenerCorreoUsuario(nombreUsuario);

                // Verificar si el rol del usuario está habilitado
                if (Controladora.Controladora.VerificarRolHabilitado(rol))
                {
                    // Verificar si el usuario está habilitado
                    if (Controladora.Controladora.VerificarUsuarioHabilitado(nombreUsuario))
                    {
                        // Guardar la información del usuario logueado
                        UsuarioActual.UsuarioLogueado = new Usuario { NombreUsuario = nombreUsuario, Rol = rol, Email = correoElectronico };

                        // Cerrar el formulario actual (Login)
                        this.Hide();

                        // Mostrar el formulario principal (Dashboard) según el rol del usuario
                        Dashboard root = new Dashboard(rol, nombreUsuario);
                        root.ShowDialog();
                    }
                    else
                    {
                        // Mostrar mensaje indicando que el usuario está deshabilitado
                        msgError("Su cuenta de usuario ha sido deshabilitada. No puede iniciar sesión.");
                    }
                }
                else
                {
                    // Mostrar mensaje indicando que el rol está deshabilitado
                    msgError("Su rol ha sido deshabilitado. No puede iniciar sesión.");
                }
            }
            else
            {
                msgError("Nombre de usuario o contraseña incorrectos");
            }
        }

        // Método para cifrar la contraseña utilizando SHA256
        private string GetHash(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        // Boton para registrarse
        private void btnRegistro_Click(object sender, EventArgs e)
        {
            panelVerficacion.Visible = true;
        }
        // Metodo para mensajes de error
        public void msgError(string msg)
        {
            lblError.Text = "      " + msg;
            lblError.Visible = true;
        }
        // Botones para ver y ocultar la clave
        private void btnOjo_Click(object sender, EventArgs e)
        {
            txtContraseña.UseSystemPasswordChar = true;
            btnOjo.Visible = false;
            btnOjoCerrado.Visible = true;
        }
        private void btnOjoCerrado_Click(object sender, EventArgs e)
        {
            if (txtContraseña.Text != "CONTRASEÑA" && txtContraseña.Text != "")
            {
                txtContraseña.UseSystemPasswordChar = false;
                btnOjoCerrado.Visible = false;
                btnOjo.Visible = true;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            btnOjoCerrado.Visible = true;
            panelVerficacion.Visible = false;
        }
        // Borrar y mostrar el valor del campo por defecto
        private void txtUsuario_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtContraseña.Text == "CONTRASEÑA")
            {
                btnOjo.Visible = false;
                btnOjoCerrado.Visible = true;
            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Length > 59)
            {
                txtUsuario.Text = txtUsuario.Text.Substring(0, 60);
                txtUsuario.SelectionStart = 60; // Establece el cursor al final del texto.
                msgError("No se pueden ingresar mas caracteres");
            }
        }
        // Abre form para crear una nueva clave
        private void lblOlvidoClave_Click(object sender, EventArgs e)
        {
            RecuperarClave recuperarclave = new RecuperarClave();
            this.Hide();
            recuperarclave.ShowDialog();
        }

        private void btnConfirmarCodigo_Click(object sender, EventArgs e)
        {
            string codigoVerificacionIngresado = txtCodigoVerificacion.Text;

            // Verificar el código de verificación ingresado
            if (codigoVerificacionIngresado == ConfigurationManager.AppSettings["CodigoVerificacion"])
            {
                Registro registro = new Registro();
                this.Hide();
                registro.comborol.Enabled = true;
                registro.ShowDialog();
            }
            else if (codigoVerificacionIngresado == "CÓDIGO DE VERIFICACIÓN")
            {
                msgError("Ingrese el código de verificación primero.");
            }
            else
            {
                msgError("El código de verificación ingresado es incorrecto.");
            }
        }

        private void btnSinCodigo_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro();
            this.Hide();
            registro.comborol.SelectedIndex = registro.comborol.Items.IndexOf("Empleado");
            registro.comborol.Enabled = false;
            registro.ShowDialog();
        }

        private void txtCodigoVerificacion_Enter(object sender, EventArgs e)
        {
            if (txtCodigoVerificacion.Text == "CÓDIGO DE VERIFICACIÓN")
            {
                txtCodigoVerificacion.Text = "";
                txtCodigoVerificacion.ForeColor = Color.LightGray;
            }
        }

        private void txtCodigoVerificacion_Leave(object sender, EventArgs e)
        {
            if (txtCodigoVerificacion.Text == "")
            {
                txtCodigoVerificacion.Text = "CÓDIGO DE VERIFICACIÓN";
                txtCodigoVerificacion.ForeColor = Color.DimGray;
            }
        }

        private void txtCodigoVerificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e = MetodosComunes.KeyPressSoloNumeros(e);

            if (e.Handled)
            {
                e.Handled = true;
            }
        }
    }
}