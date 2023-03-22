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



        private void AllDiak_Load(object sender, EventArgs e)
        {
            diakUpdate();

        }

        private void Hozzaadd_Click(object sender, EventArgs e)
        {
            database.Kapcsolat();
            database.Open();

            cmd.CommandText = "INSERT INTO `diak`(`Nev`, `Sz_Datum`, `Anyja_Sz_nev`, `Diak_ID`, `osztaly`) VALUES (@nev,@sz_datum,@anyja_sz_nev,@diakid,@osztaly)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@nev",textBox_nev.Text);
            cmd.Parameters.AddWithValue("@sz_datum",textBoxSzdatum.Text);
            cmd.Parameters.AddWithValue("anyja_sz_nev",textBoxanyjanev.Text);
            cmd.Parameters.AddWithValue("@diakid",textBoxigszam.Text);
            cmd.Parameters.AddWithValue("@osztaly",textBoxosztaly.Text);
            try
            {
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Sikeres adat rögzítés");
                    textBox_nev.Text = "";
                    textBoxSzdatum.Text = "";
                    textBoxanyjanev.Text = "";
                    textBoxigszam.Text = "";
                    textBoxosztaly.Text = "";
                }
                else
                {
                    MessageBox.Show("Sikertelen adat rögzítés");


                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            Close();
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

        private void button_kereses_torol_Click(object sender, EventArgs e)
        {
            textBox_nev.Text = "";
            textBoxSzdatum.Text = "";
            textBoxanyjanev.Text = "";
            textBoxigszam.Text = "";
            textBoxosztaly.Text = "";
        }
    }
}
