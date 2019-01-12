// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace fitnosso
{
    [Register ("LogEntryViewCell")]
    partial class LogEntryViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblcKals { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblLogEntryID { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblLogType { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lblcKals != null) {
                lblcKals.Dispose ();
                lblcKals = null;
            }

            if (lblLogEntryID != null) {
                lblLogEntryID.Dispose ();
                lblLogEntryID = null;
            }

            if (lblLogType != null) {
                lblLogType.Dispose ();
                lblLogType = null;
            }
        }
    }
}