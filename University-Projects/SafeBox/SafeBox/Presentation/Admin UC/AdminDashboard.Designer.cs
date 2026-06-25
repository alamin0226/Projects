namespace SafeBox
{
    partial class AdminDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDashboard));
            this.panelContainer = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cuiPanelGradient1 = new CuoreUI.Controls.cuiPanelGradient();
            this.btnLogout = new CuoreUI.Controls.cuiButton();
            this.Admin = new CuoreUI.Controls.cuiButton();
            this.ActivityLog = new CuoreUI.Controls.cuiButton();
            this.vaults = new CuoreUI.Controls.cuiButton();
            this.btnDashboard = new CuoreUI.Controls.cuiButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cuiPanelGradient1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.panelContainer.Location = new System.Drawing.Point(200, -1);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(939, 665);
            this.panelContainer.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(64, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 40);
            this.label2.TabIndex = 6;
            this.label2.Text = "SafeBox";
            // 
            // cuiPanelGradient1
            // 
            this.cuiPanelGradient1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cuiPanelGradient1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
            this.cuiPanelGradient1.Controls.Add(this.btnLogout);
            this.cuiPanelGradient1.Controls.Add(this.Admin);
            this.cuiPanelGradient1.Controls.Add(this.ActivityLog);
            this.cuiPanelGradient1.Controls.Add(this.vaults);
            this.cuiPanelGradient1.Controls.Add(this.btnDashboard);
            this.cuiPanelGradient1.Controls.Add(this.pictureBox1);
            this.cuiPanelGradient1.Controls.Add(this.label2);
            this.cuiPanelGradient1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
            this.cuiPanelGradient1.GradientAngle = 0F;
            this.cuiPanelGradient1.Location = new System.Drawing.Point(0, -1);
            this.cuiPanelGradient1.Name = "cuiPanelGradient1";
            this.cuiPanelGradient1.OutlineThickness = 1F;
            this.cuiPanelGradient1.PanelColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
            this.cuiPanelGradient1.PanelColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
            this.cuiPanelGradient1.PanelOutlineColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
            this.cuiPanelGradient1.PanelOutlineColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
            this.cuiPanelGradient1.Rounding = new System.Windows.Forms.Padding(8);
            this.cuiPanelGradient1.Size = new System.Drawing.Size(200, 662);
            this.cuiPanelGradient1.TabIndex = 9;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.Transparent;
            this.btnLogout.CheckButton = false;
            this.btnLogout.Checked = false;
            this.btnLogout.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(0)))));
            this.btnLogout.CheckedForeColor = System.Drawing.Color.White;
            this.btnLogout.CheckedImageTint = System.Drawing.Color.White;
            this.btnLogout.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(0)))));
            this.btnLogout.Content = "  Log out";
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.HoverBackground = System.Drawing.Color.White;
            this.btnLogout.HoverForeColor = System.Drawing.Color.Black;
            this.btnLogout.HoverImageTint = System.Drawing.Color.Black;
            this.btnLogout.HoverOutline = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageAutoCenter = true;
            this.btnLogout.ImageExpand = new System.Drawing.Point(1, 1);
            this.btnLogout.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnLogout.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLogout.Location = new System.Drawing.Point(0, 593);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
            this.btnLogout.NormalForeColor = System.Drawing.Color.White;
            this.btnLogout.NormalImageTint = System.Drawing.Color.White;
            this.btnLogout.NormalOutline = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
            this.btnLogout.OutlineThickness = 1F;
            this.btnLogout.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnLogout.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.btnLogout.PressedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnLogout.PressedImageTint = System.Drawing.Color.WhiteSmoke;
            this.btnLogout.PressedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnLogout.Rounding = new System.Windows.Forms.Padding(3);
            this.btnLogout.Size = new System.Drawing.Size(200, 68);
            this.btnLogout.TabIndex = 13;
            this.btnLogout.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnLogout.TextOffset = new System.Drawing.Point(-3, 0);
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // Admin
            // 
            this.Admin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Admin.BackColor = System.Drawing.Color.Transparent;
            this.Admin.CheckButton = false;
            this.Admin.Checked = false;
            this.Admin.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(0)))));
            this.Admin.CheckedForeColor = System.Drawing.Color.White;
            this.Admin.CheckedImageTint = System.Drawing.Color.White;
            this.Admin.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(0)))));
            this.Admin.Content = "Admin";
            this.Admin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Admin.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Admin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Admin.ForeColor = System.Drawing.Color.White;
            this.Admin.HoverBackground = System.Drawing.Color.White;
            this.Admin.HoverForeColor = System.Drawing.Color.Black;
            this.Admin.HoverImageTint = System.Drawing.Color.Black;
            this.Admin.HoverOutline = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Admin.Image = ((System.Drawing.Image)(resources.GetObject("Admin.Image")));
            this.Admin.ImageAutoCenter = true;
            this.Admin.ImageExpand = new System.Drawing.Point(4, 4);
            this.Admin.ImageOffset = new System.Drawing.Point(-8, 0);
            this.Admin.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Admin.Location = new System.Drawing.Point(0, 530);
            this.Admin.Name = "Admin";
            this.Admin.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
            this.Admin.NormalForeColor = System.Drawing.Color.White;
            this.Admin.NormalImageTint = System.Drawing.Color.White;
            this.Admin.NormalOutline = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
            this.Admin.OutlineThickness = 1F;
            this.Admin.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.Admin.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(111)))), ((int)(((byte)(21)))));
            this.Admin.PressedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Admin.PressedImageTint = System.Drawing.Color.WhiteSmoke;
            this.Admin.PressedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Admin.Rounding = new System.Windows.Forms.Padding(3);
            this.Admin.Size = new System.Drawing.Size(200, 63);
            this.Admin.TabIndex = 12;
            this.Admin.TextAlignment = System.Drawing.StringAlignment.Center;
            this.Admin.TextOffset = new System.Drawing.Point(0, 0);
            this.Admin.Click += new System.EventHandler(this.Admin_Click);
            // 
            // ActivityLog
            // 
            this.ActivityLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ActivityLog.BackColor = System.Drawing.Color.Transparent;
            this.ActivityLog.CheckButton = false;
            this.ActivityLog.Checked = false;
            this.ActivityLog.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(0)))));
            this.ActivityLog.CheckedForeColor = System.Drawing.Color.White;
            this.ActivityLog.CheckedImageTint = System.Drawing.Color.White;
            this.ActivityLog.CheckedOutline = System.Drawing.Color.White;
            this.ActivityLog.Content = "  Audit Log";
            this.ActivityLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ActivityLog.DialogResult = System.Windows.Forms.DialogResult.None;
            this.ActivityLog.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActivityLog.ForeColor = System.Drawing.Color.White;
            this.ActivityLog.HoverBackground = System.Drawing.Color.White;
            this.ActivityLog.HoverForeColor = System.Drawing.Color.Black;
            this.ActivityLog.HoverImageTint = System.Drawing.Color.Black;
            this.ActivityLog.HoverOutline = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ActivityLog.Image = ((System.Drawing.Image)(resources.GetObject("ActivityLog.Image")));
            this.ActivityLog.ImageAutoCenter = true;
            this.ActivityLog.ImageExpand = new System.Drawing.Point(3, 3);
            this.ActivityLog.ImageOffset = new System.Drawing.Point(10, 0);
            this.ActivityLog.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ActivityLog.Location = new System.Drawing.Point(0, 306);
            this.ActivityLog.Name = "ActivityLog";
            this.ActivityLog.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
            this.ActivityLog.NormalForeColor = System.Drawing.Color.White;
            this.ActivityLog.NormalImageTint = System.Drawing.Color.White;
            this.ActivityLog.NormalOutline = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
            this.ActivityLog.OutlineThickness = 1F;
            this.ActivityLog.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.ActivityLog.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(111)))), ((int)(((byte)(21)))));
            this.ActivityLog.PressedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ActivityLog.PressedImageTint = System.Drawing.Color.WhiteSmoke;
            this.ActivityLog.PressedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ActivityLog.Rounding = new System.Windows.Forms.Padding(3);
            this.ActivityLog.Size = new System.Drawing.Size(200, 55);
            this.ActivityLog.TabIndex = 11;
            this.ActivityLog.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ActivityLog.TextOffset = new System.Drawing.Point(10, 0);
            this.ActivityLog.Click += new System.EventHandler(this.btnActivityLog_Click);
            // 
            // vaults
            // 
            this.vaults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vaults.BackColor = System.Drawing.Color.Transparent;
            this.vaults.CheckButton = false;
            this.vaults.Checked = false;
            this.vaults.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(0)))));
            this.vaults.CheckedForeColor = System.Drawing.Color.White;
            this.vaults.CheckedImageTint = System.Drawing.Color.White;
            this.vaults.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(0)))));
            this.vaults.Content = "User Management";
            this.vaults.Cursor = System.Windows.Forms.Cursors.Hand;
            this.vaults.DialogResult = System.Windows.Forms.DialogResult.None;
            this.vaults.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vaults.ForeColor = System.Drawing.Color.White;
            this.vaults.HoverBackground = System.Drawing.Color.White;
            this.vaults.HoverForeColor = System.Drawing.Color.Black;
            this.vaults.HoverImageTint = System.Drawing.Color.Black;
            this.vaults.HoverOutline = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.vaults.Image = ((System.Drawing.Image)(resources.GetObject("vaults.Image")));
            this.vaults.ImageAutoCenter = true;
            this.vaults.ImageExpand = new System.Drawing.Point(2, 2);
            this.vaults.ImageOffset = new System.Drawing.Point(-5, 0);
            this.vaults.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.vaults.Location = new System.Drawing.Point(0, 246);
            this.vaults.Name = "vaults";
            this.vaults.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
            this.vaults.NormalForeColor = System.Drawing.Color.White;
            this.vaults.NormalImageTint = System.Drawing.Color.White;
            this.vaults.NormalOutline = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
            this.vaults.OutlineThickness = 1F;
            this.vaults.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.vaults.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(111)))), ((int)(((byte)(21)))));
            this.vaults.PressedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.vaults.PressedImageTint = System.Drawing.Color.WhiteSmoke;
            this.vaults.PressedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.vaults.Rounding = new System.Windows.Forms.Padding(3);
            this.vaults.Size = new System.Drawing.Size(200, 58);
            this.vaults.TabIndex = 8;
            this.vaults.TextAlignment = System.Drawing.StringAlignment.Center;
            this.vaults.TextOffset = new System.Drawing.Point(0, 0);
            this.vaults.Click += new System.EventHandler(this.btnUserManagement_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDashboard.BackColor = System.Drawing.Color.Transparent;
            this.btnDashboard.CheckButton = false;
            this.btnDashboard.Checked = false;
            this.btnDashboard.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(0)))));
            this.btnDashboard.CheckedForeColor = System.Drawing.Color.White;
            this.btnDashboard.CheckedImageTint = System.Drawing.Color.White;
            this.btnDashboard.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(0)))));
            this.btnDashboard.Content = "  DashBoard";
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.HoverBackground = System.Drawing.Color.White;
            this.btnDashboard.HoverForeColor = System.Drawing.Color.Black;
            this.btnDashboard.HoverImageTint = System.Drawing.Color.Black;
            this.btnDashboard.HoverOutline = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDashboard.Image = ((System.Drawing.Image)(resources.GetObject("btnDashboard.Image")));
            this.btnDashboard.ImageAutoCenter = true;
            this.btnDashboard.ImageExpand = new System.Drawing.Point(1, 2);
            this.btnDashboard.ImageOffset = new System.Drawing.Point(12, 0);
            this.btnDashboard.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.btnDashboard.Location = new System.Drawing.Point(0, 184);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
            this.btnDashboard.NormalForeColor = System.Drawing.Color.White;
            this.btnDashboard.NormalImageTint = System.Drawing.Color.White;
            this.btnDashboard.NormalOutline = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
            this.btnDashboard.OutlineThickness = 1F;
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnDashboard.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(111)))), ((int)(((byte)(21)))));
            this.btnDashboard.PressedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnDashboard.PressedImageTint = System.Drawing.Color.WhiteSmoke;
            this.btnDashboard.PressedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDashboard.Rounding = new System.Windows.Forms.Padding(1);
            this.btnDashboard.Size = new System.Drawing.Size(200, 60);
            this.btnDashboard.TabIndex = 7;
            this.btnDashboard.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnDashboard.TextOffset = new System.Drawing.Point(10, 0);
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 56);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(1139, 662);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.cuiPanelGradient1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminDashboard";
            this.cuiPanelGradient1.ResumeLayout(false);
            this.cuiPanelGradient1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Label label2;
        private CuoreUI.Controls.cuiPanelGradient cuiPanelGradient1;
        private CuoreUI.Controls.cuiButton btnLogout;
        private CuoreUI.Controls.cuiButton Admin;
        private CuoreUI.Controls.cuiButton ActivityLog;
        private CuoreUI.Controls.cuiButton vaults;
        private CuoreUI.Controls.cuiButton btnDashboard;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}