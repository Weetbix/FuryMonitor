namespace FuryMonitor
{
    partial class Popup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Popup));
            this.NotificationBar = new System.Windows.Forms.NotifyIcon(this.components);
            this.RightClickTrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToShirtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShirtUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.RightClickTrayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // NotificationBar
            // 
            this.NotificationBar.ContextMenuStrip = this.RightClickTrayMenu;
            this.NotificationBar.Icon = ((System.Drawing.Icon)(resources.GetObject("NotificationBar.Icon")));
            this.NotificationBar.Text = "FuryMonitor";
            this.NotificationBar.Visible = true;
            this.NotificationBar.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotificationBar_MouseDoubleClick);
            // 
            // RightClickTrayMenu
            // 
            this.RightClickTrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.goToShirtToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.RightClickTrayMenu.Name = "RightClickTrayMenu";
            this.RightClickTrayMenu.Size = new System.Drawing.Size(134, 70);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // goToShirtToolStripMenuItem
            // 
            this.goToShirtToolStripMenuItem.Name = "goToShirtToolStripMenuItem";
            this.goToShirtToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.goToShirtToolStripMenuItem.Text = "Go To Shirt";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // ShirtUpdateTimer
            // 
            this.ShirtUpdateTimer.Enabled = true;
            this.ShirtUpdateTimer.Interval = 3600000;
            this.ShirtUpdateTimer.Tag = "Every hour";
            this.ShirtUpdateTimer.Tick += new System.EventHandler(this.ShirtUpdateTimer_Tick);
            // 
            // Popup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 290);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Popup";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Popup";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Popup_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Popup_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Popup_MouseClick);
            this.MouseLeave += new System.EventHandler(this.Popup_MouseLeave);
            this.MouseHover += new System.EventHandler(this.Popup_MouseHover);
            this.RightClickTrayMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon NotificationBar;
        private System.Windows.Forms.ContextMenuStrip RightClickTrayMenu;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToShirtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Timer ShirtUpdateTimer;

    }
}

