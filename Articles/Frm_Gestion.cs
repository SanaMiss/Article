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
    public partial class Frm_Gestion : Form
    {
        public Frm_Gestion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_Consulter consult = new Frm_Consulter();
            consult.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Frm_Facture fact = new Frm_Facture();
            fact.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            Frm_Ajout ajout = new Frm_Ajout();
            ajout.Show();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
           // Frm_Consulter consult = new Frm_Consulter();
           // consult.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            Frm_Modifier modif = new Frm_Modifier();
            modif.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            Frm_Supprimer supp = new Frm_Supprimer();
            supp.Show();
        }

        private void Frm_Gestion_Load(object sender, EventArgs e)
        {

        }
    }
}
