using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect1
{
    class Buton : Button
    {

        private Color culoareBtn = Color.CornflowerBlue;
        private Color culoareBordura = Color.Black;
        private Color culoareBorduraOnHover = Color.DimGray;
        private Color culoareOnHover = Color.CornflowerBlue;
        private Color textColor = Color.Black;
        private Color textColorOnHover = Color.SteelBlue;

        private bool isHovering;
        private int grosimeBordura = 3;


        public Buton()
        {
            DoubleBuffered = true;
            MouseEnter += (sender, e) =>
            {
                isHovering = true;
                Invalidate();
            };
            MouseLeave += (sender, e) =>
            {
                isHovering = false;
                Invalidate();
            };
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            Graphics g = pevent.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Brush brush = new SolidBrush(isHovering ? culoareBorduraOnHover : culoareBordura);

            //Bordura
            g.FillRectangle(brush, 0, 0, Width, Height);


            brush.Dispose();
            brush = new SolidBrush(isHovering ? culoareOnHover : culoareBtn);

            //buton
            g.FillRectangle(brush, grosimeBordura / 2, grosimeBordura / 2, Width - grosimeBordura, Height - grosimeBordura);

            brush.Dispose();
            brush = new SolidBrush(isHovering ? textColorOnHover : textColor);

            //text
            SizeF stringSize = g.MeasureString(Text, Font);
            g.DrawString(Text, Font, brush, (Width - stringSize.Width) / 2, (Height - stringSize.Height) / 2);

        }
    }
}
