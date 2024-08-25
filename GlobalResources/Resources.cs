using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
using System.Media;
using DespairEtude.Pages;


namespace DespairEtude.GlobalResources
{
    public static class Pages
    {
        public static MainForm MainForm;
        public static UserControl GamePage;
        public static UserControl MainMenu;

        public static void InitializePages()
        {
            MainForm = new MainForm();
            GamePage = new Game();
            MainMenu = new DespairEtude.Pages.MainMenu();
        }

        public static void LoadPage(UserControl Page)
        {
            Page.Dock = DockStyle.Fill;
            MainForm.MainPanel.Controls.Add(Page);
            Page.BringToFront();
        }

    }

    public static class Resources
    {
        public static SoundPlayer MusicPlayer = new SoundPlayer();
        public static SoundPlayer EffectPlayer = new SoundPlayer();

        public static void PlayMusic(string MusicPath)
        {
            var MusicStream = GetResource(MusicPath);
            MusicPlayer.Stream = MusicStream;
            MusicPlayer.PlayLooping();
        }

        public static void PlayEffect(string EffectPath)
        {
            var EffectStream = GetResource(EffectPath);
            EffectPlayer.Stream = EffectStream;
            EffectPlayer.Play();
        }

        public static Stream GetResource(string ResourcePath)
        {
            var AssemblyReference = Assembly.GetExecutingAssembly();
            var CompletePath = $"DespairEtude.Resources.{ResourcePath}";
            var Resources = AssemblyReference.GetManifestResourceStream(CompletePath) ?? throw new Exception($"Resource {CompletePath} not found.");
            return Resources;
        }

    }

    public static class GlobalSettings
    {
        public static Size DefaultWindowSize = new Size(800, 600);
        public static bool FullScreen = false;
        public static FontFamily DefaultFontFamilly = SystemFonts.MenuFont.FontFamily;
    }

    public static class GlobalFuntions
    {
        public static void SetFullScreen()
        {
            Pages.MainForm.Opacity = 0;
            int screenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            int targetWidth = screenWidth;
            int targetHeight = (int)(screenWidth / (4.0 / 3.0));

            if (targetHeight > screenHeight)
            {
                targetHeight = screenHeight;
                targetWidth = (int)(screenHeight * (4.0 / 3.0));
            }

            int xOffset = (screenWidth - targetWidth) / 2;
            int yOffset = (screenHeight - targetHeight) / 2;

            Pages.MainForm.MainPanel.Size = new Size(targetWidth, targetHeight);
            Pages.MainForm.MainPanel.Location = new Point(xOffset, yOffset);

            Pages.MainForm.FormBorderStyle = FormBorderStyle.None;
            Pages.MainForm.WindowState = FormWindowState.Maximized;
            Pages.MainForm.Refresh();

            GlobalSettings.FullScreen = true;
            Pages.MainForm.Opacity = 100;
        }


        public static Size GetCurrentResolution()
        {
            return new Size(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height);
        }

        public static void ToggleFullScreen()
        {
            if (GlobalSettings.FullScreen)
                SetWindowed();
            else
                SetFullScreen();
        }


        public static void SetWindowed()
        {
            Pages.MainForm.Opacity = 0;
            Pages.MainForm.MainPanel.Size = GlobalSettings.DefaultWindowSize;
            Pages.MainForm.MainPanel.Location = new Point(0, 0);

            Pages.MainForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            Pages.MainForm.WindowState = FormWindowState.Normal;


            Pages.MainForm.Refresh();

            GlobalSettings.FullScreen = false;
            Pages.MainForm.Opacity = 100;
        }


        public static void SetFontSizeAuto()
        {

            float fontSize = Math.Min(Pages.MainForm.MainPanel.Width, Pages.MainForm.MainPanel.Height) / 40f;

            foreach (Control c in Pages.MainForm.MainPanel.Controls)
            {
                if (c is Button b)
                {
                    b.Font = new Font(GlobalSettings.DefaultFontFamilly, fontSize);
                }
            }
        }

        public static void SetFontSizeManual(float fontSize)
        {
            foreach (Control c in Pages.MainForm.MainPanel.Controls)
            {
                if (c is Button b)
                {
                    b.Font = new Font(GlobalSettings.DefaultFontFamilly, fontSize);
                }
            }
        }

    }


}