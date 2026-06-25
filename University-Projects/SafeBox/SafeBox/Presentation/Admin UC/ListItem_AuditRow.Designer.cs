namespace SafeBox
{
    partial class ListItem_AuditRow
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.lblDetails = new CuoreUI.Controls.cuiLabel();
            this.lblActionBadge = new CuoreUI.Controls.cuiLabel();
            this.picAdmin = new System.Windows.Forms.PictureBox();
            this.lblAdminName = new CuoreUI.Controls.cuiLabel();
            this.lblID = new CuoreUI.Controls.cuiLabel();
            this.lblTime = new CuoreUI.Controls.cuiLabel();
            this.lblDate = new CuoreUI.Controls.cuiLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picAdmin)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDetails
            // 
            this.lblDetails.BackColor = System.Drawing.Color.Transparent;
            this.lblDetails.Content = "";
            this.lblDetails.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetails.ForeColor = System.Drawing.Color.Black;
            this.lblDetails.HorizontalAlignment = System.Drawing.StringAlignment.Near;
            this.lblDetails.Location = new System.Drawing.Point(211, 8);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(211, 24);
            this.lblDetails.TabIndex = 38;
            this.lblDetails.VerticalAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblActionBadge
            // 
            this.lblActionBadge.BackColor = System.Drawing.Color.Transparent;
            this.lblActionBadge.Content = "User\\ Created";
            this.lblActionBadge.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActionBadge.ForeColor = System.Drawing.Color.White;
            this.lblActionBadge.HorizontalAlignment = System.Drawing.StringAlignment.Center;
            this.lblActionBadge.Location = new System.Drawing.Point(57, 9);
            this.lblActionBadge.Name = "lblActionBadge";
            this.lblActionBadge.Size = new System.Drawing.Size(120, 44);
            this.lblActionBadge.TabIndex = 36;
            this.lblActionBadge.VerticalAlignment = System.Drawing.StringAlignment.Center;
            // 
            // picAdmin
            // 
            this.picAdmin.Location = new System.Drawing.Point(4, 9);
            this.picAdmin.Name = "picAdmin";
            this.picAdmin.Size = new System.Drawing.Size(44, 44);
            this.picAdmin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAdmin.TabIndex = 35;
            this.picAdmin.TabStop = false;
            // 
            // lblAdminName
            // 
            this.lblAdminName.BackColor = System.Drawing.Color.Transparent;
            this.lblAdminName.Content = "";
            this.lblAdminName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblAdminName.HorizontalAlignment = System.Drawing.StringAlignment.Center;
            this.lblAdminName.Location = new System.Drawing.Point(454, 16);
            this.lblAdminName.Name = "lblAdminName";
            this.lblAdminName.Size = new System.Drawing.Size(120, 29);
            this.lblAdminName.TabIndex = 40;
            this.lblAdminName.VerticalAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblID
            // 
            this.lblID.BackColor = System.Drawing.Color.Transparent;
            this.lblID.Content = "";
            this.lblID.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.Color.DimGray;
            this.lblID.HorizontalAlignment = System.Drawing.StringAlignment.Near;
            this.lblID.Location = new System.Drawing.Point(211, 32);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(150, 18);
            this.lblID.TabIndex = 42;
            this.lblID.VerticalAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblTime
            // 
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Content = "";
            this.lblTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.DimGray;
            this.lblTime.HorizontalAlignment = System.Drawing.StringAlignment.Near;
            this.lblTime.Location = new System.Drawing.Point(659, 30);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(80, 22);
            this.lblTime.TabIndex = 43;
            this.lblTime.VerticalAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Content = "";
            this.lblDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDate.HorizontalAlignment = System.Drawing.StringAlignment.Near;
            this.lblDate.Location = new System.Drawing.Point(659, 8);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(80, 24);
            this.lblDate.TabIndex = 44;
            this.lblDate.VerticalAlignment = System.Drawing.StringAlignment.Center;
            // 
            // ListItem_AuditRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblAdminName);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.lblActionBadge);
            this.Controls.Add(this.picAdmin);
            this.Name = "ListItem_AuditRow";
            this.Size = new System.Drawing.Size(742, 60);
            ((System.ComponentModel.ISupportInitialize)(this.picAdmin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private CuoreUI.Controls.cuiLabel lblDetails;
        private CuoreUI.Controls.cuiLabel lblActionBadge;
        private System.Windows.Forms.PictureBox picAdmin;
        private CuoreUI.Controls.cuiLabel lblAdminName;
        private CuoreUI.Controls.cuiLabel lblID;
        private CuoreUI.Controls.cuiLabel lblTime;
        private CuoreUI.Controls.cuiLabel lblDate;
    }
}
