using System;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
namespace fitnosso
{
    public enum LogType { IN, OUT}
    /* This class represents an individual log entry */
    [Serializable]
    public abstract class LogEntry
    {
        // Holds the date the log entry was made, not necessarily the date of the exercise
        public readonly DateTime CreateDate = DateTime.Now;
        private string _EntryID;
        public DateTime EntryDate;
        public int IDLength = 6;
        public string EntryID
        {
            get
            {
                return _EntryID;
            }
            
        }
        public abstract LogType LogEntryType { get; }

        public LogEntry ()
        {
            _EntryID = RandomString.Generate(IDLength);
        }
    }
    [Serializable]
    public class FoodLogEntry : LogEntry
    {
        // This is an entry that describes consuming calories and protein
        public int cKalsEaten;
        public int ProteinConsumedInGrams;
        public FoodLogEntry(DateTime forDate, int forcKalsEaten, int forProteinConsumed) : base()
        {
            EntryDate = forDate;
            cKalsEaten = forcKalsEaten;
            ProteinConsumedInGrams = forProteinConsumed;
            _LogEntryType = LogType.IN; // meaning calories are intaken 
            
        }
        private LogType _LogEntryType;
        public override LogType LogEntryType
        {
            get
            {
                return _LogEntryType;
            }
        }
    }
    [Serializable]
    public class ExerciseLogEntry : LogEntry
    {
        public int Duration; // Duration of the exercise
        public int cKalsBurned; // How many calories were burned during exercise
        public Exercise ActivityCompleted;

        public ExerciseLogEntry(DateTime forDate, int pDuration, int pKalsBurned, Exercise pACompleted) : base ()
        {
            EntryDate = forDate;
            Duration = pDuration;
            cKalsBurned = pKalsBurned;
            ActivityCompleted = pACompleted;
            _LogEntryType = LogType.OUT; // It's a calorie ou - burning activity log

        }
        private LogType _LogEntryType;
        public override LogType LogEntryType
        {
            get
            {
                return _LogEntryType;
            }
        }
    }
}
