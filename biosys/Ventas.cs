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
using Entidad;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace biosys
{
    public partial class Ventas : Form
    {
        // Propiedad pública que representa una instancia del panel de control de Dashboard
        public Dashboard DashboardInstance { get; set; }

        // Declaro la lista de compras
        private List<Venta> ventasList;

        private List<ProductoInfo> productos;

        public Ventas()
        {
            InitializeComponent();

            // Inicializo la lista de compras
            ventasList = new List<Venta>();

            // Inicializar la lista de productos en el constructor
            productos = Controladora.Controladora.ObtenerProductosStockComboBox();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro/a de que desea cancelar la venta? \n\nLa información se perderá", "Confirmar cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                // Restaurar el stock original de los productos
                CargarProductos(); // Recargar productos desde la base de datos
                labelStockDisponible.Visible = false;

                // Limpiar los campos de entrada de datos
                comboProductos.SelectedIndex = -1;
                comboCliente.SelectedIndex = -1;
                numericCantidad.Value = 0;

                // Reiniciar la lista de compras
                ventasList.Clear();

                // Limpiar el contenido del ListBox
                listDetalleVenta.Items.Clear();

                // Limpiar el textbox
                txtPrecioUnitario.Text = string.Empty;

                // Habilitar campos nuevamente
                comboCliente.Enabled = true;
                fechaVenta.Enabled = true;
            }
        }

        private void btnGuardarDetalle_Click(object sender, EventArgs e)
        {
            // Validar que los campos tengan información
            if (comboProductos.SelectedIndex == -1 || numericCantidad.Value <= 0 || string.IsNullOrWhiteSpace(txtPrecioUnitario.Text) || txtPrecioUnitario.Text == "Ejemplo: 1350,70")
            {
                msgError("Completar los campos obligatorios. La cantidad debe ser mayor que cero.");
                return;
            }

            // Obtener la cantidad ingresada
            int cantidad = (int)numericCantidad.Value;

            // Obtener el producto seleccionado
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

            // Obtener el stock disponible del producto seleccionado
            ProductoInfo productoSeleccionado = productos.FirstOrDefault(p => p.Id == productoId);

            if (productoSeleccionado != null && cantidad > productoSeleccionado.Stock)
            {
                msgError("La cantidad ingresada es mayor que el stock disponible.");
                return;
            }

            // Si el texto no contiene una coma, agregar la coma y dos ceros después del número
            if (!txtPrecioUnitario.Text.Contains(","))
            {
                txtPrecioUnitario.Text += ",00";
            }

            decimal precioUnitario = decimal.Parse(txtPrecioUnitario.Text);

            // Crear el objeto Venta y agregarlo a la lista de ventas
            Venta venta = new Venta
            {
                ProductoId = productoId,
                Producto = productoCompleto,
                Cantidad = cantidad,
                PrecioUnitario = precioUnitario,
                StockOriginal = productoSeleccionado.Stock
            };
            ventasList.Add(venta);

            // Restar temporalmente la cantidad al stock disponible
            productoSeleccionado.Stock -= cantidad;

            // No dejar acceder a cambiar algunos campos
            comboCliente.Enabled = false;
            fechaVenta.Enabled = false;

            // Limpiar los campos de entrada de datos
            comboProductos.SelectedIndex = -1;
            numericCantidad.Value = 0;
            txtPrecioUnitario.Text = string.Empty;
            labelStockDisponible.Visible = false;

            // Actualizar el contenido del ListBox
            ActualizarListBox();
        }

        public void msgError(string msg)
        {
            lblError.Text = "      " + msg;
            lblError.Visible = true;
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
            listDetalleVenta.Items.Clear();

            // Agregar cada elemento de la lista al ListBox
            foreach (Venta venta in ventasList)
            {
                string item = $"ID: {venta.ProductoId} - {venta.Producto} - Cantidad: {venta.Cantidad} - Precio Total: ${venta.PrecioTotal}";
                listDetalleVenta.Items.Add(item);
            }
        }

        private void CargarClientes()
        {
            List<Cliente> clientes = Controladora.Controladora.ObtenerDatosClientes();

            comboCliente.DataSource = clientes;
            comboCliente.DisplayMember = "NombreCompleto"; // Mostrar el nombre del cliente en el combo box
            comboCliente.ValueMember = "Email"; // Utilizar el email del cliente como el valor seleccionado

            comboCliente.SelectedIndex = -1;
        }

        private void CargarProductos()
        {
            // Obtener los productos directamente desde la base de datos
            productos = Controladora.Controladora.ObtenerProductosStockComboBox();

            comboProductos.Items.Clear();

            foreach (ProductoInfo producto in productos)
            {
                comboProductos.Items.Add($"{producto.Nombre} - {producto.TipoProducto} - {producto.TipoEspecifico}");
            }

            comboProductos.SelectedIndex = -1;
        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarProductos();

            // Agregar el texto de ayuda al TextBox
            txtPrecioUnitario.Text = "Ejemplo: 1350,70";
            // Asignar el color gris al texto de ayuda
            txtPrecioUnitario.ForeColor = System.Drawing.Color.Gray;
        }

        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            if (ventasList.Count == 0)
            {
                msgError("Debe ingresar al menos un detalle de venta.");
                return;
            }

            string clienteEmail = comboCliente.SelectedValue.ToString();
            DateTime fechaVenta = this.fechaVenta.Value;
            string nombreUsuario = ((Dashboard)Application.OpenForms["Dashboard"]).NombreUsuarioActual;
            int usuarioId = Controladora.Controladora.ObtenerIdUsuario(nombreUsuario);
            string nombreCliente = comboCliente.Text;

            decimal precioTotalVenta = 0;

            // Crear un objeto VentaInfo con los datos de la venta
            VentaInfo ventaInfo = new VentaInfo
            {
                ClienteEmail = clienteEmail,
                FechaVenta = fechaVenta,
                UsuarioId = usuarioId,
                PrecioTotalVenta = precioTotalVenta
            };

            foreach (Venta venta in ventasList)
            {
                ventaInfo.PrecioTotalVenta += venta.PrecioTotal;
            }

            int ventaId = Controladora.Controladora.GuardarVenta(ventaInfo);

            // Crear un objeto DetalleVentaInfo para cada venta en la lista
            DetalleVentaInfo detalleVentaInfo = new DetalleVentaInfo();

            foreach (Venta venta in ventasList)
            {
                int productoId = venta.ProductoId;
                int cantidad = venta.Cantidad;
                decimal precioUnitario = venta.PrecioUnitario;
                decimal precioTotalDetalle = venta.PrecioTotal;

                // Asignar los valores del detalle de venta al objeto DetalleVentaInfo
                detalleVentaInfo.VentaId = ventaId;
                detalleVentaInfo.ProductoId = productoId;
                detalleVentaInfo.Cantidad = cantidad;
                detalleVentaInfo.PrecioUnitario = precioUnitario;
                detalleVentaInfo.PrecioTotalDetalle = precioTotalDetalle;

                Controladora.Controladora.GuardarDetalleVenta(detalleVentaInfo);
                Controladora.Controladora.DisminuirStock(productoId, cantidad);
            }

            // Llamar a las funciones de generación de PDF
            GenerarFacturaPDF(nombreCliente, fechaVenta, ventasList);
            GenerarRemitoPDF(nombreCliente, fechaVenta, ventasList);

            LimpiarCampos();
            ventasList.Clear();

            MessageBox.Show($"La venta se registró correctamente.\n\nPrecio total: ${ventaInfo.PrecioTotalVenta}", "Venta registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LimpiarCampos()
        {
            comboProductos.SelectedIndex = -1;
            comboCliente.SelectedIndex = -1;
            numericCantidad.Value = 0;

            // Limpiar el contenido del ListBox
            listDetalleVenta.Items.Clear();

            // Limpiar el textbox
            txtPrecioUnitario.Text = string.Empty;

            // Habilitar campos nuevamente
            comboCliente.Enabled = true;
            fechaVenta.Enabled = true;
        }

        private void txtPrecioUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números y comas
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == ',' || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPrecioUnitario_Enter(object sender, EventArgs e)
        {
            // Limpiar el texto de ayuda y cambiar el color del texto al entrar al TextBox
            if (txtPrecioUnitario.Text == "Ejemplo: 1350,70")
            {
                txtPrecioUnitario.Text = "";
                txtPrecioUnitario.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtPrecioUnitario_Leave(object sender, EventArgs e)
        {
            // Restaurar el texto de ayuda si el TextBox está vacío al salir del control
            if (string.IsNullOrWhiteSpace(txtPrecioUnitario.Text))
            {
                txtPrecioUnitario.Text = "Ejemplo: 1350,70";
                txtPrecioUnitario.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void comboProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboProductos.SelectedIndex >= 0)
            {
                // Obtén el producto seleccionado
                string productoSeleccionado = comboProductos.SelectedItem.ToString();
                string[] partesProducto = productoSeleccionado.Split(new string[] { " - " }, StringSplitOptions.None);

                if (partesProducto.Length == 3)
                {
                    string nombreProducto = partesProducto[0];
                    string tipoProductoTexto = partesProducto[1];
                    string tipoEspecificoTexto = partesProducto[2];

                    int tipoProducto = ObtenerTipoProductoSegunTexto(tipoProductoTexto);
                    int tipoEspecifico = ObtenerTipoEspecificoSegunTexto(tipoEspecificoTexto);

                    // Busca el producto en la lista de productos con stock
                    ProductoInfo producto = productos.FirstOrDefault(p =>
                        p.Nombre == nombreProducto &&
                        p.TipoProducto == tipoProductoTexto &&
                        p.TipoEspecifico == tipoEspecificoTexto
                    );

                    if (producto != null)
                    {
                        // Muestra el stock disponible del producto seleccionado
                        labelStockDisponible.Text = $"Stock Disponible: {producto.Stock}";
                        labelStockDisponible.Visible = true;
                    }
                    else
                    {
                        // Si el producto no se encuentra, oculta el Label
                        labelStockDisponible.Visible = false;
                    }
                }
            }
        }
        private void GenerarFacturaPDF(string nombreCliente, DateTime fechaVenta, List<Venta> ventas)
        {
            // Obtener la fecha actual en el formato "ddMMyyyy"
            string fechaActual = DateTime.Now.ToString("ddMMyyyy");

            // Configurar el diálogo de guardar archivo
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";
            saveFileDialog.FileName = $"Factura_{nombreCliente}_{fechaActual}.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string nombreArchivo = saveFileDialog.FileName;

                Document doc = new Document();
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(nombreArchivo, FileMode.Create));

                doc.Open();

                // Encabezado de la factura
                doc.Add(new Paragraph("FACTURA"));
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph($"Fecha de Venta: {fechaVenta.ToShortDateString()}"));
                doc.Add(new Paragraph($"Cliente: {nombreCliente}"));

                // Espacio entre el título y la información del cliente
                doc.Add(new Paragraph("\n"));

                // Contenido de la factura
                PdfPTable table = new PdfPTable(4);
                table.WidthPercentage = 100; // Ajustar el ancho de la tabla al 100% del espacio disponible
                table.SetWidths(new float[] { 2f, 1f, 1f, 2f }); // Definir tamaños de columnas

                table.AddCell(new PdfPCell(new Phrase("Producto", FontFactory.GetFont(FontFactory.HELVETICA_BOLD))));
                table.AddCell(new PdfPCell(new Phrase("Cantidad", FontFactory.GetFont(FontFactory.HELVETICA_BOLD))));
                table.AddCell(new PdfPCell(new Phrase("Precio Unitario", FontFactory.GetFont(FontFactory.HELVETICA_BOLD))));
                table.AddCell(new PdfPCell(new Phrase("Total", FontFactory.GetFont(FontFactory.HELVETICA_BOLD))));

                foreach (Venta venta in ventas)
                {
                    table.AddCell(venta.Producto);
                    table.AddCell(venta.Cantidad.ToString());
                    table.AddCell(venta.PrecioUnitario.ToString("C"));
                    table.AddCell(venta.PrecioTotal.ToString("C"));
                }

                doc.Add(table);

                // Cierra el documento
                doc.Close();

                MessageBox.Show($"La factura se generó correctamente y se guardó en:\n\n{nombreArchivo}", "Factura generada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GenerarRemitoPDF(string nombreCliente, DateTime fechaVenta, List<Venta> ventas)
        {
            // Obtener la fecha actual en el formato "ddMMyyyy"
            string fechaActual = DateTime.Now.ToString("ddMMyyyy");

            // Configurar el diálogo de guardar archivo
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";
            saveFileDialog.FileName = $"Remito_{nombreCliente}_{fechaActual}.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string nombreArchivo = saveFileDialog.FileName;

                Document doc = new Document();
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(nombreArchivo, FileMode.Create));

                doc.Open();

                // Encabezado del remito
                doc.Add(new Paragraph("REMITO"));
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph($"Fecha de Venta: {fechaVenta.ToShortDateString()}"));
                doc.Add(new Paragraph($"Cliente: {nombreCliente}"));

                // Espacio entre el título y la información del cliente
                doc.Add(new Paragraph("\n"));

                // Contenido del remito
                PdfPTable table = new PdfPTable(3);
                table.WidthPercentage = 100; // Ajustar el ancho de la tabla al 100% del espacio disponible
                table.SetWidths(new float[] { 2f, 1f, 1f }); // Definir tamaños de columnas

                table.AddCell(new PdfPCell(new Phrase("Producto", FontFactory.GetFont(FontFactory.HELVETICA_BOLD))));
                table.AddCell(new PdfPCell(new Phrase("Cantidad", FontFactory.GetFont(FontFactory.HELVETICA_BOLD))));
                table.AddCell(new PdfPCell(new Phrase("Precio Unitario", FontFactory.GetFont(FontFactory.HELVETICA_BOLD))));

                foreach (Venta venta in ventas)
                {
                    table.AddCell(venta.Producto);
                    table.AddCell(venta.Cantidad.ToString());
                    table.AddCell(venta.PrecioUnitario.ToString("C"));
                }

                doc.Add(table);

                // Cierra el documento
                doc.Close();

                MessageBox.Show($"El remito se generó correctamente y se guardó en:\n\n{nombreArchivo}", "Remito generado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
