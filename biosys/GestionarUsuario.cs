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
using SendGrid;
using SendGrid.Helpers.Mail;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace biosys
{
    public partial class GestionarUsuario : Form
    {
        public Dashboard DashboardInstance { get; set; }

        private int paginaActual = 1;
        private int tamañoPagina = 8;

        public GestionarUsuario()
        {
            InitializeComponent();

            dataGridViewUsuarios.SelectionChanged += dataGridViewUsuarios_SelectionChanged;

            // Deshabilitar la fila de agregar automáticamente en el DataGridView
            dataGridViewUsuarios.AllowUserToAddRows = false;

            CargarRolesDisponibles();
        }

        private async void btnAltaUsuario_Click(object sender, EventArgs e)
        {
            // Verificar campos vacíos
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || comborol.SelectedItem == null)
            {
                msgError("Por favor, complete todos los campos.");
                return;
            }

            string nombreUsuario = txtUsuario.Text;
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
                    Clave = string.Empty,
                    Rol = rol,
                    Email = email
                };

                // Guardar el nuevo usuario en la base de datos
                Controladora.Controladora.GuardarNuevoUsuario(usuario);

                // Obtener la API Key de Twilio SendGrid desde una variable de entorno
                string apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");

                // Verificar si la API Key se ha configurado correctamente
                if (string.IsNullOrEmpty(apiKey))
                {
                    MessageBox.Show("La API Key de Twilio SendGrid no ha sido configurada correctamente. Por favor, verifique la configuración del entorno.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Crear el cliente de Twilio SendGrid utilizando la API Key
                SendGridClient client = new SendGridClient(apiKey);
                string remitente = "soportebiosys@gmail.com";
                string asunto = "Alta de usuario";

                string contenidoHTML = $"<p>Estimado {nombreUsuario},</p>" +
                                       "<p>Le informamos que su cuenta ha sido creada exitosamente.</p>" +
                                       $"<p>Nombre de usuario: {nombreUsuario}</p>" +
                                       "<p>Deberá crear su clave para poder iniciar sesión.</p>" +
                                       "<p>Esto lo puede hacer utilizando la opción 'Olvidé mi contraseña' en la pantalla de inicio de sesión y seguir los pasos.</p>" +
                                       "<br>" +
                                       "<p>Atentamente,</p>" +
                                       "<p>Equipo de Soporte</p>";

                EmailAddress from = new EmailAddress(remitente);
                EmailAddress to = new EmailAddress(email);
                SendGridMessage message = MailHelper.CreateSingleEmail(from, to, asunto, "", contenidoHTML);

                try
                {
                    Response response = await client.SendEmailAsync(message);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Accepted)
                    {
                        DialogResult result = MessageBox.Show($"El usuario se dió de alta exitosamente.\n\nSe envió un correo a {email} con el aviso de alta de usuario.", "Alta de usuario y envió de mail", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (result == DialogResult.OK)
                        {
                            CargarUsuariosEnDataGridView();

                            txtUsuario.Text = string.Empty;
                            txtEmail.Text = string.Empty;
                            comborol.SelectedIndex = -1;
                            lblError.Visible = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hubo un problema al enviar el correo. Por favor, inténtelo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Hubo un problema al enviar el correo. Por favor, inténtelo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void msgError(string msg)
        {
            lblError.Text = "      " + msg;
            lblError.Visible = true;
        }

        private void GestionarUsuario_Load(object sender, EventArgs e)
        {
            CargarUsuariosEnDataGridView();

            // Calcular la posición x para centrar el Label horizontalmente
            int labelPosX = (this.ClientSize.Width - labelTitulo.Width) / 2;

            // Establecer la posición del Label
            labelTitulo.Location = new Point(labelPosX, 50);
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
        private void dataGridViewUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewUsuarios.SelectedRows.Count > 0)
            {
                // Obtener los datos del usuario seleccionado
                int idUsuario = Convert.ToInt32(dataGridViewUsuarios.SelectedRows[0].Cells["ID"].Value);
                Usuario usuario = Controladora.Controladora.ObtenerUsuarioPorId(idUsuario);

                // Llenar los campos del formulario con los datos del usuario
                txtUsuario.Text = usuario.NombreUsuario;
                comborol.SelectedItem = usuario.Rol;
                txtEmail.Text = usuario.Email;

                txtUsuario.Enabled = true;
                comborol.Enabled = true;
                txtEmail.Enabled = true;
            }
        }

        private async void EnviarCorreoNotificacion(Usuario usuario, string correoElectronicoAnterior)
        {
            // Obtener el nuevo correo electrónico del usuario
            string nuevoCorreoElectronico = txtEmail.Text;

            // Verificar si el correo electrónico ha cambiado
            if (nuevoCorreoElectronico != correoElectronicoAnterior)
            {
                // El correo electrónico ha cambiado, verifica si ya existe en la base de datos
                if (Controladora.Controladora.VerificarExistenciaEmail(nuevoCorreoElectronico))
                {
                    MessageBox.Show("El nuevo correo electrónico ya está registrado. Por favor, use otro correo electrónico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Obtener la API Key de Twilio SendGrid desde una variable de entorno
            string apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");

            // Verificar si la API Key se ha configurado correctamente
            if (string.IsNullOrEmpty(apiKey))
            {
                MessageBox.Show("La API Key de Twilio SendGrid no ha sido configurada correctamente. Por favor, verifique la configuración del entorno.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear el cliente de Twilio SendGrid utilizando la API Key
            SendGridClient client = new SendGridClient(apiKey);
            string remitente = "soportebiosys@gmail.com";
            string asunto = "Modificación de usuario";
            // Configura el contenido del correo
            string contenidoHTML = $"<p>Estimado {usuario.NombreUsuario},</p>" +
                                   "<p>Le informamos que su cuenta ha sido modificada.</p>" +
                                   $"<p>Nombre de usuario: {usuario.NombreUsuario}</p>" +
                                   $"<p>Rol: {usuario.Rol}</p>" +
                                   "<p>Su contraseña sigue siendo la misma que tenía anteriormente.</p>" +
                                   "<p>Si desea cambiarla, puede hacerlo en la sección 'Olvidé mi contraseña' antes de iniciar sesión.</p>" +
                                   "<br>" +
                                   "<p>Atentamente,</p>" +
                                   "<p>Equipo de Soporte</p>";

            EmailAddress from = new EmailAddress(remitente);
            EmailAddress to = new EmailAddress(nuevoCorreoElectronico);
            SendGridMessage message = MailHelper.CreateSingleEmail(from, to, asunto, "", contenidoHTML);

            try
            {
                Response response = await client.SendEmailAsync(message);
                if (response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    DialogResult result = MessageBox.Show($"El usuario se modificó exitosamente.\n\nSe envió un correo a {nuevoCorreoElectronico} con el aviso de modificación.", "Modificación de usuario y envió de mail", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (result == DialogResult.OK)
                    {
                        CargarUsuariosEnDataGridView();

                        txtUsuario.Text = string.Empty;
                        txtEmail.Text = string.Empty;
                        comborol.SelectedIndex = -1;
                        lblError.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Hubo un problema al enviar el correo. Por favor, inténtelo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hubo un problema al enviar el correo. Por favor, inténtelo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            string criterioBusqueda = txtBusqueda.Text;
            FiltrarUsuariosPorNombreOEmail(criterioBusqueda);
        }

        private void FiltrarUsuariosPorNombreOEmail(string criterioBusqueda)
        {
            // Verificar si el campo de búsqueda no está vacío
            if (string.IsNullOrWhiteSpace(criterioBusqueda))
            {
                // Si está vacío, mostrar todos los usuarios
                CargarUsuariosEnDataGridView();
            }
            else
            {
                DataTable dataTable = Controladora.Controladora.ObtenerUsuarios();
                dataTable.DefaultView.RowFilter = $"Nombre LIKE '%{criterioBusqueda}%' OR Email LIKE '%{criterioBusqueda}%'";
                dataGridViewUsuarios.DataSource = dataTable;
            }
        }

        private void CargarUsuariosEnDataGridView()
        {
            int indiceInicio = (paginaActual - 1) * tamañoPagina;
            DataTable dataTable = Controladora.Controladora.ObtenerUsuariosPaginados(indiceInicio, tamañoPagina);
            dataGridViewUsuarios.DataSource = dataTable;
            dataGridViewUsuarios.CellFormatting += dataGridViewUsuarios_CellFormatting;
            MostrarInformacionPaginacion();
        }

        private void MostrarInformacionPaginacion()
        {
            int totalUsuarios = Controladora.Controladora.ObtenerCantidadTotalUsuarios();
            int totalPaginas = (int)Math.Ceiling((double)totalUsuarios / tamañoPagina);
            labelPaginacion.Text = $"Página {paginaActual} de {totalPaginas}. Total de usuarios: {totalUsuarios}";
        }

        private void btnPaginaAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--;
                CargarUsuariosEnDataGridView();
            }
        }

        private void btnPaginaSiguiente_Click(object sender, EventArgs e)
        {
            int totalPaginas = (int)Math.Ceiling((double)Controladora.Controladora.ObtenerCantidadTotalUsuarios() / tamañoPagina);
            if (paginaActual < totalPaginas)
            {
                paginaActual++;
                CargarUsuariosEnDataGridView();
            }
        }

        // Método para cargar los roles disponibles en el ComboBox
        private void CargarRolesDisponibles()
        {
            List<string> rolesDisponibles = Controladora.Controladora.ObtenerRolesDisponibles();
            comborol.DataSource = rolesDisponibles;
        }

        private void dataGridViewUsuarios_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewUsuarios.ClearSelection();
        }

        private void btnRolesyPermisos_Click(object sender, EventArgs e)
        {
            RolesPermisos rolesPermisosForm = new RolesPermisos();
            rolesPermisosForm.DashboardInstance = DashboardInstance;
            DashboardInstance.AbrirFormHijo(rolesPermisosForm);
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = string.Empty;
            txtEmail.Text = string.Empty;
            comborol.SelectedIndex = -1;

            // Habilitar todos los campos
            txtUsuario.Enabled = true;
            comborol.Enabled = true;
            txtEmail.Enabled = true;
            lblError.Visible = false;
        }

        private void btnGuardarEdicion_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsuarios.SelectedRows.Count > 0)
            {
                // Obtener los datos del usuario seleccionado
                int idUsuario = Convert.ToInt32(dataGridViewUsuarios.SelectedRows[0].Cells["ID"].Value);
                Usuario usuario = Controladora.Controladora.ObtenerUsuarioPorId(idUsuario);

                // Guarda el valor actual del correo electrónico en una variable
                string correoElectronicoAnterior = usuario.Email;

                // Actualizar los datos del usuario con los valores de los campos editados
                usuario.NombreUsuario = txtUsuario.Text;
                usuario.Rol = comborol.SelectedItem.ToString();
                usuario.Email = txtEmail.Text;

                // Guardar los cambios en la base de datos
                Controladora.Controladora.ActualizarUsuario(usuario);

                txtUsuario.Enabled = false;
                comborol.Enabled = false;
                txtEmail.Enabled = false;

                // Actualiza el DataGridView
                CargarUsuariosEnDataGridView();

                // Envía un correo al usuario notificando los cambios
                EnviarCorreoNotificacion(usuario, correoElectronicoAnterior);

                lblError.Visible = false;

                MessageBox.Show("Usuario editado exitosamente.", "Edición exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                msgError("Debe seleccionar una fila en el DataGridView para editar un usuario.");
            }
        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            // Verificar si se seleccionó una fila en el DataGridView
            if (dataGridViewUsuarios.SelectedRows.Count > 0)
            {
                // Obtener el ID del usuario seleccionado
                int idUsuario = Convert.ToInt32(dataGridViewUsuarios.SelectedRows[0].Cells["ID"].Value);

                // Obtener el correo electrónico del usuario que está actualmente logueado
                string correoUsuarioLogueado = Entidad.UsuarioActual.UsuarioLogueado.Email;

                // Obtener el correo electrónico del usuario que se intenta eliminar
                string correoUsuarioAEliminar = Controladora.Controladora.ObtenerCorreoUsuarioAEliminar(idUsuario);

                // Verificar si el usuario ha sido utilizado en alguna compra
                bool usuarioUtilizadoEnCompras = Controladora.Controladora.UsuarioUtilizadoEnCompras(idUsuario);

                // Verificar si el usuario ha sido utilizado en alguna venta
                bool usuarioUtilizadoEnVentas = Controladora.Controladora.UsuarioUtilizadoEnVentas(idUsuario);

                // Comparar los correos electrónicos
                if (correoUsuarioAEliminar == correoUsuarioLogueado)
                {
                    // No permitir eliminar al usuario logueado
                    MessageBox.Show("No puedes eliminar al usuario con el que has iniciado sesión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (usuarioUtilizadoEnCompras)
                {
                    // No permitir eliminar al usuario si ha sido utilizado en compras
                    MessageBox.Show("No puedes eliminar un usuario que ha sido utilizado en el sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (usuarioUtilizadoEnVentas)
                {
                    // No permitir eliminar al usuario si ha sido utilizado en ventas
                    MessageBox.Show("No puedes eliminar un usuario que ha sido utilizado en el sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Mostrar un cuadro de diálogo de confirmación
                    DialogResult result = MessageBox.Show("¿Está seguro/a de que desea eliminar este usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // Si el usuario confirma la eliminación
                    if (result == DialogResult.Yes)
                    {
                        // Eliminar el usuario de la base de datos
                        Controladora.Controladora.EliminarUsuario(idUsuario);

                        // Mostrar mensaje de éxito y actualizar el DataGridView
                        MessageBox.Show("Usuario eliminado exitosamente.", "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarUsuariosEnDataGridView();
                        btnLimpiarCampos.PerformClick();
                    }
                }
            }
            else
            {
                msgError("Debe seleccionar una fila en el DataGridView para eliminar.");
                return;
            }
        }

        private void btnAltaUsuario_MouseEnter(object sender, EventArgs e)
        {
            btnAltaUsuario.BackColor = Color.FromArgb(0, 192, 0);
        }

        private void btnAltaUsuario_MouseLeave(object sender, EventArgs e)
        {
            btnAltaUsuario.BackColor = Color.White;
        }

        private void btnEliminarUsuario_MouseEnter(object sender, EventArgs e)
        {
            btnEliminarUsuario.BackColor = Color.Red;
        }

        private void btnEliminarUsuario_MouseLeave(object sender, EventArgs e)
        {
            btnEliminarUsuario.BackColor = Color.White;
        }

        private void btnGuardarEdicion_MouseEnter(object sender, EventArgs e)
        {
            btnGuardarEdicion.BackColor = Color.FromArgb(0, 192, 0);
        }

        private void btnGuardarEdicion_MouseLeave(object sender, EventArgs e)
        {
            btnGuardarEdicion.BackColor = Color.White;
        }

        private void btnHabilitarUsuario_MouseEnter(object sender, EventArgs e)
        {
            btnHabilitarUsuario.BackColor = Color.Yellow;
        }

        private void btnHabilitarUsuario_MouseLeave(object sender, EventArgs e)
        {
            btnHabilitarUsuario.BackColor = Color.White;
        }

        private void btnHabilitarUsuario_Click(object sender, EventArgs e)
        {
            // Verificar si se seleccionó una fila en el DataGridView
            if (dataGridViewUsuarios.SelectedRows.Count > 0)
            {
                // Obtener el ID del usuario seleccionado
                int idUsuario = Convert.ToInt32(dataGridViewUsuarios.SelectedRows[0].Cells["ID"].Value);

                // Obtener el correo electrónico del usuario que está actualmente logueado
                string correoUsuarioLogueado = UsuarioActual.UsuarioLogueado.Email;

                // Obtener el correo electrónico del usuario que se intenta deshabilitar
                string correoUsuarioADeshabilitar = Controladora.Controladora.ObtenerCorreoUsuarioPorID(idUsuario);

                // Comparar los correos electrónicos
                if (correoUsuarioADeshabilitar == correoUsuarioLogueado)
                {
                    // No permitir deshabilitar al usuario logueado
                    MessageBox.Show("No puedes deshabilitar al usuario con el que has iniciado sesión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Mostrar un cuadro de diálogo de confirmación
                    string mensaje = "¿Está seguro/a de que desea ";
                    mensaje += Controladora.Controladora.VerificarUsuarioHabilitadoPorID(idUsuario) ? "deshabilitar" : "habilitar";
                    mensaje += " este usuario?";

                    DialogResult result = MessageBox.Show(mensaje, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // Si el usuario confirma la acción
                    if (result == DialogResult.Yes)
                    {
                        // Obtener el estado actual del usuario
                        bool usuarioHabilitado = Controladora.Controladora.VerificarUsuarioHabilitadoPorID(idUsuario);

                        // Invertir el estado del usuario
                        bool nuevoEstadoUsuario = !usuarioHabilitado;

                        // Actualizar el estado del usuario en la base de datos
                        bool actualizacionExitosa = Controladora.Controladora.ActualizarEstadoUsuarioPorID(idUsuario, nuevoEstadoUsuario);

                        if (actualizacionExitosa)
                        {
                            // Mostrar mensaje de éxito y actualizar el DataGridView
                            if (nuevoEstadoUsuario)
                            {
                                MessageBox.Show("Usuario habilitado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Usuario deshabilitado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            btnLimpiarCampos.PerformClick();
                            // Actualizar el DataGridView
                            CargarUsuariosEnDataGridView();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo cambiar el estado del usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                msgError("Debe seleccionar una fila en el DataGridView para habilitar o deshabilitar un usuario.");
                return;
            }
        }

        private void dataGridViewUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verificar si la celda actual es de la columna "NombreUsuario" y si hay datos en la fila
            if (e.ColumnIndex == dataGridViewUsuarios.Columns[0].Index && e.RowIndex >= 0)
            {
                // Obtener el ID del usuario de la celda actual
                int idUsuario = Convert.ToInt32(dataGridViewUsuarios.Rows[e.RowIndex].Cells["ID"].Value);

                // Verificar si el usuario está habilitado
                if (!Controladora.Controladora.VerificarUsuarioHabilitadoPorID(idUsuario))
                {
                    // Cambiar el color de fondo de la fila a amarillo para indicar que el usuario está deshabilitado
                    dataGridViewUsuarios.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;

                    // Agregar un tooltip que explique por qué el usuario está inhabilitado
                    dataGridViewUsuarios.Rows[e.RowIndex].Cells[0].ToolTipText = "Este usuario está inhabilitado actualmente.";
                }
                else
                {
                    // Limpiar el tooltip si el usuario está habilitado
                    dataGridViewUsuarios.Rows[e.RowIndex].Cells[0].ToolTipText = "";
                }
            }
        }
    }
}
