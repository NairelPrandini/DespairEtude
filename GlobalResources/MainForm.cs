using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
using System.Media;
using System.Threading;

namespace DespairEtude.GlobalResources
{
    public class MainForm : Form
    {

        public Panel MainPanel;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            MainPanel = new Panel { Size = GlobalSettings.DefaultWindowSize };

            this.ClientSize = GlobalSettings.DefaultWindowSize;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.Name = "MainForm";

            this.Controls.Add(MainPanel);

            this.Load += new System.EventHandler(this.MainForm_Load);

        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            GlobalResources.Pages.LoadPage(GlobalResources.Pages.MainMenu);
        }
    }
}