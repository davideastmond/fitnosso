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
            // Extenson method that returns a random date between date1 and date2
            List<DateTime> returnList = new List<DateTime>();

            // Make sure that date2 is later in time than date1

            if (DateTime.Compare(date1, date2) < 0)
            {
                int adddays = 0;
                DateTime tDate = date1;
                while (true)
                {
                    DateTime newDate = date1.AddDays(adddays);
                    adddays++;
                    returnList.Add(newDate);

                    if (DateTime.Compare(newDate, date2) > 0)
                    {
                        break;
                    }

                }
                // Pick an entry
                int finalPick = pickRandom.Next(0, returnList.Count);
                return returnList[finalPick];
            }
            else
            {
                throw new ArgumentException("Date1 must be earlier than date2");
            }
        }
        public static DateTime GetRandomDateInRange2(DateTime date1, DateTime date2)
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
    }
}
