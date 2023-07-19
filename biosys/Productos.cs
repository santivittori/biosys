﻿using System;
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

namespace biosys
{
    public partial class Productos : Form
    {
        // Propiedad pública que representa una instancia del panel de control de Dashboard
        public Dashboard DashboardInstance { get; set; }

        private int idProductoSeleccionado = 0;

        public Productos()
        {
            InitializeComponent();
        }
        // Permite editar el campo nombre seleccionado una fila en el datagridview
        private void dataGridViewProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewProductos.SelectedRows.Count > 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow selectedRow = dataGridViewProductos.SelectedRows[0];

                // Obtener el ID del producto seleccionado
                idProductoSeleccionado = Convert.ToInt32(dataGridViewProductos.Rows[e.RowIndex].Cells["ID"].Value);

                // Cargar los datos del producto en los campos correspondientes
                txtNombreProd.Text = dataGridViewProductos.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                string tipoProducto = dataGridViewProductos.Rows[e.RowIndex].Cells["TipoProducto"].Value.ToString();
                if (tipoProducto == "Árbol")
                {
                    comboTipoProducto.SelectedValue = 1;
                }
                else if (tipoProducto == "Semilla")
                {
                    comboTipoProducto.SelectedValue = 2;
                }

                string tipoEspecifico = dataGridViewProductos.Rows[e.RowIndex].Cells["TipoEspecifico"].Value.ToString();
                if (tipoEspecifico == "Exótica")
                {
                    comboTipoEspecifico.SelectedValue = 1;
                }
                else if (tipoEspecifico == "Nativa")
                {
                    comboTipoEspecifico.SelectedValue = 2;
                }
                comboTipoEspecifico.Enabled = false;
                comboTipoProducto.Enabled = false;
            }
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

            // Verificar si el producto ya existe
            bool productoExistente = Controladora.Controladora.VerificarProductoExistente(nombre, tipoProductoID, tipoEspecificoID);

            if (productoExistente)
            {
                msgError("El producto ya existe en la base de datos.");
                return;
            }

            // Verificar si se seleccionó una fila para modificar
            if (idProductoSeleccionado != 0)
            {
                // Actualizar el producto en la base de datos utilizando el ID del producto seleccionado
                Controladora.Controladora.ActualizarProducto(idProductoSeleccionado, nombre);

                // Mostrar mensaje de éxito
                MessageBox.Show("Producto modificado exitosamente.", "Modificación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // No se seleccionó una fila previamente, se creará un nuevo registro

                // Insertar el producto en la base de datos
                Controladora.Controladora.InsertarProducto(nombre, tipoProductoID, tipoEspecificoID);

                // Mostrar mensaje de éxito
                MessageBox.Show("Producto guardado exitosamente.", "Guardado exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Limpiar los campos
            LimpiarCampos();

            // Actualizar el DataGridView
            CargarProductosEnDataGridView();
        }

        private void LimpiarCampos()
        {
            txtNombreProd.Text = string.Empty;
            comboTipoProducto.SelectedIndex = -1;
            comboTipoEspecifico.SelectedIndex = -1;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DashboardInstance.AbrirFormHijo(new Inicio());
            this.Close();
        }

        private void CargarProductosEnDataGridView()
        {
            DataTable dataTable = Controladora.Controladora.ObtenerProductosCompleto();
            dataGridViewProductos.DataSource = dataTable;
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

            comboTipoProducto.SelectedIndex = -1;
            comboTipoEspecifico.SelectedIndex = -1;

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

        private void btnEliminarProd_Click(object sender, EventArgs e)
        {
            // Verificar si se seleccionó una fila en el DataGridView
            if (dataGridViewProductos.SelectedRows.Count > 0)
            {
                // Obtener el ID del producto seleccionado
                int idProducto = Convert.ToInt32(dataGridViewProductos.SelectedRows[0].Cells["ID"].Value);

                // Verificar si el producto ha sido utilizado en una compra
                bool productoEnCompra = Controladora.Controladora.VerificarProductoEnCompra(idProducto);

                if (productoEnCompra)
                {
                    msgError("El producto no puede ser eliminado porque ha sido utilizado en una compra.");
                    return;
                }

                // Eliminar el producto de la base de datos
                Controladora.Controladora.EliminarProducto(idProducto);

                // Mostrar mensaje de éxito y actualizar el DataGridView
                MessageBox.Show("Producto eliminado exitosamente.", "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarProductosEnDataGridView();
            }
            else
            {
                msgError("Debe seleccionar una fila en el DataGridView para eliminar.");
                return;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            comboTipoEspecifico.Enabled = true;
            comboTipoProducto.Enabled = true;

            // Deseleccionar la fila en el DataGridView
            dataGridViewProductos.ClearSelection();
            idProductoSeleccionado = 0;
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
    }
}
