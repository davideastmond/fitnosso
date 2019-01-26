using System;
using System.IO;
namespace fitnosso
{
    /// <summary>
    /// Static class that supplies a quick reference to data file paths
    /// </summary>
    public static class DataFiles
    {
        // This is where we should check if there is a saved FitnessJournal on disk. If not, user needs to create one
        public static string journalDataFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "journal.dat");
        public static string exFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ex.dat");
        public static string journalBackUpDataFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "journal.bk");
        public static string profile_image_file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "profileimage.dat");
    }
}
