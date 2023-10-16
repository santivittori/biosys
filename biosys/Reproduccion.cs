using Entidad;
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
using System.Data.SqlClient;

namespace biosys
{
    public partial class Reproduccion : Form
    {
        private List<Siembra> siembraList;
        
        private List<ProductoConversion> productoConversionList;
        
        // Lista para mantener información del stock por producto
        private List<StockProducto> stockPorProductos;

        private List<Producto> productosList;

        public Dashboard DashboardInstance { get; set; }

        public Reproduccion()
        {
            InitializeComponent();

            siembraList = new List<Siembra>();

            productoConversionList = new List<ProductoConversion>();
            productoConversionList.Add(new ProductoConversion { ProductoSemillaId = 2, ProductoArbolId = 1 });

            // Inicializar la lista de stock por producto
            stockPorProductos = new List<StockProducto>();

            productosList = Controladora.Controladora.ObtenerSemillasConStockMayorCero();
        }

        private int stockInicial = 0;
        private int stockDisponible = 0;

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro/a de que desea cancelar la compra? \n\nLa información se perderá", "Confirmar cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DashboardInstance.AbrirFormHijo(new Inicio());
                this.Close();
            }
        }

        private void btnGuardarDetalle_Click(object sender, EventArgs e)
        {
            // Validar que los campos tengan información
            if (comboProductos.SelectedIndex == -1 || numericCantidad.Value <= 0)
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

            // Verificar si ya existe información de stock para este producto
            StockProducto stockProducto = stockPorProductos.FirstOrDefault(s => s.ProductoId == productoId);

            if (stockProducto == null)
            {
                msgError("No se encontró información de stock para el producto seleccionado.");
                return;
            }

            // Validar que la cantidad no exceda el stock disponible
            if (cantidad > stockProducto.StockDisponible)
            {
                msgError("La cantidad de semillas a plantar excede el stock disponible.");
                return;
            }

            // Verificar si el producto es de tipo "Semilla"
            if (tipoProducto == 2)
            {
                // Actualizar el stock de producto de tipo "Árbol"
                Controladora.Controladora.ActualizarStockArbol(productoId, cantidad);

                // Restar la cantidad de semillas sembradas del stock de semillas
                Controladora.Controladora.DisminuirStock(productoId, cantidad);
            }

            // Crear el objeto Siembra y agregarlo a la lista
            Siembra siembra = new Siembra
            {
                ProductoId = productoId,
                Producto = productoCompleto,
                Cantidad = cantidad
            };
            siembraList.Add(siembra);

            // Restar la cantidad de semillas sembradas al stock disponible
            stockProducto.StockDisponible -= cantidad;

            // Actualizar la etiqueta de stock disponible
            lblStockDisponible.Text = $"Stock disponible: {stockProducto.StockDisponible}";

            // Actualizar el contenido del ListBox
            ActualizarListBox();

            // No dejar acceder a cambiar algunos campos
            fechaCompra.Enabled = false;

            // Limpiar los campos de entrada de datos
            comboProductos.SelectedIndex = -1;
            numericCantidad.Value = 0;
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
            listDetalleSiembra.Items.Clear();

            // Agregar cada elemento de la lista al ListBox
            foreach (Siembra siembra in siembraList)
            {
                string item = $"ID: {siembra.ProductoId} - {siembra.Producto} - Cantidad: {siembra.Cantidad}";
                listDetalleSiembra.Items.Add(item);
            }
        }
        public void msgError(string msg)
        {
            lblError.Text = "      " + msg;
            lblError.Visible = true;
        }

        private void CargarProductos()
        {
            List<Producto> productos = Controladora.Controladora.ObtenerSemillasConStockMayorCero();

            comboProductos.Items.Clear();

            // Crear una lista de Producto para mantener los productos y su stock disponible
            productosList = new List<Producto>();

            foreach (Producto producto in productos)
            {
                // Agregar el stock disponible al Producto
                producto.StockDisponible = producto.Stock;

                // Agregar el producto a la lista de productos
                productosList.Add(producto);

                // Construir el texto que se mostrará en el combo box
                string productoCompleto = $"{producto.Nombre} - {ObtenerTipoProductoTexto(producto.TipoProductoId)} - {ObtenerTipoEspecificoTexto(producto.TipoEspecificoId)}";

                // Agregar el texto del producto al combo box
                comboProductos.Items.Add(productoCompleto);
            }

            comboProductos.SelectedIndex = -1;
        }

        private string ObtenerTipoEspecificoTexto(int tipoEspecificoId)
        {
            switch (tipoEspecificoId)
            {
                case 1:
                    return "Exótica";
                case 2:
                    return "Nativa";
                default:
                    return "Desconocido";
            }
        }

        private string ObtenerTipoProductoTexto(int tipoProductoId)
        {
            switch (tipoProductoId)
            {
                case 1:
                    return "Árbol";
                case 2:
                    return "Semilla";
                default:
                    return "Desconocido";
            }
        }

        private void Reproduccion_Load(object sender, EventArgs e)
        {
            // Ocultar la etiqueta al cargar la ventana
            lblStockDisponible.Visible = false;
            CargarProductos();
        }

        private void LimpiarCampos()
        {
            comboProductos.SelectedIndex = -1;
            numericCantidad.Value = 0;

            // Limpiar el contenido del ListBox
            listDetalleSiembra.Items.Clear();

            // Habilitar campos nuevamente
            fechaCompra.Enabled = true;
        }

        private void btnRegistrarSiembra_Click(object sender, EventArgs e)
        {
            if (siembraList.Count == 0)
            {
                msgError("Debe ingresar al menos un detalle de siembra.");
                return;
            }

            DateTime fechaCompra = this.fechaCompra.Value;
            string nombreUsuario = ((Dashboard)Application.OpenForms["Dashboard"]).NombreUsuarioActual;
            int usuarioId = Controladora.Controladora.ObtenerIdUsuario(nombreUsuario);

            SiembraInfo siembraInfo = new SiembraInfo
            {
                FechaSiembra = fechaCompra,
                UsuarioId = usuarioId
            };

            int siembraId = Controladora.Controladora.GuardarSiembra(siembraInfo);

            Producto productoArbol = null;

            foreach (Siembra siembra in siembraList)
            {
                int productoId = siembra.ProductoId;
                int cantidad = siembra.Cantidad;

                // Obtener el producto de tipo "Semilla" que será reducido del stock
                Producto productoSemilla = Controladora.Controladora.ObtenerProductoPorId(productoId);

                if (productoSemilla == null || productoSemilla.TipoProductoId != 2)
                {
                    // No se encontró el producto de tipo "Semilla" o el producto no es de tipo "Semilla"
                    msgError("El producto seleccionado no es una semilla válida.");
                    return;
                }

                // Comprobar que la cantidad de semillas a plantar no exceda el stock disponible
                if (cantidad > productoSemilla.Stock)
                {
                    msgError("La cantidad de semillas a plantar excede el stock disponible.");
                    return;
                }

                // Restar la cantidad de semillas utilizadas en la siembra del stock actual
                int nuevoStockSemilla = productoSemilla.Stock - cantidad;

                // Actualizar el stock de semillas
                Controladora.Controladora.DisminuirStock(productoId, cantidad);

                productoArbol = Controladora.Controladora.ObtenerProductoArbolPorNombre(productoSemilla.Nombre);

                if (productoArbol == null)
                {
                    productoArbol = new Producto
                    {
                        Nombre = productoSemilla.Nombre,
                        TipoProductoId = 1, // 1 representa el tipo de producto "Árbol"
                        TipoEspecificoId = productoSemilla.TipoEspecificoId, // Mantenemos el tipo específico
                    };

                    // Guardar el nuevo producto de tipo "Árbol" en la base de datos con el stock inicial igual a cero
                    int nuevoProductoId = Controladora.Controladora.InsertarProductoSiembra(productoArbol, 0);
                    productoArbol.Id = nuevoProductoId; // Asignar el nuevo Id del producto de árbol

                    // Como el producto de árbol es nuevo, ahora lo agregamos a la lista de stock por productos
                    stockPorProductos.Add(new StockProducto
                    {
                        ProductoId = nuevoProductoId,
                        StockInicial = 0, // Stock inicial en cero
                        StockDisponible = 0 // Stock disponible en cero
                    });
                }

                // Actualizar el stock de árboles con la cantidad sembrada
                Controladora.Controladora.ActualizarStock(productoArbol.Id, cantidad);

                // Crear un objeto DetalleSiembraInfo para cada siembra en la lista
                DetalleSiembraInfo detalleSiembraInfo = new DetalleSiembraInfo
                {
                    SiembraId = siembraId,
                    ProductoId = productoId,
                    Cantidad = cantidad
                };

                // Guardar el detalle de la siembra en la base de datos
                Controladora.Controladora.GuardarDetalleSiembra(detalleSiembraInfo);
            }

            LimpiarCampos();
            siembraList.Clear();

            MessageBox.Show($"La siembra se registró correctamente.", "Siembra registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void comboProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Actualizar el stock disponible cada vez que cambie la selección del producto
            if (comboProductos.SelectedIndex >= 0)
            {
                string productoSeleccionado = comboProductos.SelectedItem.ToString();
                string[] partesProducto = productoSeleccionado.Split(new string[] { " - " }, StringSplitOptions.None);

                if (partesProducto.Length == 3)
                {
                    string nombreProducto = partesProducto[0];
                    string tipoProductoTexto = partesProducto[1];
                    string tipoEspecificoTexto = partesProducto[2];

                    int tipoProducto = ObtenerTipoProductoSegunTexto(tipoProductoTexto);
                    int tipoEspecifico = ObtenerTipoEspecificoSegunTexto(tipoEspecificoTexto);

                    int productoId = Controladora.Controladora.ObtenerIdProducto(nombreProducto, tipoProducto, tipoEspecifico);

                    Producto productoSemilla = Controladora.Controladora.ObtenerProductoPorId(productoId);
                    if (productoSemilla != null && productoSemilla.TipoProductoId == 2)
                    {
                        // Verificar si ya existe información de stock para este producto
                        StockProducto stockProducto = stockPorProductos.FirstOrDefault(s => s.ProductoId == productoId);

                        if (stockProducto == null)
                        {
                            // Si no hay información, crear una nueva entrada para el producto
                            stockProducto = new StockProducto
                            {
                                ProductoId = productoId,
                                StockInicial = productoSemilla.Stock,
                                StockDisponible = productoSemilla.Stock
                            };
                            stockPorProductos.Add(stockProducto);
                        }

                        // Actualizar el stock disponible del producto seleccionado
                        lblStockDisponible.Text = $"Stock disponible: {stockProducto.StockDisponible}";
                        lblStockDisponible.Visible = true;
                    }
                    else
                    {
                        lblStockDisponible.Visible = false;
                    }
                }
            }
        }
    }
}
