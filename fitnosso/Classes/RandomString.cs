using System;
using System.Collections.Generic;
using System.Linq;
namespace fitnosso
{

    /// <summary>
    /// A static helper class that returns a string of random alphanumeric characters of the specified length
    /// </summary>
    public static class RandomString
    {
        static Random random = new Random(DateTime.Now.Millisecond);
        /// <summary>
        /// returns a string of random alphanumeric characters of the specified length
        /// <param name="length">Length of the string of random chracters to return.</param>
        /// </summary>

        public static string Generate(int length = 6)
        {

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
