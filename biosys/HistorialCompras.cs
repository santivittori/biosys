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
    public partial class HistorialCompras : Form
    {
        public Dashboard DashboardInstance { get; set; }

        private DataTable dtHistorialComprasOriginal; // DataTable original sin filtrar
        private int tamañoPagina = 24; // Tamaño de la página
        private int paginaActual = 1; // Página actual

        public HistorialCompras()
        {
            InitializeComponent();
        }

        private void HistorialCompras_Load(object sender, EventArgs e)
        {
            // Calcular la posición x para centrar el Label horizontalmente
            int labelPosX = (this.ClientSize.Width - labelTitulo.Width) / 2;

            // Establecer la posición del Label
            labelTitulo.Location = new Point(labelPosX, 50);

            LlenarDataGridView();

            // Configurar el DataGridView para que no se ajuste automáticamente al tamaño del formulario
            dataGridViewHistorialCompras.Anchor = AnchorStyles.None;
            dataGridViewHistorialCompras.ScrollBars = ScrollBars.None;
        }
        private void LlenarDataGridView()
        {
            // Obtener el historial de compras sin filtrar
            dtHistorialComprasOriginal = Controladora.Controladora.ObtenerHistorialComprasConNombres();

            // Asignar el DataTable al DataGridView
            dataGridViewHistorialCompras.DataSource = dtHistorialComprasOriginal;

            // Establecer el modo de autoajuste de las columnas para que llenen el ancho del DataGridView
            foreach (DataGridViewColumn column in dataGridViewHistorialCompras.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            // Aplicar el filtro de paginación
            AplicarFiltroPaginacion();

            // Mostrar información de paginación
            MostrarInformacionPaginacionCompras();
        }

        private void AplicarFiltroPaginacion()
        {
            // Obtener los datos filtrados según la página actual
            int inicio = (paginaActual - 1) * tamañoPagina;
            int fin = inicio + tamañoPagina - 1;
            DataTable dtPagina = dtHistorialComprasOriginal.Clone();

            for (int i = inicio; i <= fin && i < dtHistorialComprasOriginal.Rows.Count; i++)
            {
                dtPagina.ImportRow(dtHistorialComprasOriginal.Rows[i]);
            }

            // Asignar los datos filtrados al DataGridView
            dataGridViewHistorialCompras.DataSource = dtPagina;
        }

        private void MostrarInformacionPaginacionCompras()
        {
            int totalCompras = dtHistorialComprasOriginal.Rows.Count; // Obtener el total de compras
            int totalPaginas = (int)Math.Ceiling((double)totalCompras / tamañoPagina);
            labelHistorialCompras.Text = $"Página {paginaActual} de {totalPaginas}. Total de compras: {totalCompras}";
        }
        private void btnAntCompras_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--;
                AplicarFiltroPaginacion();
                MostrarInformacionPaginacionCompras();
            }
        }

        private void btnSigCompras_Click(object sender, EventArgs e)
        {
            int totalCompras = Controladora.Controladora.ObtenerCantidadTotalCompras();
            int totalPaginas = (int)Math.Ceiling((double)totalCompras / tamañoPagina);
            if (paginaActual < totalPaginas)
            {
                paginaActual++;
                AplicarFiltroPaginacion();
                MostrarInformacionPaginacionCompras();
            }
        }

        private void btnAplicarFiltro_Click(object sender, EventArgs e)
        {
            // Obtener las fechas seleccionadas
            DateTime fechaInicio = dateInicio.Value;
            DateTime fechaFin = dateFin.Value;

            // Aplicar el filtro de fechas
            DataView dv = dtHistorialComprasOriginal.DefaultView;

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

            dataGridViewHistorialCompras.DataSource = dv.ToTable();

            // Resetear la paginación
            paginaActual = 1;
            MostrarInformacionPaginacionCompras();
        }

        private void btnQuitarFiltro_Click(object sender, EventArgs e)
        {
            // Restablecer el filtro de fechas
            DataView dv = dtHistorialComprasOriginal.DefaultView;
            dv.RowFilter = string.Empty;

            // Aplicar el filtro de paginación con los datos sin filtrar
            dataGridViewHistorialCompras.DataSource = dv.ToTable();

            // Restablecer la paginación
            paginaActual = 1;
            MostrarInformacionPaginacionCompras();

            // Restablecer las fechas de inicio y fin al día actual
            dateInicio.Value = DateTime.Today;
            dateFin.Value = DateTime.Today;
        }

        private void pictureBack_Click(object sender, EventArgs e)
        {
            Compras comprasForm = new Compras();
            comprasForm.DashboardInstance = DashboardInstance;
            DashboardInstance.AbrirFormHijo(comprasForm);
        }

    }
}
