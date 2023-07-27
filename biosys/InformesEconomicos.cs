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
    public partial class InformesEconomicos : Form
    {
        public Dashboard DashboardInstance { get; set; }

        public InformesEconomicos()
        {
            InitializeComponent();
        }

        private void InformesEconomicos_Load(object sender, EventArgs e)
        {
            ComprasTotal();
        }
        private void ComprasTotal()
        {
            // Obtener los datos de montos de compras por tipo (Semilla o Árbol)
            DataTable datosComprasPorTipo = Controladora.Controladora.ObtenerMontosComprasPorTipo();

            // Configurar el gráfico de torta
            CompraTotal.Series.Clear();
            CompraTotal.ChartAreas.Clear();
            CompraTotal.ChartAreas.Add(new ChartArea());

            // Agregar la serie para el gráfico de torta
            Series seriesTorta = new Series("Compras");
            seriesTorta.ChartType = SeriesChartType.Pie;
            seriesTorta.IsVisibleInLegend = false; // No mostrar leyendas

            // Asignar los puntos de datos a la serie
            foreach (DataRow row in datosComprasPorTipo.Rows)
            {
                string tipoProducto = row.Field<string>("TipoProducto");
                decimal montoTotal = row.Field<decimal>("MontoTotal");

                // Agregar un punto de datos para cada tipo de producto
                DataPoint dataPoint = new DataPoint();
                dataPoint.AxisLabel = tipoProducto; // Etiqueta en el gráfico (Semillas o Arboles)
                dataPoint.Label = tipoProducto + "\n$" + montoTotal.ToString("N2"); // Etiqueta debajo de la torta con el monto formateado
                dataPoint.YValues = new double[] { (double)montoTotal }; // Valor numérico

                // Definir colores personalizados para cada tipo de producto
                if (tipoProducto == "Semillas")
                {
                    dataPoint.Color = Color.GreenYellow;
                    dataPoint.ToolTip = "Semillas"; // Etiqueta arriba del importe
                }
                else if (tipoProducto == "Árboles")
                {
                    dataPoint.Color = Color.Orange;
                    dataPoint.ToolTip = "Arboles"; // Etiqueta arriba del importe
                }

                dataPoint.BorderWidth = 1;
                dataPoint.BorderColor = Color.Black;

                seriesTorta.Points.Add(dataPoint);
            }

            // Agregar la serie al gráfico
            CompraTotal.Series.Add(seriesTorta);

            // Establecer el tamaño de la fuente para las etiquetas personalizadas dentro del gráfico
            foreach (DataPoint dataPoint in seriesTorta.Points)
            {
                dataPoint.Font = new Font("Arial", 11, FontStyle.Regular);
            }

            // Mostrar el título del gráfico
            CompraTotal.Titles.Clear();
            CompraTotal.Titles.Add("Compras");
            CompraTotal.Titles[0].Font = new Font("Arial", 12, FontStyle.Bold);

            // Mostrar el total en la parte inferior del gráfico
            decimal totalCompras = datosComprasPorTipo.AsEnumerable().Sum(row => row.Field<decimal>("MontoTotal"));
            CompraTotal.Titles.Add($"Total: ${totalCompras.ToString("N2")}");
            CompraTotal.Titles[1].Font = new Font("Arial", 12, FontStyle.Regular);

            // Configurar el color de la serie
            CompraTotal.Palette = ChartColorPalette.None;
            CompraTotal.PaletteCustomColors = new Color[] { Color.Orange, Color.GreenYellow };

            // Actualizar el gráfico
            CompraTotal.DataBind();
        }

        private void pictureBack_Click(object sender, EventArgs e)
        {
            Informes informesForm = new Informes();
            informesForm.DashboardInstance = DashboardInstance;
            DashboardInstance.AbrirFormHijo(informesForm);
        }
    }
}
