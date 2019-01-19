using System;
using System.Collections.Generic;
using System.Linq;

namespace fitnosso
{
   public static class ExtensionMethods
    {
        static Random pickRandom = new Random(DateTime.Now.Millisecond);

        public static DateTime GetRandomDateInRange(DateTime date1, DateTime date2)
        {
            if (DateTime.Compare(date1, date2) < 0)
            {
                int startYear, endYear, startMonth, endMonth, startDay, endDay;
                startYear = date1.Year;
                endYear = date2.Year;

                startMonth = date1.Month;
                endMonth = date2.Month;

                startDay = date1.Day;
                endDay = date2.Day;

                int pickRandomMonth, pickRandomYear, pickRandomDay;
                pickRandomYear = pickRandom.Next(startYear, endYear);
                pickRandomMonth = pickRandom.Next(startMonth, endMonth);
                pickRandomDay = pickRandom.Next(startDay, endDay);

                return new DateTime(pickRandomYear, pickRandomMonth, pickRandomDay);

            }
            else
            {
                throw new ArgumentException();
            }
        }
        public static void Print<T>(this ICollection<T> obj) where T : LogEntry
        {
            // prints the contents of an erray
            if (obj.Count > 0)
            {

                for (int i = 0; i < obj.Count; i++)
                {
                    // LogEntry temp = obj.ElementAt(i) as LogEntry;
                    Console.WriteLine(obj.ElementAt(i).EntryDate + " " + obj.ElementAt(i).EntryID);
                    
                }
            }
        }
    }
}
