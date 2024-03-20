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
using Font = System.Drawing.Font;

namespace biosys
{
    public partial class Ventas : Form
    {
        // Propiedad pública que representa una instancia del panel de control de Dashboard
        public Dashboard DashboardInstance { get; set; }

        // Declaro la lista de compras
        private List<Venta> ventasList;

        private List<ProductoInfo> productos;

        private decimal precioUnitarioTemporal;

        private decimal precioUnitarioFijado = 0;

        public Ventas()
        {
            InitializeComponent();

            numericGananciaPorcentual.ValueChanged += numericGananciaPorcentual_ValueChanged;

            // Inicializo la lista de compras
            ventasList = new List<Venta>();

            // Inicializar la lista de productos en el constructor
            productos = Controladora.Controladora.ObtenerProductosArbolStockComboBox();
        }
        public void msgError(string msg)
        {
            lblError.Text = "      " + msg;
            lblError.Visible = true;
        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarProductos();
            CargarMetodosdePago();
            CargarRazonSocial();

            // Agregar el texto de ayuda al TextBox
            txtPrecioUnitario.Text = "Ejemplo: 4350,70";
            // Asignar el color gris al texto de ayuda
            txtPrecioUnitario.ForeColor = System.Drawing.Color.Gray;

            // Calcular la posición x para centrar el Label horizontalmente
            int labelPosX = (this.ClientSize.Width - labelTitulo.Width) / 2;

            // Establecer la posición del Label
            labelTitulo.Location = new Point(labelPosX, 50);

            numericGananciaPorcentual.Enabled = false;
            lblNohayprecio.Visible = false;
            lblPrecioSugerido.Visible = false;
            labelStockDisponible.Visible = false;
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
            productos = Controladora.Controladora.ObtenerProductosArbolStockComboBox();

            comboProductos.Items.Clear();

            foreach (ProductoInfo producto in productos)
            {
                comboProductos.Items.Add($"{producto.Nombre} - {producto.TipoProducto} - {producto.TipoEspecifico}");
            }

            comboProductos.SelectedIndex = -1;
        }
        private void CargarMetodosdePago()
        {
            List<string> metodosdepago = new List<string> { "Efectivo", "Transferencia", "Mercado pago", "Tarjeta de crédito", "Tarjeta de débito" };

            comboMedioPago.DataSource = metodosdepago;

            // Establecer el valor predeterminado
            comboMedioPago.SelectedIndex = -1;
        }

        private void CargarRazonSocial()
        {
            List<string> razonsocial = new List<string> { "Responsable inscripto", "Consumidor final" };

            comboRazonSocial.DataSource = razonsocial;

            // Establecer el valor predeterminado
            comboRazonSocial.SelectedIndex = -1;
        }

