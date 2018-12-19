using System;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
namespace fitnosso
{
    /* This class represents an individual log entry */
    [Serializable]
    public abstract class LogEntry
    {
        // Holds the date the log entry was made, not necessarily the date of the exercise
        public readonly DateTime TimeStamp = DateTime.Now;
        public DateTime EntryDate;

    }
    public class FoodLogEntry : LogEntry
    {
        // This is an entry that describes consuming calories and protein
        public int cKalsEaten;
        public int ProteinConsumedInGrams;
        public FoodLogEntry(DateTime forDate, int forcKalsEaten, int forProteinConsumed)
        {
            EntryDate = forDate;
            cKalsEaten = forcKalsEaten;
            ProteinConsumedInGrams = forProteinConsumed;
        }
    }
    public class ExerciseLogEntry : LogEntry
    {
        public int Duration; // Duration of the exercise
        public int cKalsBurned; // How many calories were burned during exercise
        public Exercise ActivityCompleted;
        public ExerciseLogEntry(DateTime forDate, int pDuration, int pKalsBurned, Exercise pACompleted)
        {
            EntryDate = forDate;
            Duration = pDuration;
            cKalsBurned = pKalsBurned;
            ActivityCompleted = pACompleted;
        }
    }
}
