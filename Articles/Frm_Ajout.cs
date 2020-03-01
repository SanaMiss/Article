using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Articles
{
    public partial class Frm_Ajout : Form
    {
        public Frm_Ajout()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                panel2.Visible = true;
            }
            else
            {
                panel2.Visible = false;
            }
        }

        private void textBoxRef_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxRef.Text))
            {
                e.Cancel = true;
                textBoxRef.Focus();
                errorProvider1.SetError(textBoxRef, "Remplir le champ Reference!!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBoxRef, null);
            }
        }

     

        private void textBoxPrix_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPrix_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxPrix.Text))
            {
                e.Cancel = true;
                textBoxPrix.Focus();
                errorProvider1.SetError(textBoxPrix, "Remplir le champ Prix!!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBoxPrix, null);
            }
        }

        private void textBoxQte_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxQte.Text))
            {
                e.Cancel = true;
                textBoxQte.Focus();
                errorProvider1.SetError(textBoxQte, "Remplir le champ Quantité!!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBoxQte, null);
            }
        }

        private void textBoxDes_Validating_1(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxDes.Text))
            {
                e.Cancel = true;
                textBoxDes.Focus();
                errorProvider1.SetError(textBoxDes, "Remplir le champ Désignation!!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBoxDes, null);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
           
        }

        private void textBoxPrix_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
                MessageBox.Show("Le Prix doit être un Chiffre! ");
            }
        }

        private void textBoxQte_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
                MessageBox.Show("La Quantité doit être un Chiffre! ");
            }
        }
        private void textBoxRef_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                DAL d = new DAL();
                Class_Article a = new Class_Article();

                a.Reference1 = textBoxRef.Text;
                a.Designation1 = textBoxDes.Text;
                a.Prix1 = float.Parse(textBoxPrix.Text);
                a.Quantite1 = int.Parse(textBoxQte.Text);
                a.Promo1 = checkBox1.Checked;
                a.Date_Fin1 = Convert.ToDateTime(dateTimePicker2.Value);







                string refe = textBoxRef.Text;
                if (d.VerifRef(refe) == false)
                {
                    if (d.Insert(a) == true)
                    {
                        MessageBox.Show("Article Ajouté");
                        Clear();

                    }
                    else
                        MessageBox.Show("Article n'est pas Ajouté");


                }
                else
                {
                    MessageBox.Show("Référence Existe déjà");

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clear();
        }
  

        public void Clear()
        {
            textBoxRef.Clear();
            textBoxDes.Clear();
            textBoxPrix.Clear();
            textBoxQte.Clear();
            checkBox1.Checked = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxRef_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }

    }