        private void LimpiarCampos()
        {
            comboProductos.SelectedIndex = -1;
            comboCliente.SelectedIndex = -1;
            numericCantidad.Value = 0;
            comboMedioPago.SelectedIndex = -1;
            comboRazonSocial.SelectedIndex = -1;

            // Limpiar el contenido del ListBox
            listDetalleVenta.Items.Clear();

            // Limpiar el textbox
            txtPrecioUnitario.Text = string.Empty;

            // Habilitar campos nuevamente
            comboCliente.Enabled = true;
            fechaVenta.Enabled = true;

            lblError.Visible = false;
            labelStockDisponible.Visible = false;
            lblNohayprecio.Visible = false;
            lblPrecioSugerido.Visible = false;
            numericGananciaPorcentual.Enabled = false;
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
            if (txtPrecioUnitario.Text == "Ejemplo: 4350,70")
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
                txtPrecioUnitario.Text = "Ejemplo: 4350,70";
                txtPrecioUnitario.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void GenerarFacturaPDF(string nombreCliente, DateTime fechaVenta, List<Venta> ventas, bool esResponsableInscripto)
        {
            string fechaActual = DateTime.Now.ToString("dd'-'MM'-'yyyy");

            // Configurar el diálogo de guardar archivo
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";
            saveFileDialog.FileName = $"Factura_{nombreCliente}_{fechaActual}.pdf";

            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string nombreArchivo = saveFileDialog.FileName;

                    // Configurar el documento PDF
                    Document doc = new Document(PageSize.A4);
                    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(nombreArchivo, FileMode.Create));

                    // Agregar metadatos
                    doc.AddTitle("Factura");
                    doc.AddCreator("BIOSYS");

                    doc.Open();

                    // Crear una fila para el encabezado
                    PdfPTable encabezadoTable = new PdfPTable(3);
                    encabezadoTable.WidthPercentage = 100;

                    // Añadir el logo
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(@"C:\Users\vitto\Pictures\Ing de Software\Logo-ubicacion.png");
                    image.ScaleToFit(110, 110); // Ajustar el tamaño de la imagen
                    PdfPCell logoCell = new PdfPCell(image);
                    logoCell.Border = PdfPCell.BOX; // Agregar un recuadro alrededor de la celda
                    logoCell.Padding = 5; // Añadir un espacio interno para separar el contenido del borde
                    logoCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    logoCell.VerticalAlignment = Element.ALIGN_MIDDLE; // Alinear verticalmente al centro o más arriba

                    // Determinar el texto para la letra (B o A) según el tipo de cliente
                    string letra = esResponsableInscripto ? "A" : "B";

                    // Añadir la letra
                    PdfPCell letraCell = new PdfPCell(new Paragraph(letra, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 30)));
                    letraCell.Border = PdfPCell.BOX; // Agregar un recuadro alrededor de la celda
                    letraCell.Padding = 5; // Añadir un espacio interno para separar el contenido del borde
                    letraCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    letraCell.VerticalAlignment = Element.ALIGN_MIDDLE; // Alinear verticalmente al centro

                    // Agregar la palabra "ORIGINAL" centrada arriba de la letra A o B
                    PdfPCell originalCell = new PdfPCell(new Phrase("ORIGINAL", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)));
                    originalCell.Border = PdfPCell.NO_BORDER;
                    originalCell.Colspan = 3; // Colspan para ocupar el ancho de la fila
                    originalCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    encabezadoTable.AddCell(originalCell);

                    // Fecha, nombre del cliente y código de factura
                    string codigoFactura = GenerarCodigoFactura();
                    string facturaInfo = $"FACTURA\n\n\nFecha: {fechaActual}\n\nCliente: {nombreCliente}\n\nCódigo: {codigoFactura}";

                    // Crear un párrafo con la información de la factura
                    Paragraph facturaParagraph = new Paragraph(facturaInfo, FontFactory.GetFont(FontFactory.HELVETICA, 12));
                    facturaParagraph.Alignment = Element.ALIGN_CENTER;

                    // Crear una celda para la información de la factura
                    PdfPCell facturaCell = new PdfPCell(facturaParagraph);
                    facturaCell.Border = PdfPCell.BOX; // Agregar un recuadro alrededor de la celda
                    facturaCell.Padding = 5; // Añadir un espacio interno para separar el contenido del borde
                    facturaCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    facturaCell.VerticalAlignment = Element.ALIGN_MIDDLE; // Alinear verticalmente al centro

                    // Agregar las celdas con los elementos al encabezado
                    encabezadoTable.AddCell(logoCell);
                    encabezadoTable.AddCell(letraCell);
                    encabezadoTable.AddCell(facturaCell);

                    // Agregar la fila al documento
                    doc.Add(encabezadoTable);

                    // Espacio entre el encabezado y la tabla de detalles
                    doc.Add(new Paragraph(" "));

                    // Detalles de la factura
                    PdfPTable table = new PdfPTable(4);
                    table.WidthPercentage = 100;
                    table.SetWidths(new float[] { 3f, 1f, 1f, 1f });

