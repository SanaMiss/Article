using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace Articles
{
    public partial class Frm_Consulter : Form
    {

        public Frm_Consulter()
        {
            InitializeComponent();
            DAL d = new DAL();
            dataGridView1.DataSource = d.SelectAll();
            
        }



        private void button6_Click(object sender, EventArgs e)
        {
           
                DAL d = new DAL();
                string categorie = comboBox1.SelectedItem.ToString();
                string valeur = textBox1.Text;
                switch (categorie)
                {
                    case "Référence":
                        if (ValidateChildren(ValidationConstraints.Enabled))
                        {
                            dataGridView1.DataSource = d.SelectRef_Art(valeur);
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

        private void button3_Click(object sender, EventArgs e)
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Frm_Facture_Ajout fa = new Frm_Facture_Ajout();
            //this.Hide();
            //fa.textBoxRef.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            //fa.textBoxDes.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            //fa.textBoxPrix.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            //fa.ShowDialog();
        }
    }
}
