// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace fitnosso
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem btn_date_backward { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem btn_date_forward { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem btn_new_log { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem btnShowProfile { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton cmdCreateNewJournal { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView logEntryTable { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel navDateLabel { get; set; }

        [Action ("btnCreateNewJournalTap:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void btnCreateNewJournalTap (UIKit.UIButton sender);

        [Action ("date_backward_tap:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void date_backward_tap (UIKit.UIBarButtonItem sender);

        [Action ("date_forward_tap:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void date_forward_tap (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (btn_date_backward != null) {
                btn_date_backward.Dispose ();
                btn_date_backward = null;
            }

            if (btn_date_forward != null) {
                btn_date_forward.Dispose ();
                btn_date_forward = null;
            }

            if (btn_new_log != null) {
                btn_new_log.Dispose ();
                btn_new_log = null;
            }

            if (btnShowProfile != null) {
                btnShowProfile.Dispose ();
                btnShowProfile = null;
            }

            if (cmdCreateNewJournal != null) {
                cmdCreateNewJournal.Dispose ();
                cmdCreateNewJournal = null;
            }

            if (logEntryTable != null) {
                logEntryTable.Dispose ();
                logEntryTable = null;
            }

            if (navDateLabel != null) {
                navDateLabel.Dispose ();
                navDateLabel = null;
            }
        }
    }
}