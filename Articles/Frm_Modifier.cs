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
    public partial class Frm_Modifier : Form
    {
        DAL d = new DAL();
        public Frm_Modifier()
        {
            InitializeComponent();
            
            dataGridView1.DataSource = d.SelectAll();
            
        }

       

        private void btn_Quitter_Click(object sender, EventArgs e)
        {
            this.Hide();
           
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            textBoxRef.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxDes.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBoxPrix.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBoxQte.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            checkBox1.Checked = Convert.ToBoolean(this.dataGridView1.CurrentRow.Cells[5].Value);
            DateTime dt = DateTime.Parse(dataGridView1.CurrentRow.Cells[6].Value.ToString());
            dateTimePicker1.Value = DateTime.Parse(dt.ToShortDateString());
         
           
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

        private void btn_Enregister_Click(object sender, EventArgs e)
        {
            if (textBoxRef.Text == "" && textBoxDes.Text == "" && textBoxPrix.Text == "" && textBoxQte.Text == "")
            {
                MessageBox.Show("Selectionner un Article");
            }
            else
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
                    a.Date_Fin1 = Convert.ToDateTime(dateTimePicker1.Value);

                    string rf = textBoxRef.Text;
                    if (d.UpDate(a, rf) == true)
                    {
                        MessageBox.Show("Article Modifié");
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("Article n'est pas Modifié");
                    }

                    dataGridView1.DataSource = d.SelectAll();
                }
            }
          
                

        }

     


        public void Clear()
        {
            textBoxRef.Clear();
            textBoxDes.Clear();
            textBoxPrix.Clear();
            textBoxQte.Clear();
            checkBox1.Checked = false;
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

        private void textBoxDes_Validating(object sender, CancelEventArgs e)
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

        private void textBoxRef_KeyPress(object sender, KeyPressEventArgs e)
        {          
            
        }

        private void textBoxDes_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}
