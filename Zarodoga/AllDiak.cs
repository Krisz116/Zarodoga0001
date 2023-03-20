using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zarodoga
{
    public partial class AllDiak : Form
    {
        Database database = new Database();
        public AllDiak()
        {
            InitializeComponent();
        }

        public void diakUpdate()
        {
            Lista.Items.Clear();
            foreach (diak item in database.getAllDiak())
            {
                Lista.Items.Add(item);
            }
        }



        private void AllDiak_Load(object sender, EventArgs e)
        {
            diakUpdate();

        }

        private void Hozzaadd_Click(object sender, EventArgs e)
        {

        }

        private void Keres_Click(object sender, EventArgs e)
        {
            foreach (diak diak in database.getAllDiak())
            {
                if (textBox_nev.Text == diak.Nev)
                {
                    textBoxSzdatum.Text = diak.Sz_Datum1;
                    textBoxanyjanev.Text = diak.Anyja_Sz_nev1;
                    textBoxigszam.Text = diak.Diak_ID1;
                    textBoxosztaly.Text = diak.Osztaly;

                }
            }
        }
    }
}
