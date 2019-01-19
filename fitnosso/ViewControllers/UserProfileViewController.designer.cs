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
        UIKit.UIImageView imgUserImage { get; set; }

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
        UIKit.UITapGestureRecognizer profileTapGestureRec { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtEdit_Height { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtEdit_Weight { get; set; }

        [Action ("photo_gesture_tap:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void photo_gesture_tap (UIKit.UITapGestureRecognizer sender);

        void ReleaseDesignerOutlets ()
        {
            if (imgUserImage != null) {
                imgUserImage.Dispose ();
                imgUserImage = null;
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

            if (profileTapGestureRec != null) {
                profileTapGestureRec.Dispose ();
                profileTapGestureRec = null;
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