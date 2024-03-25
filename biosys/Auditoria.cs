using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace biosys
{
    public partial class Auditoria : Form
    {
        public Dashboard DashboardInstance { get; set; }

        private int paginaActual = 1;
        private int tamañoPagina = 8;

        private int pagactualproductos = 1;
        private int tamañopagproductos = 8;

        public Auditoria()
        {
            InitializeComponent();
        }

        private void Auditoria_Load(object sender, EventArgs e)
        {
            CargarAuditoriaInicioyCerrar();
            CargarAuditoriaProductos();

            dgvIniciarCerrarSesion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIniciarCerrarSesion.ScrollBars = ScrollBars.None;

            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.ScrollBars = ScrollBars.None;

            // Calcular la posición x para centrar el Label horizontalmente
            int labelPosX = (this.ClientSize.Width - labelTitulo.Width) / 2;

            // Establecer la posición del Label
            labelTitulo.Location = new Point(labelPosX, 50);
        }

        private void CargarAuditoriaInicioyCerrar()
        {
            try
            {
                // Calcular el índice de inicio para la paginación
                int indiceInicio = (paginaActual - 1) * tamañoPagina;

                // Obtener los registros de auditoría paginados desde la base de datos
                DataTable auditoriaData = Controladora.Controladora.ObtenerAuditoriaInicioyCerrarPaginada(indiceInicio, tamañoPagina);

                // Asignar los datos al DataGridView
                dgvIniciarCerrarSesion.DataSource = auditoriaData;

                // Modificar los nombres de las columnas
                dgvIniciarCerrarSesion.Columns["id"].HeaderText = "Id";
                dgvIniciarCerrarSesion.Columns["usuario"].HeaderText = "Usuario";
                dgvIniciarCerrarSesion.Columns["fechahora"].HeaderText = "Fecha y Hora";
                dgvIniciarCerrarSesion.Columns["accion"].HeaderText = "Acción";

                // Mostrar información de paginación
                MostrarInformacionPaginacion();
            }
            catch (Exception ex)
            {
                // Manejo de errores
                MessageBox.Show("Error al cargar los registros de auditoría: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPaginaAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--;
                CargarAuditoriaInicioyCerrar();
            }
        }

        private void btnPaginaSiguiente_Click(object sender, EventArgs e)
        {
            int totalInicioyCierre = Controladora.Controladora.ObtenerCantidadTotalInicioyCierre();
            int totalPaginas = (int)Math.Ceiling((double)totalInicioyCierre / tamañoPagina);

            if (paginaActual < totalPaginas)
            {
                paginaActual++;
                CargarAuditoriaInicioyCerrar();
            }
        }
        private void MostrarInformacionPaginacion()
        {
            // Calcular el número total de productos
            int totalInicioyCierre = Controladora.Controladora.ObtenerCantidadTotalInicioyCierre();

            // Calcular el número total de páginas
            int totalPaginas = (int)Math.Ceiling((double)totalInicioyCierre / tamañoPagina);

            // Mostrar información de paginación en una etiqueta o control similar
            labelPaginacion.Text = $"Página {paginaActual} de {totalPaginas}. Total de registros: {totalInicioyCierre}";
        }

        private void CargarAuditoriaProductos()
        {
            try
            {
                // Calcular el índice de inicio para la paginación
                int indiceInicio = (paginaActual - 1) * tamañoPagina;

                // Obtener los registros de auditoría de productos paginados desde la base de datos
                DataTable auditoriaData = Controladora.Controladora.ObtenerAuditoriaProductosPaginada(indiceInicio, tamañoPagina);

                // Asignar los datos al DataGridView
                dgvProductos.DataSource = auditoriaData;

                // Modificar los nombres de las columnas
                dgvProductos.Columns["id"].HeaderText = "Id";
                dgvProductos.Columns["usuario"].HeaderText = "Usuario";
                dgvProductos.Columns["fecha_hora"].HeaderText = "Fecha y Hora";
                dgvProductos.Columns["accion"].HeaderText = "Acción";
                dgvProductos.Columns["producto"].HeaderText = "Producto";
                dgvProductos.Columns["origen"].HeaderText = "Origen";

                // Mostrar información de paginación
                MostrarInformacionPaginacionProductos();
            }
            catch (Exception ex)
            {
                // Manejo de errores
                MessageBox.Show("Error al cargar los registros de auditoría de productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPagAntProductos_Click(object sender, EventArgs e)
        {
            if (pagactualproductos > 1)
            {
                pagactualproductos--;
                CargarAuditoriaProductos();
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int totalProductos = Controladora.Controladora.ObtenerCantidadTotalAuditoriaProductos();
            int totalPaginasProd = (int)Math.Ceiling((double)totalProductos / tamañopagproductos);

            if (pagactualproductos < totalPaginasProd)
            {
                pagactualproductos++;
                CargarAuditoriaProductos();
            }
        }
        private void MostrarInformacionPaginacionProductos()
        {
            // Calcular el número total de registros de auditoría de productos
            int totalProductos = Controladora.Controladora.ObtenerCantidadTotalAuditoriaProductos();

            // Calcular el número total de páginas
            int totalPaginasProd = (int)Math.Ceiling((double)totalProductos / tamañopagproductos);

            // Mostrar información de paginación en una etiqueta o control similar
            labelPaginacionProductos.Text = $"Página {pagactualproductos} de {totalPaginasProd}. Total de registros: {totalProductos}";
        }

        private void btnInfAuditorias_Click(object sender, EventArgs e)
        {
            InformesAuditoria informesAuditoriaForm = new InformesAuditoria();
            informesAuditoriaForm.DashboardInstance = DashboardInstance;
            DashboardInstance.AbrirFormHijo(informesAuditoriaForm);

        }
    }
}
