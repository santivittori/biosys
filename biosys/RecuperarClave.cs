using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMUN;
using Controladora;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace biosys
{
    public partial class RecuperarClave : Form
    {
        private string codigoVerificacion;

        public RecuperarClave()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        // Diseño para nombrar los campos de Email, Codigo verificación y Contraseña nueva
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
        private void txtContraseñaNueva_Enter(object sender, EventArgs e)
        {
            if (txtContraseñaNueva.Text == "CONTRASEÑA NUEVA")
            {
                txtContraseñaNueva.Text = "";
                txtContraseñaNueva.ForeColor = Color.LightGray;
                txtContraseñaNueva.UseSystemPasswordChar = true;
            }
        }
        private void txtContraseñaNueva_Leave(object sender, EventArgs e)
        {
            if (txtContraseñaNueva.Text == "")
            {
                txtContraseñaNueva.Text = "CONTRASEÑA NUEVA";
                txtContraseñaNueva.ForeColor = Color.DimGray;
                txtContraseñaNueva.UseSystemPasswordChar = false;
            }
        }
        private void txtCodVerificacion_Enter(object sender, EventArgs e)
        {
            if (txtCodVerificacion.Text == "CÓDIGO DE VERIFICACIÓN")
            {
                txtCodVerificacion.Text = "";
                txtCodVerificacion.ForeColor = Color.LightGray;
            }
        }
        private void txtCodVerificacion_Leave(object sender, EventArgs e)
        {
            if (txtCodVerificacion.Text == "")
            {
                txtCodVerificacion.Text = "CÓDIGO DE VERIFICACIÓN";
                txtCodVerificacion.ForeColor = Color.DimGray;
            }
        }
        private void RecuperarClave_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Show();
        }
        private void RecuperarClave_Load(object sender, EventArgs e)
        {
            txtCodVerificacion.Visible = false;
            txtContraseñaNueva.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            btnOjo.Visible = false;
            btnGuardarClave.Visible = false;
            btnVerificarCod.Visible = false;
            btnOjoCerrado.Visible = false;
        }
        // Verfica el email en la base de datos. Si lo encuentra manda el mail con el código
        private async void btnVerificarEmail_Click(object sender, EventArgs e)
        {
            // Verificar campos vacíos
            if (txtEmail.Text == "EMAIL")
            {
                msgError("Por favor, complete todos los campos.");
                return;
            }

            string email = txtEmail.Text;

            bool esValido = MetodosComunes.ValidacionEMAIL(null, email);

            if (!esValido)
            {
                msgError("Debe ingresar un email válido, por favor verifíquelo.");
                return;
            }

            // Verificar existencia de email
            if (Controladora.Controladora.VerificarEmailExistente(email))
            {
                codigoVerificacion = Controladora.Controladora.GenerarCodigoVerificacion();
                
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
                string asunto = "Recuperación de contraseña";

                string contenidoHTML = "<p>Estimado usuario,</p>" +
                                       "<p>Recibimos una solicitud para restablecer la contraseña de su cuenta.</p>" +
                                       "<p>Para completar el proceso de recuperación, ingrese el siguiente código de verificación:</p>" +
                                       "<p><strong>Código de Verificación:</strong> " + codigoVerificacion + "</p>" +
                                       "<p>Una vez que haya ingresado el código de verificación, podrá establecer una nueva contraseña.</p>" +
                                       "<p>Si no realizó esta solicitud, ignore este mensaje y su contraseña no cambiará.</p>" +
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
                        DialogResult result = MessageBox.Show("Se envió un correo a su casilla, por favor veríquela para obtener el código.", "Email enviado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (result == DialogResult.OK)
                        {
                            btnVerificarEmail.Enabled = false;
                            txtEmail.Enabled = false;
                            txtCodVerificacion.Visible = true;
                            btnVerificarCod.Visible = true;
                            pictureBox3.Visible = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hubo un problema al enviar el correo. Por favor, inténtelo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un problema al enviar el correo. Por favor, inténtelo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                msgError("El email ingresado no se encontró. Verifique e intente nuevamente.");
                return;
            }
        }

        public void msgError(string msg)
        {
            lblError.Text = "      " + msg;
            lblError.Visible = true;
        }
        // Verifica que el codigo sea el mismo que el enviado en el email
        private void btnVerificarCod_Click(object sender, EventArgs e)
        {
            string codigoIngresado = txtCodVerificacion.Text.Trim();

            // Verificar si el código ingresado coincide con el código de verificación generado
            if (codigoIngresado == codigoVerificacion)
            {
                // Habilitar campos para ingresar nueva contraseña
                txtContraseñaNueva.Visible = true;
                pictureBox2.Visible = true;
                btnOjo.Visible = true;
                btnGuardarClave.Visible = true;
                btnVerificarCod.Enabled = false;
                txtCodVerificacion.Enabled = false;
                btnOjoCerrado.Visible = true;
            }
            else
            {
                msgError("Código de verificación incorrecto. Intente nuevamente.");
                return;
            }
        }
        // Guarda la nueva contraseña
        private void btnGuardarClave_Click(object sender, EventArgs e)
        {
            string nuevaContraseña = GetHash(txtContraseñaNueva.Text);
            string email = txtEmail.Text;

            // Actualizar la contraseña en la tabla usuarios
            Controladora.Controladora.ActualizarContraseñaUsuario(email, nuevaContraseña);

            // Mostrar mensaje de éxito
            DialogResult result = MessageBox.Show("La contraseña se ha actualizado correctamente.", "Contraseña actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (result == DialogResult.OK) 
            {
                this.Close();
                Login login = new Login();
                login.Show();
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

        private void btnOjo_Click(object sender, EventArgs e)
        {
            txtContraseñaNueva.UseSystemPasswordChar = true;
            btnOjo.Visible = false;
            btnOjoCerrado.Visible = true;
        }

        private void btnOjoCerrado_Click(object sender, EventArgs e)
        {
            if (txtContraseñaNueva.Text != "CONTRASEÑA" && txtContraseñaNueva.Text != "")
            {
                txtContraseñaNueva.UseSystemPasswordChar = false;
                btnOjoCerrado.Visible = false;
                btnOjo.Visible = true;
            }
        }
    }
}
