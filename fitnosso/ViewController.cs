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
            //Test();
            Test2();
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
                FitnessJournal dJ = JournalController.Pull();

            }
            List<LogEntry> testList = JournalController.TestReturnListOfRandomLogEntries(11);
            TableViewSourceModel model = new TableViewSourceModel(testList);
            logEntryTable.Source = model;
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


        void Delegate_Data_OnReceivedRegistrationData(object sender, RegistrationReturnData data)
        {
           // Here is where we receive a message that registration was successful
           if (data.Successful)
            {
                Console.WriteLine("Registration was successful. Load the database");
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
        void Test()
        {
            List<LogEntry> myList = JournalController.TestReturnListOfRandomLogEntries(10);

        }
        void Test2()
        {
            DateTime d1 = new DateTime(2018, 1, 1);
            DateTime d2 = new DateTime(2018, 12, 31);
            for (int i = 0; i <= 10; i++)
            {
                DateTime myDate = ExtensionMethods.GetRandomDateInRange2(d1, d2);
                Console.WriteLine(myDate);

            }
        }

        partial void date_forward_tap(UIBarButtonItem sender)
        {
            ScrollDate(1); // Scroll date forward
        }

        partial void date_backward_tap(UIBarButtonItem sender)
        {
            ScrollDate(-1); // Scroll date backward
        }
    }

}
