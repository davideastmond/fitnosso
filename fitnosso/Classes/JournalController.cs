using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using System.Collections.Generic;
using ImageIO;


namespace fitnosso
{
    /// <summary>
    /// A static method
    /// </summary>
    public static class JournalController
    {
        // This is a static class used for common journal operations
        public static FitnessJournal CurrentJournal;
        public static List<LogEntry> FilteredLogs = new List<LogEntry>();
        public static bool IsValidJournal;

        /// <summary>
        /// Retrieves / de-serializes the journal object and assigns the CurrentJournal property, creating a FitnessJournal reference
        /// </summary>
        public static void Pull()
        {
            // 

            BinaryFormatter bf = new BinaryFormatter();
            FileStream fStream = new FileStream(DataFiles.journalDataFile, FileMode.Open, FileAccess.Read);

            FitnessJournal returnJournal;
            try
            {

                returnJournal = (FitnessJournal) bf.Deserialize(fStream);
                CurrentJournal = returnJournal;
                IsValidJournal = true;
                


            } catch (Exception e)
            {
                Console.WriteLine("Journal Controller, pull request problem: " + e.Message);
                IsValidJournal = false;
            }

        }

        /// <summary>
        /// Saves and automatically backs-up the journal
        /// </summary>
        public static void Save()
        {
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
                bF.Serialize(fStream, CurrentJournal);
                Console.WriteLine("Journal file serialized and saved");


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        /// <summary>
        /// This method saves replaces the existing JournalFile with the data provided in the parameter
        /// </summary>
        /// <param name="new_data"> FitnessJournal data that will completely replace the existing fitness journal data </param>
        public static void SaveNew(FitnessJournal new_data)
        {

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
                bF.Serialize(fStream, new_data);
                Console.WriteLine("Journal file serialized and saved");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            fStream.Dispose();
        }

        /// <summary>
        /// This returns all the entries that match the DateTime argument specified 
        /// </summary>
        /// <param name="d1"> Specify a time to match against </param>
        public static void GetAllEntriesByDate (DateTime d1)
        {

            List<LogEntry> returnList = new List<LogEntry>();

            // Pull a recent copy of the journal
           

            // Cycle through the log entry and add those w/ matching dates to return list
            foreach (LogEntry log in CurrentJournal.Logs)
            {
                if (log.EntryDate.Day == d1.Day && log.EntryDate.Month == d1.Month && log.EntryDate.Year == d1.Year)
                {
                    returnList.Add(log);
                }

            }
            FilteredLogs = returnList;
        }

        /// <summary>
        /// Retrieves a single log entry by the unique ID provided. Returns null if no entry found
        /// </summary>
        public static LogEntry GetEntryByID(string IDno)
        {

            IDno = IDno.ToUpper();
            if (CurrentJournal != null)
            {
                foreach (LogEntry j in CurrentJournal.Logs)
                {
                    
                    if (j.EntryID == IDno)
                    {
                        return j; // return the matching ID
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Deletes the FitnessJournal information from the device. It must be re-created manually.
        /// </summary>
        public static void Reset()
        {

            if (File.Exists(DataFiles.journalDataFile))
            {
                File.Delete(DataFiles.journalDataFile);
          }
        }
        /// <summary>
        /// A test method that the returns a list of random log entries.
        /// </summary>
        /// <param name="count"> The number of rnadom log entries to create and return.</param>
        public static void TestReturnListOfRandomLogEntries(int count)
        {
            // A Test Function that generates #count of random log entries
            List<LogEntry> returnList = new List<LogEntry>();
            Random rndGenerator = new Random(DateTime.Now.Millisecond); // New random and seed
            DateTime d1 = new DateTime(2018, 12, 20);
            DateTime d2 = new DateTime(2018, 12, 31);

            for (int i = 0 ; i <= count; i++)
            {
                // Randomly select between a Food or Ex log
                int log_type = rndGenerator.Next(0, 2);

                DateTime newTestTime = ExtensionMethods.GetRandomDateInRange(d1, d2);

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
            CurrentJournal.Logs = returnList;
           
        }

    }
}
