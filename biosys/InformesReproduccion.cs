using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

            // Calcular la posición x para centrar el Label horizontalmente
            int labelPosX = (this.ClientSize.Width - labelTitulo.Width) / 2;

            // Establecer la posición del Label
            labelTitulo.Location = new Point(labelPosX, 50);
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
            chartBajas.Titles[0].Font = new System.Drawing.Font("Arial", 12, FontStyle.Bold);

            // Agregar la serie al control Chart
            chartBajas.Series.Add(series);

            // Agregar un contorno alrededor del gráfico de torta
            chartBajas.BorderlineColor = Color.Black;
            chartBajas.BorderlineWidth = 2;
        }

        private void CantTotalBajas()
        {
            // Obtener los datos de las bajas totales de productos
            DataTable datosBajas = Controladora.Controladora.ObtenerDatosBajasTotales();

            // Limpiar la serie existente en el control Chart (si la hay)
            chartBajasTotales.Series.Clear();

            // Crear una serie para el gráfico de torta
            Series series = new Series("Bajas de Productos");
            series.ChartType = SeriesChartType.Pie;

            // Obtener la cantidad total de bajas
            int totalBajas = 0;
            foreach (DataRow row in datosBajas.Rows)
            {
                // Verificar si el valor no es DBNull antes de intentar convertirlo
                if (row["Total"] != DBNull.Value)
                {
                    totalBajas += Convert.ToInt32(row["Total"]);
                }
            }

            // Agregar un punto al gráfico de torta para la cantidad total
            DataPoint point = new DataPoint();
            point.AxisLabel = "Total";
            point.Label = "Total (" + totalBajas + ")";
            point.YValues = new double[] { totalBajas };
            series.Points.Add(point);

            // Agregar el título al gráfico
            chartBajasTotales.Titles.Clear();
            chartBajasTotales.Titles.Add("Cantidad de Bajas Totales");
            chartBajasTotales.Titles[0].Font = new System.Drawing.Font("Arial", 12, FontStyle.Bold);

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

        private void ExportarPDFGraficoReproduccion()
        {
            // Crear el documento PDF
            Document doc = new Document(PageSize.A4);
            string fileName = $"Graficos Reproducción Biosys {DateTime.Now:dd-MM-yyyy}.pdf";

            try
            {
                // Mostrar un cuadro de diálogo para guardar el archivo PDF
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.FileName = fileName;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Crear el archivo PDF en el directorio seleccionado
                    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(saveFileDialog.FileName, FileMode.Create));
                    doc.Open();

                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(@"C:\Users\vitto\Pictures\Ing de Software\biosys-transp.png");
                    image.Alignment = Element.ALIGN_CENTER;
                    doc.Add(image);

                    Paragraph title = new Paragraph("BIOSYS", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 30, iTextSharp.text.Font.BOLD));
                    title.Alignment = Element.ALIGN_CENTER;
                    doc.Add(title);

                    // Agregar la fecha del día
                    Paragraph fecha = new Paragraph(DateTime.Now.ToShortDateString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL));
                    fecha.Alignment = Element.ALIGN_CENTER;
                    doc.Add(fecha);

                    // Agregar la información de los gráficos (puedes ajustar el formato y contenido según tus necesidades)
                    doc.Add(new Paragraph("Información de los gráficos:", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.BOLD)));

                    // Agregar los gráficos al PDF con sus respectivas informaciones
                    AgregarGraficoAPDFReproduccion(doc, "", chartBajas);

                    AgregarGraficoAPDFReproduccion(doc, "", chartBajasTotales);

                    doc.Close();
                    writer.Close();

                    MessageBox.Show("El archivo PDF se ha generado exitosamente.", "PDF generado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error al generar el archivo PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarGraficoAPDFReproduccion(Document doc, string titulo, Chart chart)
        {
            // Agregar el gráfico al PDF
            MemoryStream memoryStream = new MemoryStream();
            chart.SaveImage(memoryStream, ChartImageFormat.Png);
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(memoryStream.GetBuffer());
            image.Alignment = Element.ALIGN_CENTER;
            doc.Add(image);
        }

        private void btnDescargaGrafica_Click(object sender, EventArgs e)
        {
            ExportarPDFGraficoReproduccion();
        }
    }
}
