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
    [Register ("UserProfileViewController")]
    partial class UserProfileViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton cmdDeleteReset { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem cmdSaveProfileChanges { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgUserImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblHeightCaption { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblUserAge { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblUserBMR { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblUserGender { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblUserName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblWeightCaption { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtEdit_Height { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtEdit_Weight { get; set; }

        [Action ("delete_reset_journal_tap:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void delete_reset_journal_tap (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (cmdDeleteReset != null) {
                cmdDeleteReset.Dispose ();
                cmdDeleteReset = null;
            }

            if (cmdSaveProfileChanges != null) {
                cmdSaveProfileChanges.Dispose ();
                cmdSaveProfileChanges = null;
            }

            if (imgUserImage != null) {
                imgUserImage.Dispose ();
                imgUserImage = null;
            }

            if (lblHeightCaption != null) {
                lblHeightCaption.Dispose ();
                lblHeightCaption = null;
            }

            if (lblUserAge != null) {
                lblUserAge.Dispose ();
                lblUserAge = null;
            }

            if (lblUserBMR != null) {
                lblUserBMR.Dispose ();
                lblUserBMR = null;
            }

            if (lblUserGender != null) {
                lblUserGender.Dispose ();
                lblUserGender = null;
            }

            if (lblUserName != null) {
                lblUserName.Dispose ();
                lblUserName = null;
            }

            if (lblWeightCaption != null) {
                lblWeightCaption.Dispose ();
                lblWeightCaption = null;
            }

            if (txtEdit_Height != null) {
                txtEdit_Height.Dispose ();
                txtEdit_Height = null;
            }

            if (txtEdit_Weight != null) {
                txtEdit_Weight.Dispose ();
                txtEdit_Weight = null;
            }
        }
    }
}