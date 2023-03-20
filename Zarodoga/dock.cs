using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zarodoga
{
    internal class dock
    {
        int ID;
        string Diak_ID;
        int Dock_ID;
        string Nev;
        string Dock_Nev;

        public dock(int iD1, string diak_ID1, int dock_ID1, string nev,string dock_Nev1 )
        {
            ID1 = iD1;
            Diak_ID1 = diak_ID1;
            Dock_ID1 = dock_ID1;
            Nev = nev;
            Dock_Nev1 = dock_Nev1;
           
        }

        public int ID1 { get => ID; set => ID = value; }
        public string Diak_ID1 { get => Diak_ID; set => Diak_ID = value; }
        public int Dock_ID1 { get => Dock_ID; set => Dock_ID = value; }
        public string Nev1 { get => Nev; set => Nev = value; }
        public string Dock_Nev1 { get => Dock_Nev; set => Dock_Nev = value; }
     

        public override string ToString()
        {
            return $"{Nev},{Dock_Nev}";
        }
    }
}
