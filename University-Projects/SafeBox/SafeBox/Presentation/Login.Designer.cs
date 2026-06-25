namespace SafeBox.Presentation
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.forgot = new CuoreUI.Controls.cuiPanel();
            this.txtLoginPass = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            this.txtLoginEmail = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            this.lblGoToRegister = new System.Windows.Forms.Label();
            this.btnSignIn = new CuoreUI.Controls.cuiButtonGroup();
            this.lblForgetPass = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.materialCard1 = new ReaLTaiizor.Controls.MaterialCard();
            this.forgot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.materialCard1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // forgot
            // 
            this.forgot.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.forgot.Controls.Add(this.txtLoginPass);
            this.forgot.Controls.Add(this.txtLoginEmail);
            this.forgot.Controls.Add(this.lblGoToRegister);
            this.forgot.Controls.Add(this.btnSignIn);
            this.forgot.Controls.Add(this.lblForgetPass);
            this.forgot.Controls.Add(this.pictureBox1);
            this.forgot.Controls.Add(this.label2);
            this.forgot.Controls.Add(this.label5);
            this.forgot.Controls.Add(this.checkBox1);
            this.forgot.Controls.Add(this.label1);
            this.forgot.Controls.Add(this.label7);
            this.forgot.Controls.Add(this.label4);
            this.forgot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.forgot.ForeColor = System.Drawing.SystemColors.ControlText;
            this.forgot.Location = new System.Drawing.Point(14, 14);
            this.forgot.Name = "forgot";
            this.forgot.OutlineThickness = 1F;
            this.forgot.PanelColor = System.Drawing.SystemColors.Window;
            this.forgot.PanelOutlineColor = System.Drawing.Color.Transparent;
            this.forgot.Rounding = new System.Windows.Forms.Padding(8);
            this.forgot.Size = new System.Drawing.Size(378, 588);
            this.forgot.TabIndex = 14;
            // 
            // txtLoginPass
            // 
            this.txtLoginPass.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLoginPass.AnimateReadOnly = false;
            this.txtLoginPass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtLoginPass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtLoginPass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtLoginPass.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtLoginPass.Depth = 0;
            this.txtLoginPass.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoginPass.HideSelection = true;
            this.txtLoginPass.Hint = "******";
            this.txtLoginPass.LeadingIcon = ((System.Drawing.Image)(resources.GetObject("txtLoginPass.LeadingIcon")));
            this.txtLoginPass.Location = new System.Drawing.Point(66, 353);
            this.txtLoginPass.MaxLength = 32767;
            this.txtLoginPass.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            this.txtLoginPass.Name = "txtLoginPass";
            this.txtLoginPass.PasswordChar = '\0';
            this.txtLoginPass.PrefixSuffixText = null;
            this.txtLoginPass.ReadOnly = false;
            this.txtLoginPass.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtLoginPass.SelectedText = "";
            this.txtLoginPass.SelectionLength = 0;
            this.txtLoginPass.SelectionStart = 0;
            this.txtLoginPass.ShortcutsEnabled = true;
            this.txtLoginPass.Size = new System.Drawing.Size(253, 48);
            this.txtLoginPass.TabIndex = 41;
            this.txtLoginPass.TabStop = false;
            this.txtLoginPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtLoginPass.TrailingIcon = null;
            this.txtLoginPass.UseSystemPasswordChar = false;
            // 
            // txtLoginEmail
            // 
            this.txtLoginEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLoginEmail.AnimateReadOnly = false;
            this.txtLoginEmail.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtLoginEmail.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtLoginEmail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtLoginEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtLoginEmail.Depth = 0;
            this.txtLoginEmail.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoginEmail.HideSelection = true;
            this.txtLoginEmail.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtLoginEmail.LeadingIcon = ((System.Drawing.Image)(resources.GetObject("txtLoginEmail.LeadingIcon")));
            this.txtLoginEmail.Location = new System.Drawing.Point(66, 269);
            this.txtLoginEmail.MaxLength = 32767;
            this.txtLoginEmail.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            this.txtLoginEmail.Name = "txtLoginEmail";
            this.txtLoginEmail.PasswordChar = '\0';
            this.txtLoginEmail.PrefixSuffixText = null;
            this.txtLoginEmail.ReadOnly = false;
            this.txtLoginEmail.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtLoginEmail.SelectedText = "";
            this.txtLoginEmail.SelectionLength = 0;
            this.txtLoginEmail.SelectionStart = 0;
            this.txtLoginEmail.ShortcutsEnabled = true;
            this.txtLoginEmail.Size = new System.Drawing.Size(253, 48);
            this.txtLoginEmail.TabIndex = 40;
            this.txtLoginEmail.TabStop = false;
            this.txtLoginEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtLoginEmail.TrailingIcon = null;
            this.txtLoginEmail.UseSystemPasswordChar = false;
            this.txtLoginEmail.Click += new System.EventHandler(this.txtLoginEmail_Click);
            // 
            // lblGoToRegister
            // 
            this.lblGoToRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGoToRegister.AutoSize = true;
            this.lblGoToRegister.BackColor = System.Drawing.Color.Transparent;
            this.lblGoToRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblGoToRegister.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGoToRegister.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblGoToRegister.Location = new System.Drawing.Point(226, 507);
            this.lblGoToRegister.Name = "lblGoToRegister";
            this.lblGoToRegister.Size = new System.Drawing.Size(99, 17);
            this.lblGoToRegister.TabIndex = 17;
            this.lblGoToRegister.Text = "Create account";
            this.lblGoToRegister.Click += new System.EventHandler(this.lblGoToRegister_Click);
            // 
            // btnSignIn
            // 
            this.btnSignIn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSignIn.Checked = false;
            this.btnSignIn.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(0)))));
            this.btnSignIn.CheckedForeColor = System.Drawing.Color.White;
            this.btnSignIn.CheckedImageTint = System.Drawing.Color.White;
            this.btnSignIn.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(0)))));
            this.btnSignIn.Content = "Sign In";
            this.btnSignIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSignIn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignIn.ForeColor = System.Drawing.Color.Black;
            this.btnSignIn.Group = 0;
            this.btnSignIn.HoverBackground = System.Drawing.Color.White;
            this.btnSignIn.HoverForeColor = System.Drawing.Color.Black;
            this.btnSignIn.HoverImageTint = System.Drawing.Color.Wheat;
            this.btnSignIn.HoverOutline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSignIn.Image = null;
            this.btnSignIn.ImageAutoCenter = true;
            this.btnSignIn.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnSignIn.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnSignIn.Location = new System.Drawing.Point(66, 446);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSignIn.NormalForeColor = System.Drawing.Color.Black;
            this.btnSignIn.NormalImageTint = System.Drawing.Color.White;
            this.btnSignIn.NormalOutline = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnSignIn.OutlineThickness = 1F;
            this.btnSignIn.PressedBackground = System.Drawing.Color.SlateGray;
            this.btnSignIn.PressedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSignIn.PressedImageTint = System.Drawing.Color.IndianRed;
            this.btnSignIn.PressedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnSignIn.Rounding = new System.Windows.Forms.Padding(8);
            this.btnSignIn.Size = new System.Drawing.Size(253, 45);
            this.btnSignIn.TabIndex = 14;
            this.btnSignIn.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnSignIn.TextOffset = new System.Drawing.Point(0, 0);
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // lblForgetPass
            // 
            this.lblForgetPass.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblForgetPass.AutoSize = true;
            this.lblForgetPass.BackColor = System.Drawing.Color.Transparent;
            this.lblForgetPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblForgetPass.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForgetPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblForgetPass.Location = new System.Drawing.Point(196, 410);
            this.lblForgetPass.Name = "lblForgetPass";
            this.lblForgetPass.Size = new System.Drawing.Size(117, 17);
            this.lblForgetPass.TabIndex = 14;
            this.lblForgetPass.Text = "Forgot Password?";
            this.lblForgetPass.Click += new System.EventHandler(this.lblForgetPass_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(151, 31);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(79, 84);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(125, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 40);
            this.label2.TabIndex = 4;
            this.label2.Text = "SafeBox";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(84, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(215, 21);
            this.label5.TabIndex = 8;
            this.label5.Text = "Secure Encrypted File Storage";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(65, 409);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(113, 21);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Remember me";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(61, 245);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Email/ Username";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(61, 329);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 21);
            this.label7.TabIndex = 10;
            this.label7.Text = "Password";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(66, 507);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Don\'t have an account?";
            // 
            // materialCard1
            // 
            this.materialCard1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.forgot);
            this.materialCard1.Depth = 0;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(11, 9);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(406, 616);
            this.materialCard1.TabIndex = 15;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(430, 631);
            this.Controls.Add(this.materialCard1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LogIn";
            this.forgot.ResumeLayout(false);
            this.forgot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.materialCard1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private CuoreUI.Controls.cuiPanel forgot;
        private System.Windows.Forms.Label lblGoToRegister;
        private CuoreUI.Controls.cuiButtonGroup btnSignIn;
        private System.Windows.Forms.Label lblForgetPass;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private ReaLTaiizor.Controls.MaterialCard materialCard1;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit txtLoginPass;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit txtLoginEmail;
    }
}

