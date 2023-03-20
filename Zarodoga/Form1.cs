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
    public partial class Form1 : Form
    {
        Database database = new Database();
        public Form1()
        {
            InitializeComponent();
        }
     

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void Lista_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_Dock_Click(object sender, EventArgs e)
        {
            Program.Dock_Form.ShowDialog();
        }

        private void Button_Diak_Click(object sender, EventArgs e)
        {
            Program.AllDiak.ShowDialog();
        }

        private void button_ki_be_Click(object sender, EventArgs e)
        {
            Program.Be_Ki_Iratkozas.ShowDialog();
        }
    }
}
