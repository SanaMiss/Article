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
    public partial class Frm_Supprimer : Form
    {
        public Frm_Supprimer()
        {
            InitializeComponent();
            DAL d = new DAL();
            dataGridView1.DataSource = d.SelectAll();
        }

        private void btn_Quitter_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void btn_Rechercher_Click(object sender, EventArgs e)
        {
            DAL d = new DAL();
            string categorie = comboBox1.SelectedItem.ToString();
            string valeur = textBox1.Text;
            switch (categorie)
            {
                case "Référence":
                    if (ValidateChildren(ValidationConstraints.Enabled))
                    {
                        dataGridView1.DataSource = d.SelectRef();
                        textBox1.Clear();
                    }
                    break;

                case "Désignation":
                    if (ValidateChildren(ValidationConstraints.Enabled))
                    {
                        dataGridView1.DataSource = d.SelectDesign(valeur);
                        textBox1.Clear();
                    }
                    break;

                case "Prix":
                    if (ValidateChildren(ValidationConstraints.Enabled))
                    {
                        dataGridView1.DataSource = d.SelectPrix(Convert.ToDouble(valeur));
                        textBox1.Clear();
                    }
                    break;

                case "Quantité":
                    if (ValidateChildren(ValidationConstraints.Enabled))
                    {
                        dataGridView1.DataSource = d.SelectQuantite(Convert.ToInt16(valeur));
                        textBox1.Clear();
                    }
                    break;

                case "Tout":
                    dataGridView1.DataSource = d.SelectAll();
                    break;
                default:
                    MessageBox.Show("Erreur");
                    break;



            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                e.Cancel = true;
                textBox1.Focus();
                errorProvider1.SetError(textBox1, "Donner une Valeur pour la Recherche");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox1, null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Êtes-vous sûr de vouloir Supprimer" + "\n" +
                           "ces enregistrements?" + "\n" +
                           "A T T E N T I O N." + "\n" +
                           "Cette opération est irréversible...", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DAL d = new DAL();
                Class_Article a = new Class_Article();
                a.Reference1 = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
              //  MessageBox.Show("" + a.Reference1);
                d.Delete(a.Reference1);
                dataGridView1.DataSource = d.SelectAll();

            }
            else
                this.Close();
        }

    }
}
    

