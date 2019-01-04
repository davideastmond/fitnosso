using System;
using System.Collections.Generic;
using System.Linq;
namespace fitnosso
{

    public static class RandomString
    {

        public static string Generate(int length = 6)
        {
            Random random = new Random(DateTime.Now.Millisecond);
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
