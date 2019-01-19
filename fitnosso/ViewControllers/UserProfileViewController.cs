using System;
using System.Collections.Generic;
using UIKit;

namespace fitnosso
{
    public partial class UserProfileViewController : UIViewController
    {
        public User TopicUser; // Property to hold the user

        public UserProfileViewController(IntPtr handle) : base (handle)
        {
            // Constructor
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void photo_gesture_tap(UITapGestureRecognizer sender)
        {
            System.Console.WriteLine (  "Tapped the photo");
        }
    }
}

