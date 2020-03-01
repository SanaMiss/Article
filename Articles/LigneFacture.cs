using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles
{
    public class LigneFacture
    {

        string reference;
        string rf_art;
        int quantite;
        float prix;
        int Idfacture;

        public string Reference
        {
            get
            {
                return reference;
            }

            set
            {
                reference = value;
            }
        }



        public int Quantite
        {
            get
            {
                return quantite;
            }

            set
            {
                quantite = value;
            }
        }
        public float Prix
        {
            get
            {
                return prix;
            }

            set
            {
                prix = value;
            }
        }

        public string IdArticle
        {
            get
            {
                return rf_art;
            }

            set
            {
                rf_art = value;
            }
        }

        public int ProIdfacture {
            get
            {
                return Idfacture;
            }
                set
                    { Idfacture = value; }
            }

        public LigneFacture() { }
        public LigneFacture( string num_f , string rf_ar , int qte)
        {
            Reference = num_f;
            IdArticle = rf_ar; ;
            Quantite = qte;
        }




    }
}
