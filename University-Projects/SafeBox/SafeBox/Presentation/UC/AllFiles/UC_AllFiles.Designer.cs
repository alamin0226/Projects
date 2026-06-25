namespace SafeBox.Presentation.UC.AllFiles
{
    partial class UC_AllFiles
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
            this.cuiPanel1 = new CuoreUI.Controls.cuiPanel();
            this.lblSize = new CuoreUI.Controls.cuiLabel();
            this.lblTotalFiles = new CuoreUI.Controls.cuiLabel();
            this.cuiLabel1 = new CuoreUI.Controls.cuiLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.flowFilesList = new System.Windows.Forms.FlowLayoutPanel();
            this.materialCard1 = new ReaLTaiizor.Controls.MaterialCard();
            this.materialCard2 = new ReaLTaiizor.Controls.MaterialCard();
            this.materialCard3 = new ReaLTaiizor.Controls.MaterialCard();
            this.cuiLabel7 = new CuoreUI.Controls.cuiLabel();
            this.cuiLabel6 = new CuoreUI.Controls.cuiLabel();
            this.cuiLabel5 = new CuoreUI.Controls.cuiLabel();
            this.cuiLabel4 = new CuoreUI.Controls.cuiLabel();
            this.cuiLabel2 = new CuoreUI.Controls.cuiLabel();
            this.cuiControlAnimator1 = new CuoreUI.Components.cuiControlAnimator();
            this.cuiPanel1.SuspendLayout();
            this.materialCard1.SuspendLayout();
            this.materialCard2.SuspendLayout();
            this.materialCard3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cuiPanel1
            // 
            this.cuiPanel1.Controls.Add(this.lblSize);
            this.cuiPanel1.Controls.Add(this.lblTotalFiles);
            this.cuiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cuiPanel1.Location = new System.Drawing.Point(14, 14);
            this.cuiPanel1.Name = "cuiPanel1";
            this.cuiPanel1.OutlineThickness = 1F;
            this.cuiPanel1.PanelColor = System.Drawing.Color.White;
            this.cuiPanel1.PanelOutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.cuiPanel1.Rounding = new System.Windows.Forms.Padding(8);
            this.cuiPanel1.Size = new System.Drawing.Size(851, 55);
            this.cuiPanel1.TabIndex = 0;
            // 
            // lblSize
            // 
            this.lblSize.Content = "Size\\ \\ MB";
            this.lblSize.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize.HorizontalAlignment = System.Drawing.StringAlignment.Center;
            this.lblSize.Location = new System.Drawing.Point(147, 3);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(146, 49);
            this.lblSize.TabIndex = 7;
            this.lblSize.VerticalAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblTotalFiles
            // 
            this.lblTotalFiles.Content = "Total\\ files";
            this.lblTotalFiles.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFiles.HorizontalAlignment = System.Drawing.StringAlignment.Center;
            this.lblTotalFiles.Location = new System.Drawing.Point(17, 3);
            this.lblTotalFiles.Name = "lblTotalFiles";
            this.lblTotalFiles.Size = new System.Drawing.Size(106, 49);
            this.lblTotalFiles.TabIndex = 6;
            this.lblTotalFiles.VerticalAlignment = System.Drawing.StringAlignment.Center;
            // 
            // cuiLabel1
            // 
            this.cuiLabel1.BackColor = System.Drawing.Color.Transparent;
            this.cuiLabel1.Content = "View\\ and\\ manage\\ all\\ your\\ encrypted\\ files";
            this.cuiLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuiLabel1.ForeColor = System.Drawing.Color.Gray;
            this.cuiLabel1.HorizontalAlignment = System.Drawing.StringAlignment.Near;
            this.cuiLabel1.Location = new System.Drawing.Point(22, 53);
            this.cuiLabel1.Name = "cuiLabel1";
            this.cuiLabel1.Size = new System.Drawing.Size(306, 25);
            this.cuiLabel1.TabIndex = 24;
            this.cuiLabel1.VerticalAlignment = System.Drawing.StringAlignment.Near;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(15, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 40);
            this.label1.TabIndex = 25;
            this.label1.Text = "All Files";
            // 
            // flowFilesList
            // 
            this.flowFilesList.AutoScroll = true;
            this.flowFilesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowFilesList.Location = new System.Drawing.Point(14, 14);
            this.flowFilesList.Name = "flowFilesList";
            this.flowFilesList.Size = new System.Drawing.Size(851, 351);
            this.flowFilesList.TabIndex = 32;
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.flowFilesList);
            this.materialCard1.Depth = 0;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(33, 272);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(879, 379);
            this.materialCard1.TabIndex = 33;
            // 
            // materialCard2
            // 
            this.materialCard2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard2.Controls.Add(this.cuiPanel1);
            this.materialCard2.Depth = 0;
            this.materialCard2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard2.Location = new System.Drawing.Point(33, 89);
            this.materialCard2.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard2.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.materialCard2.Name = "materialCard2";
            this.materialCard2.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard2.Size = new System.Drawing.Size(879, 83);
            this.materialCard2.TabIndex = 34;
            // 
            // materialCard3
            // 
            this.materialCard3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard3.Controls.Add(this.cuiLabel7);
            this.materialCard3.Controls.Add(this.cuiLabel6);
            this.materialCard3.Controls.Add(this.cuiLabel5);
            this.materialCard3.Controls.Add(this.cuiLabel4);
            this.materialCard3.Controls.Add(this.cuiLabel2);
            this.materialCard3.Depth = 0;
            this.materialCard3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard3.Location = new System.Drawing.Point(33, 200);
            this.materialCard3.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard3.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.materialCard3.Name = "materialCard3";
            this.materialCard3.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard3.Size = new System.Drawing.Size(879, 61);
            this.materialCard3.TabIndex = 35;
            // 
            // cuiLabel7
            // 
            this.cuiLabel7.Content = "Actions";
            this.cuiLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuiLabel7.HorizontalAlignment = System.Drawing.StringAlignment.Near;
            this.cuiLabel7.Location = new System.Drawing.Point(766, 17);
            this.cuiLabel7.Name = "cuiLabel7";
            this.cuiLabel7.Size = new System.Drawing.Size(58, 27);
            this.cuiLabel7.TabIndex = 5;
            this.cuiLabel7.VerticalAlignment = System.Drawing.StringAlignment.Center;
            // 
            // cuiLabel6
            // 
            this.cuiLabel6.Content = "Vault";
            this.cuiLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuiLabel6.HorizontalAlignment = System.Drawing.StringAlignment.Center;
            this.cuiLabel6.Location = new System.Drawing.Point(329, 17);
            this.cuiLabel6.Name = "cuiLabel6";
            this.cuiLabel6.Size = new System.Drawing.Size(106, 27);
            this.cuiLabel6.TabIndex = 4;
            this.cuiLabel6.VerticalAlignment = System.Drawing.StringAlignment.Center;
            // 
            // cuiLabel5
            // 
            this.cuiLabel5.Content = "Uploaded";
            this.cuiLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuiLabel5.HorizontalAlignment = System.Drawing.StringAlignment.Center;
            this.cuiLabel5.Location = new System.Drawing.Point(587, 17);
            this.cuiLabel5.Name = "cuiLabel5";
            this.cuiLabel5.Size = new System.Drawing.Size(95, 27);
            this.cuiLabel5.TabIndex = 3;
            this.cuiLabel5.VerticalAlignment = System.Drawing.StringAlignment.Center;
            // 
            // cuiLabel4
            // 
            this.cuiLabel4.Content = "Size";
            this.cuiLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuiLabel4.HorizontalAlignment = System.Drawing.StringAlignment.Center;
            this.cuiLabel4.Location = new System.Drawing.Point(475, 17);
            this.cuiLabel4.Name = "cuiLabel4";
            this.cuiLabel4.Size = new System.Drawing.Size(73, 27);
            this.cuiLabel4.TabIndex = 2;
            this.cuiLabel4.VerticalAlignment = System.Drawing.StringAlignment.Center;
            // 
            // cuiLabel2
            // 
            this.cuiLabel2.Content = "File\\ Name";
            this.cuiLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuiLabel2.HorizontalAlignment = System.Drawing.StringAlignment.Center;
            this.cuiLabel2.Location = new System.Drawing.Point(17, 17);
            this.cuiLabel2.Name = "cuiLabel2";
            this.cuiLabel2.Size = new System.Drawing.Size(106, 27);
            this.cuiLabel2.TabIndex = 0;
            this.cuiLabel2.VerticalAlignment = System.Drawing.StringAlignment.Center;
            // 
            // cuiControlAnimator1
            // 
            this.cuiControlAnimator1.AnimateLocation = true;
            this.cuiControlAnimator1.AnimateOnStart = true;
            this.cuiControlAnimator1.AnimateOpacity = false;
            this.cuiControlAnimator1.Duration = 1000;
            this.cuiControlAnimator1.EasingType = CuoreUI.Helpers.DrawingHelper.EasingTypes.QuadInOut;
            this.cuiControlAnimator1.TargetControl = null;
            this.cuiControlAnimator1.TargetLocation = new System.Drawing.Point(0, 0);
            this.cuiControlAnimator1.TargetOpacity = CuoreUI.Components.cuiControlAnimator.OpacityEnum.Visible;
            // 
            // UC_AllFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.materialCard3);
            this.Controls.Add(this.materialCard2);
            this.Controls.Add(this.materialCard1);
            this.Controls.Add(this.cuiLabel1);
            this.Controls.Add(this.label1);
            this.Name = "UC_AllFiles";
            this.Size = new System.Drawing.Size(939, 665);
            this.cuiPanel1.ResumeLayout(false);
            this.materialCard1.ResumeLayout(false);
            this.materialCard2.ResumeLayout(false);
            this.materialCard3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CuoreUI.Controls.cuiPanel cuiPanel1;
        private CuoreUI.Controls.cuiLabel cuiLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowFilesList;
        private ReaLTaiizor.Controls.MaterialCard materialCard1;
        private ReaLTaiizor.Controls.MaterialCard materialCard2;
        private ReaLTaiizor.Controls.MaterialCard materialCard3;
        private CuoreUI.Controls.cuiLabel cuiLabel7;
        private CuoreUI.Controls.cuiLabel cuiLabel6;
        private CuoreUI.Controls.cuiLabel cuiLabel5;
        private CuoreUI.Controls.cuiLabel cuiLabel4;
        private CuoreUI.Controls.cuiLabel cuiLabel2;
        private CuoreUI.Controls.cuiLabel lblSize;
        private CuoreUI.Controls.cuiLabel lblTotalFiles;
        private CuoreUI.Components.cuiControlAnimator cuiControlAnimator1;
    }
}
