using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using System.Collections.Generic;

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
        public static LogEntry GetEntryByID(string IDno)
        {
            /* Retrieves a single log entry by the unique ID provided. Returns null if no entry found
            */
            FitnessJournal pulledEntry = Pull();
            // Ensure it's not null

            // Ensure IDNo parameter is all uppper case
            IDno = IDno.ToUpper();
            if (pulledEntry != null)
            {
                foreach (LogEntry j in pulledEntry.Logs)
                {
                    
                    if (j.EntryID == IDno)
                    {
                        return j; // return the matching ID
                    }
                }
            }
            return null;
        }
        public static void Reset()
        {
            // Deletes / resets the journal
            if (File.Exists(DataFiles.journalDataFile))
            {
                File.Delete(DataFiles.journalDataFile);
          }
        }
        public static List<LogEntry> TestReturnListOfRandomLogEntries(int count)
        {
            // A Test Function that generates #count of random log entries
            List<LogEntry> returnList = new List<LogEntry>();
            Random rndGenerator = new Random(DateTime.Now.Millisecond); // New random and seed


            for (int i = 0 ; i <= count; i++)
            {
                // Randomly select between a Food or Ex log
                int log_type = rndGenerator.Next(0, 2);
                int rndDay, rndMonth = 0;
                rndDay = rndGenerator.Next(1, 29);
                rndMonth = rndGenerator.Next(1, 13);
                DateTime newTestTime = new DateTime(2018, rndMonth, rndDay);

                if (log_type == 0)
                {
                    // Food Log
                    FoodLogEntry fl = new FoodLogEntry(newTestTime, rndGenerator.Next(100, 500), rndGenerator.Next(0, 35));
                    returnList.Add(fl);
                }
                else
                {
                    // Exercise Log
                    // Food Log
                    ExerciseLogEntry el = new ExerciseLogEntry(newTestTime, rndGenerator.Next(15, 31), rndGenerator.Next(50, 501), Exercise.DefaultExercise);
                    returnList.Add(el);
                }
            }
            return returnList;
        }

    }
}
