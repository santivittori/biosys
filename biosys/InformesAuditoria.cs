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
    public partial class InformesAuditoria : Form
    {
        public Dashboard DashboardInstance { get; set; }

        public InformesAuditoria()
        {
            InitializeComponent();
        }

        private void InformesAuditoria_Load(object sender, EventArgs e)
        {
            CrearGraficoUsuariosMasIniciaronSesion();
            CrearGraficoUsuariosSesionNocturna();
            CrearGraficoProductosUltimoMes();
            CrearGraficoUsuariosMasProductosAgregaron();

            // Calcular la posición x para centrar el Label horizontalmente
            int labelPosX = (this.ClientSize.Width - labelTitulo.Width) / 2;

            // Establecer la posición del Label
            labelTitulo.Location = new Point(labelPosX, 50);
        }

        private void pictureBack_Click(object sender, EventArgs e)
        {
            Auditoria auditoriaForm = new Auditoria();
            auditoriaForm.DashboardInstance = DashboardInstance;
            DashboardInstance.AbrirFormHijo(auditoriaForm);
        }

        private void btnDescargaGrafica_Click(object sender, EventArgs e)
        {
            ExportarPDFGraficosAuditoria();
        }

        private void ExportarPDFGraficosAuditoria()
        {
            // Crear el documento PDF
            Document doc = new Document(PageSize.A4);
            string fileName = $"Graficos Auditorías Biosys {DateTime.Now:dd-MM-yyyy}.pdf";

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
                    AgregarGraficoAPDF(doc, chartUsuariosMasIniciaronSesion);
                    AgregarGraficoAPDF(doc, chartUsuariosMasProductosAgregaron);
                    AgregarGraficoAPDF(doc, chartUsuariosSesionNocturna);
                    AgregarGraficoAPDF(doc, chartProductosUltimoMes);

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
        public void ConfigurarGraficoBarrasUsuarios(Chart chart, DataTable data, string titulo, string ejeX, string ejeY)
        {
            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.ChartAreas.Add(new ChartArea());

            Series seriesBarras = new Series();
            seriesBarras.ChartType = SeriesChartType.Bar;
            seriesBarras.IsVisibleInLegend = false; // Ocultar leyenda

            foreach (DataRow row in data.Rows)
            {
                string usuario = row.Field<string>("Usuario");
                int numeroSesiones = row.Field<int>("NumeroSesiones");

                DataPoint dataPoint = new DataPoint();
                dataPoint.AxisLabel = usuario;
                dataPoint.Label = numeroSesiones.ToString();
                dataPoint.YValues = new double[] { numeroSesiones };

                seriesBarras.Points.Add(dataPoint);
            }

            chart.Series.Add(seriesBarras);
            chart.Titles.Clear();
            chart.Titles.Add(new Title(titulo, Docking.Top, new System.Drawing.Font("Arial", 12, FontStyle.Bold), Color.Black));

            chart.ChartAreas[0].AxisX.Title = ejeX;
            chart.ChartAreas[0].AxisY.Title = ejeY;

            // Quitar las líneas de la grilla interna
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            chart.DataBind();
        }

        public void CrearGraficoUsuariosMasIniciaronSesion()
        {
            DataTable usuariosData = Controladora.Controladora.ObtenerTresUsuariosMasIniciaronSesion();

            // Verifica si hay datos disponibles
            if (usuariosData.Rows.Count > 0)
            {
                // Configurar el gráfico de barras para los usuarios que más iniciaron sesión
                ConfigurarGraficoBarrasUsuarios(chartUsuariosMasIniciaronSesion, usuariosData, "Los tres usuarios que más veces iniciaron sesión", "Usuarios", "Número de sesiones");
            }
            else
            {
                // No hay datos, mostrar un mensaje predeterminado
                chartUsuariosMasIniciaronSesion.Series.Clear();
                chartUsuariosMasIniciaronSesion.Titles.Clear();
                chartUsuariosMasIniciaronSesion.Titles.Add(new Title("No hay datos disponibles", Docking.Top, new System.Drawing.Font("Arial", 12, FontStyle.Bold), Color.Black));
            }
        }
        public void CrearGraficoUsuariosSesionNocturna()
        {
            DataTable usuariosNocturnosData = Controladora.Controladora.ObtenerUsuariosSesionNocturna();

            // Verifica si hay datos disponibles
            if (usuariosNocturnosData.Rows.Count > 0)
            {
                // Configurar el gráfico de barras para los usuarios que iniciaron sesión en horario nocturno
                ConfigurarGraficoBarrasUsuarios(chartUsuariosSesionNocturna, usuariosNocturnosData, "Usuarios que iniciaron sesión de noche", "Usuarios", "Número de sesiones");
            }
            else
            {
                // No hay datos, mostrar un mensaje predeterminado
                chartUsuariosSesionNocturna.Series.Clear();
                chartUsuariosSesionNocturna.Titles.Clear();
                chartUsuariosSesionNocturna.Titles.Add(new Title("No hay datos disponibles", Docking.Top, new System.Drawing.Font("Arial", 12, FontStyle.Bold), Color.Black));
            }
        }

        public void ConfigurarGraficoBarrasUsuariosMasProductosAgregaron(Chart chart, DataTable data, string titulo, string ejeX, string ejeY)
        {
            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.ChartAreas.Add(new ChartArea());

            Series seriesBarras = new Series();
            seriesBarras.ChartType = SeriesChartType.Bar;
            seriesBarras.IsVisibleInLegend = false; // Ocultar leyenda

            foreach (DataRow row in data.Rows)
            {
                string usuario = row.Field<string>("Usuario");
                int numeroProductos = row.Field<int>("NumeroProductos");

                DataPoint dataPoint = new DataPoint();
                dataPoint.AxisLabel = usuario;
                dataPoint.Label = numeroProductos.ToString();
                dataPoint.YValues = new double[] { numeroProductos };

                seriesBarras.Points.Add(dataPoint);
            }

            chart.Series.Add(seriesBarras);
            chart.Titles.Clear();
            chart.Titles.Add(new Title(titulo, Docking.Top, new System.Drawing.Font("Arial", 12, FontStyle.Bold), Color.Black));

            chart.ChartAreas[0].AxisX.Title = ejeX;
            chart.ChartAreas[0].AxisY.Title = ejeY;

            // Quitar las líneas de la grilla interna
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            chart.DataBind();
        }

        public void CrearGraficoUsuariosMasProductosAgregaron()
        {
            DataTable usuariosProductosData = Controladora.Controladora.ObtenerTresUsuariosMasProductosAgregaron();

            // Verifica si hay datos disponibles
            if (usuariosProductosData.Rows.Count > 0)
            {
                // Configurar el gráfico de barras para los usuarios que más productos agregaron
                ConfigurarGraficoBarrasUsuariosMasProductosAgregaron(chartUsuariosMasProductosAgregaron, usuariosProductosData, "Los tres usuarios que más productos agregaron", "Usuarios", "Número de productos");
            }
            else
            {
                // No hay datos, mostrar un mensaje predeterminado
                chartUsuariosMasProductosAgregaron.Series.Clear();
                chartUsuariosMasProductosAgregaron.Titles.Clear();
                chartUsuariosMasProductosAgregaron.Titles.Add(new Title("No hay datos disponibles", Docking.Top, new System.Drawing.Font("Arial", 12, FontStyle.Bold), Color.Black));
            }
        }

        public void ConfigurarGraficoBarrasProductosUltimoMes(Chart chart, DataTable data, string titulo, string ejeX, string ejeY)
        {
            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.ChartAreas.Add(new ChartArea());

            Series seriesBarras = new Series();
            seriesBarras.ChartType = SeriesChartType.Bar;
            seriesBarras.IsVisibleInLegend = false; // Ocultar leyenda

            foreach (DataRow row in data.Rows)
            {
                string accion = row.Field<string>("Accion");
                int cantidadProductos = row.Field<int>("Cantidad");

                DataPoint dataPoint = new DataPoint();
                dataPoint.AxisLabel = accion;
                dataPoint.Label = cantidadProductos.ToString();
                dataPoint.YValues = new double[] { cantidadProductos };

                seriesBarras.Points.Add(dataPoint);
            }

            chart.Series.Add(seriesBarras);
            chart.Titles.Clear();
            chart.Titles.Add(new Title(titulo, Docking.Top, new System.Drawing.Font("Arial", 12, FontStyle.Bold), Color.Black));

            chart.ChartAreas[0].AxisX.Title = ejeX;
            chart.ChartAreas[0].AxisY.Title = ejeY;

            // Quitar las líneas de la grilla interna
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            chart.DataBind();
        }

        public void CrearGraficoProductosUltimoMes()
        {
            DataTable productosUltimoMesData = Controladora.Controladora.ObtenerProductosUltimoMes();

            // Verifica si hay datos disponibles
            if (productosUltimoMesData.Rows.Count > 0)
            {
                // Configurar el gráfico de barras para la cantidad de productos agregados, modificados y eliminados en el último mes
                ConfigurarGraficoBarrasProductosUltimoMes(chartProductosUltimoMes, productosUltimoMesData, "Cantidad de productos agregados, modificados y eliminados en el último mes", "Acciones", "Cantidad de productos");
            }
            else
            {
                // No hay datos, mostrar un mensaje predeterminado
                chartProductosUltimoMes.Series.Clear();
                chartProductosUltimoMes.Titles.Clear();
                chartProductosUltimoMes.Titles.Add(new Title("No hay datos disponibles", Docking.Top, new System.Drawing.Font("Arial", 12, FontStyle.Bold), Color.Black));
            }
        }
    }
}
