using iTextSharp.text;
using iTextSharp.text.pdf;
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
    public partial class InformesCompras : Form
    {
        public Dashboard DashboardInstance { get; set; }

        public InformesCompras()
        {
            InitializeComponent();
        }

        private void pictureBack_Click(object sender, EventArgs e)
        {
            Informes informesForm = new Informes();
            informesForm.DashboardInstance = DashboardInstance;
            DashboardInstance.AbrirFormHijo(informesForm);
        }

        private void InformesCompras_Load(object sender, EventArgs e)
        {
            CrearGraficoSemillas();
            CrearGraficoArboles();
            CrearGraficoComprasPorProveedor();
            CompararPreciosUnitarios();

            // Calcular la posición x para centrar el Label horizontalmente
            int labelPosX = (this.ClientSize.Width - labelTitulo.Width) / 2;

            // Establecer la posición del Label
            labelTitulo.Location = new Point(labelPosX, 50);
        }

        public void CrearGraficoSemillas()
        {
            DataTable semillasData = Controladora.Controladora.ObtenerTresSemillasMasCompradas();

            // Verifica si hay datos disponibles
            if (semillasData.Rows.Count > 0)
            {
                // Configurar el gráfico de barras para las semillas más compradas
                ConfigurarGraficoBarras(chartSemillas, semillasData, "Las Tres Semillas Más Compradas", "Semillas", "Monto");
            }
            else
            {
                // No hay datos, mostrar un mensaje predeterminado
                chartSemillas.Series.Clear();
                chartSemillas.Titles.Clear();
                chartSemillas.Titles.Add(new Title("Aún no hay compras de semillas", Docking.Top, new System.Drawing.Font("Arial", 12, FontStyle.Bold), Color.Black));
            }
        }

        public void ConfigurarGraficoBarras(Chart chart, DataTable data, string titulo, string ejeX, string ejeY)
        {
            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.ChartAreas.Add(new ChartArea());

            Series seriesBarras = new Series();
            seriesBarras.ChartType = SeriesChartType.Bar;
            seriesBarras.IsVisibleInLegend = false; // Ocultar leyenda

            foreach (DataRow row in data.Rows)
            {
                string producto = row.Field<string>("Producto");
                decimal importe = row.Field<decimal>("MontoTotal");

                DataPoint dataPoint = new DataPoint();
                dataPoint.AxisLabel = producto;
                dataPoint.Label = "$" + importe.ToString("N2"); // Mostrar el monto en negrita dentro de la barra
                dataPoint.YValues = new double[] { (double)importe };

                seriesBarras.Points.Add(dataPoint);
            }

            chart.Series.Add(seriesBarras);
            chart.Titles.Clear();
            chart.Titles.Add(new Title(titulo, Docking.Top, new System.Drawing.Font("Arial", 12, FontStyle.Bold), Color.Black));

            chart.ChartAreas[0].AxisX.Title = ejeX;
            chart.ChartAreas[0].AxisY.Title = ejeY;
            chart.ChartAreas[0].AxisX.Interval = 1;

            // Quitar las líneas de la grilla interna
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            chart.DataBind();
        }

        private void btnDescargaGrafica_Click(object sender, EventArgs e)
        {
            ExportarPDFGraficosCompras();
        }

        private void ExportarPDFGraficosCompras()
        {
            // Crear el documento PDF
            Document doc = new Document(PageSize.A4);
            string fileName = $"Graficos Compras Biosys {DateTime.Now:dd-MM-yyyy}.pdf";

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

                    // Agregar los gráficos
                    AgregarGraficoAPDF(doc, chartSemillas);
                    AgregarGraficoAPDF(doc, chartArboles);
                    AgregarGraficoAPDF(doc, chartComprasPorProveedor);
                    AgregarGraficoAPDF(doc, chartPreciosUnitarios);

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

        private void AgregarGraficoAPDF(Document doc, Chart chart)
        {
            // Agregar el gráfico al PDF
            MemoryStream memoryStream = new MemoryStream();
            chart.SaveImage(memoryStream, ChartImageFormat.Png);
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(memoryStream.GetBuffer());
            image.Alignment = Element.ALIGN_CENTER;
            doc.Add(image);
        }

        public string ObtenerInformacionGraficos()
        {
            // Crear gráficos
            CrearGraficoSemillas();
            CrearGraficoArboles();
            CrearGraficoComprasPorProveedor();
            CompararPreciosUnitarios();

            StringBuilder sb = new StringBuilder();

            // Información de las tres semillas más compradas
            sb.AppendLine("Las Tres Semillas Más Compradas:");
            DataTable semillasData = Controladora.Controladora.ObtenerTresSemillasMasCompradas();
            for (int i = 0; i < semillasData.Rows.Count; i++)
            {
                DataRow row = semillasData.Rows[i];
                string producto = row.Field<string>("Producto");
                decimal importe = row.Field<decimal>("MontoTotal");
                sb.AppendLine($"{i + 1}. {producto} - ${importe.ToString("N2")}");
            }

            // Información de los tres árboles más comprados
            sb.AppendLine("Los Tres Árboles Más Comprados:");
            DataTable arbolesData = Controladora.Controladora.ObtenerTresArbolesMasComprados();
            for (int i = 0; i < arbolesData.Rows.Count; i++)
            {
                DataRow row = arbolesData.Rows[i];
                string producto = row.Field<string>("Producto");
                decimal importe = row.Field<decimal>("MontoTotal");
                sb.AppendLine($"{i + 1}. {producto} - ${importe.ToString("N2")}");
            }

            // Información de la distribución de compras por proveedor
            sb.AppendLine("Distribución De Compras Por Proveedor:");
            DataTable comprasPorProveedorData = Controladora.Controladora.ObtenerComprasPorProveedor();
            foreach (DataRow row in comprasPorProveedorData.Rows)
            {
                string proveedor = row.Field<string>("Proveedor");
                int cantidadCompras = row.Field<int>("CantidadCompras");
                sb.AppendLine($"{proveedor}: {cantidadCompras}");
            }

            // Información de la comparación de precios unitarios
            sb.AppendLine("Comparación De Precios Unitarios De Árboles:");
            DataTable preciosUnitariosData = Controladora.Controladora.ObtenerPreciosUnitariosArboles();
            foreach (DataRow row in preciosUnitariosData.Rows)
            {
                string producto = row.Field<string>("Producto");
                decimal precioUnitario = row.Field<decimal>("PrecioUnitario");
                sb.AppendLine($"{producto}: ${precioUnitario.ToString("N2")}");
            }

            return sb.ToString();
        }

        public void CrearGraficoArboles()
        {
            DataTable arbolesData = Controladora.Controladora.ObtenerTresArbolesMasComprados();

            // Verifica si hay datos disponibles
            if (arbolesData.Rows.Count > 0)
            {
                // Configurar el gráfico de barras para los árboles más comprados
                ConfigurarGraficoBarras(chartArboles, arbolesData, "Los Tres Árboles Más Comprados", "Árboles", "Monto");
            }
            else
            {
                // No hay datos, mostrar un mensaje predeterminado
                chartArboles.Series.Clear();
                chartArboles.Titles.Clear();
                chartArboles.Titles.Add(new Title("Aún no hay compras de árboles", Docking.Top, new System.Drawing.Font("Arial", 12, FontStyle.Bold), Color.Black));
            }
        }

        public void CrearGraficoComprasPorProveedor()
        {
            DataTable comprasPorProveedorData = Controladora.Controladora.ObtenerComprasPorProveedor();

            // Verifica si hay datos disponibles
            if (comprasPorProveedorData.Rows.Count > 0)
            {
                // Configurar el gráfico de torta para la distribución de compras por proveedor
                ConfigurarGraficoTorta(chartComprasPorProveedor, comprasPorProveedorData, "Distribución De Compras Por Proveedor");
            }
            else
            {
                // No hay datos, mostrar un mensaje predeterminado
                chartComprasPorProveedor.Series.Clear();
                chartComprasPorProveedor.Titles.Clear();
                chartComprasPorProveedor.Titles.Add(new Title("No hay datos disponibles", Docking.Top, new System.Drawing.Font("Arial", 12, FontStyle.Bold), Color.Black));
            }
        }

        public void ConfigurarGraficoTorta(Chart chart, DataTable data, string titulo)
        {
            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.ChartAreas.Add(new ChartArea());

            Series seriesTorta = new Series();
            seriesTorta.ChartType = SeriesChartType.Pie;

            foreach (DataRow row in data.Rows)
            {
                string proveedor = row.Field<string>("Proveedor");
                int cantidadCompras = row.Field<int>("CantidadCompras");

                seriesTorta.Points.AddXY(proveedor, cantidadCompras);
            }

            chart.Series.Add(seriesTorta);
            chart.Titles.Clear();
            chart.Titles.Add(new Title(titulo, Docking.Top, new System.Drawing.Font("Arial", 12, FontStyle.Bold), Color.Black));

            chart.DataBind();
        }

        private void CompararPreciosUnitarios()
        {
            DataTable preciosUnitariosData = Controladora.Controladora.ObtenerPreciosUnitariosArboles();

            // Verificar si hay datos disponibles
            if (preciosUnitariosData.Rows.Count > 0)
            {
                // Configurar el gráfico de dispersión para comparar precios unitarios
                ConfigurarGraficoDispersión(chartPreciosUnitarios, preciosUnitariosData, "Comparación De Precios Unitarios De Árboles", "Producto", "Precio Unitario");
            }
            else
            {
                // No hay datos, mostrar un mensaje predeterminado
                chartPreciosUnitarios.Series.Clear();
                chartPreciosUnitarios.Titles.Clear();
                chartPreciosUnitarios.Titles.Add(new Title("No hay datos disponibles para mostrar", Docking.Top, new System.Drawing.Font("Arial", 12, FontStyle.Bold), Color.Black));
            }
        }

        private void ConfigurarGraficoDispersión(Chart chart, DataTable data, string titulo, string ejeX, string ejeY)
        {
            // Limpiar cualquier configuración previa en el gráfico
            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.ChartAreas.Add(new ChartArea());

            // Crear una nueva serie para el gráfico de dispersión
            Series seriesDispersión = new Series();
            seriesDispersión.ChartType = SeriesChartType.Point; // Tipo de gráfico de dispersión
            seriesDispersión.MarkerStyle = MarkerStyle.Circle; // Estilo de marcador (puedes ajustarlo según tus preferencias)
            seriesDispersión.MarkerSize = 10; // Ajustar el tamaño del marcador
            seriesDispersión.IsVisibleInLegend = false; // Ocultar la leyenda

            // Agregar los puntos al gráfico de dispersión
            foreach (DataRow row in data.Rows)
            {
                string producto = row.Field<string>("Producto");
                decimal precioUnitario = row.Field<decimal>("PrecioUnitario");

                // Agregar el punto al gráfico de dispersión
                seriesDispersión.Points.AddXY(producto, (double)precioUnitario);
            }

            // Agregar la serie al gráfico
            chart.Series.Add(seriesDispersión);

            // Configurar el título del gráfico
            chart.Titles.Clear();
            chart.Titles.Add(new Title(titulo, Docking.Top, new System.Drawing.Font("Arial", 12, FontStyle.Bold), Color.Black));

            // Configurar los ejes X e Y
            chart.ChartAreas[0].AxisX.Title = ejeX;
            chart.ChartAreas[0].AxisY.Title = ejeY;

            // Actualizar el gráfico
            chart.DataBind();
        }

    }
}
