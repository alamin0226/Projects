using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SafeBox
{
    public partial class ListItem_UserRow : UserControl
    {
        // Events
        // Events
        public event Action<int> UserActivated; // userId
        public event Action<int> UserDeactivated; // userId

        private static readonly Random r = new Random();
        private int _userId;
        private string _status;

        public ListItem_UserRow()
        {
            InitializeComponent();
            // Delete/Deactivate button
            btnDelet.Click += (s, e) => {
                if(MessageBox.Show("Are you sure you want to deactivate this user?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    UserDeactivated?.Invoke(_userId);
            };
            
            // Activate/Restore button
            btnReset.Click += (s, e) => {
                 if(MessageBox.Show("Are you sure you want to restore this user?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    UserActivated?.Invoke(_userId);
            };
        }

        // ডাটা রিসিভ করার ফাংশন
        public void SetData(string initial, string name, string email, string role, string status, string lastLogin, string created, int userId = 0)
        {
            _userId = userId;
            _status = status;

            lblName.Text = name;
            lblName.Content = name;
            
            lblEmail.Text = email;
            lblEmail.Content = email;
            
            lblRole.Text = role;     // যেমন: USER
            lblRole.Content = role;

            lblStatus.Text = status; // যেমন: Active
            lblStatus.Content = status;

            lblLogin.Text = lastLogin;
            lblLogin.Content = lastLogin;

            lblCreated.Text = created;
            lblCreated.Content = created;

            // ১. গোল আইকন সেট করা
            Color bg = GetRandomColor();
            picAvatar.Image = GenerateAvatar(initial, bg);

            // ২. স্ট্যাটাস কালার (Active = Green, Inactive = Red)
            if (status.ToLower() == "inactive")
            {
                lblStatus.ForeColor = Color.Salmon;
            }
            else
            {
                lblStatus.ForeColor = Color.SpringGreen;
            }

            // Wire up activate/deactivate buttons if they exist
            // You may need to adjust button names based on your Designer
        }

        // --- গোল আইকন জেনারেটর (আগের মতোই) ---
        private Bitmap GenerateAvatar(string text, Color bgColor)
        {
            if (picAvatar.Width == 0) return null;
            Bitmap bmp = new Bitmap(picAvatar.Width, picAvatar.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                using (Brush brush = new SolidBrush(bgColor))
                {
                    g.FillEllipse(brush, 0, 0, picAvatar.Width - 1, picAvatar.Height - 1);
                }
                using (Font font = new Font("Segoe UI", 10, FontStyle.Bold))
                {
                    SizeF textSize = g.MeasureString(text, font);
                    g.DrawString(text, font, Brushes.White, (picAvatar.Width - textSize.Width) / 2, (picAvatar.Height - textSize.Height) / 2);
                }
            }
            return bmp;
        }

        private Color GetRandomColor()
        {
            Color[] colors = { Color.Orange, Color.SeaGreen, Color.DodgerBlue, Color.Purple, Color.Crimson };
            return colors[r.Next(colors.Length)];
        }
    }
}