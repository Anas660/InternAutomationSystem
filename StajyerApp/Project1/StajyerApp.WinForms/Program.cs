using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StajyerApp.WinForms
{
    static class Program
    {
        static void Main()
        {


            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new  frmStajyer());
                //Application.Run(new frmStajyer());
                // Application.Run(new TestForm());



            }
            catch (Exception ex)
            {
                Application.Exit();
            }

        }
    }
}
