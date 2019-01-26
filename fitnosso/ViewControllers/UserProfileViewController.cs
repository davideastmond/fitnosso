using System;
using System.Collections.Generic;
using UIKit;

namespace fitnosso
{
    public partial class UserProfileViewController : UIViewController
    {
        UIImagePickerController picker;
        public User TopicUser; // Property to hold the user
        public event JournalDeleted OnJournalDeleted;
        public UserProfileViewController(IntPtr handle) : base (handle)
        {
           
            
        }

        void Tap(UITapGestureRecognizer tap1)
        {
            Console.WriteLine("Photo tapped");
            picker = new UIImagePickerController();

        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            // Constructor
            imgUserImage.UserInteractionEnabled = true;

            UITapGestureRecognizer tapGesture = new UITapGestureRecognizer(Tap);
            tapGesture.NumberOfTapsRequired = 1;
            imgUserImage.AddGestureRecognizer(tapGesture);

            // Retrieve the user profile
            if (JournalController.CurrentJournal != null)
            {
                lblUserName.Text = JournalController.CurrentJournal.Owner.Name;
                lblUserAge.Text = JournalController.CurrentJournal.Owner.Age.ToString();
                lblUserGender.Text = JournalController.CurrentJournal.Owner.SexGender.ToString();

                // Get the measurements: Heights
                if (JournalController.CurrentJournal.Owner.Pref_HeightMeasurementUnit == UnitsMode.Imperial)
                {
                    // Imperial
                    lblHeightCaption.Text = "Height (in.):";
                    txtEdit_Height.Text = JournalController.CurrentJournal.Owner.ImperialHeight.ToString();
                }
                else
                {
                    // Metric
                    lblHeightCaption.Text = "Height (cm):";
                    txtEdit_Height.Text = JournalController.CurrentJournal.Owner.MetricHeight.ToString();
                }

                // Weights:
                if (JournalController.CurrentJournal.Owner.Pref_WeightMeasurementUnit == UnitsMode.Imperial)
                {
                    lblWeightCaption.Text = "Weight (lbs.):";
                    txtEdit_Weight.Text = JournalController.CurrentJournal.Owner.ImperialWeight.ToString();
                        
                } else
                {
                    lblWeightCaption.Text = "Weight (kg):";
                    txtEdit_Weight.Text = JournalController.CurrentJournal.Owner.MetricWeight.ToString();
                }

                // Populate the BMI
                lblUserBMR.Text = JournalController.CurrentJournal.Owner.BasalMetabolicRate.ToString();
            }
        }

        partial void delete_reset_journal_tap(UIButton sender)
        {
            // This resets the journal and dismisses the VC
            // First we need the user to confirm the deletion with a destructive dialog

            UIAlertController del_alert = UIAlertController.Create("Delete Journal", "This will delete the journal. All data will be lost.", UIAlertControllerStyle.Alert);
            del_alert.AddAction(UIAlertAction.Create("Confirm Delete", UIAlertActionStyle.Destructive, action => deleteJournalAndDismiss()));
            del_alert.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, null));
            PresentViewController(del_alert, true, null);

        }

        private void deleteJournalAndDismiss()
        {
            // Does the above
            JournalController.Reset();

            // Trigger a delegate method
            EventArgs args = new EventArgs();

            RaiseEvent(this, args);
        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
        private void RaiseEvent(object sender, EventArgs e)
        {
            // Trigger the event
            OnJournalDeleted += UserProfileViewController_OnJournalDeleted;
            OnJournalDeleted(sender, e);
        }

        void UserProfileViewController_OnJournalDeleted(object sender, EventArgs e)
        {
            // Nothing
        }

    }
}

