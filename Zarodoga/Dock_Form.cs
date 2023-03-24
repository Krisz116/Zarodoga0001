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
   
    public partial class Dock_Form : Form
    {
        Database database = new Database();
        static public MySqlCommand cmd = Database.cmd;
        static public MySqlConnection connection = Database.connection;
        public Dock_Form()
        {
            InitializeComponent();
        }
        public void dockUpdate()
        {
            listBox1.Items.Clear();
            foreach (dock item in database.getAllDock())
            {
                listBox1.Items.Add(item);
            }
        }
        public void egydock()
        {
            listBox1.Items.Clear();
            foreach (dock item in database.getAllDock())
            {
                if (item.Diak_ID1.Contains(textBox_ig_szam.Text))
                    listBox1.Items.Add(item);
            }
        }

        private void Dock_Form_Load(object sender, EventArgs e)
        {
            dockUpdate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            database.Dock_Inser();

        }

        private void button_torol_Click(object sender, EventArgs e)
        {
            database.Dock_Delete();
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            database.Dock_Update();
        }

        private void button_keres_Click(object sender, EventArgs e)
        {
            egydock();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is dock kivalasztott_dock)
            {
                textBox_ig_szam.Text = kivalasztott_dock.Diak_ID1;
                textBox_nev.Text = kivalasztott_dock.Nev1;
                comboBox_dock_nev.Text = kivalasztott_dock.Dock_Nev1;
                
            }

        }

        private void button_keresestorlese_Click(object sender, EventArgs e)
        {
            textBox_ig_szam.Text = "";
            textBox_nev.Text = "";
            comboBox_dock_nev.Text = "";
        }
    }
}
