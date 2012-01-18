//////////////////////////////////////////////////////////////////////////
/// Fury Monitor
/// Author: John Hannagan, Jan 2012
//////////////////////////////////////////////////////////////////////////
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace FuryMonitor
{
    /// <summary>
    /// The main shirt design pop-up form. Checks the Tee fury web site every hour to 
    /// see if there is a new design, if there is the window will pop up.
    /// </summary>
    public partial class Popup : Form
    {
        /// <summary>
        /// The desired width of the small shirt preview popup
        /// </summary>
        private const int DEFAULT_PREVIEW_WIDTH = 330;

        /// <summary>
        /// The current shirt image.
        /// </summary>
        private Image popupImage;

        public Popup()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Repositions the window location to the bottom right of the primary screen
        /// </summary>
        private void RepositionPopupLocation()
        {
            var screenRect = Screen.PrimaryScreen.WorkingArea;
            SetDesktopLocation(screenRect.Width - Width,
                                screenRect.Height - Height);
        }

        /// <summary>
        /// When the app loads we need to check if there is a new shirt design
        /// </summary>
        private void Popup_Load(object sender, EventArgs e)
        {
            if (!CheckForNewShirt())
            {
                //The user has already seen this shirt design. But we still need to load the image.
                popupImage = TeeFuryQuerier.GetShirtImageFromURL(Properties.Settings.Default.LastImageURL);
            }
        }

        /// <summary>
        /// Resizes the popup window to the default preview size, and updates the screen position
        /// </summary>
        private void ResizeToPreview()
        {
            WindowState = FormWindowState.Normal;

            float imageRatio = popupImage.Height / (float)popupImage.Width;
            Width = DEFAULT_PREVIEW_WIDTH;
            Height = (int)(DEFAULT_PREVIEW_WIDTH * imageRatio);

            RepositionPopupLocation();
            Refresh();
        }

        /// <summary>
        /// Checks tee fury to see if there is a new shirt design. If there is
        /// it will download the image, popup and display the current design.
        /// </summary>
        /// <returns>True if there was a new design, false otherwise<returns>
        private bool CheckForNewShirt()
        {
            var settings = Properties.Settings.Default;
            string lastImageURL = settings.LastImageURL;
            string currentImageURL = TeeFuryQuerier.GetCurrentTShirtImageURL();

            if (String.IsNullOrEmpty(lastImageURL) || lastImageURL != currentImageURL)
            {
                //The shirt image has changed, update it.
                if (popupImage != null)
                {
                    popupImage.Dispose();
                }

                popupImage = TeeFuryQuerier.GetShirtImageFromURL(currentImageURL);
                settings.LastImageURL = currentImageURL;
                settings.Save();

                ResizeToPreview();
                Show();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Changes the popup size to the max size of the current image
        /// </summary>
        private void ResizeToFull()
        {
            Size = new Size(popupImage.Width, popupImage.Height);

            RepositionPopupLocation();
            Refresh();
        }

        private void Popup_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(popupImage, this.DisplayRectangle);
        }

        /// <summary>
        /// Show full size of mouse over
        /// </summary>
        private void Popup_MouseHover(object sender, EventArgs e)
        {
            ResizeToFull();
        }

        private void Popup_MouseLeave(object sender, EventArgs e)
        {
            ResizeToPreview();
        }

        /// <summary>
        /// Hide the shirt design when the user clicks it, until a new 
        /// shirt design is detected.
        /// </summary>
        private void Popup_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Hide();
            }
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResizeToPreview();
            Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NotificationBar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
        }

        private void goToShirtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Process.Start("http://teefury.com");
        }

        private void Popup_DoubleClick(object sender, EventArgs e)
        {
            Hide();
        }

        /// <summary>
        /// Check for a new shirt design every hour...
        /// </summary>
        private void ShirtUpdateTimer_Tick(object sender, EventArgs e)
        {
            CheckForNewShirt();
        }
    }
}
