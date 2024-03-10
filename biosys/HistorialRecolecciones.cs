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
    public partial class HistorialRecolecciones : Form
    {
        public Dashboard DashboardInstance { get; set; }

        private DataTable dtHistorialRecoleccionesOriginal; // DataTable original sin filtrar
        private int tamañoPagina = 25; // Tamaño de la página
        private int paginaActual = 1; // Página actual

        public HistorialRecolecciones()
        {
            InitializeComponent();
        }

        private void HistorialRecolecciones_Load(object sender, EventArgs e)
        {
            // Calcular la posición x para centrar el Label horizontalmente
            int labelPosX = (this.ClientSize.Width - labelTitulo.Width) / 2;

            // Establecer la posición del Label
            labelTitulo.Location = new Point(labelPosX, 50);

            LlenarDataGridView();

            // Configurar el DataGridView para que no se ajuste automáticamente al tamaño del formulario
            dataGridViewHistorialRecolecciones.Anchor = AnchorStyles.None;
        }
        private void LlenarDataGridView()
        {
            // Obtener el historial de compras sin filtrar
            dtHistorialRecoleccionesOriginal = Controladora.Controladora.ObtenerHistorialRecoleccionesConNombres();

            // Asignar el DataTable al DataGridView
            dataGridViewHistorialRecolecciones.DataSource = dtHistorialRecoleccionesOriginal;

            // Establecer el modo de autoajuste de las columnas para que llenen el ancho del DataGridView
            foreach (DataGridViewColumn column in dataGridViewHistorialRecolecciones.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            // Aplicar el filtro de paginación
            AplicarFiltroPaginacion();

            // Mostrar información de paginación
            MostrarInformacionPaginacionRecolecciones();
        }

        private void AplicarFiltroPaginacion()
        {
            // Obtener los datos filtrados según la página actual
            int inicio = (paginaActual - 1) * tamañoPagina;
            int fin = inicio + tamañoPagina - 1;
            DataTable dtPagina = dtHistorialRecoleccionesOriginal.Clone();

            for (int i = inicio; i <= fin && i < dtHistorialRecoleccionesOriginal.Rows.Count; i++)
            {
                dtPagina.ImportRow(dtHistorialRecoleccionesOriginal.Rows[i]);
            }

            // Asignar los datos filtrados al DataGridView
            dataGridViewHistorialRecolecciones.DataSource = dtPagina;
        }
        private void MostrarInformacionPaginacionRecolecciones()
        {
            int totalRecolecciones = dataGridViewHistorialRecolecciones.Rows.Count;
            int totalPaginas = (int)Math.Ceiling((double)totalRecolecciones / tamañoPagina);
            labelHistorialRecolecciones.Text = $"Página {paginaActual} de {totalPaginas}. Total de recolecciones: {totalRecolecciones}";
        }

        private void btnAplicarFiltro_Click(object sender, EventArgs e)
        {
            // Obtener las fechas seleccionadas
            DateTime fechaInicio = dateInicio.Value;
            DateTime fechaFin = dateFin.Value;

            // Aplicar el filtro de fechas
            DataView dv = dtHistorialRecoleccionesOriginal.DefaultView;

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

            dataGridViewHistorialRecolecciones.DataSource = dv.ToTable();

            // Resetear la paginación
            paginaActual = 1;
            MostrarInformacionPaginacionRecolecciones();
        }

        private void btnQuitarFiltro_Click(object sender, EventArgs e)
        {
            // Restablecer el filtro de fechas
            DataView dv = dtHistorialRecoleccionesOriginal.DefaultView;
            dv.RowFilter = string.Empty;

            // Aplicar el filtro de paginación con los datos sin filtrar
            dataGridViewHistorialRecolecciones.DataSource = dv.ToTable();

            // Restablecer la paginación
            paginaActual = 1;
            MostrarInformacionPaginacionRecolecciones();

            // Restablecer las fechas de inicio y fin al día actual
            dateInicio.Value = DateTime.Today;
            dateFin.Value = DateTime.Today;
        }

        private void btnAntRecolecciones_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--;
                AplicarFiltroPaginacion();
                MostrarInformacionPaginacionRecolecciones();
            }
        }

        private void btnSigRecolecciones_Click(object sender, EventArgs e)
        {
            int totalRecolecciones = Controladora.Controladora.ObtenerCantidadTotalRecolecciones();
            int totalPaginas = (int)Math.Ceiling((double)totalRecolecciones / tamañoPagina);
            if (paginaActual < totalPaginas)
            {
                paginaActual++;
                AplicarFiltroPaginacion();
                MostrarInformacionPaginacionRecolecciones();
            }
        }
    }
}
