namespace SafeBox.Presentation.UC.Vault
{
    partial class UC_VaultRow
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_VaultRow));
            this.cuiPanelDOCS1 = new CuoreUI.Controls.cuiPanel();
            this.lblVaultName = new CuoreUI.Controls.cuiLabel();
            this.lblDetails = new CuoreUI.Controls.cuiLabel();
            this.cuiPictureBox1 = new CuoreUI.Controls.cuiPictureBox();
            this.cuiPanelDOCS1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cuiPanelDOCS1
            // 
            this.cuiPanelDOCS1.BackColor = System.Drawing.Color.Transparent;
            this.cuiPanelDOCS1.Controls.Add(this.lblVaultName);
            this.cuiPanelDOCS1.Controls.Add(this.cuiPictureBox1);
            this.cuiPanelDOCS1.Controls.Add(this.lblDetails);
            this.cuiPanelDOCS1.Location = new System.Drawing.Point(3, 3);
            this.cuiPanelDOCS1.Name = "cuiPanelDOCS1";
            this.cuiPanelDOCS1.OutlineThickness = 1F;
            this.cuiPanelDOCS1.PanelColor = System.Drawing.Color.White;
            this.cuiPanelDOCS1.PanelOutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.cuiPanelDOCS1.Rounding = new System.Windows.Forms.Padding(8);
            this.cuiPanelDOCS1.Size = new System.Drawing.Size(190, 45);
            this.cuiPanelDOCS1.TabIndex = 39;
            // 
            // lblVaultName
            // 
            this.lblVaultName.BackColor = System.Drawing.Color.Transparent;
            this.lblVaultName.Content = "Personal\\ Documents";
            this.lblVaultName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVaultName.HorizontalAlignment = System.Drawing.StringAlignment.Near;
            this.lblVaultName.Location = new System.Drawing.Point(55, 3);
            this.lblVaultName.Name = "lblVaultName";
            this.lblVaultName.Size = new System.Drawing.Size(120, 16);
            this.lblVaultName.TabIndex = 40;
            this.lblVaultName.VerticalAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblDetails
            // 
            this.lblDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDetails.BackColor = System.Drawing.Color.Transparent;
            this.lblDetails.Content = "125\\ files\\.\\ \\ \\ \\ 4\\.5MB";
            this.lblDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetails.HorizontalAlignment = System.Drawing.StringAlignment.Near;
            this.lblDetails.Location = new System.Drawing.Point(55, 19);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(120, 16);
            this.lblDetails.TabIndex = 42;
            this.lblDetails.VerticalAlignment = System.Drawing.StringAlignment.Near;
            // 
            // cuiPictureBox1
            // 
            this.cuiPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.cuiPictureBox1.Content = ((System.Drawing.Image)(resources.GetObject("cuiPictureBox1.Content")));
            this.cuiPictureBox1.ImageTint = System.Drawing.Color.White;
            this.cuiPictureBox1.Location = new System.Drawing.Point(7, 3);
            this.cuiPictureBox1.Name = "cuiPictureBox1";
            this.cuiPictureBox1.OutlineThickness = 1F;
            this.cuiPictureBox1.PanelOutlineColor = System.Drawing.Color.Empty;
            this.cuiPictureBox1.Rotation = 0;
            this.cuiPictureBox1.Rounding = new System.Windows.Forms.Padding(8);
            this.cuiPictureBox1.Size = new System.Drawing.Size(33, 32);
            this.cuiPictureBox1.TabIndex = 41;
            // 
            // UC_VaultRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cuiPanelDOCS1);
            this.Name = "UC_VaultRow";
            this.Size = new System.Drawing.Size(195, 50);
            this.cuiPanelDOCS1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private CuoreUI.Controls.cuiPanel cuiPanelDOCS1;
        private CuoreUI.Controls.cuiLabel lblVaultName;
        private CuoreUI.Controls.cuiPictureBox cuiPictureBox1;
        private CuoreUI.Controls.cuiLabel lblDetails;
    }
}
