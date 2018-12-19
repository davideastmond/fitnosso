using System;
using System.IO;
using UIKit;
using System.Reflection;

namespace fitnosso
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            // This is where we should check if there is a saved FitnessJournal on disk. If not, user needs to create one

            string exFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ex.dat");

            // Check if the file exists
            if (!File.Exists(exFilePath))
            {
                // Create the file
                File.Create(exFilePath);
                Console.WriteLine("File has been created.");
                SetupExerciseFile(exFilePath);
            }
            else
            {
                Console.WriteLine("File exists");

            }

            // TEST
            Exercise defaultExercise = Exercise.DefaultExercise;
            ExerciseLogEntry entry = new ExerciseLogEntry(DateTime.Now, 0, 0, defaultExercise);

            // Create a new journal
            
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
        public void SetupExerciseFile(string targetPath)
        {
            //  A helper method that adds the default built in exercises from the embedded file 
            // to the custom exercise list "ex.dat"
            string stringData = "";
            Assembly assembly = IntrospectionExtensions.GetTypeInfo(typeof(Application)).Assembly;
            Stream fileStream = assembly.GetManifestResourceStream("fitnosso.exercises.txt");
            using (var reader = new StreamReader(fileStream))
            {
               stringData = reader.ReadToEnd(); // Read the data
            }

            using (StreamWriter wrtr = File.AppendText(targetPath))
            {
                wrtr.WriteLine(stringData);
            }
        }
    }
}
