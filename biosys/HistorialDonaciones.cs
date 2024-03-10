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
    public partial class HistorialDonaciones : Form
    {
        public Dashboard DashboardInstance { get; set; }

        private DataTable dtHistorialDonacionesOriginal; // DataTable original sin filtrar
        private int tamañoPagina = 25; // Tamaño de la página
        private int paginaActual = 1; // Página actual

        public HistorialDonaciones()
        {
            InitializeComponent();
        }

        private void HistorialDonaciones_Load(object sender, EventArgs e)
        {
            // Calcular la posición x para centrar el Label horizontalmente
            int labelPosX = (this.ClientSize.Width - labelTitulo.Width) / 2;

            // Establecer la posición del Label
            labelTitulo.Location = new Point(labelPosX, 50);

            LlenarDataGridView();

            // Configurar el DataGridView para que no se ajuste automáticamente al tamaño del formulario
            dataGridViewHistorialDonaciones.Anchor = AnchorStyles.None;
        }

        private void LlenarDataGridView()
        {
            // Obtener el historial de compras sin filtrar
            dtHistorialDonacionesOriginal = Controladora.Controladora.ObtenerHistorialDonacionesConNombres();

            // Asignar el DataTable al DataGridView
            dataGridViewHistorialDonaciones.DataSource = dtHistorialDonacionesOriginal;

            // Establecer el modo de autoajuste de las columnas para que llenen el ancho del DataGridView
            foreach (DataGridViewColumn column in dataGridViewHistorialDonaciones.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            // Aplicar el filtro de paginación
            AplicarFiltroPaginacion();

            // Mostrar información de paginación
            MostrarInformacionPaginacionDonaciones();
        }

        private void AplicarFiltroPaginacion()
        {
            // Obtener los datos filtrados según la página actual
            int inicio = (paginaActual - 1) * tamañoPagina;
            int fin = inicio + tamañoPagina - 1;
            DataTable dtPagina = dtHistorialDonacionesOriginal.Clone();

            for (int i = inicio; i <= fin && i < dtHistorialDonacionesOriginal.Rows.Count; i++)
            {
                dtPagina.ImportRow(dtHistorialDonacionesOriginal.Rows[i]);
            }

            // Asignar los datos filtrados al DataGridView
            dataGridViewHistorialDonaciones.DataSource = dtPagina;
        }
        private void MostrarInformacionPaginacionDonaciones()
        {
            int totalDonaciones = dataGridViewHistorialDonaciones.Rows.Count;
            int totalPaginas = (int)Math.Ceiling((double)totalDonaciones / tamañoPagina);
            labelHistorialDonaciones.Text = $"Página {paginaActual} de {totalPaginas}. Total de donaciones: {totalDonaciones}";
        }

        private void btnAntDonaciones_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--;
                AplicarFiltroPaginacion();
                MostrarInformacionPaginacionDonaciones();
            }
        }

        private void btnSigDonaciones_Click(object sender, EventArgs e)
        {
            int totalDonaciones = Controladora.Controladora.ObtenerCantidadTotalDonaciones();
            int totalPaginas = (int)Math.Ceiling((double)totalDonaciones / tamañoPagina);
            if (paginaActual < totalPaginas)
            {
                paginaActual++;
                AplicarFiltroPaginacion();
                MostrarInformacionPaginacionDonaciones();
            }
        }

        private void btnAplicarFiltro_Click(object sender, EventArgs e)
        {
            // Obtener las fechas seleccionadas
            DateTime fechaInicio = dateInicio.Value;
            DateTime fechaFin = dateFin.Value;

            // Aplicar el filtro de fechas
            DataView dv = dtHistorialDonacionesOriginal.DefaultView;

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

            dataGridViewHistorialDonaciones.DataSource = dv.ToTable();

            // Resetear la paginación
            paginaActual = 1;
            MostrarInformacionPaginacionDonaciones();
        }

        private void btnQuitarFiltro_Click(object sender, EventArgs e)
        {
            // Restablecer el filtro de fechas
            DataView dv = dtHistorialDonacionesOriginal.DefaultView;
            dv.RowFilter = string.Empty;

            // Aplicar el filtro de paginación con los datos sin filtrar
            dataGridViewHistorialDonaciones.DataSource = dv.ToTable();

            // Restablecer la paginación
            paginaActual = 1;
            MostrarInformacionPaginacionDonaciones();

            // Restablecer las fechas de inicio y fin al día actual
            dateInicio.Value = DateTime.Today;
            dateFin.Value = DateTime.Today;
        }

        private void pictureBack_Click(object sender, EventArgs e)
        {
            Donaciones donacionesForm = new Donaciones();
            donacionesForm.DashboardInstance = DashboardInstance;
            DashboardInstance.AbrirFormHijo(donacionesForm);
        }
    }
}
