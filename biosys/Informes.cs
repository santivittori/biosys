using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Controladora;

namespace biosys
{
    public partial class Informes : Form
    {
        // Propiedad pública que representa una instancia del panel de control de Dashboard
        public Dashboard DashboardInstance { get; set; }

        public Informes()
        {
            InitializeComponent();
        }

        private void Informes_Load(object sender, EventArgs e)
        {
            CantTotalArbolesySemillas();
            SemillasTipoCant();
            ArbolesTipoCant();
        }
        // Metodo para obtener la cant total de semillas y árboles
        private void CantTotalArbolesySemillas()
        {
            // Obtener los datos del gráfico
            DataTable datos = Controladora.Controladora.ObtenerDatosGraficoProductos();

            // Filtrar los datos por tipo de producto y calcular la suma del stock
            int stockArboles = datos.AsEnumerable()
                .Where(row => row.Field<int>("TipoProductoId") == 1)
                .Sum(row => row.Field<int>("stock"));

            int stockSemillas = datos.AsEnumerable()
                .Where(row => row.Field<int>("TipoProductoId") == 2)
                .Sum(row => row.Field<int>("stock"));

            // Configurar el control Chart
            CantTotal.Series.Clear();
            CantTotal.ChartAreas.Clear();
            CantTotal.ChartAreas.Add(new ChartArea());

            // Agregar la serie para Árboles
            Series seriesArboles = new Series("Árboles");
            seriesArboles.ChartType = SeriesChartType.Column;
            seriesArboles.Points.AddXY("", stockArboles);
            seriesArboles.Color = Color.Orange;
            seriesArboles.BorderWidth = 1;
            seriesArboles.BorderColor = Color.Black;
            CantTotal.Series.Add(seriesArboles);

            // Agregar la serie para Semillas
            Series seriesSemillas = new Series("Semillas");
            seriesSemillas.ChartType = SeriesChartType.Column;
            seriesSemillas.Points.AddXY("", stockSemillas);
            seriesSemillas.Color = Color.GreenYellow;
            seriesSemillas.BorderWidth = 1;
            seriesSemillas.BorderColor = Color.Black;
            CantTotal.Series.Add(seriesSemillas);

            // Configurar las etiquetas de valores
            seriesArboles.IsValueShownAsLabel = true;
            seriesArboles.Font = new Font(seriesArboles.Font, FontStyle.Bold);

            seriesSemillas.IsValueShownAsLabel = true;
            seriesSemillas.Font = new Font(seriesSemillas.Font, FontStyle.Bold);

            // Configurar el título del gráfico
            CantTotal.Titles.Clear();
            CantTotal.Titles.Add("Total de Semillas y Árboles");
            CantTotal.Titles[0].Font = new Font("Arial", 12, FontStyle.Bold);

            CantTotal.DataBind();
        }
        // Método para mostrar la cant de cada tipo de semilla que tenemos
        private void SemillasTipoCant()
        {
            // Obtener los datos del gráfico
            DataTable datos = Controladora.Controladora.ObtenerDatosGraficoSemillas();

            // Configurar el control Chart para las Semillas
            SemillasTipo.Series.Clear();
            SemillasTipo.ChartAreas.Clear();
            SemillasTipo.ChartAreas.Add(new ChartArea());

            // Agregar las series para las Semillas
            foreach (DataRow row in datos.Rows)
            {
                string nombreSemilla = row.Field<string>("Nombre");
                int stockSemilla = row.Field<int>("stock");

                if (stockSemilla != 0)
                {
                    Series seriesSemilla = new Series(nombreSemilla);
                    seriesSemilla.ChartType = SeriesChartType.Column;
                    seriesSemilla.Points.Add(stockSemilla);
                    seriesSemilla.Color = Color.ForestGreen;
                    seriesSemilla.BorderWidth = 1;
                    seriesSemilla.BorderColor = Color.Black;
                    SemillasTipo.Series.Add(seriesSemilla);

                    seriesSemilla.IsValueShownAsLabel = true;

                    // Agregar el nombre de la semilla dentro de la barra
                    DataPoint dataPoint = seriesSemilla.Points[0];
                    dataPoint.Label = nombreSemilla;
                    dataPoint.Font = new Font("Arial", 10, FontStyle.Bold);
                    dataPoint.LabelForeColor = Color.Black;
                    // Establecer la personalización de la etiqueta
                    seriesSemilla.SetCustomProperty("LabelStyle", "Top");
                    seriesSemilla.SetCustomProperty("InsideLabelAlignment", "Center");

                    // Configurar la etiqueta de valor al hacer hover
                    dataPoint.ToolTip = stockSemilla.ToString();
                }
            }

            // Configurar el título del gráfico de Semillas
            SemillasTipo.Titles.Clear();
            SemillasTipo.Titles.Add("Stock de Semillas");
            SemillasTipo.Titles[0].Font = new Font("Arial", 12, FontStyle.Bold);

            // Ocultar la leyenda
            SemillasTipo.Legends.Clear();

            if (SemillasTipo.Series.Count > 0)
            {
                // Habilitar la interacción y los eventos de tooltip
                SemillasTipo.Series[0].IsValueShownAsLabel = true;
                SemillasTipo.Series[0].ToolTip = "#VALY";
            }

            SemillasTipo.DataBind();
        }
        // Método para mostrar la cant de cada tipo de árbol que tenemos
        private void ArbolesTipoCant()
        {
            // Obtener los datos del gráfico
            DataTable datos = Controladora.Controladora.ObtenerDatosGraficoArboles();

            // Configurar el control Chart para los Árboles
            ArbolesTipo.Series.Clear();
            ArbolesTipo.ChartAreas.Clear();
            ArbolesTipo.ChartAreas.Add(new ChartArea());

            // Agregar las series para los Árboles
            foreach (DataRow row in datos.Rows)
            {
                string nombreArbol = row.Field<string>("Nombre");
                int stockArbol = row.Field<int>("stock");

                if (stockArbol != 0)
                {
                    Series seriesArbol = new Series(nombreArbol);
                    seriesArbol.ChartType = SeriesChartType.Column;
                    seriesArbol.Points.Add(stockArbol);
                    seriesArbol.Color = Color.Coral;
                    seriesArbol.BorderWidth = 1;
                    seriesArbol.BorderColor = Color.Black;
                    ArbolesTipo.Series.Add(seriesArbol);

                    seriesArbol.IsValueShownAsLabel = true;

                    // Agregar el nombre del árbol dentro de la barra
                    DataPoint dataPoint = seriesArbol.Points[0];
                    dataPoint.Label = nombreArbol;
                    dataPoint.Font = new Font("Arial", 10, FontStyle.Bold);
                    dataPoint.LabelForeColor = Color.Black;
                    // Establecer la personalización de la etiqueta
                    seriesArbol.SetCustomProperty("LabelStyle", "Top");
                    seriesArbol.SetCustomProperty("InsideLabelAlignment", "Center");

                    // Configurar la etiqueta de valor al hacer hover
                    dataPoint.ToolTip = stockArbol.ToString();
                }
            }

            // Configurar el título del gráfico de Árboles
            ArbolesTipo.Titles.Clear();
            ArbolesTipo.Titles.Add("Stock de Árboles");
            ArbolesTipo.Titles[0].Font = new Font("Arial", 12, FontStyle.Bold);

            // Ocultar la leyenda
            ArbolesTipo.Legends.Clear();

            if (ArbolesTipo.Series.Count > 0)
            {
                // Habilitar la interacción y los eventos de tooltip
                ArbolesTipo.Series[0].IsValueShownAsLabel = true;
                ArbolesTipo.Series[0].ToolTip = "#VALY";
            }

            ArbolesTipo.DataBind();
        }
    }
}
