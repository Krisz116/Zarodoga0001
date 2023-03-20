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
        Database database = new Database();
        static public MySqlCommand cmd;
        static public MySqlConnection connection;
        
       

        public Be_Ki_iratkozas()
        {
            InitializeComponent();
        }
        public void iratUpdate()
        {
            listBox1.Items.Clear();
            foreach (iratkozas item in database.getAllIrat())
            {
                listBox1.Items.Add(item);
            }
        }

        private void Be_Ki_iratkozas_Load(object sender, EventArgs e)
        {
            iratUpdate();
        }

        private void Hozzáadd_Click(object sender, EventArgs e)
        {
            
            
            if (string.IsNullOrEmpty(textBox_IG_szam.Text))
            {
                MessageBox.Show("Adja meg a Diák igazolvány szánot");
                textBox_IG_szam.Focus();
                return;
            }
            if (string.IsNullOrEmpty(textBox_nev.Text))
            {
                MessageBox.Show("Adja meg a diák nevét!");
                textBox_nev.Focus();
                return;
            }
            if (string.IsNullOrEmpty(comboBox_isk_nev.Text))
            {
                MessageBox.Show("Adja meg az Iskola nevét");
                comboBox_isk_nev.Focus();
                return;
            }
            Kapcsolat();
            database.Open();
            cmd.CommandText = "INSERT INTO `be_ki_iratkozas`(`Diak_ID`, `Isk_ID`, `Ki_Be`, `Datum`) VALUES (@Diak_ID, @Isk_ID, @Ki_Be, @Datum)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Diak_ID",textBox_IG_szam);
            cmd.Parameters.AddWithValue("@Isk_ID", comboBox_isk_nev.Text);
            cmd.Parameters.AddWithValue("@Ki_Be",comboBox_ki_be.Text);
            cmd.Parameters.AddWithValue("@Datum",textBox_datum.Text);
            

            
            try
            {
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Sikeres adat rögzítés");
                    textBox_IG_szam.Text = "";
                    textBox_nev.Text = "";
                    comboBox_isk_nev.Text = "";
                    comboBox_ki_be.Text = "";
                    textBox_datum.Text = "";
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
    }
}