                    table.AddCell(new PdfPCell(new Phrase("Producto", FontFactory.GetFont(FontFactory.HELVETICA_BOLD))));
                    table.AddCell(new PdfPCell(new Phrase("Cantidad", FontFactory.GetFont(FontFactory.HELVETICA_BOLD))));
                    table.AddCell(new PdfPCell(new Phrase("Precio Unitario", FontFactory.GetFont(FontFactory.HELVETICA_BOLD))));
                    table.AddCell(new PdfPCell(new Phrase("Total", FontFactory.GetFont(FontFactory.HELVETICA_BOLD))));

                    decimal totalFactura = 0; // Inicializar el total de la factura

                    foreach (Venta venta in ventas)
                    {
                        table.AddCell(venta.Producto);
                        table.AddCell(venta.Cantidad.ToString());
                        table.AddCell(venta.PrecioUnitario.ToString("C"));
                        table.AddCell(venta.PrecioTotal.ToString("C"));

                        totalFactura += venta.PrecioTotal; // Sumar al total de la factura
                    }

                    doc.Add(table);

                    // Total de la factura
                    Paragraph total = new Paragraph($"Total: {totalFactura.ToString("C")}", FontFactory.GetFont(FontFactory.HELVETICA_BOLD));
                    total.Alignment = Element.ALIGN_RIGHT;
                    doc.Add(total);

                    // Cierra el documento
                    doc.Close();

