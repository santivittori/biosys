﻿using Microsoft.Win32;
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
                string item = $"ID: {compra.ProductoId} - {compra.Producto} - Cantidad: {compra.Cantidad} - Precio Total: ${compra.PrecioTotal}";
                listDetalleCompra.Items.Add(item);
            }
        }

        private void CargarProveedores()
        {
            List<Proveedor> proveedores = Controladora.Controladora.ObtenerDatosProveedores();

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

            // Agregar el texto de ayuda al TextBox
            txtPrecioUnitario.Text = "Ejemplo: 1350,70";
            // Asignar el color gris al texto de ayuda
            txtPrecioUnitario.ForeColor = System.Drawing.Color.Gray;

            // Calcular la posición x para centrar el Label horizontalmente
            int labelPosX = (this.ClientSize.Width - labelTitulo.Width) / 2;

            // Establecer la posición del Label
            labelTitulo.Location = new Point(labelPosX, 50);

            labelPrecioTotal.Visible = false;
            txtPrecioTotal.Visible = false;
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
            txtPrecioUnitario.Text = string.Empty;
            lblError.Visible = false;

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
                txtPrecioUnitario.Text = string.Empty;

                // Habilitar campos nuevamente
                txtNroFactura.Enabled = true;
                txtNroRemito.Enabled = true;
                comboProveedor.Enabled = true;
                fechaCompra.Enabled = true;
                lblError.Visible = false;
            }
        }

        private void btnGuardarDetalle_Click(object sender, EventArgs e)
        {
            // Validar que los campos tengan información
            if (string.IsNullOrWhiteSpace(txtNroFactura.Text) || string.IsNullOrWhiteSpace(txtNroRemito.Text) || comboProveedor.SelectedIndex == -1 || comboProductos.SelectedIndex == -1 || numericCantidad.Value <= 0)
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

            decimal precioTotal = 0;
            decimal precioUnitario = 0; // Declarar precioUnitario aquí para que esté disponible en todo el método

            // Si el producto es una semilla, obtener el precio total del TextBox
            if (tipoProductoTexto.Equals("Semilla"))
            {
                if (!decimal.TryParse(txtPrecioTotal.Text, out precioTotal))
                {
                    msgError("Ingrese un precio total válido para la semilla.");
                    return;
                }
            }
            else
            {
                // Si el texto no contiene una coma, agregar la coma y dos ceros después del número
                if (!txtPrecioUnitario.Text.Contains(","))
                {
                    txtPrecioUnitario.Text += ",00";
                }

                if (!decimal.TryParse(txtPrecioUnitario.Text, out precioUnitario))
                {
                    msgError("Ingrese un precio unitario válido para el producto.");
                    return;
                }

                // Calcular el precio total
                precioTotal = precioUnitario * cantidad;
            }

            // Crear una instancia de la clase Compra y agregarla a la lista
            Compra compra = new Compra(productoId, productoCompleto, cantidad, precioUnitario, precioTotal);
            comprasList.Add(compra);

            // No dejar acceder a cambiar algunos campos
            txtNroFactura.Enabled = false;
            txtNroRemito.Enabled = false;
            comboProveedor.Enabled = false;
            fechaCompra.Enabled = false;

            // Limpiar los campos de entrada de datos
            comboProductos.SelectedIndex = -1;
            numericCantidad.Text = string.Empty;
            txtPrecioUnitario.Text = string.Empty;
            txtPrecioTotal.Text = string.Empty;
            lblError.Visible = false;

            // Actualizar el contenido del ListBox
            ActualizarListBox();
        }

        private void btnRegistrarCompra_Click(object sender, EventArgs e)
        {
            if (comprasList.Count == 0)
            {
                msgError("Debe ingresar al menos un detalle de compra.");
                return;
            }

            // Mostrar cuadro de diálogo de confirmación
            DialogResult result = MessageBox.Show("¿Está seguro/a de que desea realizar la compra?", "Confirmar Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Verificar si el usuario confirmó la acción
            if (result == DialogResult.Yes)
            {
                string nroFactura = txtNroFactura.Text;
                string nroRemito = txtNroRemito.Text;
                string proveedorEmail = comboProveedor.SelectedValue.ToString();
                DateTime fechaCompra = this.fechaCompra.Value;

                string nombreUsuario = ((Dashboard)Application.OpenForms["Dashboard"]).NombreUsuarioActual;

                int usuarioId = Controladora.Controladora.ObtenerIdUsuario(nombreUsuario);

                decimal precioTotalCompra = 0;

                // Crear un objeto CompraInfo con los datos de la compra
                CompraInfo compraInfo = new CompraInfo
                {
                    NroFactura = nroFactura,
                    NroRemito = nroRemito,
                    ProveedorEmail = proveedorEmail,
                    FechaCompra = fechaCompra,
                    UsuarioId = usuarioId,
                    PrecioTotalCompra = precioTotalCompra
                };

                foreach (Compra compra in comprasList)
                {
                    compraInfo.PrecioTotalCompra += compra.PrecioTotal;
                }

                int compraId = Controladora.Controladora.GuardarCompra(compraInfo);

                // Crear un objeto DetalleCompraInfo fuera del foreach
                DetalleCompraInfo detalleCompraInfo = new DetalleCompraInfo();

                foreach (Compra compra in comprasList)
                {
                    int productoId = compra.ProductoId;
                    int cantidad = compra.Cantidad;
                    decimal precioUnitario = compra.PrecioUnitario;
                    decimal precioTotalDetalle = compra.PrecioTotal;

                    // Asignar los valores del detalle de compra al objeto DetalleCompraInfo
                    detalleCompraInfo.CompraId = compraId;
                    detalleCompraInfo.ProductoId = productoId;
                    detalleCompraInfo.Cantidad = cantidad;
                    detalleCompraInfo.PrecioUnitario = precioUnitario;
                    detalleCompraInfo.PrecioTotalDetalle = precioTotalDetalle;

                    Controladora.Controladora.GuardarDetalleCompra(detalleCompraInfo);
                    Controladora.Controladora.ActualizarStock(productoId, cantidad);
                }

                LimpiarCampos();
                comprasList.Clear();

                MessageBox.Show($"La compra se registró correctamente.\n\nPrecio total: ${compraInfo.PrecioTotalCompra}", "Compra registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnRegistrarCompra_MouseEnter(object sender, EventArgs e)
        {
            btnRegistrarCompra.BackColor = Color.FromArgb(0, 192, 0);
        }

        private void btnRegistrarCompra_MouseLeave(object sender, EventArgs e)
        {
            btnRegistrarCompra.BackColor = Color.White;
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
                        txtPrecioTotal.Visible = true;
                        labelPrecioTotal.Visible = true;

                        // Habilitar el TextBox de precio total y deshabilitar el de precio unitario
                        txtPrecioTotal.Enabled = true;
                        txtPrecioUnitario.Enabled = false;

                        txtPrecioUnitario.Visible = false;
                        labelPrecioUnitario.Visible = false;

                    }
                    else
                    {
                        txtPrecioUnitario.Visible = true;
                        labelPrecioUnitario.Visible = true;

                        // Habilitar el TextBox de precio unitario y deshabilitar el de precio total
                        txtPrecioTotal.Enabled = false;
                        txtPrecioUnitario.Enabled = true;

                        txtPrecioTotal.Visible = false;
                        labelPrecioTotal.Visible = false;
                    }
                }
            }
        }

        private void btnHistorialCompras_Click(object sender, EventArgs e)
        {
            HistorialCompras historialComprasForm = new HistorialCompras();
            historialComprasForm.DashboardInstance = DashboardInstance;
            DashboardInstance.AbrirFormHijo(historialComprasForm);
        }
    }
}
