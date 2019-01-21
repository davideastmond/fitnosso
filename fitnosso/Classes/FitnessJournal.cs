using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters;
using System.Collections.Generic;
using System.IO;


namespace fitnosso
{
    // The actual journal, which is owned by a User and contains a list of LogEntries
    [Serializable]
    public class FitnessJournal
    {
        private User _JOwner;
        public User Owner
        {
            get
            {
                return _JOwner;
            }
        }
        public List<LogEntry> Logs;
        private DateTime _createDate;
        public DateTime CreateDate
        {
            get
            {
                return _createDate;
            }
        }
        public FitnessJournal(User forOwner)
        {
            if (forOwner != null)
            {
                _JOwner = forOwner;
                // Create a default List<T> of Logs
                this.Logs = new List<LogEntry>(); // Instantiate an empty list object
                _createDate = DateTime.Now;

                // Create a default entry
                ExerciseLogEntry myDefaultEntry = this.CreateDefaultEntry();

                // Add the entry to the list
                Logs.Add(myDefaultEntry); // Add
            }
        }
        private ExerciseLogEntry CreateDefaultEntry()
        {
            // Use the static field of the Exercise class to get a default exercise log object
            return new ExerciseLogEntry(DateTime.Now, 0, 0, Exercise.DefaultExercise);

        }
    }

}
