using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SafeBox.Domain.Entities;
using SafeBox.Application.Interfaces;
using SafeBox.Application.Services;
using SafeBox.Infrastructure.Repositories;

namespace SafeBox.Presentation.UC.ActivityLog
{
    public partial class UC_ActivityLog : UserControl
    {
        private readonly IActivityService _activityService;

        public UC_ActivityLog()
        {
            InitializeComponent();
            _activityService = new ActivityService();
            if (!this.DesignMode) LoadActivityLogs();
        }

        public UC_ActivityLog(IActivityService activityService)
        {
            InitializeComponent();
            _activityService = activityService;
            LoadActivityLogs();
        }

        /// <summary>
        /// Loads and displays all activity logs in descending order
        /// </summary>
        private void LoadActivityLogs()
        {
            try
            {
                int userId = SessionManager.CurrentUserId;
                if (userId == 0)
                {
                    MessageBox.Show("Please log in to view activity logs.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                flowLogList.Controls.Clear();

                // Get all activities (already sorted by Timestamp DESC)
                var activities = _activityService.GetAllActivities(userId);

                if (!activities.Any())
                {
                    Label lblEmpty = new Label
                    {
                        Text = "No activity logs found.",
                        Font = new Font("Segoe UI", 12F),
                        ForeColor = Color.Gray,
                        AutoSize = true,
                        Padding = new Padding(20)
                    };
                    flowLogList.Controls.Add(lblEmpty);
                    return;
                }

                Color[] colors = { Color.Moccasin, Color.AliceBlue, Color.Honeydew, Color.Lavender, Color.LavenderBlush };
                int colorIndex = 0;

                foreach (var activity in activities)
                {
                    UC_ActivityLogRow row = new UC_ActivityLogRow();
                    row.SetLogData(activity.Action, activity.Description ?? string.Empty,
                        activity.Timestamp.ToString("M/d/yyyy, h:mm tt"),
                        colors[colorIndex % colors.Length]);

                    row.Width = flowLogList.Width - 25;
                    flowLogList.Controls.Add(row);
                    colorIndex++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading activity logs: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Public method to refresh activity logs
        /// </summary>
        public void RefreshLogs()
        {
            LoadActivityLogs();
        }
    }
}
