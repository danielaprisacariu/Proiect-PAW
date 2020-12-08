using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect1
{
    public partial class FormGrafic : Form
    {
        List<Pariu> pariuri;
        public FormGrafic(List<Pariu> lista)
        {
            InitializeComponent();
            pariuri = lista;
  
        }

        private static void DrawPieChart(Graphics g, Rectangle rect, Brush[] brushes, Pen[] pens, float[] values)
        {
            float CastigTotal = values.Sum();

            float startAngle = 0;
            for (int i = 0; i < values.Length; i++)
            {
                float sweepAngle = values[i] * 360 / CastigTotal;
                g.FillPie(brushes[i % brushes.Length], rect, startAngle, sweepAngle);
                g.DrawPie(pens[i % pens.Length], rect, startAngle, sweepAngle);
                startAngle += sweepAngle;
            }

        }
        private Brush[] SliceBrushes =
            {
                 Brushes.Red,
                 Brushes.LightGreen,
                 Brushes.Blue,
                 Brushes.LightBlue,
                 Brushes.Green,
                 Brushes.Lime,
                 Brushes.Orange,
                 Brushes.Fuchsia,
                 Brushes.Yellow,
                 Brushes.Cyan,
                 Brushes.Pink,

            };
        private Pen[] SlicePen = { Pens.Black };

       

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(30, 50, 300, 300);

            float[] values = new float[pariuri.Count];
            string[] meciuri = new string[pariuri.Count];
            int j = 0;
            foreach (Pariu p in pariuri)
            {
                values[j] = p.ValoareaCastig;
                foreach (Meci m in p.Meciuri)
                {
                    if(p.Meciuri.Count == 1)
                    {
                        meciuri[j] = m.Denumire;
                    }
                    else
                    {
                        meciuri[j] += m.Denumire + ", ";
                    }
                    
                }

                if (j < values.Length)
                {
                    j++;

                }
            }

            Font font = new Font(FontFamily.GenericSansSerif, 20, FontStyle.Bold);
            g.DrawString("Graficul castigurilor", font, new SolidBrush(Color.Black), new Point((panel1.Width - 250) / 2, 10));
            g.DrawString("Legenda:", new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold), new SolidBrush(Color.Black), new Point(400, 10 + font.Height + 10));

            DrawPieChart(e.Graphics, rect, SliceBrushes, SlicePen, values);

            for (int i = 0; i < values.Length; i++)
            {
                Rectangle rec = new Rectangle(400, (int)(10 + font.Height + 40 + i * 20), 10, 10);
                g.DrawRectangle(new Pen(Color.Black), rec);
                g.FillRectangle(SliceBrushes[i % SliceBrushes.Length], rec);
                g.DrawString(meciuri[i], panel1.Font, new SolidBrush(Color.Black), new Point(400 + 10 + 5, (int)(10 + font.Height + 40 + i * 20)));
            }
        }

        private void salveaza(Control c, String denumire)
        {
            Bitmap bitmap = new Bitmap(c.Width, c.Height);
            c.DrawToBitmap(bitmap, new Rectangle(c.ClientRectangle.X, c.ClientRectangle.Y, c.ClientRectangle.Width, c.ClientRectangle.Height));
            bitmap.Save(denumire);
            bitmap.Dispose();
        }

        private void salveazaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            salveaza(panel1, "grafic.bmp");
            MessageBox.Show("Grafic salvat!");
        }

        private void FormGrafic_KeyDown(object sender, KeyEventArgs e)
        {
            if( ModifierKeys.HasFlag(Keys.Control) && e.KeyCode == Keys.S)
            {
                salveaza(panel1, "grafic.bmp");
                MessageBox.Show("Grafic salvat!");
            }
        }
    }
}
