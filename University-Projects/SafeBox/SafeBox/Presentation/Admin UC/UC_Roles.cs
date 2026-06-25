using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SafeBox
{
    // নেমস্পেস 'SafeBox' রাখা হয়েছে যাতে AdminDashboard এর সাথে সহজে কানেক্ট হয়
    public partial class UC_Roles : UserControl
    {
        // বর্তমান রোল ট্র্যাক করার জন্য (ডিফল্ট: User)
        private string currentRole = "User";

        public UC_Roles()
        {
            InitializeComponent();

            // শুরুতেই UI এবং লিস্ট লোড হবে
            UpdateRoleUI();
            LoadPermissions();

            // প্যানেলে ক্লিক করলে রোল পরিবর্তন হবে
            // (আমরা কোড দিয়েই ইভেন্ট হ্যান্ডলার যোগ করছি)
            pnlRoleUser.Click += (s, e) => { currentRole = "User"; UpdateRoleUI(); LoadPermissions(); };
            pnlRoleAdmin.Click += (s, e) => { currentRole = "Administrator"; UpdateRoleUI(); LoadPermissions(); };

            // প্যানেলের ভেতরের লেবেলে ক্লিক করলেও যাতে কাজ করে
            AssignClickToChildren(pnlRoleUser, "User");
            AssignClickToChildren(pnlRoleAdmin, "Administrator");
        }

        // --- হেল্পার: চাইল্ড কন্ট্রোলে ক্লিক ইভেন্ট দেওয়া ---
        private void AssignClickToChildren(Control parent, string role)
        {
            foreach (Control c in parent.Controls)
            {
                c.Click += (s, e) => { currentRole = role; UpdateRoleUI(); LoadPermissions(); };
            }
        }

        // --- ১. রোল সিলেকশন স্টাইল আপডেট ---
        private void UpdateRoleUI()
        {
            // রিসেট (Dark Color)
            pnlRoleUser.BackColor = Color.FromArgb(30, 40, 60);
            pnlRoleAdmin.BackColor = Color.FromArgb(30, 40, 60);

            // বর্ডার বা হাইলাইট লজিক
            if (currentRole == "User")
            {
                // সিলেক্টেড হলে একটু লাইট কালার এবং বর্ডার
                pnlRoleUser.BackColor = Color.FromArgb(45, 55, 75);
                // আপনি চাইলে বর্ডার স্টাইল কোড দিয়ে দিতে পারেন, বা শুধু কালার চেঞ্জ যথেষ্ট
            }
            else
            {
                pnlRoleAdmin.BackColor = Color.FromArgb(45, 55, 75);
            }
        }

        // --- ২. পারমিশন লিস্ট জেনারেট করা ---
        private void LoadPermissions()
        {
            flowPermissions.Controls.Clear(); // আগের লিস্ট ক্লিয়ার

            // পারমিশন ডাটা (Category -> Permissions)
            var permissions = new Dictionary<string, string[]>
            {
                { "Vault Management", new[] { "Create vaults", "Delete vaults", "Share vaults" } },
                { "File Operations", new[] { "Upload files", "Download files", "Delete files" } },
                { "User Management", new[] { "Create user accounts", "Activate/Deactivate users", "Reset user passwords", "Assign roles" } },
                { "System Access", new[] { "View audit logs", "Modify system settings" } },
                { "Data Access", new[] { "Access own encrypted data", "Access user encrypted data" } }
            };

            foreach (var category in permissions)
            {
                // ১. ক্যাটাগরি হেডার তৈরি
                Label lblHeader = new Label();
                lblHeader.Text = category.Key;
                lblHeader.ForeColor = Color.Orange; // হেডারের কালার
                lblHeader.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                lblHeader.AutoSize = true;
                lblHeader.Margin = new Padding(5, 15, 0, 5); // উপরে একটু গ্যাপ
                flowPermissions.Controls.Add(lblHeader);

                // ২. চেকবক্স তৈরি
                foreach (string perm in category.Value)
                {
                    CheckBox chk = new CheckBox();
                    chk.Text = " " + perm;
                    chk.ForeColor = Color.WhiteSmoke;
                    chk.Font = new Font("Segoe UI", 10);
                    chk.AutoSize = false;
                    chk.Width = 900; // পুরো লাইন জুড়ে থাকবে
                    chk.Height = 35;
                    chk.Padding = new Padding(10, 0, 0, 0);
                    chk.Cursor = Cursors.Hand;

                    // চেকবক্স ডিজাইন (Optional: Flat Look)
                    chk.FlatStyle = FlatStyle.Flat;
                    chk.FlatAppearance.BorderColor = Color.Gray;

                    // ৩. রোল অনুযায়ী পারমিশন লজিক
                    if (currentRole == "Administrator")
                    {
                        chk.Checked = true;       // অ্যাডমিনের সব অন
                        chk.Enabled = false;      // চেঞ্জ করা যাবে না
                        chk.ForeColor = Color.Gray; // ডিসেবল কালার
                    }
                    else // User Mode
                    {
                        // ডামি লজিক: ইউজার শুধু ফাইল আর ভল্ট ম্যানেজ করতে পারবে
                        if (category.Key == "Vault Management" || category.Key == "File Operations" || perm.Contains("own encrypted data"))
                        {
                            chk.Checked = true;
                            chk.ForeColor = Color.SpringGreen; // একটিভ বুঝাতে সবুজ
                        }
                        else
                        {
                            chk.Checked = false;
                            chk.ForeColor = Color.Silver;
                        }
                    }

                    flowPermissions.Controls.Add(chk);
                }
            }
        }
    }
}