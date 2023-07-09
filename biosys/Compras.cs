using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controladora;
using COMUN;

namespace biosys
{
    public partial class Compras : Form
    {
        // Declaro la lista de compras
        private List<Compra> comprasList;

        // Propiedad pública que representa una instancia del panel de control de Dashboard
        public Dashboard DashboardInstance { get; set; }

        public Compras()
        {
            InitializeComponent();

            // Inicializo la lista de compras
            comprasList = new List<Compra>();
        }

        // Clase para representar un producto, cantidad y id de producto
        public class Compra
        {
            public int ProductoId { get; set; }
            public string Producto { get; set; }
            public int Cantidad { get; set; }
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
                comboProveedor.SelectedIndex = -1;
                numericCantidad.Value = 0;

                // Reiniciar la lista de compras
                comprasList.Clear();

                // Limpiar el contenido del ListBox
                listDetalleCompra.Items.Clear();

                // Limpiar los textbox
                txtNroFactura.Text = string.Empty;
                txtNroRemito.Text = string.Empty;

                // Habilitar campos nuevamente
                txtNroFactura.Enabled = true;
                txtNroRemito.Enabled = true;
                comboProveedor.Enabled = true;
                fechaCompra.Enabled = true;
            }
        }

        private void btnGuardarDetalle_Click(object sender, EventArgs e)
        {
            // Validar que los campos tengan información
            if (string.IsNullOrWhiteSpace(txtNroFactura.Text) || comboProveedor.SelectedIndex == -1 ||
                comboProductos.SelectedIndex == -1 || numericCantidad.Value <= 0)
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

            // Crear una instancia de la clase Compra y agregarla a la lista
            Compra compra = new Compra
            {
                ProductoId = productoId,
                Producto = productoCompleto,
                Cantidad = cantidad
            };
            comprasList.Add(compra);

            // No dejar acceder a cambiar algunos campos
            txtNroFactura.Enabled = false;
            txtNroRemito.Enabled = false;
            comboProveedor.Enabled = false;
            fechaCompra.Enabled = false;

            // Limpiar los campos de entrada de datos
            comboProductos.SelectedIndex = -1;
            numericCantidad.Text = string.Empty;

            // Actualizar el contenido del ListBox
            ActualizarListBox();
        }

        public static int ObtenerTipoProductoSegunTexto(string tipoProductoTexto)
        {
            switch (tipoProductoTexto)
            {
                case "Árbol":
                    return 1;
                case "Semilla":
                    return 2;
                default:
                    return 0; // Valor predeterminado en caso de texto no válido
            }
        }

        public static int ObtenerTipoEspecificoSegunTexto(string tipoEspecificoTexto)
        {
            switch (tipoEspecificoTexto)
            {
                case "Exótica":
                    return 1;
                case "Nativa":
                    return 2;
                default:
                    return 0; // Valor predeterminado en caso de texto no válido
            }
        }

        private void ActualizarListBox()
        {
            // Limpiar el contenido actual del ListBox
            listDetalleCompra.Items.Clear();

            // Agregar cada elemento de la lista al ListBox
            foreach (Compra compra in comprasList)
            {
                string item = $"ID: {compra.ProductoId} - {compra.Producto} - Cantidad: {compra.Cantidad}";
                listDetalleCompra.Items.Add(item);
            }
        }

        private void CargarProveedores()
        {
            List<Controladora.Controladora.Proveedor> proveedores = Controladora.Controladora.ObtenerDatosProveedores();

            comboProveedor.DataSource = proveedores;
            comboProveedor.DisplayMember = "NombreCompleto"; // Mostrar el nombre del proveedor en el combo box
            comboProveedor.ValueMember = "Email"; // Utilizar el email del proveedor como el valor seleccionado

            comboProveedor.SelectedIndex = -1;
        }


        private void CargarProductos()
        {
            List<string> productos = Controladora.Controladora.ObtenerProductosComboBox();

            comboProductos.Items.Clear();
            comboProductos .Items.AddRange(productos.ToArray());
            comboProductos.SelectedIndex = -1;
        }

        private void Compras_Load(object sender, EventArgs e)
        {
            CargarProveedores();
            CargarProductos();
        }

        private void btnRegistrarCompra_Click(object sender, EventArgs e)
        {
            if (comprasList.Count == 0)
            {
                msgError("Debe ingresar al menos un detalle de compra.");
                return;
            }

            string nroFactura = txtNroFactura.Text;
            string nroRemito = txtNroRemito.Text;
            string proveedorEmail = comboProveedor.SelectedValue.ToString();
            DateTime fechaCompra = this.fechaCompra.Value;

            int compraId = Controladora.Controladora.GuardarCompra(nroFactura, nroRemito, fechaCompra, proveedorEmail);

            foreach (Compra compra in comprasList)
            {
                int productoId = compra.ProductoId;
                int cantidad = compra.Cantidad;

                Controladora.Controladora.GuardarDetalleCompra(compraId, productoId, cantidad);
                Controladora.Controladora.ActualizarStock(productoId, cantidad);
            }

            LimpiarCampos();
            comprasList.Clear();

            MessageBox.Show("La compra se registró correctamente.", "Compra registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LimpiarCampos()
        {
            comboProductos.SelectedIndex = -1;
            comboProveedor.SelectedIndex = -1;
            numericCantidad.Value = 0;

            // Limpiar el contenido del ListBox
            listDetalleCompra.Items.Clear();

            // Limpiar los textbox
            txtNroFactura.Text = string.Empty;
            txtNroRemito.Text = string.Empty;

            // Habilitar campos nuevamente
            txtNroFactura.Enabled = true;
            txtNroRemito.Enabled = true;
            comboProveedor.Enabled = true;
            fechaCompra.Enabled = true;
        }

        public void msgError(string msg)
        {
            lblError.Text = "      " + msg;
            lblError.Visible = true;
        }

        private void txtNroFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            e = MetodosComunes.KeyPressSoloNumeros(e);

            if (e.Handled)
            {
                // Cancela el evento KeyPress
                e.Handled = true;
            }
        }

        private void txtNroRemito_KeyPress(object sender, KeyPressEventArgs e)
        {
            e = MetodosComunes.KeyPressSoloNumeros(e);

            if (e.Handled)
            {
                e.Handled = true;
            }
        }
    }
}
