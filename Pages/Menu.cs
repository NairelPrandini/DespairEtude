using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;
using System.Threading;
using DespairEtude.GlobalResources;
using DespairEtude.CustomComponents;

namespace DespairEtude.Pages
{
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private BufferedTableLayoutPanel PageLayout;
        private PictureBox TitleImage;
        private Button NewGame;
        private Button Extras;
        private Button FullScreen;
        private Button Continue;
        private Button ExitGame;

        private void InitializeComponent()
        {

            this.PageLayout = new BufferedTableLayoutPanel();
            this.TitleImage = new PictureBox();
            this.NewGame = new Button();
            this.Continue = new Button();
            this.FullScreen = new Button();
            this.Extras = new Button();
            this.ExitGame = new Button();

            // 
            // MainLayout
            //

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
            this.PageLayout.Controls.Add(this.FullScreen, 1, 5);    // Row 5
            this.PageLayout.Controls.Add(this.Extras, 1, 7);      // Row 7
            this.PageLayout.Controls.Add(this.ExitGame, 1, 9);    // Row 9

            // Buttons
            this.NewGame.Dock = DockStyle.Fill;
            this.NewGame.Name = "NewGameButton";
            this.NewGame.Text = "New Game";
            this.NewGame.Click += new EventHandler(this.NewGame_Click);

            this.Continue.Dock = DockStyle.Fill;
            this.Continue.Name = "ContinueButton";
            this.Continue.Text = "Continue";
            this.Continue.Enabled = false;

            this.FullScreen.Dock = DockStyle.Fill;
            this.FullScreen.Name = "FullscreenButton";
            this.FullScreen.Text = "Fullscreen";
            this.FullScreen.Click += new EventHandler(this.FullScreen_Click);

            this.Extras.Dock = DockStyle.Fill;
            this.Extras.Name = "ExtrasButton";
            this.Extras.Text = "Extras";
            this.Extras.Enabled = false;


            this.ExitGame.Dock = DockStyle.Fill;
            this.ExitGame.Name = "ExitButton";
            this.ExitGame.Text = "Exit";
            this.ExitGame.Click += new EventHandler(this.Exit_Click);

            // 
            // MainMenu
            // 

            this.Load += new EventHandler(this.MainMenu_Load);
            this.Controls.Add(this.PageLayout);

        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            Resources.PlayMusic("Music.Nocturne.wav");
        }

        private void NewGame_Click(object sender, EventArgs e)
        {
            GlobalResources.Pages.LoadPage(GlobalResources.Pages.GamePage);
        }

        private void FullScreen_Click(object sender, EventArgs e)
        {
            GlobalResources.GlobalFuntions.ToggleFullScreen();
            FullScreen.Text = GlobalResources.GlobalSettings.FullScreen ? "Windowed" : "Fullscreen";
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}