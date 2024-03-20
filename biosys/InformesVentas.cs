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
    public partial class InformesVentas : Form
    {
        public Dashboard DashboardInstance { get; set; }

        public InformesVentas()
        {
            InitializeComponent();
        }

        private void pictureBack_Click(object sender, EventArgs e)
        {
            Informes informesForm = new Informes();
            informesForm.DashboardInstance = DashboardInstance;
            DashboardInstance.AbrirFormHijo(informesForm);
        }

        private void InfrormesVentas_Load(object sender, EventArgs e)
        {
            CrearGraficoArbolesMasVendidos();
            CrearGraficoMediosPago();
            CrearGraficoVentasPorCliente();
            CrearGraficoVentasPorProducto();

            // Calcular la posición x para centrar el Label horizontalmente
            int labelPosX = (this.ClientSize.Width - labelTitulo.Width) / 2;

            // Establecer la posición del Label
            labelTitulo.Location = new Point(labelPosX, 50);
        }

        private void btnDescargaGrafica_Click(object sender, EventArgs e)
        {
            ExportarPDFGraficosVentas();
        }

        private void ExportarPDFGraficosVentas()
        {
            // Crear el documento PDF
            Document doc = new Document(PageSize.A4);
            string fileName = $"Graficos Ventas Biosys {DateTime.Now:dd-MM-yyyy}.pdf";

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

                    // Agregar los gráficos CAMBIARLOS POR LOS GRAFICOS DE VENTAS
                    AgregarGraficoAPDF(doc, chartArbolesMasVendidos);
                    AgregarGraficoAPDF(doc, chartMediosPago);
                    AgregarGraficoAPDF(doc, chartVentasPorCliente);
                    AgregarGraficoAPDF(doc, chartVentasPorProducto);

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
            CrearGraficoArbolesMasVendidos();
            CrearGraficoMediosPago();
            CrearGraficoVentasPorCliente();
            CrearGraficoVentasPorProducto();

            StringBuilder sb = new StringBuilder();

            // Información de los tres árboles más vendidos
            sb.AppendLine("Los tres árboles más vendidos:");
            DataTable arbolesvendidosData = Controladora.Controladora.ObtenerTresArbolesMasVendidos();
            for (int i = 0; i < arbolesvendidosData.Rows.Count; i++)
            {
                DataRow row = arbolesvendidosData.Rows[i];
                string producto = row.Field<string>("Producto");
                decimal importe = row.Field<decimal>("MontoTotal");
                sb.AppendLine($"{i + 1}. {producto} - ${importe.ToString("N2")}");
            }

            // Información de los tres medios de pagos mas utilizados
            sb.AppendLine("Los tres medios de pagos más utilizados:");
            DataTable mediosdepagoData = Controladora.Controladora.ObtenerTresMediosPagoMasUtilizados();
            for (int i = 0; i < mediosdepagoData.Rows.Count; i++)
            {
                DataRow row = mediosdepagoData.Rows[i];
                string medioPago = row.Field<string>("MedioPago");
                int cantidad = row.Field<int>("Cantidad");
                sb.AppendLine($"{i + 1}. {medioPago} - Cantidad: {cantidad}");
            }

            // Información de la distribución de ventas por cliente
            sb.AppendLine("Distribución de ventas por cliente:");
            DataTable ventasPorClienteData = Controladora.Controladora.ObtenerVentasPorCliente();
            foreach (DataRow row in ventasPorClienteData.Rows)
            {
                string cliente = row.Field<string>("Cliente");
                int cantidadVentas = row.Field<int>("CantidadVentas");
                sb.AppendLine($"{cliente}: {cantidadVentas}");
            }
            // Información de ventas por producto
            sb.AppendLine("Ventas por producto:");
            DataTable ventasporproductoData = Controladora.Controladora.ObtenerVentasPorProducto();

            foreach (DataRow row in ventasporproductoData.Rows)
            {
                string producto = row.Field<string>("Producto");
                decimal precioUnitario = row.Field<decimal>("PrecioUnitario");
                sb.AppendLine($"{producto}: ${precioUnitario.ToString("N2")}");
            }

            return sb.ToString();
        }

        public void CrearGraficoArbolesMasVendidos()
        {
            // Obtener los datos de los tres árboles más vendidos desde la base de datos
            DataTable arbolesMasVendidosData = Controladora.Controladora.ObtenerTresArbolesMasVendidos();

            // Verificar si hay datos disponibles
            if (arbolesMasVendidosData.Rows.Count > 0)
            {
                // Configurar el gráfico de barras para los árboles más vendidos
                ConfigurarGraficoBarras(chartArbolesMasVendidos, arbolesMasVendidosData, "Los tres árboles más vendidos", "Árboles", "Monto");
            }
            else
            {
                // No hay datos, mostrar un mensaje predeterminado
                chartArbolesMasVendidos.Series.Clear();
                chartArbolesMasVendidos.Titles.Clear();
                chartArbolesMasVendidos.Titles.Add(new Title("Aún no hay datos disponibles sobre los árboles más vendidos", Docking.Top, new System.Drawing.Font("Arial", 12, FontStyle.Bold), Color.Black));
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

        public void ConfigurarGraficoBarrasMediosPago(Chart chart, DataTable data, string titulo, string ejeX, string ejeY)
        {
            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.ChartAreas.Add(new ChartArea());

            Series seriesBarras = new Series();
            seriesBarras.ChartType = SeriesChartType.Bar;
            seriesBarras.IsVisibleInLegend = false; // Ocultar leyenda

            foreach (DataRow row in data.Rows)
            {
                string medioPago = row.Field<string>("MedioPago");
                int cantidad = row.Field<int>("Cantidad");

                DataPoint dataPoint = new DataPoint();
                dataPoint.AxisLabel = medioPago;
                dataPoint.Label = cantidad.ToString(); // Mostrar la cantidad en negrita dentro de la barra
                dataPoint.YValues = new double[] { cantidad };

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

        public void CrearGraficoMediosPago()
        {
            // Obtener los datos de los tres medios de pago más utilizados
            DataTable mediosPagoData = Controladora.Controladora.ObtenerTresMediosPagoMasUtilizados();

            // Verificar si hay datos disponibles
            if (mediosPagoData.Rows.Count > 0)
            {
                // Configurar el gráfico de barras para los medios de pago más utilizados
                ConfigurarGraficoBarrasMediosPago(chartMediosPago, mediosPagoData, "Los tres medios de pago más utilizados", "Medios de Pago", "Cantidad");
            }
            else
            {
                // No hay datos, mostrar un mensaje predeterminado
                chartMediosPago.Series.Clear();
                chartMediosPago.Titles.Clear();
                chartMediosPago.Titles.Add(new Title("Aún no hay datos de medios de pago", Docking.Top, new System.Drawing.Font("Arial", 12, FontStyle.Bold), Color.Black));
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
                string proveedor = row.Field<string>("Cliente");
                int cantidadCompras = row.Field<int>("CantidadVentas");

                seriesTorta.Points.AddXY(proveedor, cantidadCompras);
            }

            chart.Series.Add(seriesTorta);
            chart.Titles.Clear();
            chart.Titles.Add(new Title(titulo, Docking.Top, new System.Drawing.Font("Arial", 12, FontStyle.Bold), Color.Black));

            chart.DataBind();
        }

        public void CrearGraficoVentasPorCliente()
        {
            DataTable ventasPorClienteData = Controladora.Controladora.ObtenerVentasPorCliente();

            // Verifica si hay datos disponibles
            if (ventasPorClienteData.Rows.Count > 0)
            {
                // Configurar el gráfico de torta para la distribución de ventas por cliente
                ConfigurarGraficoTorta(chartVentasPorCliente, ventasPorClienteData, "Distribución de ventas por cliente");
            }
            else
            {
                // No hay datos, mostrar un mensaje predeterminado
                chartVentasPorCliente.Series.Clear();
                chartVentasPorCliente.Titles.Clear();
                chartVentasPorCliente.Titles.Add(new Title("No hay datos disponibles", Docking.Top, new System.Drawing.Font("Arial", 12, FontStyle.Bold), Color.Black));
            }
        }

        public void ConfigurarGraficoBarrasVentasPorProducto(Chart chart, DataTable data, string titulo, string ejeX, string ejeY)
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
                int cantidadVentas = row.Field<int>("CantidadVentas");

                DataPoint dataPoint = new DataPoint();
                dataPoint.AxisLabel = producto;
                dataPoint.Label = cantidadVentas.ToString(); // Mostrar la cantidad en negrita dentro de la barra
                dataPoint.YValues = new double[] { cantidadVentas };

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

        public void CrearGraficoVentasPorProducto()
        {
            DataTable ventasPorProductoData = Controladora.Controladora.ObtenerVentasPorProducto();

            // Verifica si hay datos disponibles
            if (ventasPorProductoData.Rows.Count > 0)
            {
                // Configurar el gráfico de barras para las ventas por producto
                ConfigurarGraficoBarrasVentasPorProducto(chartVentasPorProducto, ventasPorProductoData, "Ventas por producto", "Producto", "Cantidad");
            }
            else
            {
                // No hay datos, mostrar un mensaje predeterminado
                chartVentasPorProducto.Series.Clear();
                chartVentasPorProducto.Titles.Clear();
                chartVentasPorProducto.Titles.Add(new Title("No hay datos disponibles", Docking.Top, new System.Drawing.Font("Arial", 12, FontStyle.Bold), Color.Black));
            }
        }

    }
}
