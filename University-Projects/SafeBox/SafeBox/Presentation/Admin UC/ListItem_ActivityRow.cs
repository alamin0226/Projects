using System.Windows.Forms;

namespace SafeBox
{
    public partial class ListItem_ActivityRow : UserControl
    {
        public ListItem_ActivityRow()
        {
            InitializeComponent();
        }

        public void SetData(string title, string description, string time)
        {
            lblTitle.Content = title;
            lblDesc.Content = description;
            lblTime.Content = time;
        }
    }
}