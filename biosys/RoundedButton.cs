using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace biosys
{
    public class RoundedButton : Button
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            GraphicsPath path = new GraphicsPath();
            int radius = 50; // Aumenta el radio para obtener bordes más redondeados
            Rectangle bounds = new Rectangle(0, 0, this.Width, this.Height);

            // Agrega los bordes redondeados al GraphicsPath
            path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90); // Esquina superior izquierda
            path.AddArc(bounds.X + bounds.Width - radius, bounds.Y, radius, radius, 270, 90); // Esquina superior derecha
            path.AddArc(bounds.X + bounds.Width - radius, bounds.Y + bounds.Height - radius, radius, radius, 0, 90); // Esquina inferior derecha
            path.AddArc(bounds.X, bounds.Y + bounds.Height - radius, radius, radius, 90, 90); // Esquina inferior izquierda
            path.CloseFigure();

            // Asigna el GraphicsPath como el área de recorte del botón
            this.Region = new Region(path);
        }
    }
}



