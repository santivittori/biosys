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
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            CentrarImagenEnFormulario();
        }
        private void CentrarImagenEnFormulario()
        {
            // Obtener el tamaño de la imagen
            int imagenAncho = btnHome.Image.Width;
            int imagenAlto = btnHome.Image.Height;

            // Obtener el tamaño del formulario
            int formularioAncho = this.ClientSize.Width;
            int formularioAlto = this.ClientSize.Height;

            // Calcular la posición del PictureBox para centrarlo horizontal y verticalmente
            int posX = (formularioAncho - imagenAncho) / 2;
            int posY = (formularioAlto - imagenAlto) / 2;

            // Establecer la posición del PictureBox
            btnHome.Location = new Point(posX, posY);
        }

    }
}
