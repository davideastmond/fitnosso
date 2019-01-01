using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
namespace fitnosso
{
    public class ListPopulator
    {
        /* A helper class that returns a list of numbers or alphabet characters within a certain range */
        public List<double> ReturnIntegersInRange(IEnumerable<double> range)
        {
            List<double> returnList = new List<double>();

            foreach(int i in range)
            {
                returnList.Add(i);
            }
            return returnList;
        }

        public List<double> ReturnIntegersInRange(int start, int max)
        {
            List<double> returnList = new List<double>();

            if (start > max)
            {
                // Swap the values
                for (int i = max; i <= start; i++)
                {
                    returnList.Add(i);
                }
                return returnList;
            }

            // Swap the values
            for (int i = start; i <= max; i++)
            {
                returnList.Add(i);
            }
            return returnList;
           
        }
        public List<char> ReturnAlphabetCharacters(char startChar, char endChar)
        {
            // Upper case the charactes by default
            startChar = char.ToUpper(startChar);
            endChar = char.ToUpper(endChar);
            List<char> returnList = new List<char>();
            if ((int) startChar > (int) endChar)
            {
                int s = (int)startChar;
                int e = (int)endChar;

                for (int element = e; element <=s; element++)
                {
                    returnList.Add((char)element);
                }
                return returnList;
            }
            // else
            int s_ = (int)startChar;
            int e_ = (int)endChar;
            for (int el = s_; el <= e_; el++)
            {
                returnList.Add((char)el);
            }
            return returnList;
        }
        public int[] ReturnIntegerArrayInRange(IEnumerable<int> range)
        {
            throw new NotImplementedException();
        }
        public int[] ReturnIntegerArrayInRange(int start, int max)
        {
            throw new NotImplementedException();
        }

    }
}
