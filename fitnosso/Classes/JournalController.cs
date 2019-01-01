using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace fitnosso
{
    public static class JournalController
    {
        // This is a static class used for common journal operations
        public static FitnessJournal Pull()
        {
            // Retrieves / de-serializes the journal object

            BinaryFormatter bf = new BinaryFormatter();
            FileStream fStream = new FileStream(DataFiles.journalDataFile, FileMode.Open, FileAccess.Read);

            FitnessJournal returnJournal;
            try
            {
                returnJournal = (FitnessJournal) bf.Deserialize(fStream);
                return returnJournal;

            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }

        public static void Save(FitnessJournal jData)
        {
            // Saves and backs up

            // Get any saved journal, back it up

            if (File.Exists(DataFiles.journalDataFile))
            {
                // Check to see if the backup exists

                if (File.Exists(DataFiles.journalBackUpDataFile))
                {
                    // Delete the backup
                    File.Delete(DataFiles.journalBackUpDataFile);
                }

                // Backup the main file
                File.Copy(DataFiles.journalDataFile, DataFiles.journalBackUpDataFile);
                // Delete the journal file and prepare to write a new one
                File.Delete(DataFiles.journalDataFile);
            }

            // Write the fitness journal data to file
            FileStream fStream = new FileStream(DataFiles.journalDataFile, FileMode.OpenOrCreate);
            BinaryFormatter bF = new BinaryFormatter();

            try
            {
                bF.Serialize(fStream, jData);
                Console.WriteLine("Journal file serialized and saved");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public static void Reset()
        {
            // Deletes / resets the journal
            if (File.Exists(DataFiles.journalDataFile))
            {
                File.Delete(DataFiles.journalDataFile)
;            }
        }


    }
}
