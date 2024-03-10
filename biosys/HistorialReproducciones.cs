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
    public partial class HistorialReproducciones : Form
    {

        public Dashboard DashboardInstance { get; set; }

        private DataTable dtHistorialReproduccionesOriginal; // DataTable original sin filtrar
        private int tamañoPagina = 25; // Tamaño de la página
        private int paginaActual = 1; // Página actual

        public HistorialReproducciones()
        {
            InitializeComponent();
        }

        private void HistorialReproducciones_Load(object sender, EventArgs e)
        {
            // Calcular la posición x para centrar el Label horizontalmente
            int labelPosX = (this.ClientSize.Width - labelTitulo.Width) / 2;

            // Establecer la posición del Label
            labelTitulo.Location = new Point(labelPosX, 50);

            LlenarDataGridView();

            // Configurar el DataGridView para que no se ajuste automáticamente al tamaño del formulario
            dataGridViewHistorialReproducciones.Anchor = AnchorStyles.None;
        }

        private void LlenarDataGridView()
        {
            // Obtener el historial de compras sin filtrar
            dtHistorialReproduccionesOriginal = Controladora.Controladora.ObtenerHistorialReproduccionesConNombres();

            // Asignar el DataTable al DataGridView
            dataGridViewHistorialReproducciones.DataSource = dtHistorialReproduccionesOriginal;

            // Establecer el modo de autoajuste de las columnas para que llenen el ancho del DataGridView
            foreach (DataGridViewColumn column in dataGridViewHistorialReproducciones.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            // Aplicar el filtro de paginación
            AplicarFiltroPaginacion();

            // Mostrar información de paginación
            MostrarInformacionPaginacionReproducciones();
        }
        private void AplicarFiltroPaginacion()
        {
            // Obtener los datos filtrados según la página actual
            int inicio = (paginaActual - 1) * tamañoPagina;
            int fin = inicio + tamañoPagina - 1;
            DataTable dtPagina = dtHistorialReproduccionesOriginal.Clone();

            for (int i = inicio; i <= fin && i < dtHistorialReproduccionesOriginal.Rows.Count; i++)
            {
                dtPagina.ImportRow(dtHistorialReproduccionesOriginal.Rows[i]);
            }

            // Asignar los datos filtrados al DataGridView
            dataGridViewHistorialReproducciones.DataSource = dtPagina;
        }
        private void MostrarInformacionPaginacionReproducciones()
        {
            int totalReproducciones = dataGridViewHistorialReproducciones.Rows.Count;
            int totalPaginas = (int)Math.Ceiling((double)totalReproducciones / tamañoPagina);
            labelHistorialReproducciones.Text = $"Página {paginaActual} de {totalPaginas}. Total de reproducciones: {totalReproducciones}";
        }

        private void btnAntReproducciones_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--;
                AplicarFiltroPaginacion();
                MostrarInformacionPaginacionReproducciones();
            }
        }

        private void btnSigReproducciones_Click(object sender, EventArgs e)
        {
            int totalReproducciones = Controladora.Controladora.ObtenerCantidadTotalReproducciones();
            int totalPaginas = (int)Math.Ceiling((double)totalReproducciones / tamañoPagina);
            if (paginaActual < totalPaginas)
            {
                paginaActual++;
                AplicarFiltroPaginacion();
                MostrarInformacionPaginacionReproducciones();
            }
        }

        private void btnAplicarFiltro_Click(object sender, EventArgs e)
        {
            // Obtener las fechas seleccionadas
            DateTime fechaInicio = dateInicio.Value;
            DateTime fechaFin = dateFin.Value;

            // Aplicar el filtro de fechas
            DataView dv = dtHistorialReproduccionesOriginal.DefaultView;

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

            dataGridViewHistorialReproducciones.DataSource = dv.ToTable();

            // Resetear la paginación
            paginaActual = 1;
            MostrarInformacionPaginacionReproducciones();
        }

        private void btnQuitarFiltro_Click(object sender, EventArgs e)
        {
            // Restablecer el filtro de fechas
            DataView dv = dtHistorialReproduccionesOriginal.DefaultView;
            dv.RowFilter = string.Empty;

            // Aplicar el filtro de paginación con los datos sin filtrar
            dataGridViewHistorialReproducciones.DataSource = dv.ToTable();

            // Restablecer la paginación
            paginaActual = 1;
            MostrarInformacionPaginacionReproducciones();

            // Restablecer las fechas de inicio y fin al día actual
            dateInicio.Value = DateTime.Today;
            dateFin.Value = DateTime.Today;
        }

        private void pictureBack_Click(object sender, EventArgs e)
        {
            Reproduccion reproduccionesForm = new Reproduccion();
            reproduccionesForm.DashboardInstance = DashboardInstance;
            DashboardInstance.AbrirFormHijo(reproduccionesForm);
        }
    }
}
