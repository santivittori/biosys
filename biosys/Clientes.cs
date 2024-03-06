using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
    public partial class Clientes : Form
    {
        // Propiedad pública que representa una instancia del panel de control de Dashboard
        public Dashboard DashboardInstance { get; set; }

        private int idClienteSeleccionado = 0;

        // Declarar variables para la paginación
        private int paginaActual = 1;
        private int tamañoPagina = 8; // Cantidad de registros por página

        public Clientes()
        {
            InitializeComponent();
        }

        private void dataGridViewClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewClientes.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewClientes.SelectedRows[0];
                ClienteInfo clienteSeleccionado = new ClienteInfo
                {
                    Id = Convert.ToInt32(selectedRow.Cells["ID"].Value),
                    Nombre = selectedRow.Cells["Nombre"].Value.ToString(),
                    Apellido = selectedRow.Cells["Apellido"].Value.ToString(),
                    Email = selectedRow.Cells["Email"].Value.ToString(),
                    Telefono = selectedRow.Cells["Telefono"].Value.ToString()
                };

                txtNombreCliente.Text = clienteSeleccionado.Nombre;
                txtApellidoCliente.Text = clienteSeleccionado.Apellido;
                txtEmailCliente.Text = clienteSeleccionado.Email;
                txtTelefonoCliente.Text = clienteSeleccionado.Telefono;
            }
        }

        private void LimpiarCamposCliente()
        {
            txtNombreCliente.Text = string.Empty;
            txtApellidoCliente.Text = string.Empty;
            txtEmailCliente.Text = string.Empty;
            txtTelefonoCliente.Text = string.Empty;
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            comboBoxOrdenar.Items.Add("Nombre ascendente");
            comboBoxOrdenar.Items.Add("Nombre descendente");
            comboBoxOrdenar.Items.Add("Apellido ascendente");
            comboBoxOrdenar.Items.Add("Apellido descendente");
            comboBoxOrdenar.SelectedIndex = -1;

            CargarClientesEnDataGridView();

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
        private void txtNombreCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            e = MetodosComunes.KeyPressSoloLetras(e);

            if (e.Handled)
            {
                e.Handled = true;
            }
        }

        private void txtApellidoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            e = MetodosComunes.KeyPressSoloLetras(e);

            if (e.Handled)
            {
                e.Handled = true;
            }
        }
        private void txtTelefonoCliente_KeyPress(object sender, KeyPressEventArgs e)
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
            if (string.IsNullOrWhiteSpace(criterioBusqueda))
            {
                CargarClientesEnDataGridView();
            }
            else
            {
                DataTable dataTable = Controladora.Controladora.ObtenerClientes();
                dataTable.DefaultView.RowFilter = $"Nombre LIKE '%{criterioBusqueda}%' OR Apellido LIKE '%{criterioBusqueda}%'";
                dataGridViewClientes.DataSource = dataTable;
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
            DataTable dataTable = Controladora.Controladora.ObtenerClientes();
            dataTable.DefaultView.Sort = "Nombre ASC";
            dataGridViewClientes.DataSource = dataTable;
        }

        private void OrdenarPorNombreDescendente()
        {
            DataTable dataTable = Controladora.Controladora.ObtenerClientes();
            dataTable.DefaultView.Sort = "Nombre DESC";
            dataGridViewClientes.DataSource = dataTable;
        }

        private void OrdenarPorApellidoAscendente()
        {
            DataTable dataTable = Controladora.Controladora.ObtenerClientes();
            dataTable.DefaultView.Sort = "Apellido ASC";
            dataGridViewClientes.DataSource = dataTable;
        }

        private void OrdenarPorApellidoDescendente()
        {
            DataTable dataTable = Controladora.Controladora.ObtenerClientes();
            dataTable.DefaultView.Sort = "Apellido DESC";
            dataGridViewClientes.DataSource = dataTable;
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            e = MetodosComunes.KeyPressSoloLetras(e);

            if (e.Handled)
            {
                e.Handled = true;
            }
        }

        private void CargarClientesEnDataGridView()
        {
            // Calcular el índice de inicio para la paginación
            int indiceInicio = (paginaActual - 1) * tamañoPagina;

            // Obtener los clientes paginados desde la base de datos
            DataTable dataTable = Controladora.Controladora.ObtenerClientesPaginados(indiceInicio, tamañoPagina);

            // Actualizar el DataSource del DataGridView
            dataGridViewClientes.DataSource = dataTable;

            // Mostrar información de paginación
            MostrarInformacionPaginacion();
        }

        private void MostrarInformacionPaginacion()
        {
            // Calcular el número total de clientes
            int totalClientes = Controladora.Controladora.ObtenerCantidadTotalClientes();

            // Calcular el número total de páginas
            int totalPaginas = (int)Math.Ceiling((double)totalClientes / tamañoPagina);

            // Mostrar información de paginación en una etiqueta o control similar
            labelPaginacion.Text = $"Página {paginaActual} de {totalPaginas}. Total de clientes: {totalClientes}";
        }

        private void btnPaginaAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--;
                CargarClientesEnDataGridView();
            }
        }

        private void btnPaginaSiguiente_Click(object sender, EventArgs e)
        {
            int totalClientes = Controladora.Controladora.ObtenerCantidadTotalClientes();
            int totalPaginas = (int)Math.Ceiling((double)totalClientes / tamañoPagina);

            if (paginaActual < totalPaginas)
            {
                paginaActual++;
                CargarClientesEnDataGridView();
            }
        }

        private void btnQuitarFiltros_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = string.Empty;
            comboBoxOrdenar.SelectedIndex = -1;
            CargarClientesEnDataGridView();
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            if (dataGridViewClientes.SelectedRows.Count > 0)
            {
                // Obtener el ID del cliente seleccionado
                int idCliente = Convert.ToInt32(dataGridViewClientes.SelectedRows[0].Cells["ID"].Value);

                // Verificar si el cliente está asociado a alguna compra
                bool clienteEnCompra = Controladora.Controladora.VerificarClienteEnVentas(idCliente);

                // Mostrar un cuadro de diálogo de confirmación
                DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar este cliente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Si el usuario confirma la eliminación
                if (result == DialogResult.Yes)
                {
                    // Eliminar el cliente
                    Controladora.Controladora.EliminarCliente(idCliente);

                    // Actualizar la vista
                    MessageBox.Show("Cliente eliminado exitosamente.", "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarClientesEnDataGridView();
                }
            }
            else
            {
                // Si no se ha seleccionado ningún cliente, mostrar un mensaje de error
                msgError("Debe seleccionar una fila en el DataGridView para eliminar.");
                return;
            }
        }

        private void brnCancelar_Click(object sender, EventArgs e)
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
            LimpiarCamposCliente();
            dataGridViewClientes.ClearSelection();
            idClienteSeleccionado = 0;
            lblError.Visible = false;
        }

        private void btnGuardarCliente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreCliente.Text) || string.IsNullOrEmpty(txtApellidoCliente.Text) || string.IsNullOrEmpty(txtEmailCliente.Text) || string.IsNullOrEmpty(txtTelefonoCliente.Text))
            {
                msgError("Por favor, complete todos los campos obligatorios.");
                return;
            }

            string nombre = txtNombreCliente.Text;
            string apellido = txtApellidoCliente.Text;
            string email = txtEmailCliente.Text;
            string telefono = txtTelefonoCliente.Text;

            bool esValido = MetodosComunes.ValidacionEMAIL(null, email);

            ClienteInfo clienteInfo = new ClienteInfo
            {
                Id = idClienteSeleccionado,
                Nombre = nombre,
                Apellido = apellido,
                Email = email,
                Telefono = telefono
            };

            bool clienteExistente = Controladora.Controladora.VerificarClienteExistente(clienteInfo);

            if (!esValido)
            {
                msgError("Debe ingresar un email válido, por favor verifíquelo.");
                return;
            }
            else if (clienteExistente)
            {
                msgError("El cliente ya existe en la base de datos.");
                return;
            }

            if (idClienteSeleccionado != 0)
            {
                Controladora.Controladora.ActualizarCliente(clienteInfo);
                MessageBox.Show("Cliente modificado exitosamente.", "Modificación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Controladora.Controladora.InsertarCliente(clienteInfo);
                MessageBox.Show("Cliente guardado exitosamente.", "Guardado exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LimpiarCamposCliente();
            CargarClientesEnDataGridView();
        }
    }
}
