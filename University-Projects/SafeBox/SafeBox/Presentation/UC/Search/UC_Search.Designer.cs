namespace SafeBox.Presentation.UC.Search
{
    partial class UC_Search
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;



        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Search));
            this.txtSearch = new System.Windows.Forms.Panel();
            this.materialCard2 = new ReaLTaiizor.Controls.MaterialCard();
            this.flowSearchResults = new System.Windows.Forms.FlowLayoutPanel();
            this.cuiLabel1 = new CuoreUI.Controls.cuiLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFind = new ReaLTaiizor.Controls.MaterialMaskedTextBox();
            this.txtSearch.SuspendLayout();
            this.materialCard2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSearch.Controls.Add(this.txtFind);
            this.txtSearch.Controls.Add(this.materialCard2);
            this.txtSearch.Controls.Add(this.cuiLabel1);
            this.txtSearch.Controls.Add(this.label1);
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Location = new System.Drawing.Point(0, 0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(939, 665);
            this.txtSearch.TabIndex = 0;
            // 
            // materialCard2
            // 
            this.materialCard2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard2.Controls.Add(this.flowSearchResults);
            this.materialCard2.Depth = 0;
            this.materialCard2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard2.Location = new System.Drawing.Point(18, 180);
            this.materialCard2.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard2.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.materialCard2.Name = "materialCard2";
            this.materialCard2.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard2.Size = new System.Drawing.Size(899, 471);
            this.materialCard2.TabIndex = 43;
            // 
            // flowSearchResults
            // 
            this.flowSearchResults.AutoScroll = true;
            this.flowSearchResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowSearchResults.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowSearchResults.Location = new System.Drawing.Point(14, 14);
            this.flowSearchResults.Name = "flowSearchResults";
            this.flowSearchResults.Size = new System.Drawing.Size(871, 443);
            this.flowSearchResults.TabIndex = 0;
            this.flowSearchResults.Visible = false;
            // 
            // cuiLabel1
            // 
            this.cuiLabel1.BackColor = System.Drawing.Color.Transparent;
            this.cuiLabel1.Content = "Search\\ across\\ all\\ your\\ encrypted\\ vaults";
            this.cuiLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuiLabel1.ForeColor = System.Drawing.Color.Gray;
            this.cuiLabel1.HorizontalAlignment = System.Drawing.StringAlignment.Near;
            this.cuiLabel1.Location = new System.Drawing.Point(13, 56);
            this.cuiLabel1.Name = "cuiLabel1";
            this.cuiLabel1.Size = new System.Drawing.Size(306, 25);
            this.cuiLabel1.TabIndex = 27;
            this.cuiLabel1.VerticalAlignment = System.Drawing.StringAlignment.Near;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 40);
            this.label1.TabIndex = 9;
            this.label1.Text = "Search File";
            // 
            // txtFind
            // 
            this.txtFind.AllowPromptAsInput = true;
            this.txtFind.AnimateReadOnly = false;
            this.txtFind.AsciiOnly = false;
            this.txtFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtFind.BeepOnError = false;
            this.txtFind.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.txtFind.Depth = 0;
            this.txtFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtFind.HidePromptOnLeave = false;
            this.txtFind.HideSelection = true;
            this.txtFind.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.txtFind.LeadingIcon = ((System.Drawing.Image)(resources.GetObject("txtFind.LeadingIcon")));
            this.txtFind.Location = new System.Drawing.Point(140, 98);
            this.txtFind.Mask = "";
            this.txtFind.MaxLength = 32767;
            this.txtFind.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            this.txtFind.Name = "txtFind";
            this.txtFind.PasswordChar = '\0';
            this.txtFind.PrefixSuffixText = null;
            this.txtFind.PromptChar = '_';
            this.txtFind.ReadOnly = false;
            this.txtFind.RejectInputOnFirstFailure = false;
            this.txtFind.ResetOnPrompt = true;
            this.txtFind.ResetOnSpace = true;
            this.txtFind.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFind.SelectedText = "";
            this.txtFind.SelectionLength = 0;
            this.txtFind.SelectionStart = 0;
            this.txtFind.ShortcutsEnabled = true;
            this.txtFind.Size = new System.Drawing.Size(646, 48);
            this.txtFind.SkipLiterals = true;
            this.txtFind.TabIndex = 44;
            this.txtFind.TabStop = false;
            this.txtFind.Text = "Search by filename..";
            this.txtFind.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtFind.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.txtFind.TrailingIcon = null;
            this.txtFind.UseSystemPasswordChar = false;
            this.txtFind.ValidatingType = null;
            // 
            // UC_Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtSearch);
            this.Name = "UC_Search";
            this.Size = new System.Drawing.Size(939, 665);
            this.txtSearch.ResumeLayout(false);
            this.txtSearch.PerformLayout();
            this.materialCard2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel txtSearch;
        private System.Windows.Forms.Label label1;
        private CuoreUI.Controls.cuiLabel cuiLabel1;
        private System.Windows.Forms.FlowLayoutPanel flowSearchResults;
        private ReaLTaiizor.Controls.MaterialCard materialCard2;
        private ReaLTaiizor.Controls.MaterialMaskedTextBox txtFind;
    }
}
