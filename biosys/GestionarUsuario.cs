using COMUN;
using Entidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace biosys
{
    public partial class GestionarUsuario : Form
    {
        public Dashboard DashboardInstance { get; set; }

        public GestionarUsuario()
        {
            InitializeComponent();
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
        private void btnAltaUsuario_Click(object sender, EventArgs e)
        {
            // Verificar campos vacíos
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtContraseña.Text) || comborol.SelectedItem == null)
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

                MessageBox.Show("El usuario se dió de alta exitosamente", "Alta de usuario exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtUsuario.Text = string.Empty;
                txtContraseña.Text = string.Empty;
                txtEmail.Text = string.Empty;
                comborol.SelectedIndex = -1;
                lblError.Visible = false;

                CargarUsuariosEnDataGridView();
            }
        }
        private void CargarUsuariosEnDataGridView()
        {
            DataTable dataTable = Controladora.Controladora.ObtenerUsuarios();
            dataGridViewUsuarios.DataSource = dataTable;
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
            if (txtContraseña.Text != "")
            {
                txtContraseña.UseSystemPasswordChar = false;
                btnOjoCerrado.Visible = false;
                btnOjo.Visible = true;
            }
        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "")
            {
                txtContraseña.UseSystemPasswordChar = true;
            }
        }
        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "")
            {
                txtContraseña.UseSystemPasswordChar = false;
            }
        }
        private void txtUsuario_Click(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "")
            {
                btnOjo.Visible = false;
                btnOjoCerrado.Visible = true;
            }
        }
        private void txtEmail_Click(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "")
            {
                btnOjo.Visible = false;
                btnOjoCerrado.Visible = true;
            }
        }
        private void GestionarUsuario_Load(object sender, EventArgs e)
        {
            CargarUsuariosEnDataGridView();
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

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            // Verificar si se seleccionó una fila en el DataGridView
            if (dataGridViewUsuarios.SelectedRows.Count > 0)
            {
                // Obtener el ID del proveedor seleccionado
                int idUsuario = Convert.ToInt32(dataGridViewUsuarios.SelectedRows[0].Cells["ID"].Value);

                // Eliminar el usuario de la base de datos
                Controladora.Controladora.EliminarUsuario(idUsuario);

                // Mostrar mensaje de éxito y actualizar el DataGridView
                MessageBox.Show("Usuario eliminado exitosamente.", "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarUsuariosEnDataGridView();
            }
            else
            {
                msgError("Debe seleccionar una fila en el DataGridView para eliminar.");
                return;
            }
        }
    }
}
