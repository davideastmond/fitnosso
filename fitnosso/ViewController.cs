using System;
using System.IO;
using UIKit;
using System.Reflection;
using System.Threading.Tasks;
using Foundation;

namespace fitnosso
{
    public delegate void RegistrationReceived(object sender, RegistrationReturnData data);
    public partial class ViewController : UIViewController
    {

     
        
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            JournalController.Reset();
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


        void Delegate_Data_OnReceivedRegistrationData(object sender, RegistrationReturnData data)
        {
           
        }

    }

}
