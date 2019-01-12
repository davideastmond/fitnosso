using Foundation;
using System;
using UIKit;

namespace fitnosso
{
    public partial class LogEntryViewCell : UITableViewCell
    {
        public LogEntryViewCell (IntPtr handle) : base (handle)
        {
        }
        public void SetTextString(string IDInfo)
        {
            lblLogEntryID.Text = IDInfo;
        }
    }
}