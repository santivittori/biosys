using iTextSharp.text.pdf;
using iTextSharp.text;
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
using System.IO;

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
            VentasTotal();

            // Calcular la posición x para centrar el Label horizontalmente
            int labelPosX = (this.ClientSize.Width - labelTitulo.Width) / 2;

            // Establecer la posición del Label
            labelTitulo.Location = new Point(labelPosX, 50);
        }
        public void ComprasTotal()
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
                dataPoint.Font = new System.Drawing.Font("Arial", 11, FontStyle.Regular);
            }

            // Mostrar el título del gráfico
            CompraTotal.Titles.Clear();
            CompraTotal.Titles.Add("Compras");
            CompraTotal.Titles[0].Font = new System.Drawing.Font("Arial", 12, FontStyle.Bold);

            // Mostrar el total en la parte inferior del gráfico
            decimal totalCompras = datosComprasPorTipo.AsEnumerable().Sum(row => row.Field<decimal>("MontoTotal"));
            CompraTotal.Titles.Add($"Total: ${totalCompras.ToString("N2")}");
            CompraTotal.Titles[1].Font = new System.Drawing.Font("Arial", 12, FontStyle.Regular);

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

        // Método para obtener la información de los gráficos de InformesEconomicos
        public string ObtenerInformacionGraficos()
        {
            ComprasTotal();
            VentasTotal();

            StringBuilder sb = new StringBuilder();

            // Información del gráfico de Compras
            sb.AppendLine($"Total de compras = ${CompraTotal.Titles[1].Text.Replace("Total: $", "")}");
            sb.AppendLine();

            // Información del gráfico de Ventas
            sb.AppendLine($"Total de ventas = ${VentaTotal.Titles[1].Text.Replace("Total: $", "")}");
            sb.AppendLine();

            return sb.ToString();
        }

        public void VentasTotal()
        {
            // Obtener los datos de montos de ventas por tipo (Semilla o Árbol)
            DataTable datosVentasPorTipo = Controladora.Controladora.ObtenerMontosVentasPorTipo();

            // Configurar el gráfico de torta para ventas
            VentaTotal.Series.Clear();
            VentaTotal.ChartAreas.Clear();
            VentaTotal.ChartAreas.Add(new ChartArea());

            // Agregar la serie para el gráfico de torta
            Series seriesTorta = new Series("Ventas");
            seriesTorta.ChartType = SeriesChartType.Pie;
            seriesTorta.IsVisibleInLegend = false; // No mostrar leyendas

            // Asignar los puntos de datos a la serie
            foreach (DataRow row in datosVentasPorTipo.Rows)
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
            VentaTotal.Series.Add(seriesTorta);

            // Establecer el tamaño de la fuente para las etiquetas personalizadas dentro del gráfico
            foreach (DataPoint dataPoint in seriesTorta.Points)
            {
                dataPoint.Font = new System.Drawing.Font("Arial", 11, FontStyle.Regular);
            }

            // Mostrar el título del gráfico
            VentaTotal.Titles.Clear();
            VentaTotal.Titles.Add("Ventas");
            VentaTotal.Titles[0].Font = new System.Drawing.Font("Arial", 12, FontStyle.Bold);

            // Mostrar el total en la parte inferior del gráfico
            decimal totalVentas = datosVentasPorTipo.AsEnumerable().Sum(row => row.Field<decimal>("MontoTotal"));
            VentaTotal.Titles.Add($"Total: ${totalVentas.ToString("N2")}");
            VentaTotal.Titles[1].Font = new System.Drawing.Font("Arial", 12, FontStyle.Regular);

            // Configurar el color de la serie
            VentaTotal.Palette = ChartColorPalette.None;
            VentaTotal.PaletteCustomColors = new Color[] { Color.Orange, Color.GreenYellow };

            // Actualizar el gráfico
            VentaTotal.DataBind();
        }

        private void ExportarPDFGraficosEconomicos()
        {
            // Crear el documento PDF
            Document doc = new Document(PageSize.A4);
            string fileName = $"Graficos Economicos Biosys {DateTime.Now:dd-MM-yyyy}.pdf";

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
                    AgregarGraficoAPDF(doc, CompraTotal);
                    AgregarGraficoAPDF(doc, VentaTotal);

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

        private void btnDescargaGrafica_Click(object sender, EventArgs e)
        {
            ExportarPDFGraficosEconomicos();
        }
    }
}
