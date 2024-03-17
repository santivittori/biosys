using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMUN;
using Controladora;
using static biosys.Compras;
using Entidad;
using OfficeOpenXml;
using System.IO;

namespace biosys
{
    public partial class Productos : Form
    {
        // Propiedad pública que representa una instancia del panel de control de Dashboard
        public Dashboard DashboardInstance { get; set; }

        private int idProductoSeleccionado = 0;

        private int paginaActual = 1;
        private int tamañoPagina = 8;

        public Productos()
        {
            InitializeComponent();
        }
        private void EstablecerContextoLicencia()
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        }

        private void dataGridViewProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewProductos.SelectedRows.Count > 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow selectedRow = dataGridViewProductos.SelectedRows[0];

                // Obtener el ID del producto seleccionado
                idProductoSeleccionado = Convert.ToInt32(selectedRow.Cells["ID"].Value);

                // Cargar los datos del producto en los campos correspondientes
                txtNombreProd.Text = selectedRow.Cells["Nombre"].Value.ToString();
                string tipoProducto = selectedRow.Cells["TipoProducto"].Value.ToString();
                comboTipoProducto.SelectedValue = ObtenerTipoProductoID(tipoProducto);

                string tipoEspecifico = selectedRow.Cells["TipoEspecifico"].Value.ToString();
                comboTipoEspecifico.SelectedValue = ObtenerTipoEspecificoID(tipoEspecifico);

                // Obtener el valor del tamaño de semilla
                string tamSemilla = selectedRow.Cells["Tamaño de Semilla"].Value.ToString();

                // Verificar si el tamaño de semilla está vacío
                if (string.IsNullOrEmpty(tamSemilla))
                {
                    // Si está vacío, deshabilitar el ComboBox y dejarlo sin ninguna opción seleccionada
                    comboTamSemilla.Enabled = false;
                    comboTamSemilla.SelectedIndex = -1;
                }
                else
                {
                    // Si no está vacío, habilitar el ComboBox y seleccionar el valor correspondiente
                    comboTamSemilla.SelectedValue = ObtenerTamSemillaID(tamSemilla);
                    comboTamSemilla.Enabled = false;
                }

