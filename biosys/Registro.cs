using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using Controladora;
using COMUN;
using Entidad;

namespace biosys
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
            CargarRolesDisponibles();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        // Diseño para nombrar los campos de Usurio, Contraseña y Email
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
        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "EMAIL")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.LightGray;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "EMAIL";
                txtEmail.ForeColor = Color.DimGray;
            }
        }
        private void Registro_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // Vuelve al login
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Show();
        }

        // Minimiza la aplicación
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        // Crea el usuario y lo guarda en la base de datos
        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            // Verificar campos vacíos
            if (txtUsuario.Text == "USUARIO" || txtContraseña.Text == "CONTRASEÑA" || comborol.SelectedItem == null)
            {
                msgError("Por favor, complete todos los campos.");
                return;
            }

            string nombreUsuario = txtUsuario.Text;
            string clave = GetHash(txtContraseña.Text);
            string rol = comborol.SelectedItem.ToString();
            string email = txtEmail.Text;

            // Verificar existencia de usuario
            if (Controladora.Controladora.VerificarExistenciaUsuario(nombreUsuario))
            {
                msgError("El nombre de usuario ya existe. Por favor, elija otro.");
                return;
            }

            bool esValido = MetodosComunes.ValidacionEMAIL(null, email);

            if (!esValido)
            {
                msgError("Debe ingresar un email válido, por favor verifíquelo.");
                return;
            }
            else if (Controladora.Controladora.VerificarExistenciaEmail(email))
            {
                msgError("El email ya está registrado. Por favor, use otro email.");
                return;
                
            }
            else
            {
                // Crear el objeto Usuario con los datos del nuevo usuario
                Usuario usuario = new Usuario
                {
                    NombreUsuario = nombreUsuario,
                    Clave = clave,
                    Rol = rol,
                    Email = email
                };

                // Guardar el nuevo usuario en la base de datos
                Controladora.Controladora.GuardarNuevoUsuario(usuario);

                MessageBox.Show("Usuario registrado exitosamente", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cerrar el formulario actual (Registro)
                this.Close();

                // Abrir el formulario de inicio de sesión (Login)
                Login login = new Login();
                login.Show();
            }
        }

        public void msgError(string msg)
        {
            lblError.Text = "      " + msg;
            lblError.Visible = true;
        }

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

        private void txtUsuario_Click(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "CONTRASEÑA")
            {
                btnOjo.Visible = false;
                btnOjoCerrado.Visible = true;
            }
        }
        private void txtEmail_Click(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "CONTRASEÑA")
            {
                btnOjo.Visible = false;
                btnOjoCerrado.Visible = true;
            }
        }
        private void Registro_Load(object sender, EventArgs e)
        {
            btnOjoCerrado.Visible = true;
            btnOjo.Visible = false;
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

        // Método para cargar los roles disponibles en el ComboBox
        private void CargarRolesDisponibles()
        {
            List<string> rolesDisponibles = Controladora.Controladora.ObtenerRolesDisponibles();
            comborol.DataSource = rolesDisponibles;
        }
    }   
}