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

        private void Dock_Form_Load(object sender, EventArgs e)
        {
            dockUpdate();
        }
    }
}
