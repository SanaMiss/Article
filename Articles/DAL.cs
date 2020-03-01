using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.Data;
using System.Data.SqlClient;

namespace Articles
{
    public class DAL
    {
        static string myConnecting = @"Data Source=DESKTOP-KSGLTG1\SANASQL;Initial Catalog=dbArticle;Integrated Security=True;";
        static SqlConnection conn = new SqlConnection(myConnecting);

        //Affichage de tout les Articles
        public DataTable SelectAll()
        {
            conn.Open();
            string Marequet = "SELECT * FROM Article ";
            SqlCommand cmd = new SqlCommand(Marequet, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
            return dt;
        }




        //Ajout d'un Article
        public Boolean Insert (Class_Article a)
        {
            
            conn.Open();
            string Marequet = "INSERT INTO Article (Reference,Designation,Prix,Quantite,Promo,DateFinPromo) Values (@rf,@des,@px,@qte,@prm,@df)";
            SqlCommand cmd = new SqlCommand(Marequet,conn);
            cmd.Parameters.AddWithValue("@rf", a.Reference1);
            cmd.Parameters.AddWithValue("@des", a.Designation1);
            cmd.Parameters.AddWithValue("@px", a.Prix1);
            cmd.Parameters.AddWithValue("@qte", a.Quantite1);
            cmd.Parameters.AddWithValue("@prm", a.Promo1);
            cmd.Parameters.AddWithValue("@df", a.Date_Fin1);
            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
        }

        public Boolean VerifRef(string v)
        {
            conn.Open();
            string Marequet = "SELECT * FROM Article WHERE Reference=@rf";
            SqlCommand cmd = new SqlCommand(Marequet, conn);
            cmd.Parameters.AddWithValue("@rf", v);
            SqlDataReader reader = cmd.ExecuteReader();

            int i = 0;
            while (reader.Read())
            {
                i++;
            }
            conn.Close();

            if (i > 0)

            {
                return true;
            }
            else
            {
                return false;
            }
         }

        //Recherche d'un Article (par refernce)
                 
        public DataTable SelectRef ()
        {
            conn.Open();
            string Marequet = "SELECT Reference FROM Article ";
            SqlCommand cmd = new SqlCommand(Marequet, conn);
            
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
            return dt;
        }


        public DataTable SelectRef_Art(string v)
        {
            conn.Open();
            string Marequet = "SELECT * FROM Article WHERE Reference=@rf";
            SqlCommand cmd = new SqlCommand(Marequet, conn);
            cmd.Parameters.AddWithValue("@rf", v);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        //Par Désignation
        public DataTable SelectDesign(string design)
        {
            conn.Open();
            string Marequet = "SELECT * FROM Article WHERE Designation = @des";
            SqlCommand cmd = new SqlCommand(Marequet,conn);
            cmd.Parameters.AddWithValue("@des", design);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
            return dt;
        }


        //Par Prix
        public DataTable SelectPrix(double prix)
        {
            conn.Open();
            string Marequet = "SELECT * FROM Article WHERE Prix = @px";
            SqlCommand cmd = new SqlCommand(Marequet,conn);
            cmd.Parameters.AddWithValue("@px", prix);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
            return dt;
        }


        //Par Quantité
        public DataTable SelectQuantite(int Qte)
        {
            conn.Open();
            string Marequet = "SELECT * FROM Article WHERE Quantite = @qte";
            SqlCommand cmd = new SqlCommand(Marequet, conn);
            cmd.Parameters.AddWithValue("@qte", Qte);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        // Modifier Article 
        public Boolean UpDate (Class_Article a , string rf)
        {
            conn.Open();
            string Marequet = " UPDATE Article SET Reference = @rf, Designation = @des, Prix = @px, Quantite = @qte, Promo = @prm, DateFinPromo = @df WHERE Reference = '" + rf + "' ";
            SqlCommand cmd = new SqlCommand(Marequet,conn);
            cmd.Parameters.AddWithValue("@rf", a.Reference1);
            cmd.Parameters.AddWithValue("@des", a.Designation1);
            cmd.Parameters.AddWithValue("@px", a.Prix1);
            cmd.Parameters.AddWithValue("@qte", a.Quantite1);
            cmd.Parameters.AddWithValue("@prm", a.Promo1);
            cmd.Parameters.AddWithValue("@df", a.Date_Fin1);
            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
        }
        public Boolean UpDate_qte(Class_Article a, string rf)
        {
            conn.Open();
            string Marequet = " UPDATE Article SET  Quantite = @qte WHERE Reference = '" + rf + "' ";
            SqlCommand cmd = new SqlCommand(Marequet,conn);
            
            cmd.Parameters.AddWithValue("@qte", a.Quantite1);
            
            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
        }


        // Supprimer Article 

        public Boolean Delete (string v)
        {
            conn.Open();
            string Marequet = "DELETE FROM Article WHERE Reference = @rf";
            SqlCommand cmd = new SqlCommand(Marequet, conn);
            cmd.Parameters.AddWithValue("@rf", v);
            cmd.ExecuteNonQuery();
            conn.Close(); 
            return true;
        }


        public Class_Article fill_textbox(string v)
        {
            Class_Article a = new Class_Article();
            conn.Open();

            String reqsql = "SELECT Reference , PrixUnit, Quantite FROM Article WHERE Designation = @des";
            SqlCommand cmd = new SqlCommand(reqsql, conn);
            cmd.Parameters.AddWithValue("@des", v);
            SqlDataReader reader = cmd.ExecuteReader();
           reader = cmd.ExecuteReader();
            


            string rf;
            float prix;
            int qte;
            while (reader.Read())
            {

                rf = reader.GetString(1);                           
                prix = reader.GetFloat(5);
               qte = reader.GetInt16(6);
                a.Reference1 = rf;
                
                a.Prix1 = Convert.ToSingle(prix);
                a.Quantite1 = Convert.ToInt16(qte);

            }


            reader.Close();
            conn.Close();
            return a;

        }


         public  Class_Article  get_reference( string des  )
        {
            Class_Article A = new Class_Article();
            conn.Open();
            string Marequet = "SELECT * FROM Article  where designation= @des";
            SqlCommand cmd = new SqlCommand(Marequet, conn);
            cmd.Parameters.AddWithValue("@des", des);
            DataTable dts = new DataTable();
            SqlDataReader r1 = cmd.ExecuteReader();
            while (r1.Read())
            {
                A.Reference1 = r1.GetString(1);
                 A.Prix1 = r1.GetFloat(6);
                A.Quantite1 = r1.GetInt32(5);

            }
            conn.Close();
            return A;
        }
        public DataTable Combo_fill_des()
        {
            conn.Open();
            string Marequet = "SELECT Designation FROM Article ";
            SqlCommand cmd = new SqlCommand(Marequet, conn);
            
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
            return dt;
        }



        //Ajout Facture

        public int Insert_facture(Facture f)
        {

            conn.Open();
            string Marequet = "INSERT INTO Facture( [num_facture] , [date_facture] ) VALUES (@numf, @datef); select id from facture where num_facture = @numf  ";
            SqlCommand cmd = new SqlCommand(Marequet, conn);
            cmd.Parameters.AddWithValue("@numf", f.Num_facture);
            cmd.Parameters.AddWithValue("@datef", f.Date_facture);

            int idFact;
            idFact = cmd.ExecuteNonQuery();
            conn.Close();
            return idFact;
        }


        //Ajout Commande 

        public Boolean Insert_Commande( LigneFacture c)
        {

            conn.Open();
            string Marequet = "INSERT INTO LigneFacture (Reference , Id_act , Quantite) VALUES ( @Reference , @IdArticle , @Quantite )";
            SqlCommand cmd = new SqlCommand(Marequet, conn);
            cmd.Parameters.AddWithValue("@Reference", c.Reference);
            cmd.Parameters.AddWithValue("@IdArticle", c.IdArticle);
            cmd.Parameters.AddWithValue("@IdArticle", c.Idfacture);
            cmd.Parameters.AddWithValue("@Quantite", c.Quantite);
            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
        }


        public Class_Article fill_art_ref(string v)
        {
            Class_Article a = new Class_Article();
            conn.Open();

            String reqsql = "SELECT id, reference, designation, promo, datefinpromo, quantite, prix FROM Article WHERE Reference = @rf";
            SqlCommand cmd = new SqlCommand(reqsql,conn);
            cmd.Parameters.AddWithValue("@rf", v);
            SqlDataReader reader = cmd.ExecuteReader();
            //reader = cmd.ExecuteReader();


            string rf;
            float prix;
            int ? qte;
            while (reader.Read())
            {
                try
                {
                    rf = reader.GetString(1);
                    prix = reader.GetFloat(6);
                    qte = reader.GetInt32(5);
                    a.Reference1 = rf;

                    a.Prix1 = Convert.ToSingle(prix);
                    a.Quantite1 = Convert.ToInt16(qte);
                }
                catch
                {

                }

            }


            reader.Close();
            conn.Close();
            return a;

        }

    }



}


