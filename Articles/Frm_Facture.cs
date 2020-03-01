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
    public partial class Frm_Facture : Form
    {
        public Frm_Facture()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Frm_Consulter consult = new Frm_Consulter();
            //consult.Show();
            Frm_Facture_Ajout fa = new Frm_Facture_Ajout(this);
            fa.ShowDialog();
            dataGridView1.DataSource = ConvertirEnDataTable(fa.ligne);

        }


        public DataTable ConvertirEnDataTable(object[] NewLigne)
        {
            DataTable data = new DataTable();
            data.Columns.Add("Référence", typeof(string));
            data.Columns.Add("Désignation", typeof(string));
            data.Columns.Add("PrixUnit", typeof(int));
            data.Columns.Add("Quantité", typeof(int));
            data.Columns.Add("Montant", typeof(float));
            DataRow newRow = data.NewRow();
            if (dataGridView1.Rows.Count <= 0)
            {
                data.Rows.Add(
                    NewLigne[0].ToString(),
                    NewLigne[1].ToString(),
                    int.Parse(NewLigne[2].ToString()),
                    int.Parse(NewLigne[3].ToString()),
                    float.Parse(NewLigne[4].ToString())
                    );
            }
            else
            {
                for(int i = 0; i < dataGridView1.Rows.Count; i++) {

                    data.Rows.Add(
                        dataGridView1.Rows[i].Cells[0].Value.ToString(),
                        dataGridView1.Rows[i].Cells[1].Value.ToString(),
                        int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()),
                        int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()),
                        float.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString())
                        );
                }
                data.Rows.Add(
                    NewLigne[0].ToString(),
                    NewLigne[1].ToString(),
                    int.Parse(NewLigne[2].ToString()),
                    int.Parse(NewLigne[3].ToString()),
                    float.Parse(NewLigne[4].ToString())
                    );
            }


            return data;

        }
        public DataTable dt = new DataTable();
        private void Frm_Facture_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("Référence",typeof(string));
            dt.Columns.Add("Désignation",typeof(string));
            dt.Columns.Add("PrixUnit",typeof(int));
            dt.Columns.Add("Quantité",typeof(int));
            dt.Columns.Add("Montant",typeof(float));

            dataGridView1.DataSource = dt;
        }
        string rf;
        private void button2_Click(object sender, EventArgs e)
        {
            DAL d = new DAL();
            Facture f = new Facture();
            Class_Article a = new Class_Article();
            LigneFacture c = new LigneFacture();

            f.Num_facture = textBox1.Text;
            f.Date_facture = dateTimePicker1.Value;
            // int IdFact = d.Insert Facture(f);
            // if (IdFact > 0)
            // {
            MessageBox.Show("Facture Ajouté");
        
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                c.Reference = textBox1.Text;
                //c.IdArticle = Convert.ToString(r.Cells[0].Value);
                c.Quantite = Convert.ToInt16(r.Cells[3].Value);
                d.Insert_Commande(c);

                int qte = Convert.ToInt16(r.Cells[3].Value);
                a = d.fill_art_ref(Convert.ToString(r.Cells[0].Value));
                // MessageBox.Show("" + a.Quantite1);
                a.Quantite1 = a.Quantite1 - qte;
                string refe = Convert.ToString(r.Cells[0].Value);
                d.UpDate_qte(a, refe);
            }
         
                MessageBox.Show("Facture n'est pas Ajouté");
            
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        //private void label1_Click(object sender, EventArgs e)
       // {

       // }
    }
}
