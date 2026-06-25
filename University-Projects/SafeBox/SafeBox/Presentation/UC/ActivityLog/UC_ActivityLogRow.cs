using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SafeBox.Presentation.UC.ActivityLog
{
    public partial class UC_ActivityLogRow : UserControl
    {
        public UC_ActivityLogRow()
        {
            InitializeComponent();
        }
        public void SetLogData(string action, string details, string time, Color rowColor)
        {
            lblAction.Content = action;
            lblDetails.Content = details;
            lblTimestamp.Content = time;
            this.BackColor = rowColor;
        }

        private void lblDetails_Load(object sender, EventArgs e)
        {

        }

        private void lblAction_Load(object sender, EventArgs e)
        {

        }

        private void lblTimestamp_Load(object sender, EventArgs e)
        {

        }
    }
}