                // Deshabilitar los ComboBox de tipo de producto y tipo específico
                comboTipoEspecifico.Enabled = false;
                comboTipoProducto.Enabled = false;
            }
        }
        private void LimpiarCampos()
        {
            txtNombreProd.Text = string.Empty;
            comboTipoProducto.SelectedIndex = -1;
            comboTipoEspecifico.SelectedIndex = -1;
            comboTamSemilla.SelectedIndex = -1;
            lblError.Visible = false;

            comboTipoEspecifico.Enabled = true;
            comboTipoProducto.Enabled = true;
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            // Cargar tipos de producto en ComboBox
            string sqlTiposProducto = "SELECT id, nombre FROM tipos_producto";
            DataTable dtTiposProducto = Controladora.Controladora.ExecuteQuery(sqlTiposProducto);
            comboTipoProducto.DataSource = dtTiposProducto;
            comboTipoProducto.DisplayMember = "nombre";
            comboTipoProducto.ValueMember = "id";

            // Cargar tipos específicos en ComboBox
            string sqlTiposEspecifico = "SELECT id, nombre FROM tipos_especifico";
            DataTable dtTiposEspecifico = Controladora.Controladora.ExecuteQuery(sqlTiposEspecifico);
            comboTipoEspecifico.DataSource = dtTiposEspecifico;
            comboTipoEspecifico.DisplayMember = "nombre";
            comboTipoEspecifico.ValueMember = "id";

            string sqlTamaniosSemilla = "SELECT id, nombre FROM tam_semilla";
            DataTable dtTamaniosSemilla = Controladora.Controladora.ExecuteQuery(sqlTamaniosSemilla);
            comboTamSemilla.DataSource = dtTamaniosSemilla;
            comboTamSemilla.DisplayMember = "nombre";
            comboTamSemilla.ValueMember = "id";

            comboTipoProducto.SelectedIndex = -1;
            comboTipoEspecifico.SelectedIndex = -1;
            comboTamSemilla.SelectedIndex = -1;

            comboTamSemilla.Enabled = true;

            // Agregar las opciones de ordenamiento al ComboBox
            comboBoxOrdenar.Items.Add("Nombre ascendente");
            comboBoxOrdenar.Items.Add("Nombre descendente");
            comboBoxOrdenar.Items.Add("TipoProducto ascendente");
            comboBoxOrdenar.Items.Add("TipoProducto descendente");
            comboBoxOrdenar.Items.Add("TipoEspecifico ascendente");
            comboBoxOrdenar.Items.Add("TipoEspecifico descendente");

            // Establecer el valor predeterminado para el ComboBox
            comboBoxOrdenar.SelectedIndex = -1;

            CargarProductosEnDataGridView();

            dataGridViewProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProductos.ScrollBars = ScrollBars.None;

            // Calcular la posición x para centrar el Label horizontalmente
            int labelPosX = (this.ClientSize.Width - labelTitulo.Width) / 2;

            // Establecer la posición del Label
            labelTitulo.Location = new Point(labelPosX, 50);
        }

        public void msgError(string msg)
        {
            lblError.Text = "      " + msg;
            lblError.Visible = true;
        }

        private void txtNombreProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e = MetodosComunes.KeyPressSoloLetras(e);

            if (e.Handled)
            {
                // Cancela el evento KeyPress
                e.Handled = true;
            }
        }

        private void txtDescProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e = MetodosComunes.KeyPressSoloLetras(e);

            if (e.Handled)
            {
                e.Handled = true;
            }
        }
        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            e = MetodosComunes.KeyPressSoloLetras(e);

            if (e.Handled)
            {
                e.Handled = true;
            }
        }
        private void FiltrarProductos(string criterioBusqueda)
        {
            // Verificar si el campo de búsqueda no está vacío
            if (string.IsNullOrWhiteSpace(criterioBusqueda))
            {
                // Si está vacío, mostrar todos los productos
                CargarProductosEnDataGridView();
            }
            else
            {
                DataTable dataTable = Controladora.Controladora.ObtenerProductosCompleto();
                dataTable.DefaultView.RowFilter = $"Nombre LIKE '%{criterioBusqueda}%' OR TipoProducto LIKE '%{criterioBusqueda}%' OR TipoEspecifico LIKE '%{criterioBusqueda}%'";
                dataGridViewProductos.DataSource = dataTable;
            }
        }
        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            string criterioBusqueda = txtBusqueda.Text;
            FiltrarProductos(criterioBusqueda);
        }
        private void OrdenarPorNombreAscendente()
        {
            DataTable dataTable = Controladora.Controladora.ObtenerProductosCompleto();
            dataTable.DefaultView.Sort = "Nombre ASC";
            dataGridViewProductos.DataSource = dataTable;
        }

        private void OrdenarPorNombreDescendente()
        {
            DataTable dataTable = Controladora.Controladora.ObtenerProductosCompleto();
            dataTable.DefaultView.Sort = "Nombre DESC";
            dataGridViewProductos.DataSource = dataTable;
        }

        private void OrdenarPorTipoProductoAscendente()
        {
            DataTable dataTable = Controladora.Controladora.ObtenerProductosCompleto();
            dataTable.DefaultView.Sort = "TipoProducto ASC";
            dataGridViewProductos.DataSource = dataTable;
        }

        private void OrdenarPorTipoProductoDescendente()
        {
            DataTable dataTable = Controladora.Controladora.ObtenerProductosCompleto();
            dataTable.DefaultView.Sort = "TipoProducto DESC";
            dataGridViewProductos.DataSource = dataTable;
        }

        private void OrdenarPorTipoEspecificoAscendente()
        {
            DataTable dataTable = Controladora.Controladora.ObtenerProductosCompleto();
            dataTable.DefaultView.Sort = "TipoEspecifico ASC";
            dataGridViewProductos.DataSource = dataTable;
        }

        private void OrdenarPorTipoEspecificoDescendente()
        {
            DataTable dataTable = Controladora.Controladora.ObtenerProductosCompleto();
            dataTable.DefaultView.Sort = "TipoEspecifico DESC";
            dataGridViewProductos.DataSource = dataTable;
        }

        private void comboBoxOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxOrdenar.SelectedItem != null)
            {
                string opcionOrdenamiento = comboBoxOrdenar.SelectedItem.ToString();

                // Realizar el ordenamiento según la opción seleccionada
                if (opcionOrdenamiento == "Nombre ascendente")
                {
                    OrdenarPorNombreAscendente();
                }
                else if (opcionOrdenamiento == "Nombre descendente")
                {
                    OrdenarPorNombreDescendente();
                }
                else if (opcionOrdenamiento == "TipoProducto ascendente")
                {
                    OrdenarPorTipoProductoAscendente();
                }
                else if (opcionOrdenamiento == "TipoProducto descendente")
                {
                    OrdenarPorTipoProductoDescendente();
                }
                else if (opcionOrdenamiento == "TipoEspecifico ascendente")
                {
                    OrdenarPorTipoEspecificoAscendente();
                }
                else if (opcionOrdenamiento == "TipoEspecifico descendente")
                {
                    OrdenarPorTipoEspecificoDescendente();
                }
            }
        }
        private List<Producto> LeerExcel(string filePath)
        {
            List<Producto> productos = new List<Producto>();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                int rows = worksheet.Dimension.Rows;

                // Verificar que el archivo Excel tiene las columnas esperadas (NOMBRE, TIPO PRODUCTO, TIPO ESPECIFICO y TAMAÑO SEMILLA)
                if (worksheet.Cells[1, 1].Text.Trim().ToUpper() != "NOMBRE" ||
                    worksheet.Cells[1, 2].Text.Trim().ToUpper() != "TIPO PRODUCTO" ||
                    worksheet.Cells[1, 3].Text.Trim().ToUpper() != "TIPO ESPECIFICO" ||
                    worksheet.Cells[1, 4].Text.Trim().ToUpper() != "TAMAÑO SEMILLA")
                {
                    // Si las columnas no tienen los títulos esperados, mostrar un mensaje de error y salir
                    msgError("El archivo Excel no tiene los títulos adecuados.");
                    return null;
                }

                for (int i = 2; i <= rows; i++)
                {
                    string nombre = worksheet.Cells[i, 1].Value?.ToString(); // Columna 1 (Nombre)
                    string tipoProductoString = worksheet.Cells[i, 2].Value?.ToString(); // Columna 2 (TipoProducto)
                    string tipoEspecificoString = worksheet.Cells[i, 3].Value?.ToString(); // Columna 3 (TipoEspecifico)
                    string tamSemillaString = worksheet.Cells[i, 4].Value?.ToString(); // Columna 4 (TamañoSemilla)

                    // Verificar que los campos no estén vacíos
                    if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(tipoProductoString) || string.IsNullOrWhiteSpace(tipoEspecificoString))
                    {
                        // Si alguno de los campos está vacío, mostrar un mensaje de error y salir
                        msgError("El archivo Excel contiene datos incompletos.");
                        return null;
                    }

                    int tipoProducto;
                    int tipoEspecifico;
                    int? tamSemillaId = null; // Inicializar en null para productos de tipo Árbol

                    // Obtener los valores enteros correspondientes a TipoProducto y TipoEspecifico
                    try
                    {
                        tipoProducto = ObtenerTipoProductoID(tipoProductoString);
                        tipoEspecifico = ObtenerTipoEspecificoID(tipoEspecificoString);

                        // Obtener el ID del tamaño de semilla si el producto es de tipo Semilla
                        if (tipoProducto == 2) // Si el producto es de tipo Semilla
                        {
                            // Verificar que se haya proporcionado un valor válido para tamaño de semilla
                            if (string.IsNullOrWhiteSpace(tamSemillaString) || !tamSemillaDictionary.ContainsKey(tamSemillaString))
                            {
                                msgError("Valor de Tamaño Semilla inválido para productos de tipo Semilla.");
                                return null;
                            }
                            tamSemillaId = tamSemillaDictionary[tamSemillaString];
                        }
                        else
                        {
                            // Si el producto es de tipo Árbol, asegúrate de que el valor de tamaño de semilla esté en blanco
                            if (!string.IsNullOrWhiteSpace(tamSemillaString))
                            {
                                msgError("Para productos de tipo Árbol, el campo Tamaño Semilla debe estar en blanco.");
                                return null;
                            }
                        }
                    }
                    catch (ArgumentException)
                    {
                        // Si se produce una excepción en los métodos ObtenerTipoProductoID o ObtenerTipoEspecificoID,
                        // significa que los valores no son válidos.
                        msgError("Valores inválidos en el archivo Excel.");
                        return null;
                    }

                    // Agregar los datos leídos a la lista de productos
                    productos.Add(new Producto
                    {
                        Nombre = nombre,
                        TipoProductoId = tipoProducto,
                        TipoEspecificoId = tipoEspecifico,
                        TamSemillaId = tamSemillaId
                    });
                }
            }

            return productos;
        }

        private List<Producto> NormalizarDatos(List<Producto> productos)
        {
            List<Producto> productosNormalizados = new List<Producto>();

            foreach (Producto producto in productos)
            {
                // Verificar que los datos normalizados sean válidos
                if (IsValid(producto))
                {
                    productosNormalizados.Add(producto);
                }
                else
                {
                    // Si los datos no son válidos, detener el proceso y devolver null
                    msgError("Los datos del producto no son válidos.");
                    return null;
                }
            }

            return productosNormalizados;
        }

        private bool IsValid(Producto producto)
        {
            // Verificar que el nombre no sea nulo o vacío
            if (string.IsNullOrWhiteSpace(producto.Nombre))
            {
                return false;
            }

            // Verificar si los valores son válidos (1 para Árbol o 2 para Semilla) y (1 para Éxotica o 2 para Nativa)
            if ((producto.TipoProductoId == 1 || producto.TipoProductoId == 2) &&
                (producto.TipoEspecificoId == 1 || producto.TipoEspecificoId == 2))
            {
                return true;
            }

            return false;
        }

        private Dictionary<string, int> tipoProductoDictionary = new Dictionary<string, int>()
        {
            { "Árbol", 1 },
            { "Semilla", 2 }
        };

        private Dictionary<string, int> tipoEspecificoDictionary = new Dictionary<string, int>()
        {
            { "Exótica", 1 },
            { "Nativa", 2 }
        };

        private Dictionary<string, int> tamSemillaDictionary = new Dictionary<string, int>()
        {
            { "Pequeña", 1 },
            { "Mediana", 2 },
            { "Grande", 3 }
        };

        private int ObtenerTamSemillaID(string tamSemillaString)
        {
            if (tamSemillaDictionary.TryGetValue(tamSemillaString, out int tamSemillaID))
            {
                return tamSemillaID;
            }
            throw new ArgumentException("Valor de TamañoSemilla no válido.");
        }

        private int ObtenerTipoProductoID(string tipoProductoString)
        {
            if (tipoProductoDictionary.TryGetValue(tipoProductoString, out int tipoProductoID))
            {
                return tipoProductoID;
            }
            throw new ArgumentException("Valor de TipoProducto no válido.");
        }

        private int ObtenerTipoEspecificoID(string tipoEspecificoString)
        {
            if (tipoEspecificoDictionary.TryGetValue(tipoEspecificoString, out int tipoEspecificoID))
            {
                return tipoEspecificoID;
            }
            throw new ArgumentException("Valor de TipoEspecifico no válido.");
        }

        private void CargarProductosEnDataGridView()
        {
            // Calcular el índice de inicio para la paginación
            int indiceInicio = (paginaActual - 1) * tamañoPagina;

            // Obtener los productos paginados desde la base de datos
            DataTable dataTable = Controladora.Controladora.ObtenerProductosPaginados(indiceInicio, tamañoPagina);

            // Mostrar información de paginación
            MostrarInformacionPaginacion();

            // Actualizar el DataSource del DataGridView
            dataGridViewProductos.DataSource = dataTable;
        }

        private void MostrarInformacionPaginacion()
        {
            // Calcular el número total de productos
            int totalProductos = Controladora.Controladora.ObtenerCantidadTotalProductos();

            // Calcular el número total de páginas
            int totalPaginas = (int)Math.Ceiling((double)totalProductos / tamañoPagina);

            // Mostrar información de paginación en una etiqueta o control similar
            labelPaginacion.Text = $"Página {paginaActual} de {totalPaginas}. Total de productos: {totalProductos}";
        }
        private void btnPaginaAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--;
                CargarProductosEnDataGridView();
            }
        }
        private void btnPaginaSiguiente_Click(object sender, EventArgs e)
        {
            int totalProductos = Controladora.Controladora.ObtenerCantidadTotalProductos();
            int totalPaginas = (int)Math.Ceiling((double)totalProductos / tamañoPagina);

            if (paginaActual < totalPaginas)
            {
                paginaActual++;
                CargarProductosEnDataGridView();
            }
        }

        private void btnQuitarFiltros_Click(object sender, EventArgs e)
        {
            // Limpiar el TextBox de búsqueda
            txtBusqueda.Text = string.Empty;

            // Deseleccionar el ComboBox
            comboBoxOrdenar.SelectedIndex = -1;

            // Mostrar todos los proveedores en el DataGridView
            CargarProductosEnDataGridView();
        }

        private void btnEliminarProd_Click(object sender, EventArgs e)
        {
            // Verificar si se seleccionó una fila en el DataGridView
            if (dataGridViewProductos.SelectedRows.Count > 0)
            {
                // Obtener el ID del producto seleccionado
                int idProducto = Convert.ToInt32(dataGridViewProductos.SelectedRows[0].Cells["ID"].Value);

                // Verificar si el producto ha sido utilizado en una compra
                bool productoEnCompra = Controladora.Controladora.VerificarProductoEnCompra(idProducto);

                // Verificar si el producto ha sido utilizado en detalle_siembra
                bool productoEnDetalleSiembra = Controladora.Controladora.VerificarProductoEnDetalleSiembra(idProducto);

                if (productoEnCompra || productoEnDetalleSiembra)
                {
                    msgError("El producto no puede ser eliminado porque ha sido utilizado.");
                    return;
                }

                // Mostrar un cuadro de diálogo de confirmación
                DialogResult result = MessageBox.Show("¿Está seguro/a de que desea eliminar este producto?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Si el usuario confirma la eliminación
                if (result == DialogResult.Yes)
                {
                    // Eliminar el producto de la base de datos
                    Controladora.Controladora.EliminarProducto(idProducto);

                    // Mostrar mensaje de éxito y actualizar el DataGridView
                    MessageBox.Show("Producto eliminado exitosamente.", "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarProductosEnDataGridView();
                }
            }
            else
            {
                msgError("Debe seleccionar una fila en el DataGridView para eliminar.");
                return;
            }
        }

        private void btnCargarExcel_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            // Mensaje informativo sobre cómo debe estar estructurado el archivo Excel
            string mensajeInstrucciones =
                "El archivo Excel debe tener el siguiente formato:\n\n" +
                "1. La primera fila debe contener los títulos de las columnas.\n\n" +
                "2. Las columnas deben estar en el siguiente orden:\n\n" +
                "   NOMBRE | TIPO PRODUCTO | TIPO ESPECIFICO | TAMAÑO SEMILLA\n\n" +
                "3. En la columna 'TIPO PRODUCTO', debe especificar 'Árbol' o 'Semilla'. Respetar tildes y buena tipografía.\n\n" +
                "4. En la columna 'TIPO ESPECIFICO', debe especificar 'Éxotica' o 'Nativa'. Respetar tildes y buena tipografía.\n\n" +
                "5. En la columna 'TAMAÑO SEMILLA', debe especificar 'Pequeña', 'Mediana' o 'Grande' para productos de tipo Semilla. Para productos de tipo Árbol, dejar el campo vacío.";


            MessageBox.Show(mensajeInstrucciones, "Instrucciones para cargar el archivo Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);

            EstablecerContextoLicencia();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos Excel (*.xlsx)|*.xlsx|Todos los archivos (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;

                // Leer el contenido del archivo Excel y obtener los datos en una lista de objetos
                List<Producto> productos = LeerExcel(path);

                if (productos != null && productos.Count > 0)
                {
                    // Normalizar los datos y verificar su validez
                    List<Producto> productosNormalizados = NormalizarDatos(productos);

                    if (productosNormalizados != null && productosNormalizados.Count > 0)
                    {
                        // Agregar los productos normalizados a la base de datos
                        foreach (Producto producto in productosNormalizados)
                        {
                            // Verificar si el producto ya existe en la base de datos
                            bool productoExistente = Controladora.Controladora.VerificarProductoExistente(producto);
                            if (productoExistente)
                            {
                                // Omitir la inserción de este producto, ya que ya existe en la base de datos.
                                continue;
                            }

                            // Si el producto no existe, proceder con la inserción
                            Controladora.Controladora.InsertarProducto(producto);
                        }

                        MessageBox.Show("Los productos se han cargado exitosamente.", "Carga exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarProductosEnDataGridView();
                    }
                    else
                    {
                        msgError("El archivo Excel no contiene datos válidos o no se pudo normalizar.");
                        return;
                    }
                }
                else
                {
                    msgError("El archivo Excel no contiene datos válidos o está vacío.");
                    return;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Mostrar un cuadro de diálogo de confirmación
            DialogResult result = MessageBox.Show("¿Está seguro/a de que desea cancelar? La información no guardada se perderá.", "Confirmar cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Verificar si el usuario ha confirmado la cancelación
            if (result == DialogResult.Yes)
            {
                // Si el usuario confirma, cerrar el formulario
                DashboardInstance.AbrirFormHijo(new Inicio());
                this.Close();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            comboTipoEspecifico.Enabled = true;
            comboTipoProducto.Enabled = true;
            comboTamSemilla.Enabled = false;

            // Deseleccionar la fila en el DataGridView
            dataGridViewProductos.ClearSelection();
            idProductoSeleccionado = 0;
            lblError.Visible = false;
        }

        private void btnGuardarProd_Click(object sender, EventArgs e)
        {
            // Validar que se ingresen todos los campos obligatorios
            if (string.IsNullOrEmpty(txtNombreProd.Text) || comboTipoProducto.SelectedItem == null || comboTipoEspecifico.SelectedItem == null)
            {
                msgError("Por favor, complete todos los campos obligatorios.");
                return;
            }

            // Obtener los valores ingresados
            string nombre = txtNombreProd.Text;
            int tipoProductoID = Convert.ToInt32(comboTipoProducto.SelectedValue);
            int tipoEspecificoID = Convert.ToInt32(comboTipoEspecifico.SelectedValue);
            int? tamSemillaID = null;

            if (tipoProductoID == 2)
            {
                // Verificar si se seleccionó un valor en el combo box
                if (comboTamSemilla.SelectedValue == null)
                {
                    msgError("Por favor, seleccione un tamaño de semilla.");
                    return;
                }
                else
                {
                    tamSemillaID = Convert.ToInt32(comboTamSemilla.SelectedValue);
                }
            }

            Producto producto = new Producto()
            {
                Nombre = nombre,
                TipoProductoId = tipoProductoID,
                TipoEspecificoId = tipoEspecificoID,
                TamSemillaId = tamSemillaID
            };

            // Verificar si el producto ya existe
            bool productoExistente = Controladora.Controladora.VerificarProductoExistente(producto);

            if (productoExistente)
            {
                msgError("El producto ya existe en la base de datos.");
                return;
            }

            // Verificar si se debe insertar un nuevo producto o actualizar uno existente
            if (idProductoSeleccionado != 0)
            {
                // Actualizar el producto en la base de datos utilizando el ID del producto seleccionado
                Controladora.Controladora.ActualizarProducto(idProductoSeleccionado, nombre);

                // Mostrar mensaje de éxito
                MessageBox.Show("Producto modificado exitosamente.", "Modificación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Insertar el producto y obtener su ID
                int productoId = Controladora.Controladora.InsertarProducto(producto);

                // Insertar el precio inicial del producto
                Controladora.Controladora.InsertarPrecioProducto(productoId, 0);

                // Mostrar mensaje de éxito
                MessageBox.Show("Producto guardado exitosamente.", "Guardado exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Limpiar los campos
            LimpiarCampos();

            // Actualizar el DataGridView
            CargarProductosEnDataGridView();
        }

        private void btnCancelar_MouseEnter(object sender, EventArgs e)
        {
            btnCancelar.BackColor = Color.Red;
        }

        private void btnCancelar_MouseLeave(object sender, EventArgs e)
        {
            btnCancelar.BackColor = Color.White;
        }

        private void btnEliminarProd_MouseEnter(object sender, EventArgs e)
        {
            btnEliminarProd.BackColor = Color.Red;
        }

        private void btnEliminarProd_MouseLeave(object sender, EventArgs e)
        {
            btnEliminarProd.BackColor = Color.White;
        }

        private void btnGuardarProd_MouseEnter(object sender, EventArgs e)
        {
            btnGuardarProd.BackColor = Color.FromArgb(0, 192, 0);
        }

        private void btnGuardarProd_MouseLeave(object sender, EventArgs e)
        {
            btnGuardarProd.BackColor = Color.White;
        }

        private void comboTipoProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el ID del tipo de producto seleccionado
            if (comboTipoProducto.SelectedItem != null && int.TryParse(comboTipoProducto.SelectedValue.ToString(), out int selectedProductId))
            {
                // Verificar si el ID del tipo de producto seleccionado es igual al ID correspondiente a "Semilla" (por ejemplo, 2)
                if (selectedProductId == 2) // Cambiar 2 por el ID correcto de "Semilla" en tu base de datos
                {
                    comboTamSemilla.Enabled = true; // Habilitar comboTamSemilla si el tipo de producto es "Semilla"
                }
                else
                {
                    comboTamSemilla.Enabled = false; // Deshabilitar comboTamSemilla si el tipo de producto no es "Semilla"
                    comboTamSemilla.SelectedIndex = -1; // Deseleccionar cualquier opción seleccionada en comboTamSemilla
                }
            }
            else
            {
                // Deshabilitar comboTamSemilla si no hay ningún tipo de producto seleccionado
                comboTamSemilla.Enabled = false;
                // Deseleccionar cualquier opción seleccionada en comboTamSemilla
                comboTamSemilla.SelectedIndex = -1;
            }
        }

    }
}
