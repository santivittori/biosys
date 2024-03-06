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

namespace biosys
{
    public partial class BajaProductos : Form
    {
        public Dashboard DashboardInstance { get; set; }

        // Campo para almacenar la lista de productos
        private List<ProductoInfo> productos;

        public BajaProductos()
        {
            InitializeComponent();
            
            // Inicializar la lista de productos
            productos = Controladora.Controladora.ObtenerProductosStockComboBox();
        }

        public void msgError(string msg)
        {
            lblError.Text = "      " + msg;
            lblError.Visible = true;
        }

        private void CargarProductos()
        {
            // Limpia el ComboBox
            comboProductos.Items.Clear();

            // Filtra los productos con stock mayor a cero
            var productosConStock = productos.Where(p => p.Stock > 0).ToList();

            foreach (var producto in productosConStock)
            {
                // Agrega los productos al ComboBox
                comboProductos.Items.Add($"{producto.Nombre} - {producto.TipoProducto} - {producto.TipoEspecifico}");
            }

            comboProductos.SelectedIndex = -1;
        }

        private void CargarMotivos()
        {
            // Agrega los motivos posibles al comboMotivo
            comboMotivo.Items.Add("Muerte");
            comboMotivo.Items.Add("Enfermedad");
            comboMotivo.Items.Add("Falta de riego");
            comboMotivo.Items.Add("Hormigas");
            comboMotivo.Items.Add("Hongos");
            comboMotivo.Items.Add("Exceso de agua");
            comboMotivo.Items.Add("Perdida o robo");
            comboMotivo.Items.Add("Semilla sin viabilidad");
            comboMotivo.Items.Add("Otro");

            comboMotivo.SelectedIndex = -1;
        }


        private void BajaProductos_Load(object sender, EventArgs e)
        {
            CargarProductos();
            CargarMotivos();

            // Calcular la posición x para centrar el Label horizontalmente
            int labelPosX = (this.ClientSize.Width - labelTitulo.Width) / 2;

            // Establecer la posición del Label
            labelTitulo.Location = new Point(labelPosX, 50);
        }

        private void LimpiarCampos()
        {
            comboProductos.SelectedIndex = -1;
            comboMotivo.SelectedIndex = -1;
            numericCantidad.Value = 0;
        }

        private void comboProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboProductos.SelectedIndex != -1)
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro/a de que desea cancelar la baja de productos? \n\nLa información se perderá", "Confirmar cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                comboMotivo.SelectedIndex = -1;
                numericCantidad.Value = 0;
            }
        }

        private void btnConfirmarBaja_Click(object sender, EventArgs e)
        {
            // Verificar que se ha seleccionado un producto y un motivo
            if (string.IsNullOrWhiteSpace(comboProductos.Text))
            {
                msgError("Por favor, seleccione un producto antes de confirmar la baja.");
                return;
            }

            if (string.IsNullOrWhiteSpace(comboMotivo.Text))
            {
                msgError("Por favor, seleccione un motivo para la baja.");
                return;
            }

            // Obtener el producto seleccionado
            string productName = comboProductos.SelectedItem.ToString();

            // Extraer el nombre del producto seleccionado
            productName = productName.Split('-')[0].Trim();

            // Obtener la cantidad ingresada por el usuario
            int cantidadBaja = (int)numericCantidad.Value;

            // Verificar que la cantidad sea mayor a cero
            if (cantidadBaja <= 0)
            {
                msgError("La cantidad ingresada debe ser mayor que cero.");
                return;
            }

            int stock = Controladora.Controladora.ObtenerStockProducto(productName);

            if (cantidadBaja > stock)
            {
                msgError("La cantidad ingresada es mayor que el stock disponible. Verifique la cantidad.");
                return;
            }

            Controladora.Controladora.DisminuirStockProducto(productName, cantidadBaja);

            // Actualizar la lista de productos con stock
            productos = Controladora.Controladora.ObtenerProductosStockComboBox();

            MessageBox.Show($"Se realizó la baja de {cantidadBaja} unidad/es de {productName}.", "Baja Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Registrar la baja del producto
            Controladora.Controladora.RegistrarBajaProducto(productName, cantidadBaja, comboMotivo.Text);

            // Ocultar el mensaje de error
            lblError.Visible = false;

            // Limpiar los campos
            LimpiarCampos();
        }
    }
}
