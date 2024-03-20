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
using System.Windows.Media.Media3D;

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

            comboUnidadMedida.Enabled = false;
            labelgramo.Visible = false;
            labelkilogramo.Visible = false;
        }

        private void Donaciones_Load(object sender, EventArgs e)
        {
            CargarProductos();
            CargarUnidades();

            // Calcular la posición x para centrar el Label horizontalmente
            int labelPosX = (this.ClientSize.Width - labelTitulo.Width) / 2;

            // Establecer la posición del Label
            labelTitulo.Location = new Point(labelPosX, 50);
        }

        private void CargarUnidades()
        {
            // Lista de unidades disponibles (esto puede venir de tu lógica de negocio o base de datos)
            List<string> unidades = new List<string> { "Unidades", "Gramos", "Kilogramos" };

            // Asignar la lista de unidades al ComboBox
            comboUnidadMedida.DataSource = unidades;

            // Establecer el valor predeterminado
            comboUnidadMedida.SelectedIndex = -1;
        }

        private void CargarProductos()
        {
            List<string> productos = Controladora.Controladora.ObtenerProductosComboBox();

            comboProductos.Items.Clear();
            comboProductos.Items.AddRange(productos.ToArray());
            comboProductos.SelectedIndex = -1;
        }

        private void ActualizarListBox()
        {
            // Limpiar el contenido actual del ListBox
            listDetalleDonacion.Items.Clear();

            // Agregar cada elemento de la lista al ListBox
            foreach (Donacion donacion in donacionList)
            {
                string unidadMedida = donacion.TipoProducto == "Semilla" ? ObtenerUnidadMedida(donacion.UnidadMedida) : ""; // Obtener la unidad de medida solo si el producto es una semilla
                string item = $"ID: {donacion.ProductoId} - {donacion.Producto} - Cantidad: {donacion.Cantidad} {unidadMedida}";
                listDetalleDonacion.Items.Add(item);
            }
        }

        private string ObtenerUnidadMedida(string unidad)
        {
            switch (unidad)
            {
                case "gramos":
                    return "gramos";
                case "kilogramos":
                    return "kilogramos";
                default:
                    return ""; // En caso de que la unidad no sea ni gramos ni kilogramos
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

        private void LimpiarCampos()
        {
            // Limpiar los campos de entrada de datos
            comboProductos.SelectedIndex = -1;
            comboUnidadMedida.SelectedIndex = -1;
            numericCantidad.Value = 0;
            comboUnidadMedida.Enabled = false;

            // Limpiar el contenido del ListBox
            listDetalleDonacion.Items.Clear();

            // Limpiar los textbox
            txtDonante.Text = string.Empty;

            // Habilitar campos nuevamente
            txtDonante.Enabled = true;
            fechaDonacion.Enabled = true;

            lblError.Visible = false;
            labelgramo.Visible = false;
            labelkilogramo.Visible = false;
        }

        public void msgError(string msg)
        {
            lblError.Text = "      " + msg;
            lblError.Visible = true;
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea cancelar la compra? \n\nLa información se perderá.", "Confirmar cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                // Limpiar los campos de entrada de datos
                comboProductos.SelectedIndex = -1;
                comboUnidadMedida.SelectedIndex = -1;
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
                lblError.Visible = false;
                comboUnidadMedida.Enabled = false;
                labelgramo.Visible = false;
                labelkilogramo.Visible = false;
            }
        }

        private void btnGuardarDetalle_Click(object sender, EventArgs e)
        {
            // Validar que los campos tengan información
            if (string.IsNullOrWhiteSpace(txtDonante.Text) || comboProductos.SelectedIndex == -1 || numericCantidad.Value <= 0)
            {
                msgError("  Complete los campos obligatorios.");
                return;
            }

            // Obtener el producto seleccionado y la cantidad ingresada
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
            int cantidad = int.Parse(numericCantidad.Text);

            // Obtener la unidad de medida seleccionada
            string unidadMedida = comboUnidadMedida.SelectedItem?.ToString(); // Usando el operador de navegación segura

            // Verificar si la unidad de medida es null
            if (unidadMedida == null)
            {
                msgError("  Seleccione una unidad de medida.");
                return;
            }

            // Calcular la cantidad de semillas o árboles según el tipo de producto y la unidad de medida seleccionada
            int cantidadSemillas = 0;
            if (tipoProductoTexto.Equals("Semilla"))
            {
                // Obtener el tamaño de semilla del producto
                int tamSemillaId = Controladora.Controladora.ObtenerTamSemillaIdDeProducto(productoId);

                if (unidadMedida == "Gramos")
                {
                    // Obtener el número de semillas por gramo del tamaño de semilla
                    int semillasPorGramo = Controladora.Controladora.ObtenerSemillasPorGramo(tamSemillaId);

                    // Calcular la cantidad de semillas
                    cantidadSemillas = cantidad * semillasPorGramo;
                }
                else if (unidadMedida == "Kilogramos")
                {
                    // Obtener el número de semillas por gramo del tamaño de semilla
                    int semillasPorGramo = Controladora.Controladora.ObtenerSemillasPorGramo(tamSemillaId);

                    // Convertir kilogramos a gramos y luego calcular la cantidad de semillas
                    cantidadSemillas = cantidad * 1000 * semillasPorGramo;
                }
                else
                {
                    // La cantidad ingresada ya está en semillas
                    cantidadSemillas = cantidad;
                }
            }
            else if (tipoProductoTexto.Equals("Árbol"))
            {
                // Para los árboles, la cantidad siempre es igual al valor ingresado en el campo de cantidad
                cantidadSemillas = cantidad;
            }

            // Crear una instancia de la clase Donacion y agregarla a la lista
            Donacion donacion = new Donacion
            {
                ProductoId = productoId,
                Producto = productoCompleto,
                Cantidad = cantidadSemillas,
                TipoProducto = tipoProductoTexto,
                UnidadMedida = unidadMedida
            };
            donacionList.Add(donacion);

            // No dejar acceder a cambiar algunos campos
            txtDonante.Enabled = false;
            fechaDonacion.Enabled = false;
            lblError.Visible = false;

            // Limpiar los campos de entrada de datos
            comboProductos.SelectedIndex = -1;
            comboUnidadMedida.SelectedIndex = -1;
            numericCantidad.Text = string.Empty;

            // Actualizar el contenido del ListBox
            ActualizarListBox();
        }

        private void btnRegistrarDonacion_Click(object sender, EventArgs e)
        {
            if (donacionList.Count == 0)
            {
                msgError("  Ingrese al menos un detalle de donación.");
                return;
            }

            // Mostrar cuadro de diálogo de confirmación
            DialogResult result = MessageBox.Show("¿Desea registrar la donación?", "Confirmar Donación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Verificar si el usuario confirmó la acción
            if (result == DialogResult.Yes)
            {
                string donante = txtDonante.Text;
                DateTime fechaDonacion = this.fechaDonacion.Value;

                string nombreUsuario = ((Dashboard)Application.OpenForms["Dashboard"]).NombreUsuarioActual;

                int usuarioId = Controladora.Controladora.ObtenerIdUsuario(nombreUsuario);

                DonacionInfo donacionInfo = new DonacionInfo
                {
                    Donante = donante,
                    FechaDonacion = fechaDonacion,
                    UsuarioId = usuarioId
                };

                int donacionId = Controladora.Controladora.GuardarDonacion(donacionInfo);

                DetalleDonacionInfo detalleDonacionInfo = new DetalleDonacionInfo();

                foreach (Donacion donacion in donacionList)
                {
                    int productoId = donacion.ProductoId;
                    int cantidad = donacion.Cantidad;

                    detalleDonacionInfo.DonacionId = donacionId;
                    detalleDonacionInfo.ProductoId = productoId;
                    detalleDonacionInfo.Cantidad = cantidad;

                    Controladora.Controladora.GuardarDetalleDonacion(detalleDonacionInfo);
                    Controladora.Controladora.ActualizarStock(productoId, cantidad);
                }

                LimpiarCampos();
                donacionList.Clear();

                MessageBox.Show("La donación se registró correctamente.", "Donación registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelar_MouseEnter(object sender, EventArgs e)
        {
            btnCancelar.BackColor = Color.Red;
        }

        private void btnCancelar_MouseLeave(object sender, EventArgs e)
        {
            btnCancelar.BackColor = Color.White;
        }

        private void btnRegistrarDonacion_MouseEnter(object sender, EventArgs e)
        {
            btnRegistrarDonacion.BackColor = Color.FromArgb(0, 192, 0);
        }

        private void btnRegistrarDonacion_MouseLeave(object sender, EventArgs e)
        {
            btnRegistrarDonacion.BackColor = Color.White;
        }

        private void btnHistorialDonaciones_Click(object sender, EventArgs e)
        {
            HistorialDonaciones historialDonacionesForm = new HistorialDonaciones();
            historialDonacionesForm.DashboardInstance = DashboardInstance;
            DashboardInstance.AbrirFormHijo(historialDonacionesForm);
        }

        private void comboProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboProductos.SelectedItem != null)
            {
                string productoCompleto = comboProductos.SelectedItem.ToString();
                string[] partesProducto = productoCompleto.Split(new string[] { " - " }, StringSplitOptions.None);

                if (partesProducto.Length == 3)
                {
                    string tipoProductoTexto = partesProducto[1];

                    // Verificar si el producto seleccionado es una semilla
                    if (tipoProductoTexto.Equals("Semilla"))
                    {
                        // Habilitar el combobox de unidad de medida
                        comboUnidadMedida.Enabled = true;
                    }
                    else if (tipoProductoTexto.Equals("Árbol"))
                    {
                        comboUnidadMedida.SelectedIndex = comboUnidadMedida.FindStringExact("Unidades");
                        comboUnidadMedida.Enabled = false; // Deshabilitar el combo de unidad de medida
                    }
                    else
                    {
                        comboUnidadMedida.Enabled = false;
                    }
                }
            }
        }

        private void comboUnidadMedida_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar si hay un elemento seleccionado en el combo box
            if (comboUnidadMedida.SelectedItem != null)
            {
                string selectedUnit = comboUnidadMedida.SelectedItem.ToString();

                if (selectedUnit == "Gramos")
                {
                    // Hacer visible el label de gramos y ocultar el de kilogramos
                    labelgramo.Visible = true;
                    labelkilogramo.Visible = false;
                }
                else if (selectedUnit == "Kilogramos")
                {
                    // Hacer visible el label de kilogramos y ocultar el de gramos
                    labelkilogramo.Visible = true;
                    labelgramo.Visible = false;
                }
                else
                {
                    // Si se selecciona "Unidades", ocultar ambos labels
                    labelgramo.Visible = false;
                    labelkilogramo.Visible = false;
                }
            }
            else
            {
                // Manejar el caso cuando no hay ningún elemento seleccionado en el combo box
                // Por ejemplo, puedes dejar ambos labels ocultos
                labelgramo.Visible = false;
                labelkilogramo.Visible = false;
            }
        }
    }
}
