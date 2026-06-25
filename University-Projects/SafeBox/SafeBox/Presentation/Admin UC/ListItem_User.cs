using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SafeBox
{
    public partial class ListItem_User : UserControl
    {
        // র‍্যান্ডম কালার জেনারেটর (Static রাখা জরুরি)
        private static readonly Random r = new Random();

        public ListItem_User()
        {
            InitializeComponent();
        }

        // --- মেইন ফাংশন: ডাটা রিসিভ করা ---
        public void SetData(string initial, string name, string email, string status)
        {
            // ডিজাইনারের লেবেলের নামগুলো (Name) নিচের নামের সাথে মিলতে হবে!
            // ডিজাইনারের লেবেলের নামগুলো (Name) নিচের নামের সাথে মিলতে হবে!
            lblName.Content = name;
            lblEmail.Content = email;
            lblStatus.Content = status;

            // ১. গোল অবতার তৈরি করা
            Color bg = GetRandomColor();
            picAvatar.Image = GenerateAvatar(initial, bg);

            // ২. স্ট্যাটাস কালার চেঞ্জ
            if (status.ToLower() == "inactive")
            {
                lblStatus.ForeColor = Color.Red;
            }
            else
            {
                lblStatus.ForeColor = Color.SeaGreen;
            }
        }

        // --- গোল ছবি জেনারেট করার লজিক ---
        private Bitmap GenerateAvatar(string text, Color bgColor)
        {
            if (picAvatar.Width == 0) return null; // সেফটি চেক

            int w = picAvatar.Width;
            int h = picAvatar.Height;
            Bitmap bmp = new Bitmap(w, h);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                // গোল ব্যাকগ্রাউন্ড
                using (Brush brush = new SolidBrush(bgColor))
                {
                    g.FillEllipse(brush, 0, 0, w - 1, h - 1);
                }

                // মাঝখানের টেক্সট
                using (Font font = new Font("Segoe UI", 12, FontStyle.Bold))
                {
                    SizeF textSize = g.MeasureString(text, font);
                    g.DrawString(text, font, Brushes.White, (w - textSize.Width) / 2, (h - textSize.Height) / 2);
                }
            }
            return bmp;
        }

        // --- র‍্যান্ডম কালার ---
        private Color GetRandomColor()
        {
            Color[] colors = {
                Color.Orange, Color.SeaGreen, Color.DodgerBlue,
                Color.MediumPurple, Color.Crimson, Color.Teal
            };
            return colors[r.Next(colors.Length)];
        }
    }
}