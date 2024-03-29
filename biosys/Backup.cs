using Entidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace biosys
{
    public partial class Backup : Form
    {
        public Dashboard DashboardInstance { get; set; }

        public Backup()
        {
            InitializeComponent();
        }

        private void Backup_Load(object sender, EventArgs e)
        {
            // Obtener la fecha del último respaldo
            DateTime ultimaFechaRespaldo = Controladora.Controladora.ObtenerFechaUltimoRespaldo();

            // Mostrar la fecha del último respaldo en el label
            if (ultimaFechaRespaldo != DateTime.MinValue)
            {
                labelUltimoRespaldo.Text = "Último respaldo realizado: " + ultimaFechaRespaldo.ToString("dd/MM/yyyy");
            }
            else
            {
                labelUltimoRespaldo.Text = "Aún no se ha realizado un respaldo.";
            }

            // Calcular la posición x para centrar el Label horizontalmente
            int labelPosX = (this.ClientSize.Width - labelTitulo.Width) / 2;

            // Establecer la posición del Label
            labelTitulo.Location = new Point(labelPosX, 50);

            txtRutaArchivo.Enabled = false;
        }

        private void btnResguardo_Click(object sender, EventArgs e)
        {
            // Preguntar al usuario si realmente desea realizar el respaldo
            DialogResult result = MessageBox.Show("¿Desea realizar el respaldo de la base de datos?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Verificar si el usuario confirmó la acción
            if (result == DialogResult.Yes)
            {
                // Definir la carpeta de respaldo
                string carpetaBackup = @"C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\Backup";

                // Definir el nombre del archivo de respaldo
                string nombreArchivo = "biosys_" + DateTime.Now.ToString("yyyy-MM-dd") + ".bak";

                // Combinar la carpeta de respaldo con el nombre de archivo
                string rutaRespaldo = Path.Combine(carpetaBackup, nombreArchivo);

                if (Controladora.Controladora.RealizarRespaldoBaseDatos(rutaRespaldo))
                {
                    MessageBox.Show($"Respaldo de base de datos completado correctamente. \n\nSe guardó en: {rutaRespaldo}", "Respaldo exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblError.Visible = false;

                    Controladora.Controladora.GuardarInfoRespaldo(rutaRespaldo);
                }
                else
                {
                    MessageBox.Show("Error al realizar el respaldo de la base de datos. Consulte los registros para obtener más detalles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBuscarArchivo_Click(object sender, EventArgs e)
        {
            // Obtener la carpeta donde se guardó el backup anteriormente
            string carpetaBackup = @"C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\Backup\";

            // Crear el cuadro de diálogo de selección de archivo
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivo de respaldo (*.bak)|*.bak";
            openFileDialog.Title = "Seleccionar archivo de respaldo";
            openFileDialog.InitialDirectory = carpetaBackup; // Establecer la carpeta inicial

            // Mostrar el cuadro de diálogo y asignar la ruta seleccionada al campo de texto
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtRutaArchivo.Text = openFileDialog.FileName;
                txtRutaArchivo.Enabled = false;
            }
            lblError.Visible = false;
        }

        private void btnRestauracion_Click(object sender, EventArgs e)
        {
            // Obtener la ruta del archivo seleccionado para la restauración
            string rutaArchivo = txtRutaArchivo.Text;

            // Verificar si se ha seleccionado un archivo
            if (string.IsNullOrWhiteSpace(rutaArchivo))
            {
                msgError("  Seleccione un archivo de respaldo.");
                return;
            }

            // Verificar si el archivo seleccionado tiene la extensión .bak
            if (!rutaArchivo.EndsWith(".bak", StringComparison.OrdinalIgnoreCase))
            {
                msgError("  El archivo seleccionado no tiene la extensión .bak.");
                return;
            }

            // Confirmar con el usuario si realmente desea realizar la restauración
            DialogResult result = MessageBox.Show("¿Desea restaurar la base de datos?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;

            // Intentar realizar la restauración de la base de datos
            if (Controladora.Controladora.RealizarRestauracionBaseDatos(rutaArchivo))
            {
                MessageBox.Show("Restauración de la base de datos completada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRutaArchivo.Text = ""; // Limpiar el campo de texto después de la restauración exitosa
                lblError.Visible = false;
            }
            else
            {
                MessageBox.Show("Error al restaurar la base de datos. Consulte los registros para obtener más detalles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void msgError(string msg)
        {
            lblError.Text = "      " + msg;
            lblError.Visible = true;
        }
    }
}
