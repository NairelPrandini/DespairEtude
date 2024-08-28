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
    public partial class Game : UserControl, ControlInputHandler
    {
        private PictureBox Background;
        private PictureBox CharacterImage;
        private Label TitleLabel;
        private RichTextBox DialogueText;

        public Game()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Background Image
            this.Background = new PictureBox();
            this.Background.Dock = DockStyle.Fill;
            //this.BackgroundImage.Image = Image.FromStream(Resources.GetResource("Game.fea_r1f.png"));
            this.Background.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(this.Background);

            // Character Image
            this.CharacterImage = new PictureBox();
            this.CharacterImage.Size = new Size(300, 600); // Adjust size based on your character image
            this.CharacterImage.Location = new Point(50, 100); // Adjust position as needed
            //this.CharacterImage.Image = Image.FromStream(Resources.GetResource("Game.jes_a11_atya1.png"));
            this.CharacterImage.SizeMode = PictureBoxSizeMode.Zoom;
            this.Background.Controls.Add(this.CharacterImage); // Add to BackgroundImage to overlay

            // Title Label
            this.TitleLabel = new Label();
            this.TitleLabel.Text = "Despair Etude"; // Replace with your title
            this.TitleLabel.Font = new Font("Arial", 24, FontStyle.Bold);
            this.TitleLabel.ForeColor = Color.White;
            this.TitleLabel.BackColor = Color.Transparent;
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new Point(20, 20); // Adjust position as needed
            this.Background.Controls.Add(this.TitleLabel);

            // Dialogue Text
            this.DialogueText = new RichTextBox();
            this.DialogueText.Size = new Size(700, 150); // Adjust size based on your needs
            this.DialogueText.Location = new Point(50, 500); // Adjust position as needed
            this.DialogueText.Font = new Font("Arial", 14);
            this.DialogueText.BackColor = Color.Black;
            this.DialogueText.ForeColor = Color.White;
            this.DialogueText.Text = "This is where the character's dialogue will be displayed."; // Initial text
            this.DialogueText.ReadOnly = true;
            this.DialogueText.BorderStyle = BorderStyle.None;
            this.Background.Controls.Add(this.DialogueText);
        }

        public void ProcessInput(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                GlobalResources.Pages.LoadPage(GlobalResources.Pages.MainMenu);
            }

        }

    }
}