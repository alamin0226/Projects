using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SafeBox
{
    public partial class ListItem_AuditRow : UserControl
    {
        public ListItem_AuditRow()
        {
            InitializeComponent();
        }

        public void SetData(string action, string details, string targetId, string adminName, DateTime timestamp)
        {
            lblActionBadge.Content = action;
            lblDetails.Content = details;
            lblAdminName.Content = adminName;
            lblDate.Content = timestamp.ToString("M/d/yyyy");
            lblTime.Content = timestamp.ToString("h:mm tt");
            lblID.Content = $"Target User ID: {targetId}";

            StyleActionBadge(action);
            picAdmin.Image = GenerateAvatar(GetInitial(adminName), GetAvatarColor(action));
        }

        private string GetInitial(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "A";
            string cleanName = name.Replace("Admin ", "").Trim();
            return cleanName.Length > 0 ? cleanName[0].ToString().ToUpper() : "A";
        }

        private Color GetAvatarColor(string action)
        {
            switch (action)
            {
                case "User Created":
                    return Color.FromArgb(46, 204, 113);
                case "User Activated":
                    return Color.FromArgb(46, 204, 113);
                case "User Deactivated":
                    return Color.FromArgb(231, 76, 60);
                case "Password Reset":
                case "Password Changed":
                    return Color.FromArgb(52, 152, 219);
                case "Role Updated":
                    return Color.FromArgb(243, 156, 18);
                default:
                    return Color.FromArgb(149, 165, 166);
            }
        }

        private void StyleActionBadge(string action)
        {
            Color badgeColor;
            switch (action)
            {
                case "User Created":
                    badgeColor = Color.SeaGreen;
                    break;
                case "User Activated":
                    badgeColor = Color.SeaGreen;
                    break;
                case "User Deactivated":
                    badgeColor = Color.IndianRed;
                    break;
                case "Password Reset":
                case "Password Changed":
                    badgeColor = Color.RoyalBlue;
                    break;
                case "Role Updated":
                    badgeColor = Color.Orange;
                    break;
                case "Admin Profile Updated":
                    badgeColor = Color.MediumPurple;
                    break;
                default:
                    badgeColor = Color.Gray;
                    break;
            }
            lblActionBadge.BackColor = badgeColor;
            lblActionBadge.ForeColor = Color.White;
        }

        private Bitmap GenerateAvatar(string text, Color bgColor)
        {
            if (picAdmin.Width == 0 || picAdmin.Height == 0) return null;
            Bitmap bmp = new Bitmap(picAdmin.Width, picAdmin.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                using (Brush brush = new SolidBrush(bgColor))
                {
                    g.FillEllipse(brush, 0, 0, picAdmin.Width - 1, picAdmin.Height - 1);
                }
                using (Font font = new Font("Segoe UI", 12, FontStyle.Bold))
                {
                    SizeF textSize = g.MeasureString(text, font);
                    g.DrawString(text, font, Brushes.White,
                        (picAdmin.Width - textSize.Width) / 2,
                        (picAdmin.Height - textSize.Height) / 2);
                }
            }
            return bmp;
        }
    }
}