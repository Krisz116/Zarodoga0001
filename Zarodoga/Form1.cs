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
        public void diakUpdate()
        {
            Lista.Items.Clear();
            foreach (diak item in database.getAllDiak())
            {
                Lista.Items.Add(item);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            diakUpdate();
        }

        private void Lista_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
