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

            
           

            Database.Alt_Insert();
            
        }
    }
}
