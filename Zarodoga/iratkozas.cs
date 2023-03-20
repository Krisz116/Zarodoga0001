using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zarodoga
{
    internal class iratkozas
    {
        int ID;
        string Diak_Id;
        int Isk_ID;
        string Be_Ki;
        string Datum;
        string Isk_nev;
        string Nev;

        public iratkozas(int iD1, string diak_Id1, int isk_ID1, string be_Ki1, string datum1, string isk_nev1, string nev )
        {
            ID1 = iD1;
            Diak_Id1 = diak_Id1;
            Isk_ID1 = isk_ID1;
            Be_Ki1 = be_Ki1;
            Datum1 = datum1;
            Isk_nev1 = isk_nev1;
            Nev = nev;
        }

        public int ID1 { get => ID; set => ID = value; }
        public string Diak_Id1 { get => Diak_Id; set => Diak_Id = value; }
        public int Isk_ID1 { get => Isk_ID; set => Isk_ID = value; }
        public string Be_Ki1 { get => Be_Ki; set => Be_Ki = value; }
        public string Datum1 { get => Datum; set => Datum = value; }
        public string Isk_nev1 { get => Isk_nev; set => Isk_nev = value; }
        public string Nev1 { get => Nev; set => Nev = value; }

        public override string ToString()
        {
            return $"{Nev}, {Be_Ki}iratkozott";
        }
    }
}
