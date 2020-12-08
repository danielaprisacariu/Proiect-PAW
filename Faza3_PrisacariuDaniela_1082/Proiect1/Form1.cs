using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect1
{
    public partial class Form1 : Form
    {
        string provider;
        public Form1()
        {
            InitializeComponent();
            provider = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = utilizatori.accdb";
            
        }

        private void tbUser_Enter(object sender, EventArgs e)
        {
            if(tbUser.Text.Equals("Nume utilizator"))
            {
                tbUser.Text = "";
                tbUser.ForeColor = Color.Black;
            }
        }

        private void tbUser_Leave(object sender, EventArgs e)
        {
            if (tbUser.Text.Equals(""))
            {
                tbUser.Text = "Nume utilizator";
                tbUser.ForeColor = Color.Silver;
            }
        }

        private void tbPassword_Enter(object sender, EventArgs e)
        {
            if (tbPassword.Text.Equals("Parola"))
            {
                tbPassword.Text = "";
                tbPassword.ForeColor = Color.Black;

            }
        }

        private void tbPassword_Leave(object sender, EventArgs e)
        {
            if (tbPassword.Text.Equals(""))
            {
                tbPassword.Text = "Parola";
                tbPassword.ForeColor = Color.Silver;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conexiune = new OleDbConnection(provider);
            string sqlSelect = "select * from utilizatori";
            OleDbCommand comanda = new OleDbCommand(sqlSelect, conexiune);
            string nume_utilizator = tbUser.Text;
            string parola = tbPassword.Text;

            try
            {
                conexiune.Open();
                //MessageBox.Show("conexiune realizata cu succes!");
                OleDbDataReader reader = comanda.ExecuteReader();

                bool vb = false;
                while (reader.Read())
                {
                    if (reader["nume"].ToString().Equals(nume_utilizator) && reader["parola"].ToString().Equals(parola))
                    {
                        vb = true;
                        FormHome frm = new FormHome();
                        frm.Show();
                        tbUser.Clear();
                        tbPassword.Clear();
                    }
                 
                }
                if (!vb)
                {
                    MessageBox.Show("Nume de utilizator si parola incorecte", "Credentiale incorecte!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbUser.Clear();
                    tbPassword.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormInregistrare frm = new FormInregistrare();
            frm.Show();
        }

        private void btnAutentificare_Click(object sender, EventArgs e)
        {
            OleDbConnection conexiune = new OleDbConnection(provider);
            string sqlSelect = "select * from utilizatori";
            OleDbCommand comanda = new OleDbCommand(sqlSelect, conexiune);
            string nume_utilizator = tbUser.Text;
            string parola = tbPassword.Text;

            try
            {
                conexiune.Open();
                //MessageBox.Show("conexiune realizata cu succes!");
                OleDbDataReader reader = comanda.ExecuteReader();

                bool vb = false;
                while (reader.Read())
                {
                    if (reader["nume"].ToString().Equals(nume_utilizator) && reader["parola"].ToString().Equals(parola))
                    {
                        vb = true;
                        FormHome frm = new FormHome();
                        frm.ShowDialog();
                        tbUser.Clear();
                        tbPassword.Clear();
                    }

                }
                if (!vb)
                {
                    MessageBox.Show("Nume de utilizator si parola incorecte", "Credentiale incorecte!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbUser.Clear();
                    tbPassword.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
