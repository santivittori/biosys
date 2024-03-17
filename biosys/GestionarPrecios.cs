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
using Font = System.Drawing.Font;

namespace biosys
{
    public partial class GestionarPrecios : Form
    {
        public Dashboard DashboardInstance { get; set; }

        private List<ProductoInfo> productos;

        public GestionarPrecios()
        {
            InitializeComponent();

            // Inicializar la lista de productos en el constructor
            productos = Controladora.Controladora.ObtenerProductosArbolStockComboBox();
        }

        private void GestionarPrecios_Load(object sender, EventArgs e)
        {
            CargarProductosArbolConStock();

            // Agregar el texto de ayuda al TextBox
            txtPrecioUnitario.Text = "Fijar nuevo precio. Ej: 2350,70";
            // Asignar el color gris al texto de ayuda
            txtPrecioUnitario.ForeColor = System.Drawing.Color.Gray;

            // Calcular la posición x para centrar el Label horizontalmente
            int labelPosX = (this.ClientSize.Width - labelTitulo.Width) / 2;

            // Establecer la posición del Label
            labelTitulo.Location = new Point(labelPosX, 50);

            lblNohayprecio.Visible = false;
            labelPrecioCosto.Visible = false;
        }

        private void CargarProductosArbolConStock()
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

        private void txtPrecioUnitario_Enter(object sender, EventArgs e)
        {
            // Limpiar el texto de ayuda y cambiar el color del texto al entrar al TextBox
            if (txtPrecioUnitario.Text == "Fijar nuevo precio. Ej: 2350,70")
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
                txtPrecioUnitario.Text = "Fijar nuevo precio. Ej: 2350,70";
                txtPrecioUnitario.ForeColor = System.Drawing.Color.Gray;
            }
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro/a de que desea cancelar la operación? \n\nLa información se perderá.", "Confirmar cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DashboardInstance.AbrirFormHijo(new Inicio());
                this.Close();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro/a de que desea limpiar los campos? \n\nLa información se perderá.", "Confirmar limpieza de campos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                CargarProductosArbolConStock();
                lblNohayprecio.Visible = false;
                labelPrecioCosto.Visible = false;
                txtPrecioUnitario.Text = string.Empty;
                comboProductos.SelectedIndex = -1;
            }
        }
        public void msgError(string msg)
        {
            lblError.Text = "      " + msg;
            lblError.Visible = true;
        }

        private void btnFijarPrecio_MouseEnter(object sender, EventArgs e)
        {
            btnFijarPrecio.BackColor = Color.FromArgb(0, 192, 0);
        }

        private void btnFijarPrecio_MouseLeave(object sender, EventArgs e)
        {
            btnFijarPrecio.BackColor = Color.White;
        }

        private void btnCancelar_MouseEnter(object sender, EventArgs e)
        {
            btnCancelar.BackColor = Color.Red;
        }

        private void btnCancelar_MouseLeave(object sender, EventArgs e)
        {
            btnCancelar.BackColor = Color.White;
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

        private void comboProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarPrecioMostrado();
        }

        private void btnFijarPrecio_Click(object sender, EventArgs e)
        {
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

                    ProductoInfo producto = productos.FirstOrDefault(p =>
                        p.Nombre == nombreProducto &&
                        p.TipoProducto == tipoProductoTexto &&
                        p.TipoEspecifico == tipoEspecificoTexto
                    );

                    if (producto != null)
                    {
                        if (!string.IsNullOrEmpty(txtPrecioUnitario.Text))
                        {
                            decimal precioUnitarioIngresado;
                            if (decimal.TryParse(txtPrecioUnitario.Text, out precioUnitarioIngresado))
                            {
                                // Mostrar cuadro de diálogo de confirmación
                                DialogResult result = MessageBox.Show("¿Está seguro/a de fijar el precio unitario de costo?", "Confirmar Precio", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                // Verificar si el usuario confirmó la acción
                                if (result == DialogResult.Yes)
                                {
                                    Controladora.Controladora.GuardarPrecioUnitario(producto.Id, precioUnitarioIngresado);
                                    ActualizarPrecioMostrado();
                                    LimpiarControles();
                                    MessageBox.Show("Precio unitario de costo fijado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                msgError("El precio unitario ingresado no es válido.");
                            }
                        }
                        else
                        {
                            msgError("Por favor ingrese el precio unitario.");
                        }
                    }
                }
            }
            else
            {
                msgError("Por favor seleccione un producto.");
            }
        }

        private void ActualizarPrecioMostrado()
        {
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

                    ProductoInfo producto = productos.FirstOrDefault(p =>
                        p.Nombre == nombreProducto &&
                        p.TipoProducto == tipoProductoTexto &&
                        p.TipoEspecifico == tipoEspecificoTexto
                    );

                    if (producto != null)
                    {
                        decimal precioUnitarioFijado = Controladora.Controladora.ObtenerPrecioUnitarioFijado(producto.Id);

                        if (precioUnitarioFijado > 0)
                        {
                            labelPrecioCosto.Text = $"Precio Unitario de Costo: {precioUnitarioFijado.ToString("N2")}";
                            labelPrecioCosto.Font = new Font(labelPrecioCosto.Font, FontStyle.Bold);
                            labelPrecioCosto.ForeColor = Color.Black;
                            labelPrecioCosto.Visible = true;
                        }
                        else
                        {
                            lblNohayprecio.Font = new Font(lblNohayprecio.Font, FontStyle.Bold);
                            lblNohayprecio.ForeColor = Color.Black;
                            lblNohayprecio.Visible = true;
                            labelPrecioCosto.Visible = false;
                        }
                    }
                }
            }
            else
            {
                lblNohayprecio.Visible = true;
                labelPrecioCosto.Visible = false;
            }
        }

        private void LimpiarControles()
        {
            comboProductos.SelectedIndex = -1;
            lblNohayprecio.Visible = false;
            labelPrecioCosto.Visible = false;
            txtPrecioUnitario.Clear();
        }

    }
}
