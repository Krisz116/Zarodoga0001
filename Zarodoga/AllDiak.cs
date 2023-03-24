using MySql.Data.MySqlClient;
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
        static public MySqlCommand cmd = Database.cmd;
        static public MySqlConnection connection = Database.connection;
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
        public void egydiak() 
        {
            Lista.Items.Clear();
            foreach (diak item in database.getAllDiak())
            {
                if (item.Nev.Contains(textBox_nev.Text))
                Lista.Items.Add(item);
            }
        }



        private void AllDiak_Load(object sender, EventArgs e)
        {
            diakUpdate();

        }

        private void Hozzaadd_Click(object sender, EventArgs e)
        {
            database.Diak_Insert();
        }

        private void Keres_Click(object sender, EventArgs e)
        {
            //  foreach (diak diak in database.getAllDiak())
            //{
            //    if (textBox_nev.Text == diak.Nev)
            //  {
            //      textBoxSzdatum.Text = diak.Sz_Datum1;
            //    textBoxanyjanev.Text = diak.Anyja_Sz_nev1;
            //  textBoxigszam.Text = diak.Diak_ID1;
            // textBoxosztaly.Text = diak.Osztaly;

            //}
            //}

            egydiak();
      

        }

        private void button_kereses_torol_Click(object sender, EventArgs e)
        {
            textBox_nev.Text = "";
            textBoxSzdatum.Text = "";
            textBoxanyjanev.Text = "";
            textBoxigszam.Text = "";
            textBoxosztaly.Text = "";
        }

        private void Töröl_Click(object sender, EventArgs e)
        {
            database.Diak_Delete();
        }

        private void Szerkeszt_Click(object sender, EventArgs e)
        {
            database.Diak_Update();
        }

        private void Lista_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Lista.SelectedItem is diak kivalasztott_diak)
            {
                textBox_nev.Text = kivalasztott_diak.Nev;
                textBoxSzdatum.Text = kivalasztott_diak.Sz_Datum1;
                textBoxanyjanev.Text = kivalasztott_diak.Anyja_Sz_nev1;
                textBoxigszam.Text = kivalasztott_diak.Diak_ID1;
                textBoxosztaly.Text = kivalasztott_diak.Osztaly;
            }
        }
    }
}
