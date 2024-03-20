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
    public partial class Recolecciones : Form
    {
        private List<Recoleccion> recoleccionList;

        public Dashboard DashboardInstance { get; set; }

        public Recolecciones()
        {
            InitializeComponent();

            recoleccionList = new List<Recoleccion>();
        }

        private void CargarProductos()
        {
            List<string> productos = Controladora.Controladora.ObtenerProductosComboBox();

            comboProductos.Items.Clear();
            comboProductos.Items.AddRange(productos.ToArray());
            comboProductos.SelectedIndex = -1;
        }

        private void Recolecciones_Load(object sender, EventArgs e)
        {
            CargarProductos();

            // Calcular la posición x para centrar el Label horizontalmente
            int labelPosX = (this.ClientSize.Width - labelTitulo.Width) / 2;

            // Establecer la posición del Label
            labelTitulo.Location = new Point(labelPosX, 50);
        }
        private void ActualizarListBox()
        {
            // Limpiar el contenido actual del ListBox
            listDetalleRecoleccion.Items.Clear();

            // Agregar cada elemento de la lista al ListBox
            foreach (Recoleccion recoleccion in recoleccionList)
            {
                string item = $"ID: {recoleccion.ProductoId} - {recoleccion.Producto} - Cantidad: {recoleccion.Cantidad}";
                listDetalleRecoleccion.Items.Add(item);
            }
        }
        public void msgError(string msg)
        {
            lblError.Text = "      " + msg;
            lblError.Visible = true;
        }
        private void LimpiarCampos()
        {
            // Limpiar los campos de entrada de datos
            comboProductos.SelectedIndex = -1;
            numericCantidad.Value = 0;

            // Limpiar el contenido del ListBox
            listDetalleRecoleccion.Items.Clear();

            // Limpiar los textbox
            txtLugar.Text = string.Empty;
            lblError.Visible = false;

            // Habilitar campos nuevamente
            txtLugar.Enabled = true;
            fechaRecoleccion.Enabled = true;
        }
        private void txtLugar_KeyPress(object sender, KeyPressEventArgs e)
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
                numericCantidad.Value = 0;

                // Reiniciar la lista de donación
                recoleccionList.Clear();

                // Limpiar el contenido del ListBox
                listDetalleRecoleccion.Items.Clear();

                // Limpiar los textbox
                txtLugar.Text = string.Empty;

                // Habilitar campos nuevamente
                txtLugar.Enabled = true;
                fechaRecoleccion.Enabled = true;
                lblError.Visible = false;
            }
        }

        private void btnGuardarDetalle_Click(object sender, EventArgs e)
        {
            // Validar que los campos tengan información
            if (string.IsNullOrWhiteSpace(txtLugar.Text) || comboProductos.SelectedIndex == -1 || numericCantidad.Value <= 0)
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

            // Crear una instancia de la clase Recoleccion y agregarla a la lista
            Recoleccion recoleccion = new Recoleccion
            {
                ProductoId = productoId,
                Producto = productoCompleto,
                Cantidad = cantidad
            };
            recoleccionList.Add(recoleccion);

            // No dejar acceder a cambiar algunos campos
            txtLugar.Enabled = false;
            fechaRecoleccion.Enabled = false;
            lblError.Visible = false;

            // Limpiar los campos de entrada de datos
            comboProductos.SelectedIndex = -1;
            numericCantidad.Text = string.Empty;

            // Actualizar el contenido del ListBox
            ActualizarListBox();
        }

        private void btnRegistrarRecoleccion_Click(object sender, EventArgs e)
        {
            if (recoleccionList.Count == 0)
            {
                msgError("  Ingrese al menos un detalle de recolección.");
                return;
            }

            // Mostrar cuadro de diálogo de confirmación
            DialogResult result = MessageBox.Show("¿Desea registrar la recolección?", "Confirmar Recolección", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Verificar si el usuario confirmó la acción
            if (result == DialogResult.Yes)
            {
                string lugar = txtLugar.Text;
                DateTime fechaRecoleccion = this.fechaRecoleccion.Value;

                string nombreUsuario = ((Dashboard)Application.OpenForms["Dashboard"]).NombreUsuarioActual;

                int usuarioId = Controladora.Controladora.ObtenerIdUsuario(nombreUsuario);

                RecoleccionInfo recoleccionInfo = new RecoleccionInfo
                {
                    Lugar = lugar,
                    FechaRecoleccion = fechaRecoleccion,
                    UsuarioId = usuarioId
                };

                int recoleccionId = Controladora.Controladora.GuardarRecoleccion(recoleccionInfo);

                DetalleRecoleccionInfo detalleRecoleccionInfo = new DetalleRecoleccionInfo();

                foreach (Recoleccion recoleccion in recoleccionList)
                {
                    int productoId = recoleccion.ProductoId;
                    int cantidad = recoleccion.Cantidad;

                    detalleRecoleccionInfo.RecoleccionId = recoleccionId;
                    detalleRecoleccionInfo.ProductoId = productoId;
                    detalleRecoleccionInfo.Cantidad = cantidad;

                    Controladora.Controladora.GuardarDetalleRecoleccion(detalleRecoleccionInfo);
                    Controladora.Controladora.ActualizarStock(productoId, cantidad);
                }

                LimpiarCampos();
                recoleccionList.Clear();

                MessageBox.Show("La recolección se registró correctamente.", "Recolección registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnRegistrarRecoleccion_MouseEnter(object sender, EventArgs e)
        {
            btnRegistrarRecoleccion.BackColor = Color.FromArgb(0, 192, 0);
        }

        private void btnRegistrarRecoleccion_MouseLeave(object sender, EventArgs e)
        {
            btnRegistrarRecoleccion.BackColor = Color.White;
        }

        private void btnHistorialRecolecciones_Click(object sender, EventArgs e)
        {
            HistorialRecolecciones historialRecoleccionesForm = new HistorialRecolecciones();
            historialRecoleccionesForm.DashboardInstance = DashboardInstance;
            DashboardInstance.AbrirFormHijo(historialRecoleccionesForm);
        }
    }
}
