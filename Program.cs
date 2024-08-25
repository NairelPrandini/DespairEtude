using System;
using System.Windows.Forms;
using DespairEtude.GlobalResources;
using DespairEtude.Pages;

namespace DespairEtude
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            GlobalResources.Pages.InitializePages();
            Application.Run(GlobalResources.Pages.MainForm);

        }
    }
}
