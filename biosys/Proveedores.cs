using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMUN;
using Controladora;
using Entidad;

namespace biosys
{
    public partial class Proveedores : Form
    {
        // Propiedad pública que representa una instancia del panel de control de Dashboard
        public Dashboard DashboardInstance { get; set; }

        private int idProveedorSeleccionado = 0;

        // Declarar variables para la paginación
        private int paginaActual = 1;
        private int tamañoPagina = 8; // Cantidad de registros por página

        public Proveedores()
        {
            InitializeComponent();
        }
        private void dataGridViewProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewProveedores.SelectedRows.Count > 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow selectedRow = dataGridViewProveedores.SelectedRows[0];

                // Crear un objeto ProveedorInfo con los datos del proveedor seleccionado
                ProveedorInfo proveedorSeleccionado = new ProveedorInfo
                {
                    Id = Convert.ToInt32(selectedRow.Cells["ID"].Value),
                    Nombre = selectedRow.Cells["Nombre"].Value.ToString(),
                    Apellido = selectedRow.Cells["Apellido"].Value.ToString(),
                    Email = selectedRow.Cells["Email"].Value.ToString(),
                    Telefono = selectedRow.Cells["Telefono"].Value.ToString()
                };

                // Cargar los datos del proveedor en los campos correspondientes
                txtNombreProv.Text = proveedorSeleccionado.Nombre;
                txtApellidoProv.Text = proveedorSeleccionado.Apellido;
                txtEmailProv.Text = proveedorSeleccionado.Email;
                txtTelefonoProv.Text = proveedorSeleccionado.Telefono;
            }
        }
        private void LimpiarCamposProveedor()
        {
            txtNombreProv.Text = string.Empty;
            txtApellidoProv.Text = string.Empty;
            txtEmailProv.Text = string.Empty;
            txtTelefonoProv.Text = string.Empty;
        }

        private void Proveedores_Load(object sender, EventArgs e)
        {
            // Agregar las opciones de ordenamiento al ComboBox
            comboBoxOrdenar.Items.Add("Nombre ascendente");
            comboBoxOrdenar.Items.Add("Nombre descendente");
            comboBoxOrdenar.Items.Add("Apellido ascendente");
            comboBoxOrdenar.Items.Add("Apellido descendente");

            // Establecer el valor predeterminado para el ComboBox
            comboBoxOrdenar.SelectedIndex = -1;

            CargarProveedoresEnDataGridView();

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

        private void txtNombreProv_KeyPress(object sender, KeyPressEventArgs e)
        {
            e = MetodosComunes.KeyPressSoloLetras(e);

            if (e.Handled)
            {
                // Cancela el evento KeyPress
                e.Handled = true;
            }
        }

        private void txtApellidoProv_KeyPress(object sender, KeyPressEventArgs e)
        {
            e = MetodosComunes.KeyPressSoloLetras(e);

            if (e.Handled)
            {
                e.Handled = true;
            }
        }

        private void txtTelefonoProv_KeyPress(object sender, KeyPressEventArgs e)
        {
            e = MetodosComunes.KeyPressSoloNumeros(e);

            if (e.Handled)
            {
                e.Handled = true;
            }
        }
        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            string criterioBusqueda = txtBusqueda.Text;
            FiltrarPorNombreOApellido(criterioBusqueda);
        }
        private void FiltrarPorNombreOApellido(string criterioBusqueda)
        {
            // Verificar si el campo de búsqueda no está vacío
            if (string.IsNullOrWhiteSpace(criterioBusqueda))
            {
                // Si está vacío, mostrar todos los proveedores
                CargarProveedoresEnDataGridView();
            }
            else
            {
                DataTable dataTable = Controladora.Controladora.ObtenerProveedores();
                dataTable.DefaultView.RowFilter = $"Nombre LIKE '%{criterioBusqueda}%' OR Apellido LIKE '%{criterioBusqueda}%'";
                dataGridViewProveedores.DataSource = dataTable;
            }
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
                else if (opcionOrdenamiento == "Apellido ascendente")
                {
                    OrdenarPorApellidoAscendente();
                }
                else if (opcionOrdenamiento == "Apellido descendente")
                {
                    OrdenarPorApellidoDescendente();
                }
            }
        }
        private void OrdenarPorNombreAscendente()
        {
            DataTable dataTable = Controladora.Controladora.ObtenerProveedores();
            dataTable.DefaultView.Sort = "Nombre ASC";
            dataGridViewProveedores.DataSource = dataTable;
        }
        private void OrdenarPorNombreDescendente()
        {
            DataTable dataTable = Controladora.Controladora.ObtenerProveedores();
            dataTable.DefaultView.Sort = "Nombre DESC";
            dataGridViewProveedores.DataSource = dataTable;
        }
        private void OrdenarPorApellidoAscendente()
        {
            DataTable dataTable = Controladora.Controladora.ObtenerProveedores();
            dataTable.DefaultView.Sort = "Apellido ASC";
            dataGridViewProveedores.DataSource = dataTable;
        }
        private void OrdenarPorApellidoDescendente()
        {
            DataTable dataTable = Controladora.Controladora.ObtenerProveedores();
            dataTable.DefaultView.Sort = "Apellido DESC";
            dataGridViewProveedores.DataSource = dataTable;
        }
        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            e = MetodosComunes.KeyPressSoloLetras(e);

            if (e.Handled)
            {
                e.Handled = true;
            }
        }

        private void CargarProveedoresEnDataGridView()
        {
            // Calcular el índice de inicio para la paginación
            int indiceInicio = (paginaActual - 1) * tamañoPagina;

            // Obtener los proveedores paginados desde la base de datos
            DataTable dataTable = Controladora.Controladora.ObtenerProveedoresPaginados(indiceInicio, tamañoPagina);

            // Actualizar el DataSource del DataGridView
            dataGridViewProveedores.DataSource = dataTable;

            // Mostrar información de paginación
            MostrarInformacionPaginacion();
        }

        private void MostrarInformacionPaginacion()
        {
            // Calcular el número total de proveedores
            int totalProveedores = Controladora.Controladora.ObtenerCantidadTotalProveedores();

            // Calcular el número total de páginas
            int totalPaginas = (int)Math.Ceiling((double)totalProveedores / tamañoPagina);

            // Mostrar información de paginación en una etiqueta o control similar
            labelPaginacion.Text = $"Página {paginaActual} de {totalPaginas}. Total de proveedores: {totalProveedores}";
        }

        private void btnPaginaAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--;
                CargarProveedoresEnDataGridView();
            }
        }

        private void btnPaginaSiguiente_Click(object sender, EventArgs e)
        {
            int totalProveedores = Controladora.Controladora.ObtenerCantidadTotalProveedores();
            int totalPaginas = (int)Math.Ceiling((double)totalProveedores / tamañoPagina);

            if (paginaActual < totalPaginas)
            {
                paginaActual++;
                CargarProveedoresEnDataGridView();
            }
        }

        private void btnQuitarFiltros_Click(object sender, EventArgs e)
        {
            // Limpiar el TextBox de búsqueda
            txtBusqueda.Text = string.Empty;

            // Deseleccionar el ComboBox
            comboBoxOrdenar.SelectedIndex = -1;

            // Mostrar todos los proveedores en el DataGridView
            CargarProveedoresEnDataGridView();
        }

        private void btnEliminarProv_Click(object sender, EventArgs e)
        {
            // Verificar si se seleccionó una fila en el DataGridView
            if (dataGridViewProveedores.SelectedRows.Count > 0)
            {
                // Obtener el ID del proveedor seleccionado
                int idProveedor = Convert.ToInt32(dataGridViewProveedores.SelectedRows[0].Cells["ID"].Value);

                // Verificar si el proveedor ha sido utilizado en una compra
                bool proveedorEnCompra = Controladora.Controladora.VerificarProveedorEnCompras(idProveedor);

                if (proveedorEnCompra)
                {
                    msgError("El proveedor no puede ser eliminado porque ha sido utilizado en una compra.");
                    return;
                }

                // Mostrar un cuadro de diálogo de confirmación
                DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar este proveedor?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Si el usuario confirma la eliminación
                if (result == DialogResult.Yes)
                {
                    // Eliminar el proveedor de la base de datos
                    Controladora.Controladora.EliminarProveedor(idProveedor);

                    // Mostrar mensaje de éxito y actualizar el DataGridView
                    MessageBox.Show("Proveedor eliminado exitosamente.", "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarProveedoresEnDataGridView();
                }
            }
            else
            {
                msgError("Debe seleccionar una fila en el DataGridView para eliminar.");
                return;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Mostrar un cuadro de diálogo de confirmación
            DialogResult result = MessageBox.Show("¿Está seguro de que desea cancelar? La información no guardada se perderá.", "Confirmar cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
            LimpiarCamposProveedor();
            // Deseleccionar la fila en el DataGridView
            dataGridViewProveedores.ClearSelection();
            idProveedorSeleccionado = 0;
            lblError.Visible = false;
        }

        private void btnGuardarProv_Click(object sender, EventArgs e)
        {
            // Verificar campos vacíos
            if (string.IsNullOrEmpty(txtNombreProv.Text) || string.IsNullOrEmpty(txtApellidoProv.Text) ||
                string.IsNullOrEmpty(txtEmailProv.Text) || string.IsNullOrEmpty(txtTelefonoProv.Text))
            {
                msgError("Por favor, complete todos los campos obligatorios.");
                return;
            }

            string nombre = txtNombreProv.Text;
            string apellido = txtApellidoProv.Text;
            string email = txtEmailProv.Text;
            string telefono = txtTelefonoProv.Text;

            bool esValido = MetodosComunes.ValidacionEMAIL(null, email);

            // Crear el objeto ProveedorInfo con los datos del proveedor
            ProveedorInfo proveedorInfo = new ProveedorInfo
            {
                Id = idProveedorSeleccionado,
                Nombre = nombre,
                Apellido = apellido,
                Email = email,
                Telefono = telefono
            };

            bool proveedorExistente = Controladora.Controladora.VerificarProveedorExistente(proveedorInfo);

            if (!esValido)
            {
                msgError("Debe ingresar un email válido, por favor verifíquelo.");
                return;
            }
            else if (proveedorExistente)
            {
                msgError("El proveedor ya existe en la base de datos.");
                return;
            }

            // Verificar si se seleccionó una fila para modificar
            if (idProveedorSeleccionado != 0)
            {
                // Actualizar el producto en la base de datos utilizando el ID del producto seleccionado
                Controladora.Controladora.ActualizarProveedor(proveedorInfo);

                // Mostrar mensaje de éxito
                MessageBox.Show("Proveedor modificado exitosamente.", "Modificación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Controladora.Controladora.InsertarProveedor(proveedorInfo);

                // Mostrar mensaje de éxito y limpiar campos
                MessageBox.Show("Proveedor guardado exitosamente.", "Guardado exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LimpiarCamposProveedor();

            // Actualizar el DataGridView
            CargarProveedoresEnDataGridView();
        }

        private void btnEliminarProv_MouseEnter(object sender, EventArgs e)
        {
            btnEliminarProv.BackColor = Color.Red;
        }

        private void btnEliminarProv_MouseLeave(object sender, EventArgs e)
        {
            btnEliminarProv.BackColor = Color.White;
        }

        private void btnCancelar_MouseEnter(object sender, EventArgs e)
        {
            btnCancelar.BackColor = Color.Red;
        }

        private void btnCancelar_MouseLeave(object sender, EventArgs e)
        {
            btnCancelar.BackColor = Color.White;
        }

        private void btnGuardarProv_MouseEnter(object sender, EventArgs e)
        {
            btnGuardarProv.BackColor = Color.FromArgb(0, 192, 0);
        }

        private void btnGuardarProv_MouseLeave(object sender, EventArgs e)
        {
            btnGuardarProv.BackColor = Color.White;
        }
    }
}
