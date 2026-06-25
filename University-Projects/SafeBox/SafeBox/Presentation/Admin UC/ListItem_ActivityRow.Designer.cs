namespace SafeBox
{
    partial class ListItem_ActivityRow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListItem_ActivityRow));
            this.lblDesc = new CuoreUI.Controls.cuiLabel();
            this.lblTitle = new CuoreUI.Controls.cuiLabel();
            this.pnlDot = new System.Windows.Forms.PictureBox();
            this.lblTime = new CuoreUI.Controls.cuiLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDot)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDesc
            // 
            this.lblDesc.Content = "";
            this.lblDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.HorizontalAlignment = System.Drawing.StringAlignment.Near;
            this.lblDesc.Location = new System.Drawing.Point(73, 39);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(265, 15);
            this.lblDesc.TabIndex = 6;
            this.lblDesc.VerticalAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblTitle
            // 
            this.lblTitle.Content = "";
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.HorizontalAlignment = System.Drawing.StringAlignment.Near;
            this.lblTitle.Location = new System.Drawing.Point(73, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(265, 26);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.VerticalAlignment = System.Drawing.StringAlignment.Center;
            // 
            // pnlDot
            // 
            this.pnlDot.Image = ((System.Drawing.Image)(resources.GetObject("pnlDot.Image")));
            this.pnlDot.InitialImage = ((System.Drawing.Image)(resources.GetObject("pnlDot.InitialImage")));
            this.pnlDot.Location = new System.Drawing.Point(14, 25);
            this.pnlDot.Name = "pnlDot";
            this.pnlDot.Size = new System.Drawing.Size(28, 29);
            this.pnlDot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pnlDot.TabIndex = 4;
            this.pnlDot.TabStop = false;
            // 
            // lblTime
            // 
            this.lblTime.Content = "";
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.HorizontalAlignment = System.Drawing.StringAlignment.Near;
            this.lblTime.Location = new System.Drawing.Point(73, 60);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(265, 15);
            this.lblTime.TabIndex = 7;
            this.lblTime.VerticalAlignment = System.Drawing.StringAlignment.Center;
            // 
            // ListItem_ActivityRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pnlDot);
            this.Name = "ListItem_ActivityRow";
            this.Size = new System.Drawing.Size(402, 83);
            ((System.ComponentModel.ISupportInitialize)(this.pnlDot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private CuoreUI.Controls.cuiLabel lblDesc;
        private CuoreUI.Controls.cuiLabel lblTitle;
        private System.Windows.Forms.PictureBox pnlDot;
        private CuoreUI.Controls.cuiLabel lblTime;
    }
}
