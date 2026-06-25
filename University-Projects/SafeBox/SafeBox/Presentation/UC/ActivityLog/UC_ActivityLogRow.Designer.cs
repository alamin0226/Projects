namespace SafeBox.Presentation.UC.ActivityLog
{
    partial class UC_ActivityLogRow
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
            this.lblDetails = new CuoreUI.Controls.cuiLabel();
            this.lblTimestamp = new CuoreUI.Controls.cuiLabel();
            this.lblAction = new CuoreUI.Controls.cuiLabel();
            this.SuspendLayout();
            // 
            // lblDetails
            // 
            this.lblDetails.Content = "";
            this.lblDetails.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetails.HorizontalAlignment = System.Drawing.StringAlignment.Center;
            this.lblDetails.Location = new System.Drawing.Point(293, 3);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(268, 83);
            this.lblDetails.TabIndex = 2;
            this.lblDetails.VerticalAlignment = System.Drawing.StringAlignment.Center;
            this.lblDetails.Load += new System.EventHandler(this.lblDetails_Load);
            // 
            // lblTimestamp
            // 
            this.lblTimestamp.Content = "";
            this.lblTimestamp.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimestamp.HorizontalAlignment = System.Drawing.StringAlignment.Near;
            this.lblTimestamp.Location = new System.Drawing.Point(596, 3);
            this.lblTimestamp.Name = "lblTimestamp";
            this.lblTimestamp.Size = new System.Drawing.Size(190, 83);
            this.lblTimestamp.TabIndex = 3;
            this.lblTimestamp.VerticalAlignment = System.Drawing.StringAlignment.Center;
            this.lblTimestamp.Load += new System.EventHandler(this.lblTimestamp_Load);
            // 
            // lblAction
            // 
            this.lblAction.Content = "";
            this.lblAction.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAction.HorizontalAlignment = System.Drawing.StringAlignment.Center;
            this.lblAction.Location = new System.Drawing.Point(3, 3);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(290, 83);
            this.lblAction.TabIndex = 1;
            this.lblAction.VerticalAlignment = System.Drawing.StringAlignment.Center;
            this.lblAction.Load += new System.EventHandler(this.lblAction_Load);
            // 
            // UC_ActivityLogRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTimestamp);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.lblAction);
            this.Name = "UC_ActivityLogRow";
            this.Size = new System.Drawing.Size(786, 89);
            this.ResumeLayout(false);

        }

        #endregion
        private CuoreUI.Controls.cuiLabel lblDetails;
        private CuoreUI.Controls.cuiLabel lblTimestamp;
        private CuoreUI.Controls.cuiLabel lblAction;
    }
}
