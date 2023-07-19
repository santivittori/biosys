using COMUN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static biosys.Compras;
using Entidad;

namespace biosys
{
    public partial class Donaciones : Form
    {
        // Declaro la lista de donación
        private List<Donacion> donacionList;

        public Dashboard DashboardInstance { get; set; }

        public Donaciones()
        {
            InitializeComponent();

            // Inicializo la lista de donación
            donacionList = new List<Donacion>();
        }

        private void Donaciones_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void CargarProductos()
        {
            List<string> productos = Controladora.Controladora.ObtenerProductosComboBox();

            comboProductos.Items.Clear();
            comboProductos.Items.AddRange(productos.ToArray());
            comboProductos.SelectedIndex = -1;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro/a de que desea cancelar la compra? \n\nLa información se perderá", "Confirmar cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DashboardInstance.AbrirFormHijo(new Inicio());
                this.Close();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro/a de que desea limpiar los campos? \n\nLa información se perderá", "Confirmar limpieza de campos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Limpiar los campos de entrada de datos
                comboProductos.SelectedIndex = -1;
                numericCantidad.Value = 0;

                // Reiniciar la lista de donación
                donacionList.Clear();

                // Limpiar el contenido del ListBox
                listDetalleDonacion.Items.Clear();

                // Limpiar los textbox
                txtDonante.Text = string.Empty;

                // Habilitar campos nuevamente
                txtDonante.Enabled = true;
                fechaDonacion.Enabled = true;
            }
        }

        private void ActualizarListBox()
        {
            // Limpiar el contenido actual del ListBox
            listDetalleDonacion.Items.Clear();

            // Agregar cada elemento de la lista al ListBox
            foreach (Donacion donacion in donacionList)
            {
                string item = $"ID: {donacion.ProductoId} - {donacion.Producto} - Cantidad: {donacion.Cantidad}";
                listDetalleDonacion.Items.Add(item);
            }
        }

        private void btnGuardarDetalle_Click(object sender, EventArgs e)
        {
            // Validar que los campos tengan información
            if (string.IsNullOrWhiteSpace(txtDonante.Text) || comboProductos.SelectedIndex == -1 || numericCantidad.Value <= 0)
            {
                msgError("Completar los campos obligatorios. La cantidad debe ser mayor que cero.");
                return;
            }

            // Obtener el producto seleccionado y la cantidad ingresada
            string productoCompleto = comboProductos.SelectedItem.ToString();
            string[] partesProducto = productoCompleto.Split(new string[] { " - " }, StringSplitOptions.None);

            if (partesProducto.Length != 3)
            {
                msgError("El formato del producto seleccionado es incorrecto.");
                return;
            }

            string nombreProducto = partesProducto[0];
            string tipoProductoTexto = partesProducto[1];
            string tipoEspecificoTexto = partesProducto[2];

            // Obtener los valores de tipoProducto y tipoEspecifico como enteros
            int tipoProducto = ObtenerTipoProductoSegunTexto(tipoProductoTexto);
            int tipoEspecifico = ObtenerTipoEspecificoSegunTexto(tipoEspecificoTexto);

            int productoId = Controladora.Controladora.ObtenerIdProducto(nombreProducto, tipoProducto, tipoEspecifico);
            int cantidad = int.Parse(numericCantidad.Text);

            // Crear una instancia de la clase Donacion y agregarla a la lista
            Donacion donacion = new Donacion
            {
                ProductoId = productoId,
                Producto = productoCompleto,
                Cantidad = cantidad
            };
            donacionList.Add(donacion);

            // No dejar acceder a cambiar algunos campos
            txtDonante.Enabled = false;
            fechaDonacion.Enabled = false;

            // Limpiar los campos de entrada de datos
            comboProductos.SelectedIndex = -1;
            numericCantidad.Text = string.Empty;

            // Actualizar el contenido del ListBox
            ActualizarListBox();
        }

        private void LimpiarCampos()
        {
            // Limpiar los campos de entrada de datos
            comboProductos.SelectedIndex = -1;
            numericCantidad.Value = 0;

            // Limpiar el contenido del ListBox
            listDetalleDonacion.Items.Clear();

            // Limpiar los textbox
            txtDonante.Text = string.Empty;

            // Habilitar campos nuevamente
            txtDonante.Enabled = true;
            fechaDonacion.Enabled = true;
        }

        public void msgError(string msg)
        {
            lblError.Text = "      " + msg;
            lblError.Visible = true;
        }

        private void btnRegistrarDonacion_Click(object sender, EventArgs e)
        {
            if (donacionList.Count == 0)
            {
                msgError("Debe ingresar al menos un detalle de donación.");
                return;
            }

            string donante = txtDonante.Text;
            DateTime fechaDonacion = this.fechaDonacion.Value;

            string nombreUsuario = ((Dashboard)Application.OpenForms["Dashboard"]).NombreUsuarioActual;

            int usuarioId = Controladora.Controladora.ObtenerIdUsuario(nombreUsuario);

            int donacionId = Controladora.Controladora.GuardarDonacion(donante, fechaDonacion, usuarioId);

            foreach (Donacion donacion in donacionList)
            {
                int productoId = donacion.ProductoId;
                int cantidad = donacion.Cantidad;

                Controladora.Controladora.GuardarDetalleDonacion(donacionId, productoId, cantidad);
                Controladora.Controladora.ActualizarStock(productoId, cantidad);
            }

            LimpiarCampos();
            donacionList.Clear();

            MessageBox.Show("La donación se registró correctamente.", "Donación registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtDonante_KeyPress(object sender, KeyPressEventArgs e)
        {
            e = MetodosComunes.KeyPressSoloLetras(e);

            if (e.Handled)
            {
                // Cancela el evento KeyPress
                e.Handled = true;
            }
        }
    }
}
