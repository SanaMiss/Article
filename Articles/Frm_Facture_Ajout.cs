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
    public partial class Frm_Facture_Ajout : Form
    {
        DAL d = new DAL();
        public Frm_Facture facture;
        public object[] ligne { get; set; }
        public DataGridView newDataGridView
        {
            get; set;
        }
        public Frm_Facture_Ajout(Frm_Facture facture)
        {
            InitializeComponent();
            comboBox1.DataSource = d.Combo_fill_des();
             comboBox1.ValueMember = "Designation";
            this.facture = facture;
        }

        private void FillCombo()
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        { 


            float montant;
            montant = (Convert.ToSingle(textBoxPrix.Text) * Convert.ToSingle(textBoxQte.Text));
            
            ligne = new object[]
            {
                textBoxRef.Text , comboBox1.SelectedValue.ToString() , textBoxPrix.Text , textBoxQte.Text , Convert.ToString(montant)
            };



            //DataGridVie.DataSource = TaDataSet.Tables("Facture");

            float montantTot = 0;

            foreach (DataGridViewRow l in facture.dataGridView1.Rows)
            {
                montantTot = montantTot + Convert.ToSingle(l.Cells[4].Value);
                


                facture.textBox2.Text = Convert.ToString(montantTot);
            }

            this.Close();
           
        }

        public string valeur;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        { DAL d = new DAL();
            valeur = comboBox1.SelectedValue.ToString();
            Class_Article a = new Class_Article();
           Class_Article at = d.get_reference(valeur);
            textBoxRef.Text = at.Reference1;
            textBoxPrix.Text = Convert.ToString(at.Prix1);
            textBoxRef.ReadOnly = true;
            textBoxPrix.ReadOnly = true;

        }
        

        private void Frm_Facture_Ajout_Load(object sender, EventArgs e)
        {

        }

        private void textBoxRef_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBoxQte_TextChanged(object sender, EventArgs e)
        {

        }
        //private void Combo()
        //{
        //    Class_Article a = new Class_Article();
        //    valeur = comboBox1.SelectedValue.ToString();
        //    a = d.fill_ComboBox(valeur);
        //    textBoxDes.Text = a.Designation1;
        //    float prix = a.Prix1;
        //    textBoxPrix.Text = Convert.ToString(prix);
        //    textBoxDes.ReadOnly = true;

        //}
    }
}
