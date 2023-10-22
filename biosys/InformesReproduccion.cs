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

namespace biosys
{
    public partial class InformesReproduccion : Form
    {
        public Dashboard DashboardInstance { get; set; }

        public InformesReproduccion()
        {
            InitializeComponent();
        }

        private void pictureBack_Click(object sender, EventArgs e)
        {
            Informes informesForm = new Informes();
            informesForm.DashboardInstance = DashboardInstance;
            DashboardInstance.AbrirFormHijo(informesForm);
        }

        private void InformesReproduccion_Load(object sender, EventArgs e)
        {
            CantTotalBajasPorMotivos();
            CantTotalBajas();
        }

        private void CantTotalBajasPorMotivos()
        {
            // Obtener los datos de las bajas de productos
            DataTable datosBajas = Controladora.Controladora.ObtenerDatosBajasProductos();

            // Limpiar la serie existente en el control Chart (si la hay)
            chartBajas.Series.Clear();

            // Crear una serie para el gráfico de torta
            Series series = new Series("Bajas de Productos");
            series.ChartType = SeriesChartType.Pie;

            // Agregar los datos a la serie
            foreach (DataRow row in datosBajas.Rows)
            {
                string motivo = row["motivo"].ToString();
                int cantidad = Convert.ToInt32(row["Total"]);

                // Agregar un punto al gráfico de torta
                DataPoint point = new DataPoint();
                point.AxisLabel = motivo;
                point.Label = motivo + " (" + cantidad + ")";
                point.YValues = new double[] { cantidad };
                series.Points.Add(point);
            }

            // Agregar el título al gráfico
            chartBajas.Titles.Clear();
            chartBajas.Titles.Add("Bajas Totales por Motivo");
            chartBajas.Titles[0].Font = new Font("Arial", 12, FontStyle.Bold);

            // Agregar la serie al control Chart
            chartBajas.Series.Add(series);

            // Agregar un contorno alrededor del gráfico de torta
            chartBajas.BorderlineColor = Color.Black;
            chartBajas.BorderlineWidth = 2;
        }

        private void CantTotalBajas()
        {
            // Obtener los datos de las bajas de productos
            DataTable datosBajas = Controladora.Controladora.ObtenerDatosBajasTotales();

            // Limpiar la serie existente en el control Chart (si la hay)
            chartBajasTotales.Series.Clear();

            // Crear una serie para el gráfico de torta
            Series series = new Series("Bajas de Productos");
            series.ChartType = SeriesChartType.Pie;

            // Agregar los datos a la serie
            foreach (DataRow row in datosBajas.Rows)
            {
                int cantidad = row["Total"] != DBNull.Value ? Convert.ToInt32(row["Total"]) : 0;
                string motivo = "Total";

                // Agregar un punto al gráfico de torta
                DataPoint point = new DataPoint();
                point.AxisLabel = motivo;
                point.Label = motivo + " (" + cantidad + ")";
                point.YValues = new double[] { cantidad };
                series.Points.Add(point);
            }

            // Agregar el título al gráfico
            chartBajasTotales.Titles.Clear();
            chartBajasTotales.Titles.Add("Cantidad de Bajas Totales");
            chartBajasTotales.Titles[0].Font = new Font("Arial", 12, FontStyle.Bold);

            // Agregar la serie al control Chart
            chartBajasTotales.Series.Add(series);

            // Agregar un contorno alrededor del gráfico de torta
            chartBajasTotales.BorderlineColor = Color.Black;
            chartBajasTotales.BorderlineWidth = 2;
        }

        // Método para obtener la información de los gráficos
        public string ObtenerInfoGraficosReprod()
        {
            CantTotalBajas();
            CantTotalBajasPorMotivos();

            StringBuilder sb = new StringBuilder();

            // Información del gráfico de Bajas por Motivo
            sb.AppendLine("Bajas Totales por Motivo:");
            foreach (DataPoint dataPoint in chartBajas.Series[0].Points)
            {
                string motivo = dataPoint.AxisLabel;
                int cantidad = (int)dataPoint.YValues[0];
                sb.AppendLine($"{motivo}: {cantidad}");
            }
            sb.AppendLine();

            // Información del gráfico de Bajas Totales
            sb.AppendLine("Cantidad de Bajas Totales:");
            foreach (DataPoint dataPoint in chartBajasTotales.Series[0].Points)
            {
                string motivo = dataPoint.AxisLabel;
                int cantidad = (int)dataPoint.YValues[0];
                sb.AppendLine($"{motivo}: {cantidad}");
            }

            return sb.ToString();
        }

    }
}