                    MessageBox.Show($"La factura se generó correctamente y se guardó en:\n\n{nombreArchivo}", "Factura generada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (IOException)
            {
                MessageBox.Show("El archivo PDF no se puede sobrescribir porque está siendo utilizado por otro proceso. Por favor, cierre cualquier visor de PDF que esté utilizando el archivo y vuelva a intentarlo.", "Error al generar la factura", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarRemitoPDF(string nombreCliente, DateTime fechaVenta, List<Venta> ventas)
        {
            string fechaActual = DateTime.Now.ToString("dd'-'MM'-'yyyy");

            // Configurar el diálogo de guardar archivo
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";
            saveFileDialog.FileName = $"Remito_{nombreCliente}_{fechaActual}.pdf";

            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string nombreArchivo = saveFileDialog.FileName;

                    Document doc = new Document(PageSize.A4);
                    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(nombreArchivo, FileMode.Create));

                    doc.Open();

                    // Crear una fila para el encabezado
                    PdfPTable encabezadoTable = new PdfPTable(3);
                    encabezadoTable.WidthPercentage = 100;

                    // Agregar el logo
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(@"C:\Users\vitto\Pictures\Ing de Software\Logo-ubicacion.png");
                    image.ScaleToFit(110, 110); // Ajustar el tamaño de la imagen
                    PdfPCell logoCell = new PdfPCell(image);
                    logoCell.Border = PdfPCell.BOX; // Agregar un recuadro alrededor de la celda
                    logoCell.Padding = 5; // Añadir un espacio interno para separar el contenido del borde
                    logoCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    logoCell.VerticalAlignment = Element.ALIGN_MIDDLE; // Alinear verticalmente al centro o más arriba

                    // Añadir la letra "R"
                    PdfPCell letraCell = new PdfPCell(new Paragraph("R", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 30)));
                    letraCell.Border = PdfPCell.BOX; // Agregar un recuadro alrededor de la celda
                    letraCell.Padding = 5; // Añadir un espacio interno para separar el contenido del borde
                    letraCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    letraCell.VerticalAlignment = Element.ALIGN_MIDDLE; // Alinear verticalmente al centro

                    // Agregar la palabra "ORIGINAL" centrada arriba de la letra R
                    PdfPCell originalCell = new PdfPCell(new Phrase("ORIGINAL", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)));
                    originalCell.Border = PdfPCell.NO_BORDER;
                    originalCell.Colspan = 3; // Colspan para ocupar el ancho de la fila
                    originalCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    encabezadoTable.AddCell(originalCell);

                    // Fecha, nombre del cliente y código de remito
                    string codigoRemito = GenerarCodigoRemito();
                    string remitoInfo = $"REMITO\n\n\nFecha: {fechaActual}\n\nCliente: {nombreCliente}\n\nCódigo: {codigoRemito}";

                    // Crear un párrafo con la información del remito
                    Paragraph remitoParagraph = new Paragraph(remitoInfo, FontFactory.GetFont(FontFactory.HELVETICA, 12));
                    remitoParagraph.Alignment = Element.ALIGN_CENTER;

                    // Crear una celda para la información del remito
                    PdfPCell remitoCell = new PdfPCell(remitoParagraph);
                    remitoCell.Border = PdfPCell.BOX; // Agregar un recuadro alrededor de la celda
                    remitoCell.Padding = 5; // Añadir un espacio interno para separar el contenido del borde
                    remitoCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    remitoCell.VerticalAlignment = Element.ALIGN_MIDDLE; // Alinear verticalmente al centro

                    // Agregar las celdas con los elementos al encabezado
                    encabezadoTable.AddCell(logoCell);
                    encabezadoTable.AddCell(letraCell);
                    encabezadoTable.AddCell(remitoCell);

                    // Agregar la fila al documento
                    doc.Add(encabezadoTable);

                    // Espacio entre el encabezado y la tabla de detalles
                    doc.Add(new Paragraph(" "));

                    // Detalles del remito
                    PdfPTable table = new PdfPTable(2);
                    table.WidthPercentage = 100; // Ajustar el ancho de la tabla al 100% del espacio disponible
                    table.SetWidths(new float[] { 3f, 1f }); // Definir tamaños de columnas

                    table.AddCell(new PdfPCell(new Phrase("Producto", FontFactory.GetFont(FontFactory.HELVETICA_BOLD))));
                    table.AddCell(new PdfPCell(new Phrase("Cantidad", FontFactory.GetFont(FontFactory.HELVETICA_BOLD))));

                    foreach (Venta venta in ventas)
                    {
                        table.AddCell(venta.Producto);
                        table.AddCell(venta.Cantidad.ToString());
                    }

                    doc.Add(table);

                    // Cierra el documento
                    doc.Close();

                    MessageBox.Show($"El remito se generó correctamente y se guardó en:\n\n{nombreArchivo}", "Remito generado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (IOException)
            {
                MessageBox.Show("El archivo PDF no se puede sobrescribir porque está siendo utilizado por otro proceso. Por favor, cierre cualquier visor de PDF que esté utilizando el archivo y vuelva a intentarlo.", "Error al generar el remito", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para generar un código de remito único
        private string GenerarCodigoRemito()
        {
            // Puedes generar un código único basado en la fecha y hora actual
            string codigo = DateTime.Now.ToString("yyyyMMddHHmmssfff");

            // También puedes agregar algún prefijo o sufijo si es necesario
            codigo = "REMITO-" + codigo;

            return codigo;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea cancelar la venta? \n\nLa información se perderá.", "Confirmar cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DashboardInstance.AbrirFormHijo(new Inicio());
                this.Close();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea limpiar los campos? \n\nLa información se perderá.", "Confirmar limpieza de campos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Restaurar el stock original de los productos
                CargarProductos(); // Recargar productos desde la base de datos
                labelStockDisponible.Visible = false;
                lblNohayprecio.Visible = false;
                lblPrecioSugerido.Visible = false;
                numericGananciaPorcentual.Enabled = false;

                // Limpiar los campos de entrada de datos
                comboProductos.SelectedIndex = -1;
                comboCliente.SelectedIndex = -1;
                numericCantidad.Value = 0;
                comboMedioPago.SelectedIndex = -1;
                comboRazonSocial.SelectedIndex = -1;

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
            if (comboProductos.SelectedIndex == -1 || numericCantidad.Value <= 0 || string.IsNullOrWhiteSpace(txtPrecioUnitario.Text) || txtPrecioUnitario.Text == "Ejemplo: 4350,70")
            {
                msgError("  Complete los campos obligatorios.");
                return;
            }

            // Obtener la cantidad ingresada
            int cantidad = (int)numericCantidad.Value;

            // Obtener el producto seleccionado
            string productoCompleto = comboProductos.SelectedItem.ToString();
            string[] partesProducto = productoCompleto.Split(new string[] { " - " }, StringSplitOptions.None);

            if (partesProducto.Length != 3)
            {
                msgError("  El formato del producto seleccionado es incorrecto.");
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
                msgError("  La cantidad ingresada es mayor que el stock disponible.");
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
            lblError.Visible = false;
            lblPrecioSugerido.Visible = false;
            lblNohayprecio.Visible = false;
            numericGananciaPorcentual.Value = 0;

            // Actualizar el contenido del ListBox
            ActualizarListBox();
        }

        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            if (ventasList.Count == 0)
            {
                msgError("  Ingrese al menos un detalle de venta.");
                return;
            }

            // Verificar si se ha seleccionado un medio de pago
            if (comboMedioPago.SelectedIndex == -1)
            {
                msgError("  Ingrese un medio de pago.");
                return;
            }

            // Verificar si se ha seleccionado una opción en el comboRazonSocial
            if (comboRazonSocial.SelectedIndex == -1)
            {
                msgError("  Seleccione la razón social.");
                return;
            }

            // Obtener el valor seleccionado del comboRazonSocial
            bool esResponsableInscripto = comboRazonSocial.SelectedIndex == 0; // Si el índice seleccionado es 0, es Responsable Inscripto; de lo contrario, es Consumidor Final

            // Mostrar cuadro de diálogo de confirmación
            DialogResult result = MessageBox.Show("¿Desea realizar la venta?", "Confirmar Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Verificar si el usuario confirmó la acción
            if (result == DialogResult.Yes)
            {
                string clienteEmail = comboCliente.SelectedValue.ToString();
                DateTime fechaVenta = this.fechaVenta.Value;
                string nombreUsuario = ((Dashboard)Application.OpenForms["Dashboard"]).NombreUsuarioActual;
                int usuarioId = Controladora.Controladora.ObtenerIdUsuario(nombreUsuario);
                string nombreCliente = comboCliente.Text;

                decimal precioTotalVenta = 0;

                // Crear un objeto VentaInfo con los datos de la venta, incluyendo el medio de pago
                VentaInfo ventaInfo = new VentaInfo
                {
                    ClienteEmail = clienteEmail,
                    FechaVenta = fechaVenta,
                    UsuarioId = usuarioId,
                    PrecioTotalVenta = precioTotalVenta,
                    MedioPago = comboMedioPago.SelectedItem.ToString()
                };

                foreach (Venta venta in ventasList)
                {
                    ventaInfo.PrecioTotalVenta += venta.PrecioTotal;
                }

                // Generar código de factura
                string codigoFactura = GenerarCodigoFactura();

                // Asignar el código de factura a la venta
                ventaInfo.CodigoFactura = codigoFactura;

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

                // Llamar a las funciones de generación de PDF, pasando el valor de esResponsableInscripto
                GenerarFacturaPDF(nombreCliente, fechaVenta, ventasList, esResponsableInscripto);
                GenerarRemitoPDF(nombreCliente, fechaVenta, ventasList);

                LimpiarCampos();
                ventasList.Clear();

                MessageBox.Show($"La venta se registró correctamente.\n\nPrecio total: ${ventaInfo.PrecioTotalVenta}", "Venta registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar los productos en el combo box excluyendo los que tienen stock cero
                CargarProductos();
            }
        }

        // Método para generar un código de factura único
        private string GenerarCodigoFactura()
        {
            // Puedes generar un código único basado en la fecha y hora actual
            string codigo = DateTime.Now.ToString("yyyyMMddHHmmssfff");

            // También puedes agregar algún prefijo o sufijo si es necesario
            codigo = "FACTURA-" + codigo;

            return codigo;
        }

        private void btnCancelar_MouseEnter(object sender, EventArgs e)
        {
            btnCancelar.BackColor = Color.Red;
        }

        private void btnCancelar_MouseLeave(object sender, EventArgs e)
        {
            btnCancelar.BackColor = Color.White;
        }

        private void btnRegistrarVenta_MouseEnter(object sender, EventArgs e)
        {
            btnRegistrarVenta.BackColor = Color.FromArgb(0, 192, 0);
        }

        private void btnRegistrarVenta_MouseLeave(object sender, EventArgs e)
        {
            btnRegistrarVenta.BackColor = Color.White;
        }

        private void btnHistorialVentas_Click(object sender, EventArgs e)
        {
            HistorialVentas historialVentasForm = new HistorialVentas();
            historialVentasForm.DashboardInstance = DashboardInstance;
            DashboardInstance.AbrirFormHijo(historialVentasForm);
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
                        labelStockDisponible.Text = $"Stock disponible: {producto.Stock}";
                        labelStockDisponible.Visible = true;

                        // Obtener el precio unitario fijado del producto
                        decimal precioFijadoProducto = Controladora.Controladora.ObtenerPrecioUnitarioFijado(producto.Id);

                        // Verificar si se ha fijado un precio para el producto
                        if (precioFijadoProducto > 0)
                        {
                            // Asignar el precio unitario fijado a la variable de clase
                            precioUnitarioFijado = precioFijadoProducto;

                            // Habilitar el numericGananciaPorcentual
                            numericGananciaPorcentual.Value = 0;
                            numericGananciaPorcentual.Enabled = true;
                            lblPrecioSugerido.Visible = false;
                            lblNohayprecio.Visible = false;
                        }
                        else
                        {
                            // Deshabilitar el numericGananciaPorcentual si no hay precio fijado
                            numericGananciaPorcentual.Value = 0;
                            numericCantidad.Value = 0;
                            numericGananciaPorcentual.Enabled = false;
                            lblPrecioSugerido.Visible = false;
                            lblNohayprecio.Visible = true;
                        }
                    }
                    else
                    {
                        // Si el producto no se encuentra, oculta el Label
                        labelStockDisponible.Visible = false;
                    }
                }
            }
        }

        private void numericGananciaPorcentual_ValueChanged(object sender, EventArgs e)
        {
            // Obtener el valor del numericGananciaPorcentual
            decimal porcentajeGanancia = numericGananciaPorcentual.Value;

            // Verificar si el porcentaje de ganancia es mayor que cero
            if (porcentajeGanancia > 0)
            {
                // Mostrar el precio sugerido en el lblPrecioSegurido
                lblPrecioSugerido.Text = $"El precio sugerido de venta es: ${ObtenerPrecioSugerido(porcentajeGanancia):N2}";

                // Establecer la fuente del Label a negrita y aumentar su tamaño
                lblPrecioSugerido.Font = new Font(lblPrecioSugerido.Font, FontStyle.Bold);
                lblPrecioSugerido.ForeColor = Color.Green;
                lblPrecioSugerido.Visible = true;
            }
            else
            {
                // Si el porcentaje de ganancia es cero o negativo, ocultar el lblPrecioSegurido
                lblPrecioSugerido.Visible = false;
            }
        }

        private decimal ObtenerPrecioSugerido(decimal porcentajeGanancia)
        {
            // Verificar si se ha fijado un precio unitario para el producto
            if (precioUnitarioFijado > 0)
            {
                // Calcular el precio sugerido utilizando el precio unitario fijado
                decimal precioSugerido = precioUnitarioFijado + (precioUnitarioFijado * porcentajeGanancia / 100);
                return precioSugerido;
            }
            else
            {
                // Si no se ha fijado un precio unitario, devolver 0
                return 0;
            }
        }

    }
}
