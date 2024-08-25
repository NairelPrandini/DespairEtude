using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
using System.Media;
using DespairEtude.GlobalResources;
using System.Threading;
using DespairEtude.CustomComponents;

namespace DespairEtude.Pages
{
    public partial class Game : UserControl
    {
        private BufferedTableLayoutPanel PageLayout;
        private PictureBox TitleImage;
        private Button NewGame;
        private Button Continue;

        public Game()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {

            this.PageLayout = new BufferedTableLayoutPanel();
            this.TitleImage = new PictureBox();
            this.NewGame = new Button();
            this.Continue = new Button();



            this.PageLayout.ColumnCount = 3;
            this.PageLayout.Dock = DockStyle.Fill;
            this.PageLayout.BackgroundImage = Image.FromStream(Resources.GetResource("Images.MenuBackground.jpg"));
            this.PageLayout.BackgroundImageLayout = ImageLayout.Stretch;


            this.PageLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));  // Remaining space for background
            this.PageLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));  // Fixed width for the image and buttons
            this.PageLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));   // Fixed width for the image and buttons

            // Add an empty row to space out the buttons
            this.PageLayout.RowCount = 11;  // Adjusted to include space rows
            this.PageLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));  // Space between buttons
            this.PageLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));  // Button row
            this.PageLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));   // Space between buttons
            this.PageLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));  // Button row
            this.PageLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));   // Space between buttons
            this.PageLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));  // Button row
            this.PageLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));   // Space between buttons

            // 
            // TitleImage
            // 
            this.TitleImage.BackColor = Color.Transparent;
            this.TitleImage.Dock = DockStyle.Fill;
            this.TitleImage.SizeMode = PictureBoxSizeMode.Zoom;
            this.TitleImage.TabStop = false;
            this.TitleImage.Image = Image.FromStream(Resources.GetResource("Images.Title.png"));

            // Add buttons to the panel
            this.PageLayout.Controls.Add(this.TitleImage, 1, 0);  // Title Image
            this.PageLayout.Controls.Add(this.NewGame, 1, 1);     // Row 1
            this.PageLayout.Controls.Add(this.Continue, 1, 3);    // Row 3


            // Buttons
            this.NewGame.Dock = DockStyle.Fill;
            this.NewGame.Name = "NewGameButton";
            this.NewGame.Text = "New Game";
            this.NewGame.Click += new EventHandler(this.NewGame_Click);

            this.Continue.Dock = DockStyle.Fill;
            this.Continue.Name = "ContinueButton";
            this.Continue.Text = "Continue";
            this.Continue.Enabled = false;


            this.Controls.Add(this.PageLayout);

        }

        private void Game_Paint(object sender, PaintEventArgs e)
        {
            this.Invalidate();
        }


        private void NewGame_Click(object sender, EventArgs e)
        {
            GlobalResources.Pages.LoadPage(GlobalResources.Pages.MainMenu);
        }
    }
}