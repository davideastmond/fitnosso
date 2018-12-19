using System;
using System.IO;
using UIKit;
using System.Reflection;
using System.Threading.Tasks;

namespace fitnosso
{
    public partial class ViewController : UIViewController
    {
        // This is where we should check if there is a saved FitnessJournal on disk. If not, user needs to create one
        string journalDataFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "journal.dat");

        string exFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ex.dat");
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            // Application launches - check if a serialized journal file exists - if not, segue to a registration screen
            // If so, segue to today's entry browser and de-serialize
            if (!File.Exists(journalDataFile))
            {
                // Segue to a registration screen
                
                
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

    }
}
