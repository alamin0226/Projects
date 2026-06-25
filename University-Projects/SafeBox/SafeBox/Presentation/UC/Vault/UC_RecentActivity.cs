using System;
using System.Drawing;
using System.Windows.Forms;

namespace SafeBox.Presentation.UC.Vault
{
    public partial class UC_RecentActivity : UserControl
    {
        public UC_RecentActivity()
        {
            InitializeComponent();
        }

        public void SetData(string action, string details, string timestamp, Color backgroundColor)
        {
            lblAction.Content = action;
            lblDetails.Content = details;
            lblTimestamp.Content = timestamp;
            this.BackColor = backgroundColor;

            // Ensure labels inherit background or are transparent
            lblAction.BackColor = Color.Transparent;
            lblDetails.BackColor = Color.Transparent;
            lblTimestamp.BackColor = Color.Transparent;
        }
    }
}
