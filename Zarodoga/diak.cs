using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zarodoga
{
    internal class diak
    {
        string nev;
        string Sz_Datum;
        string Anyja_Sz_nev;
        string Diak_ID;
        string osztaly;

        public diak(string nev, string sz_Datum1, string anyja_Sz_nev1, string diak_ID1, string osztaly)
        {
            Nev = nev;
            Sz_Datum1 = sz_Datum1;
            Anyja_Sz_nev1 = anyja_Sz_nev1;
            Diak_ID1 = diak_ID1;
            Osztaly = osztaly;
        }

        public string Nev { get => nev; set => nev = value; }
        public string Sz_Datum1 { get => Sz_Datum; set => Sz_Datum = value; }
        public string Anyja_Sz_nev1 { get => Anyja_Sz_nev; set => Anyja_Sz_nev = value; }
        public string Diak_ID1 { get => Diak_ID; set => Diak_ID = value; }
        public string Osztaly { get => osztaly; set => osztaly = value; }

        public override string ToString()
        {
            return $"{nev},{osztaly}";
        }
    }

}
