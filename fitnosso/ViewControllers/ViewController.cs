using System;
using System.IO;
using UIKit;
using System.Reflection;
using System.Threading.Tasks;
using Foundation;
using System.Collections.Generic;

namespace fitnosso
{
    public delegate void RegistrationReceived(object sender, RegistrationReturnData data);
    public partial class ViewController : UIViewController
    {
        DateTime DateTimeSetting = DateTime.Now;
      
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //JournalController.Reset();
            // Perform any additional setup after loading the view, typically from a nib.

            // Application launches - check if a serialized journal file exists - if not, segue to a registration screen
            // If so, segue to today's entry browser and de-serialize
            
            if (!File.Exists(DataFiles.journalDataFile))
            {
                // Segue to a registration screen
                // Create a delegate object

                this.PerformSegue("showSetupJournal", this);
            } else
            {
                // Deserialize and pass information

                // Set the label to display the time

                navDateLabel.Text = DateTimeSetting.ToString("MMM d, yyyy");
                JournalController.Pull();

            }

            // We have to check if the CurrentJournal is null after it has been pulled. If it is, that  means there was something wrong
            // and we have to re-create a journal

            if (JournalController.CurrentJournal == null)
            {
                this.PerformSegue("showSetupJournal", this);

            }
            else
            {
                /*
                JournalController.TestReturnListOfRandomLogEntries(12);
                JournalController.Save();
                */
                TableViewSourceModel model = new TableViewSourceModel(JournalController.FilteredLogs);
                logEntryTable.Source = model;
                UIImage img = new UIImage();

            }
        }

       
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.



            
        }
        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);


            if (segue.Identifier == "showSetupJournal")
            {
                setupViewController setScreen = segue.DestinationViewController as setupViewController; // Create a new instance of the setup screen
                setScreen.delegate_data.OnReceivedRegistrationData += Delegate_Data_OnReceivedRegistrationData;
            }
        }
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            if (!JournalController.IsValidJournal)
            {
                Console.WriteLine("Please create a new Journal");
                logEntryTable.Hidden = true;
                cmdCreateNewJournal.Hidden = false;
                btn_new_log.Enabled = false;
                btnShowProfile.Enabled = false;
                btn_date_forward.Enabled = false;
                btn_date_backward.Enabled = false;
            }
            else
            {
                logEntryTable.Hidden = false;
                cmdCreateNewJournal.Hidden = true;
                btn_new_log.Enabled = true;
                btnShowProfile.Enabled = true;
                btn_date_forward.Enabled = true;
                btn_date_backward.Enabled = true;
            }

        }

        partial void btnCreateNewJournalTap(UIButton sender)
        {
            if (!JournalController.IsValidJournal)
            {
                // bring up the new journal setup screen
                this.PerformSegue("showSetupJournal", this);
            }
        }

        void Delegate_Data_OnReceivedRegistrationData(object sender, RegistrationReturnData data)
        {
           // Here is where we receive a message that registration was successful
           if (data.Successful)
            {
                Console.WriteLine("Registration was successful. Load the database");
                // Refresh and pull
                //JournalController.Pull();
                // pop
                this.NavigationController.PopViewController(true);
                GlobalToast.Toast.ShowToast("Journal Created");



            }
        }
        void ScrollDate (int dateDirection)
        {
            // Changes the date and updates the label
            switch (dateDirection)
            {
                case -1:
                    // Go back in time

                    DateTimeSetting = DateTimeSetting.AddDays(-1);
                    navDateLabel.Text = DateTimeSetting.ToString("MMM d, yyyy");
                    break;
                case 1:
                    DateTimeSetting = DateTimeSetting.AddDays(1);
                    navDateLabel.Text = DateTimeSetting.ToString("MMM d, yyyy");
                    break;
                default:
                    // Do nothing
                    return;
            }
        }



        partial void date_forward_tap(UIBarButtonItem sender)
        {
            // Only do this is if a valid journal is open

            if (JournalController.CurrentJournal != null)
            {
                ScrollDate(1); // Scroll date forward
                JournalController.GetAllEntriesByDate(DateTimeSetting);
                // JournalController.FilteredLogs.Print();
                TableViewSourceModel model = new TableViewSourceModel(JournalController.FilteredLogs);
                logEntryTable.Source = model;
                logEntryTable.ReloadData();
            }

        }

        partial void date_backward_tap(UIBarButtonItem sender)
        {
            if (JournalController.CurrentJournal != null)
            {
                ScrollDate(-1); // Scroll date backward
                JournalController.GetAllEntriesByDate(DateTimeSetting);
                // JournalController.FilteredLogs.Print();
                TableViewSourceModel model = new TableViewSourceModel(JournalController.FilteredLogs);
                logEntryTable.Source = model;
                logEntryTable.ReloadData();
            }
           
        }
    }

}
