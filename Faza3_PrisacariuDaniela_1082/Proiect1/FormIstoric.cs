using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect1
{
    public partial class FormIstoric : Form
    {
        const string Calefisier = "istoric.txt";
        List<Pariu> lista = new List<Pariu>();
        public FormIstoric()
        {
            InitializeComponent();
            lista = FormBilet.listaPariuri;
            initializareListView();
           
        }

        private void initializareListView()
        {
            List<Pariu> pariuri = citirePariuriDinFisier();
            foreach(Pariu pariu in lista)
            {
                pariuri.Add(pariu);
            }
            pariuri.Sort();
            lista = pariuri;
            foreach(Pariu p in pariuri)
            {
                ListViewItem rand = new ListViewItem();
                List<Meci> meciuri = p.Meciuri;
                meciuri.Sort();
                string meciuriStr = "";
                foreach (Meci m in meciuri)
                {
                    meciuriStr += m.ToString() + " | ";
                }

                rand.Text = meciuriStr;
                rand.SubItems.Add(p.Miza.ToString());
                rand.SubItems.Add(p.CotaTotala.ToString());
                rand.SubItems.Add(p.ValoareaCastig.ToString());
                rand.Tag = p.ToString();
                listView1.Items.Add(rand);
            }
        }

        private List<Pariu> citirePariuriDinFisier()
        {
            string[] linii = File.ReadAllLines(Calefisier);
            List<Pariu> pariuri = new List<Pariu>();

            foreach (string linie in linii)
            {
                Pariu pariu = new Pariu();
                List<Meci> listaMeciuri = new List<Meci>();
                string[] meciuriStr = linie.Trim().Split('|');
                for (int i = 0; i < meciuriStr.Length - 1; i++)
                {
                    string[] s = meciuriStr[i].Trim().Split(',');
                    string dateStr = s[0];

                    DateTime date = DateTime.ParseExact(dateStr, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                    string denumire = s[1];
                    string pronostic = s[2];
                    float cota = float.Parse(s[3]);
                    Meci meci = new Meci(date, denumire, pronostic, cota);
                    listaMeciuri.Add(meci);

                }
                pariu.Meciuri = listaMeciuri;
                string[] t = meciuriStr[meciuriStr.Length - 1].Split(',');
                float miza = float.Parse(t[0]);
                float cotaTotala = float.Parse(t[1]);
                float valoareCastig = float.Parse(t[2]);
                pariu.Miza = miza;
                pariu.CotaTotala = cotaTotala;
                pariu.ValoareaCastig = valoareCastig;

                pariuri.Add(pariu);

            }
            return pariuri;
        }


        private void btnInapoi_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void descarcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "(*.txt)|*.txt";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(dlg.FileName);
                foreach(ListViewItem rand in listView1.Items)
                {
                    sw.Write(rand.Tag.ToString() + Environment.NewLine + Environment.NewLine);
                }
                
                sw.Close();


            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog dlg = new FontDialog();
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                listView1.Font = dlg.Font;

            }
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButtonGrafic_Click(object sender, EventArgs e)
        {
            FormGrafic frm = new FormGrafic(lista);
            frm.Show();
        }
    }
}
