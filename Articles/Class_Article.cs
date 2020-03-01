using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles
{
    public class Class_Article
    {
        string Reference;
        string Designation;
        float Prix;
        int Quantite;
        bool Promo;
        DateTime DateFinPromo;
        

        public string Reference1
        {
            get
            {
                return Reference;
            }

            set
            {
                Reference = value;
            }
        }

        public string Designation1
        {
            get
            {
                return Designation;
            }

            set
            {
                Designation = value;
            }
        }

        public float Prix1
        {
            get
            {
                return Prix;
            }

            set
            {
                Prix = value;
            }
        }

        public int Quantite1
        {
            get
            {
                return Quantite;
            }

            set
            {
                Quantite = value;
            }
        }

        public bool Promo1
        {
            get
            {
                return Promo;
            }

            set
            {
                Promo = value;
            }
        }

       

        public DateTime Date_Fin1
        {
            get
            {
                return DateFinPromo;
            }

            set
            {
                DateFinPromo = value;
            }
        }

        public Class_Article() { }

        public Class_Article(string rf, string des, float px, int qte, bool prm, DateTime df)
        {

            Reference1 = rf;
            Designation1 = des;
            Prix1 = px;
            Quantite1 = qte;
            Promo1 = prm;
            DateFinPromo = df;
        }
    }
}
