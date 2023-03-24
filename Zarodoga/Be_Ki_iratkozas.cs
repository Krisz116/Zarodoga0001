using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zarodoga
{
    public partial class Be_Ki_iratkozas : Form
    {
        Database Database = new Database();
        static public MySqlCommand cmd = Database.cmd;
        static public MySqlConnection connection = Database.connection;




        public Be_Ki_iratkozas()
        {
            InitializeComponent();
        }
        public void iratUpdate()
        {
            listBox1.Items.Clear();
            foreach (iratkozas item in Database.getAllIrat())
            {
                listBox1.Items.Add(item);
            }
        }
        public void egyirat()
        {
            listBox1.Items.Clear();
            foreach (iratkozas item in Database.getAllIrat())
            {
                if (item.Diak_Id1.Contains(textBox_IG_szam.Text))
                    listBox1.Items.Add(item);
            }
        }


        private void Be_Ki_iratkozas_Load(object sender, EventArgs e)
        {
            iratUpdate();
            Database.Kapcsolat();
        }

        private void Hozzáadd_Click(object sender, EventArgs e)
        {
           
            
            
            if (string.IsNullOrEmpty(textBox_IG_szam.Text))
            {
                MessageBox.Show("Adja meg a Diák igazolvány szánot");
                textBox_IG_szam.Focus();
                return;
            }
        
        
            if (string.IsNullOrEmpty(comboBox_isk_nev.Text))
            {
                MessageBox.Show("Adja meg az Iskola nevét");
                comboBox_isk_nev.Focus();
                return;
            }

            
           

            Database.Be_Ki_Insert();
            
        }

        private void Töröl_Click(object sender, EventArgs e)
        {
            Database.Be_Ki_Delete();
        }

        private void Szerkeszt_Click(object sender, EventArgs e)
        {
            Database.Be_Ki_Update();
        }

        private void button_kereses_Click(object sender, EventArgs e)
        {
            egyirat();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is iratkozas kivalasztott_irat)
            {
                textBox_nev.Text = kivalasztott_irat.Nev1;
                textBox_IG_szam.Text = kivalasztott_irat.Diak_Id1;
                textBox_datum.Text = kivalasztott_irat.Datum1;
                comboBox_isk_nev.Text = kivalasztott_irat.Isk_nev1;
                comboBox_ki_be.Text = kivalasztott_irat.Be_Ki1;
            }
        }

        private void button_keresestorol_Click(object sender, EventArgs e)
        {
            textBox_nev.Text = "";
            textBox_IG_szam.Text = "";
            textBox_datum.Text = "";
            comboBox_isk_nev.Text = "";
            comboBox_ki_be.Text = "";
        }
    }
}
