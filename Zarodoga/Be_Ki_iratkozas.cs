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
    public partial class Be_Ki_iratkozas : Form
    {
        Database database = new Database();
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
    }
}
