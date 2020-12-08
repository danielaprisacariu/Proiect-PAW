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
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
        }

        private void btnPariaza_Click(object sender, EventArgs e)
        {
            FormBilet frm = new FormBilet();
            frm.Show();
        }

        private void btnIstoric_Click(object sender, EventArgs e)
        {
            FormIstoric frm = new FormIstoric();
            frm.Show();
        }

        private void btnDeconectare_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox4.DoDragDrop(pictureBox4.Image, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            if((e.KeyState & 8) == 8 && (e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                e.Effect = DragDropEffects.Copy;
            }
            else if((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            Graphics g = Graphics.FromHwnd(panel1.Handle);
            Bitmap img = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            g.DrawImage(img, new Rectangle(panel1.ClientRectangle.X, panel1.ClientRectangle.Y, panel1.ClientRectangle.Width, panel1.ClientRectangle.Height));
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox2.DoDragDrop(pictureBox2.Image, DragDropEffects.Copy | DragDropEffects.Move);
        }


        private void panel2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;

            if((e.KeyState & 8) == 8 && (e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                e.Effect = DragDropEffects.Copy;
            }
            else if((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void panel2_DragDrop(object sender, DragEventArgs e)
        {
            Graphics g = Graphics.FromHwnd(panel2.Handle);
            Bitmap img = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            g.DrawImage(img, new Rectangle(panel2.ClientRectangle.X, panel2.ClientRectangle.Y, panel2.ClientRectangle.Width, panel2.ClientRectangle.Height));
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.DoDragDrop(pictureBox1.Image, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void panel4_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;

            if((e.KeyState & 8) == 8 && (e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                e.Effect = DragDropEffects.Copy;
            }
            else if((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void panel4_DragDrop(object sender, DragEventArgs e)
        {
            Graphics g = Graphics.FromHwnd(panel4.Handle);
            Bitmap img = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            g.DrawImage(img, new Rectangle(panel4.ClientRectangle.X, panel4.ClientRectangle.Y, panel4.ClientRectangle.Width, panel4.ClientRectangle.Height));

        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox3.DoDragDrop(pictureBox3.Image, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void panel3_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;

            if((e.KeyState & 8) == 8 && (e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                e.Effect = DragDropEffects.Copy;
            }
            else if((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void panel3_DragDrop(object sender, DragEventArgs e)
        {
            Graphics g = Graphics.FromHwnd(panel3.Handle);
            Bitmap img = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            g.DrawImage(img, new Rectangle(panel4.ClientRectangle.X, panel4.ClientRectangle.Y, panel4.ClientRectangle.Width, panel4.ClientRectangle.Height));
        }

        private void btnPariaza_Click_1(object sender, EventArgs e)
        {
            FormBilet frm = new FormBilet();
            frm.Show();
        }

        private void btnIstoric_Click_1(object sender, EventArgs e)
        {
            FormIstoric frm = new FormIstoric();
            frm.Show();
        }
    }
}
