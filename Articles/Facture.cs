using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles
{
    public class Facture
    {


        string num_facture;
        DateTime date_facture;

        public DateTime Date_facture
        {
            get
            {
                return date_facture;
            }

            set
            {
                date_facture = value;
            }
        }

        public string Num_facture
        {
            get
            {
                return num_facture;
            }

            set
            {
                num_facture = value;
            }
        }

        public Facture() { }
        public Facture(string numf, DateTime datef)
        {
            num_facture = numf;
            date_facture = datef;
        }
    }
}

