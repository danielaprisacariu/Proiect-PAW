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
    public partial class FormInregistrare : Form
    {
        string provider;
        public FormInregistrare()
        {
            InitializeComponent();
            provider = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = utilizatori.accdb";
        }

     

        private void buton1_Click(object sender, EventArgs e)
        {
            OleDbConnection conexiune = new OleDbConnection(provider);
            string nume_utilizator = tbUser.Text;
            string parola1 = tbPassword.Text;
            string parola2 = tbPassword2.Text;
            string sqlSelect = "Select nume from utilizatori";
            OleDbCommand comandaSelect = new OleDbCommand(sqlSelect, conexiune);
            try
            {
                conexiune.Open();
                //MessageBox.Show("Conexiune realizata cu succes!");
                OleDbDataReader reader = comandaSelect.ExecuteReader();
                while (reader.Read())
                {

                    if (reader["nume"].ToString().Equals(nume_utilizator))
                    {
                        errorProvider1.SetError(tbUser, "Acest nume este deja folosit!");
                        errorProvider1.Tag = "Eroare1";
                    }
                    else
                    {
                        if (nume_utilizator.Length <= 3)
                        {
                            errorProvider1.SetError(tbUser, "Numele trebuie sa fie mai mare de 3 caractere!");
                            errorProvider1.Tag = "Eroare2";
                        }
                        else
                        {
                            errorProvider1.Tag = "Nou";
                        }

                    }

                }

                if (!parola1.Equals(parola2))
                {
                    errorProvider1.SetError(tbPassword, "Cele doua parole introduse nu sunt identice!");
                    errorProvider1.SetError(tbPassword2, "Cele doua parole nu sunt identice!");
                }
                else
                {
                    if (parola1.Length <= 3)
                    {
                        errorProvider1.SetError(tbPassword, "Parola trebuie sa aiba mai mult de 3 caractere!");
                    }
                    else
                    {

                        string sqlIdCount = "select count(*) from utilizatori";
                        OleDbCommand comandaCount = new OleDbCommand(sqlIdCount, conexiune);
                        OleDbCommand comandaInsert = new OleDbCommand();
                        comandaInsert.Connection = conexiune;

                        if (errorProvider1.Tag.ToString() != "Eroare1" && errorProvider1.Tag.ToString() != "Eroare2")
                        {
                            int id = Convert.ToInt32(comandaCount.ExecuteScalar());

                            comandaInsert.Transaction = conexiune.BeginTransaction();
                            comandaInsert.CommandText = "insert into utilizatori(id, nume, parola) values (?, ?, ?)";

                            comandaInsert.Parameters.Add("id", OleDbType.Integer).Value = id + 1;
                            comandaInsert.Parameters.Add("nume", OleDbType.Char).Value = nume_utilizator;
                            comandaInsert.Parameters.Add("parola", OleDbType.Char).Value = parola1;

                            comandaInsert.ExecuteNonQuery();
                            comandaInsert.Transaction.Commit();

                            MessageBox.Show("Inregistrare realizata cu succes!");

                            tbUser.Clear();
                            tbPassword.Clear();
                            tbPassword2.Clear();
                            errorProvider1.Clear();

                            Close();
                        }

                    }
                }

            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexiune.Close();

            }
        }
    }
}
