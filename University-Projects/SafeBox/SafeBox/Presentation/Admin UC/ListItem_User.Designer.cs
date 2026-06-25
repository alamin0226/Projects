namespace SafeBox
{
    partial class ListItem_User
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListItem_User));
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.lblName = new CuoreUI.Controls.cuiLabel();
            this.lblEmail = new CuoreUI.Controls.cuiLabel();
            this.lblStatus = new CuoreUI.Controls.cuiLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // picAvatar
            // 
            this.picAvatar.InitialImage = ((System.Drawing.Image)(resources.GetObject("picAvatar.InitialImage")));
            this.picAvatar.Location = new System.Drawing.Point(3, 9);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(40, 40);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatar.TabIndex = 0;
            this.picAvatar.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.Content = "";
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.HorizontalAlignment = System.Drawing.StringAlignment.Near;
            this.lblName.Location = new System.Drawing.Point(70, 10);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(181, 26);
            this.lblName.TabIndex = 1;
            this.lblName.VerticalAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblEmail
            // 
            this.lblEmail.Content = "";
            this.lblEmail.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.HorizontalAlignment = System.Drawing.StringAlignment.Near;
            this.lblEmail.Location = new System.Drawing.Point(70, 42);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(181, 15);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.VerticalAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblStatus
            // 
            this.lblStatus.Content = "ACTIVE";
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.DarkKhaki;
            this.lblStatus.HorizontalAlignment = System.Drawing.StringAlignment.Near;
            this.lblStatus.Location = new System.Drawing.Point(309, 17);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(85, 26);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.VerticalAlignment = System.Drawing.StringAlignment.Center;
            // 
            // ListItem_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picAvatar);
            this.Name = "ListItem_User";
            this.Size = new System.Drawing.Size(402, 60);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picAvatar;
        private CuoreUI.Controls.cuiLabel lblName;
        private CuoreUI.Controls.cuiLabel lblEmail;
        private CuoreUI.Controls.cuiLabel lblStatus;
    }
}
