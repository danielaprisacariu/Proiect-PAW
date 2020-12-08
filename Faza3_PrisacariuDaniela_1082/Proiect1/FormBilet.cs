using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Drawing.Printing;

namespace Proiect1
{
    public partial class FormBilet : Form
    {
        public static List<Pariu> listaPariuri = new List<Pariu>();
        Pariu pariu = new Pariu();


        public FormBilet()
        {
            InitializeComponent();
        }

        private void btnRenunta_Click(object sender, EventArgs e)
        {
            const string message = "Datele introduse vor fi pierdute. Continuati?";
            const string caption = "Form closing";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(result == DialogResult.Yes)
            {
              
                this.Close();
            }

        }



        private void dataGridViewMeci_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText = dataGridViewMeci.Columns[e.ColumnIndex].HeaderText;
            if (headerText.Equals("Data"))
            {


                if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    dataGridViewMeci.Rows[e.RowIndex].ErrorText = "Introduceti data!";
                    //e.Cancel = true;
                }
                else
                {
                    bool valid;
                    DateTime date;
                    valid = DateTime.TryParseExact(e.FormattedValue.ToString(), "dd.MM.yyyy", new CultureInfo("ro-RO"), DateTimeStyles.None, out date);
                    if (!valid || date < DateTime.Today)
                    {
                        MessageBox.Show("Introduceti o data valida! Format: dd.MM.yyyy");
                    }
                }

            }
            else
            {
                if (headerText.Equals("Meci"))
                {
                    if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                    {
                        dataGridViewMeci.Rows[e.RowIndex].ErrorText = "Introduceti numele meciului!";
                        e.Cancel = true;
                    }
                }
                else
                {
                    if (headerText.Equals("Pronostic"))
                    {
                        if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                        {
                            dataGridViewMeci.Rows[e.RowIndex].ErrorText = "Introduceti pronosticul!";
                            e.Cancel = true;
                        }
                    }
                    else
                    {
                        if (headerText.Equals("Cota"))
                        {
                            if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                            {
                                dataGridViewMeci.Rows[e.RowIndex].ErrorText = "Introduceti cota!";
                                e.Cancel = true;
                            }
                            else
                            {
                                Regex regex = new Regex(@"1[.]\d*");
                                bool valid = regex.IsMatch(e.FormattedValue.ToString());
                                //MessageBox.Show(e.FormattedValue.ToString()+ " " + valid.ToString());
                                if (!valid)
                                {
                                    MessageBox.Show("Cota trebuie sa fie sub forma de procent: 1.xx!");
                                }
                            }
                        }
                    }
                }
            }
          
            
        }

        private void dataGridViewMeci_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewMeci.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void btnSalveaza_Click(object sender, EventArgs e)
        {
            
            if (tbCotaTotala.Text.Equals(""))
            {
                errorProvider1.SetError(tbCotaTotala, "Introduceti cota!");
            }
            else
            {
                if (tbMiza.Text.Equals(""))
                {
                    errorProvider1.SetError(tbMiza, "Introduceti miza!");
                }
                else
                {
                    if (tbCastig.Text.Equals(""))
                    {
                        errorProvider1.SetError(tbCastig, "Introduceti castigul!");
                    }
                    else
                    {
                        errorProvider1.Clear();

                        try
                        {

                            List<Meci> listaMeciuri = new List<Meci>();
                            for (int i = 0; i < dataGridViewMeci.RowCount - 1; i++)
                            {
                                DataGridViewRow row = dataGridViewMeci.Rows[i];

                                string dataStr = row.Cells[0].Value.ToString();
                                DateTime date = DateTime.ParseExact(dataStr, "dd.MM.yyyy", CultureInfo.InvariantCulture);//Convert.ToDateTime(dataStr);
                                string denumire = row.Cells[1].Value.ToString();
                                string pronostic = row.Cells[2].Value.ToString();
                                float cota = float.Parse(row.Cells[3].Value.ToString());
                                Meci meci = new Meci(date, denumire, pronostic, cota);
                                listaMeciuri.Add(meci);


                            }

                            float miza = float.Parse(tbMiza.Text);
                            float cotaTotala = float.Parse(tbCotaTotala.Text);
                            float valoareCastig = float.Parse(tbCastig.Text);
                            pariu = new Pariu(listaMeciuri, miza, cotaTotala, valoareCastig);

                            listaPariuri.Add(pariu);
                            //MessageBox.Show(pariu.ToString());
                            MessageBox.Show("Pariu efectuat!");

                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.ToString());
                        }
                        finally
                        {
                            dataGridViewMeci.RowCount = 1;
                            tbCastig.Text = "";
                            tbMiza.Text = "";
                            tbCotaTotala.Text = "";
                        }
                    }
                }
            }
            
        }

      

        private void tbMiza_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == (char)8 || e.KeyChar == '.'){
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

  

        private void tbCotaTotala_Click(object sender, EventArgs e)
        {
            float cotaTotala = 0.0f;
            for (int i = 0; i < dataGridViewMeci.RowCount - 1; i++)
            {
                DataGridViewRow row = dataGridViewMeci.Rows[i];

                cotaTotala += float.Parse(row.Cells[3].Value.ToString());
            }
            tbCotaTotala.Text = cotaTotala.ToString();
        }

        private void tbCastig_Click(object sender, EventArgs e)
        {
            float valoareTotala = 0.0f;
            float miza = float.Parse(tbMiza.Text);
            float cotaTotala = float.Parse(tbCotaTotala.Text);
            for(int i = 0; i < dataGridViewMeci.RowCount - 1; i++)
            {
                DataGridViewRow row = dataGridViewMeci.Rows[i];
                valoareTotala = miza * cotaTotala;
            }
            tbCastig.Text = valoareTotala.ToString();
        }

        private void pdPrintBilet(object sender, PrintPageEventArgs e)
        {
            Graphics gr = e.Graphics;
            Rectangle rec = new Rectangle(e.PageBounds.X, e.PageBounds.Y, e.PageBounds.Width, e.PageBounds.Height);
            Pen pen = new Pen(Color.Black, 12);
            Brush br = new SolidBrush(Color.Black);
            Bitmap img = new Bitmap("Logo.png");
            int margine = 30;

            gr.DrawImage(img, new Rectangle(margine, margine, 50, 50));
            Font font = new Font(FontFamily.GenericSansSerif, 30, FontStyle.Bold);
            gr.DrawString("Super pariu", font, br, new Point(margine + 50 + 5, margine));

            gr.DrawString(DateTime.Now.ToString(), this.Font, br, new Point(margine, 130));

            Rectangle linie = new Rectangle(e.PageBounds.X, 150, e.PageBounds.Width, 5);
            gr.FillRectangle(br, linie);

            
            int latime = e.PageBounds.Width / 5;
            string[] denumiri = new string[] { "Nr", "Data", "Meci", "Pronostic", "Cota" };
            for(int i = 0;i< 5; i++)
            {
                gr.DrawString(denumiri[i], this.Font, br, new Point( 30 + i * latime, 165));
            }


            int nr_crt = 1;
            int d = 165 + this.Font.Height;
           
            gr.DrawLine(new Pen(Color.Black, 1), new Point(e.PageBounds.X, d + 2), new Point(e.PageBounds.Width, d + 2));

            if (pariu.Meciuri!= null)
            {
                foreach (Meci m in pariu.Meciuri)
                {
                    gr.DrawString(nr_crt.ToString(), this.Font, br, new Point(30, d + 5 * nr_crt + (nr_crt - 1) * this.Font.Height));
                    gr.DrawString(m.Data.ToString(), this.Font, br, new Point(30 + latime, d + 5 * nr_crt + (nr_crt - 1) * this.Font.Height));
                    gr.DrawString(m.Denumire, this.Font, br, new Point(30 + 2 * latime, d + 5 * nr_crt + (nr_crt - 1) * this.Font.Height));
                    gr.DrawString(m.Pronostic, this.Font, br, new Point(30 + 3 * latime, d + 5 * nr_crt + (nr_crt - 1) * this.Font.Height));
                    gr.DrawString(m.Cota.ToString(), this.Font, br, new Point(30 + 4 * latime, d + 5 * nr_crt + (nr_crt - 1) * this.Font.Height));
                    gr.DrawLine(new Pen(Color.Black, 1), new Point(e.PageBounds.X, d + 5 * nr_crt + nr_crt * this.Font.Height + 2), new Point(e.PageBounds.Width, d + 5 * nr_crt + nr_crt * this.Font.Height + 2));

                    nr_crt++;

                }

                Font font2 = new Font(FontFamily.GenericSansSerif, 14);
                gr.DrawString("Cota finala:", font2, br, new Point(30, e.PageBounds.Height / 2));
                gr.DrawString(pariu.CotaTotala.ToString(), font2, br, new Point(30 + 100 + 5 , e.PageBounds.Height / 2));
                gr.DrawString("Miza:", font2, br, new Point(30, e.PageBounds.Height / 2 + font2.Height + 5));
                gr.DrawString(pariu.Miza.ToString() + " LEI", font2, br, new Point(30 + 105, e.PageBounds.Height / 2 + font2.Height + 5));

                Rectangle rectangle = new Rectangle(e.PageBounds.X, e.PageBounds.Height / 2 + 2 * (font2.Height + 5) + 10, e.PageBounds.Width, 5);
                gr.FillRectangle(br, rectangle);

                gr.DrawString("Valoare Castig:", font2, br, new Point(30, e.PageBounds.Height / 2 + 2 * (font2.Height + 5) + 10 + 10));

                Rectangle rectangle2 = new Rectangle(30, e.PageBounds.Height / 2 + 2 * (font2.Height + 5) + 10 + 10 + font2.Height + 10, e.PageBounds.Width - 2 * 30, 100);
                gr.FillRectangle(new SolidBrush(Color.Red), rectangle2);
                gr.DrawString(pariu.ValoareaCastig + " LEI", new Font(FontFamily.GenericSansSerif, 30, FontStyle.Bold), new SolidBrush(Color.White), new Point(e.PageBounds.Width - 2 * 30 - 480, e.PageBounds.Height / 2 + 2 * (font2.Height + 5) + 10 + 10 + font2.Height + 10 + 30));

            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(pdPrintBilet);
            PrintPreviewDialog dlg = new PrintPreviewDialog();
            dlg.Document = pd;
            dlg.ShowDialog();
        }

        private void btnSalveaza_Click_1(object sender, EventArgs e)
        {
            if (tbCotaTotala.Text.Equals(""))
            {
                errorProvider1.SetError(tbCotaTotala, "Introduceti cota!");
            }
            else
            {
                if (tbMiza.Text.Equals(""))
                {
                    errorProvider1.SetError(tbMiza, "Introduceti miza!");
                }
                else
                {
                    if (tbCastig.Text.Equals(""))
                    {
                        errorProvider1.SetError(tbCastig, "Introduceti castigul!");
                    }
                    else
                    {
                        errorProvider1.Clear();

                        try
                        {

                            List<Meci> listaMeciuri = new List<Meci>();
                            for (int i = 0; i < dataGridViewMeci.RowCount - 1; i++)
                            {
                                DataGridViewRow row = dataGridViewMeci.Rows[i];

                                string dataStr = row.Cells[0].Value.ToString();
                                DateTime date = DateTime.ParseExact(dataStr, "dd.MM.yyyy", CultureInfo.InvariantCulture);//Convert.ToDateTime(dataStr);
                                string denumire = row.Cells[1].Value.ToString();
                                string pronostic = row.Cells[2].Value.ToString();
                                float cota = float.Parse(row.Cells[3].Value.ToString());
                                Meci meci = new Meci(date, denumire, pronostic, cota);
                                listaMeciuri.Add(meci);


                            }

                            float miza = float.Parse(tbMiza.Text);
                            float cotaTotala = float.Parse(tbCotaTotala.Text);
                            float valoareCastig = float.Parse(tbCastig.Text);
                            pariu = new Pariu(listaMeciuri, miza, cotaTotala, valoareCastig);

                            listaPariuri.Add(pariu);
                            //MessageBox.Show(pariu.ToString());
                            MessageBox.Show("Pariu efectuat!");

                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.ToString());
                        }
                        finally
                        {
                            dataGridViewMeci.RowCount = 1;
                            tbCastig.Text = "";
                            tbMiza.Text = "";
                            tbCotaTotala.Text = "";
                        }
                    }
                }
            }
        }

        private void btnRenunta_Click_1(object sender, EventArgs e)
        {
            const string message = "Datele introduse vor fi pierdute. Continuati?";
            const string caption = "Form closing";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {

                this.Close();
            }
        }
    }
}
