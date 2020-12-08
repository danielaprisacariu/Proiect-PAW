using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect1
{
    public class Meci : IComparable, ICloneable
    {
        private DateTime data;
        private string denumire;
        private float cota;
        private string pronostic;

        public Meci()
        {
            denumire = "Anonim";
            data = System.DateTime.Now;
            cota = 0.0f;
            pronostic = "anonim";

        }

        public Meci( DateTime v_data, string v_denumuire, string v_pronostic, float v_cota)
        {
            denumire = v_denumuire;
            data = v_data;
            cota = v_cota;
            pronostic = v_pronostic;
        }

        //proprietati
        public string Denumire
        {
            get { return denumire; }
            set { if (value != null) denumire = value; }
        }
        public DateTime Data
        {
            get { return data; }
            set { if (value != null) data = value; }
        }
        public float Cota {
            get { return cota; }
        }
        public string Pronostic
        {
            get { return pronostic; }
            set { if (value != null) pronostic = value; }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public int CompareTo(object obj)
        {
            Meci m = (Meci)obj;
            if(this.data > m.data)
            {
                return 1;
            }
            else
            {
                if(this.data < m.data)
                {
                    return -1;
                }
                else
                {
                    return string.Compare(this.denumire, m.denumire);
                }
            }
        }

        public override string ToString()
        {
            return data + ", " + denumire + ", " + pronostic + ", " + cota;
        }

    }
}
