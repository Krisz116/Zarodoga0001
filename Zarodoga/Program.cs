using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zarodoga
{
    internal static class Program
    {
        static public Dock_Form Dock_Form = null;
        static public Be_Ki_iratkozas Be_Ki_Iratkozas = null;
        static public AllDiak AllDiak = null;
        static public Form1 Form1 = null;
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Dock_Form = new Dock_Form();
            Be_Ki_Iratkozas = new Be_Ki_iratkozas();
            AllDiak = new AllDiak();
            Form1 = new Form1();
            Application.Run(Form1);

        }
    }
}
