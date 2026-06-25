using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SafeBox.Application.Services;
using SafeBox.Infrastructure.Repositories;

namespace SafeBox
{
    public partial class UC_AuditLog : UserControl
    {
        private readonly AuditService _auditService;
        private readonly UserRepository _userRepository;

        public UC_AuditLog()
        {
            InitializeComponent();
            _auditService = new AuditService();
            _userRepository = new UserRepository();

            CalculateStats();
            PopulateAuditList("");
        }

        private void CalculateStats()
        {
            try
            {
                int totalUsers = _auditService.GetTotalUsers();
                int deactivatedUsers = _auditService.GetDeactivatedUserCount();
                int passwordResets = _auditService.GetPasswordResetCount();

                try
                {
                    if (lblCreatedCount != null)
                        lblCreatedCount.Text = totalUsers.ToString();
                    if (lblDeactiveCount != null)
                        lblDeactiveCount.Text = deactivatedUsers.ToString();
                    if (lblResetCount != null)
                        lblResetCount.Text = passwordResets.ToString();
                }
                catch { }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error calculating statistics: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateAuditList(string search)
        {
            try
            {
                flowAuditList.Controls.Clear();
                search = search.ToLower();

                var auditLogs = _auditService.GetRecentAuditLogs(10);

                if (!auditLogs.Any())
                {
                    Label lblEmpty = new Label
                    {
                        Text = "No audit logs found",
                        Font = new Font("Segoe UI", 12F),
                        ForeColor = Color.Gray,
                        AutoSize = true,
                        Padding = new Padding(20)
                    };
                    flowAuditList.Controls.Add(lblEmpty);
                    return;
                }

                var filteredLogs = auditLogs;
                if (!string.IsNullOrWhiteSpace(search))
                {
                    filteredLogs = auditLogs.Where(log =>
                        log.Action.ToLower().Contains(search) ||
                        (log.Description != null && log.Description.ToLower().Contains(search)))
                        .ToList();
                }

                foreach (var log in filteredLogs)
                {
                    var user = log.UserId.HasValue ? _userRepository.GetById(log.UserId.Value) : null;
                    string adminName = user != null ? $"Admin {user.Username}" : "System";
                    string targetId = ExtractTargetId(log.Description);

                    ListItem_AuditRow row = new ListItem_AuditRow();
                    row.SetData(
                        log.Action,
                        log.Description ?? string.Empty,
                        targetId,
                        adminName,
                        log.Timestamp
                    );

                    row.MouseEnter += (s, e) => row.BackColor = Color.FromArgb(245, 245, 245);
                    row.MouseLeave += (s, e) => row.BackColor = Color.White;

                    row.Width = flowAuditList.Width - 25;
                    flowAuditList.Controls.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading audit logs: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ExtractTargetId(string description)
        {
            if (string.IsNullOrEmpty(description)) return "N/A";

            int colonIndex = description.LastIndexOf(':');
            if (colonIndex > 0 && colonIndex < description.Length - 1)
            {
                return description.Substring(colonIndex + 1).Trim();
            }
            return "N/A";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch?.Text?.Trim() ?? "";
            PopulateAuditList(searchText);
        }

        public void RefreshAuditLogs()
        {
            CalculateStats();
            PopulateAuditList(txtSearch?.Text ?? "");
        }
    }
}
