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
    public partial class HistorialVentas : Form
    {
        public Dashboard DashboardInstance { get; set; }

        private DataTable dtHistorialVentasOriginal; // DataTable original sin filtrar
        private int tamañoPagina = 24; // Tamaño de la página
        private int paginaActual = 1; // Página actual

        public HistorialVentas()
        {
            InitializeComponent();
        }

        private void HistorialVentas_Load(object sender, EventArgs e)
        {
            // Calcular la posición x para centrar el Label horizontalmente
            int labelPosX = (this.ClientSize.Width - labelTitulo.Width) / 2;

            // Establecer la posición del Label
            labelTitulo.Location = new Point(labelPosX, 50);

            LlenarDataGridView();

            // Configurar el DataGridView para que no se ajuste automáticamente al tamaño del formulario
            dataGridViewHistorialVentas.Anchor = AnchorStyles.None;
            dataGridViewHistorialVentas.ScrollBars = ScrollBars.None;
        }

        private void LlenarDataGridView()
        {
            // Obtener el historial de compras sin filtrar
            dtHistorialVentasOriginal = Controladora.Controladora.ObtenerHistorialVentasConNombres();

            // Asignar el DataTable al DataGridView
            dataGridViewHistorialVentas.DataSource = dtHistorialVentasOriginal;

            // Establecer el modo de autoajuste de las columnas para que llenen el ancho del DataGridView
            foreach (DataGridViewColumn column in dataGridViewHistorialVentas.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            // Aplicar el filtro de paginación
            AplicarFiltroPaginacion();

            // Mostrar información de paginación
            MostrarInformacionPaginacionVentas();
        }
        private void AplicarFiltroPaginacion()
        {
            // Obtener los datos filtrados según la página actual
            int inicio = (paginaActual - 1) * tamañoPagina;
            int fin = inicio + tamañoPagina - 1;
            DataTable dtPagina = dtHistorialVentasOriginal.Clone();

            for (int i = inicio; i <= fin && i < dtHistorialVentasOriginal.Rows.Count; i++)
            {
                dtPagina.ImportRow(dtHistorialVentasOriginal.Rows[i]);
            }

            // Asignar los datos filtrados al DataGridView
            dataGridViewHistorialVentas.DataSource = dtPagina;
        }

        private void MostrarInformacionPaginacionVentas()
        {
            int totalVentas = dtHistorialVentasOriginal.Rows.Count; // Obtener el total de ventas
            int totalPaginas = (int)Math.Ceiling((double)totalVentas / tamañoPagina);
            labelHistorialVentas.Text = $"Página {paginaActual} de {totalPaginas}. Total de ventas: {totalVentas}";
        }

        private void btnAntVentas_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--;
                AplicarFiltroPaginacion();
                MostrarInformacionPaginacionVentas();
            }
        }

        private void btnSigVentas_Click(object sender, EventArgs e)
        {
            int totalVentas = Controladora.Controladora.ObtenerCantidadTotalVentas();
            int totalPaginas = (int)Math.Ceiling((double)totalVentas / tamañoPagina);
            if (paginaActual < totalPaginas)
            {
                paginaActual++;
                AplicarFiltroPaginacion();
                MostrarInformacionPaginacionVentas();
            }
        }

        private void btnAplicarFiltro_Click(object sender, EventArgs e)
        {
            // Obtener las fechas seleccionadas
            DateTime fechaInicio = dateInicio.Value;
            DateTime fechaFin = dateFin.Value;

            // Aplicar el filtro de fechas
            DataView dv = dtHistorialVentasOriginal.DefaultView;

            // Verificar si las fechas son iguales
            if (fechaInicio == fechaFin)
            {
                // Si las fechas son iguales, establecer el filtro para ese día específico
                dv.RowFilter = $"fecha = '{fechaInicio.ToShortDateString()}'";
            }
            else
            {
                // Si las fechas son diferentes, aplicar el filtro como antes
                dv.RowFilter = $"fecha >= '{fechaInicio.ToShortDateString()}' AND fecha <= '{fechaFin.ToShortDateString()}'";
            }

            dataGridViewHistorialVentas.DataSource = dv.ToTable();

            // Resetear la paginación
            paginaActual = 1;
            MostrarInformacionPaginacionVentas();
        }

        private void btnQuitarFiltro_Click(object sender, EventArgs e)
        {
            // Restablecer el filtro de fechas
            DataView dv = dtHistorialVentasOriginal.DefaultView;
            dv.RowFilter = string.Empty;

            // Aplicar el filtro de paginación con los datos sin filtrar
            dataGridViewHistorialVentas.DataSource = dv.ToTable();

            // Restablecer la paginación
            paginaActual = 1;
            MostrarInformacionPaginacionVentas();

            // Restablecer las fechas de inicio y fin al día actual
            dateInicio.Value = DateTime.Today;
            dateFin.Value = DateTime.Today;
        }
        private void pictureBack_Click(object sender, EventArgs e)
        {
            Ventas ventasForm = new Ventas();
            ventasForm.DashboardInstance = DashboardInstance;
            DashboardInstance.AbrirFormHijo(ventasForm);
        }
    }
}
