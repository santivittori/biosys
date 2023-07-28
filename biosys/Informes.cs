using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Font = System.Drawing.Font;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Controladora;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;

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
            TotalPorDivision();
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

        private void TotalPorDivision()
        {
            // Obtener los totales por división (Compras, Donaciones y Recolección)
            int totalCompras = Controladora.Controladora.ObtenerTotalCompras();
            int totalDonaciones = Controladora.Controladora.ObtenerTotalDonaciones();
            int totalRecoleccion = Controladora.Controladora.ObtenerTotalRecoleccion();

            // Configurar el control Chart
            TotalporDivision.Series.Clear();
            TotalporDivision.ChartAreas.Clear();
            TotalporDivision.ChartAreas.Add(new ChartArea());

            // Agregar la serie para Compras
            Series seriesCompras = new Series("Compras");
            seriesCompras.Points.AddXY("", totalCompras);
            seriesCompras.Color = Color.Blue;
            seriesCompras.BorderWidth = 1;
            seriesCompras.BorderColor = Color.Black;
            TotalporDivision.Series.Add(seriesCompras);

            // Agregar la serie para Donaciones
            Series seriesDonaciones = new Series("Donaciones");
            seriesDonaciones.Points.AddXY("", totalDonaciones);
            seriesDonaciones.Color = Color.Green;
            seriesDonaciones.BorderWidth = 1;
            seriesDonaciones.BorderColor = Color.Black;
            TotalporDivision.Series.Add(seriesDonaciones);

            // Agregar la serie para Recolección
            Series seriesRecoleccion = new Series("Recolecciones");
            seriesRecoleccion.Points.AddXY("", totalRecoleccion);
            seriesRecoleccion.Color = Color.Orange;
            seriesRecoleccion.BorderWidth = 1;
            seriesRecoleccion.BorderColor = Color.Black;
            TotalporDivision.Series.Add(seriesRecoleccion);

            // Configurar las etiquetas de valores
            seriesCompras.IsValueShownAsLabel = true;
            seriesCompras.Font = new Font(seriesCompras.Font, FontStyle.Bold);

            seriesDonaciones.IsValueShownAsLabel = true;
            seriesDonaciones.Font = new Font(seriesDonaciones.Font, FontStyle.Bold);

            seriesRecoleccion.IsValueShownAsLabel = true;
            seriesRecoleccion.Font = new Font(seriesRecoleccion.Font, FontStyle.Bold);

            // Configurar el título del gráfico
            TotalporDivision.Titles.Clear();
            TotalporDivision.Titles.Add("Totales por División");
            TotalporDivision.Titles[0].Font = new Font("Arial", 12, FontStyle.Bold);

            TotalporDivision.DataBind();
        }
        private void ExportarPDF()
        {
            // Crear el documento PDF
            Document doc = new Document(PageSize.A4);
            string fileName = $"Informes Biosys {DateTime.Now:dd-MM-yyyy}.pdf";

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

                    // Agregar la información de CantTotal
                    doc.Add(new Paragraph("\nTotal de Semillas y Árboles:", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD)));
                    doc.Add(new Paragraph($"Cantidad total de semillas = {CantTotal.Series["Semillas"].Points.FirstOrDefault()?.YValues[0] ?? 0}."));
                    doc.Add(new Paragraph($"Cantidad total de árboles = {CantTotal.Series["Árboles"].Points.FirstOrDefault()?.YValues[0] ?? 0}."));

                    // Agregar la información de SemillasTipo
                    doc.Add(new Paragraph("\nStock de Semillas por tipo:", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD)));
                    foreach (Series seriesSemilla in SemillasTipo.Series)
                    {
                        doc.Add(new Paragraph($"Cantidad de {seriesSemilla.Name} = {seriesSemilla.Points.FirstOrDefault()?.YValues[0] ?? 0}."));
                    }

                    // Agregar la información de ArbolesTipo
                    doc.Add(new Paragraph("\nStock de Árboles por tipo:", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD)));
                    foreach (Series seriesArbol in ArbolesTipo.Series)
                    {
                        doc.Add(new Paragraph($"Cantidad de {seriesArbol.Name} = {seriesArbol.Points.FirstOrDefault()?.YValues[0] ?? 0}."));
                    }

                    // Agregar la información de TotalporDivision
                    doc.Add(new Paragraph("\nTotales por División:", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD)));
                    doc.Add(new Paragraph($"Total de Compras = {TotalporDivision.Series["Compras"].Points.FirstOrDefault()?.YValues[0] ?? 0}."));
                    doc.Add(new Paragraph($"Total de Donaciones = {TotalporDivision.Series["Donaciones"].Points.FirstOrDefault()?.YValues[0] ?? 0}."));
                    doc.Add(new Paragraph($"Total de Recolecciones = {TotalporDivision.Series["Recolecciones"].Points.FirstOrDefault()?.YValues[0] ?? 0}."));

                    // Initialize the CompraTotal chart in InformesEconomicos form
                    InformesEconomicos informesEconomicosForm = new InformesEconomicos();
                    informesEconomicosForm.ComprasTotal();

                    // Agregar la información de InformesEconomicos
                    string informacionGraficos = informesEconomicosForm.ObtenerInformacionGraficos();
                    doc.Add(new Paragraph("\nCompras:", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD)));
                    doc.Add(new Paragraph(informacionGraficos, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL)));

                    // Cerrar el documento
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

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            ExportarPDF();
        }

        private void btnInfEconomicos_Click(object sender, EventArgs e)
        {
            InformesEconomicos informesEconomicosForm = new InformesEconomicos();
            informesEconomicosForm.DashboardInstance = DashboardInstance;
            DashboardInstance.AbrirFormHijo(informesEconomicosForm);
        }
    }
}
