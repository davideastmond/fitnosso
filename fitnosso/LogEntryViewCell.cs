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
        // These methods update the labels on the cell
        public void SetItemIDText(string IDInfo)
        {
            lblLogEntryID.Text = IDInfo;
        }
        public void SetExerciseFoodText (string IDInfo)
        {
            lblEx_Food.Text = IDInfo;
        }
        public void SetcKalText (string IDInfo)
        {
            lblcKals.Text = IDInfo;
        }
        public void SetInOutText (string IDInfo)
        {
            lblLogType.Text = IDInfo;
        }
        public void SetcKalLabelColor (UIColor col)
        {
            lblcKals.TextColor = col;
        }
    }
}