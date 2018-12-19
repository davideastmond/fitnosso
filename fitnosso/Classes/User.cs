using System;
using Foundation;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters;
namespace fitnosso
{
    /* This is the user who owns the fitness journal */
    public enum Sex {Male, Female, Other}
    [Serializable]
    public class User
    {
        public string Name;

        private DateTime DOB;
        public DateTime DateOfBirth
        {
            get
            {
                return DOB;
            }
        }
        public Sex SexGender;
        public int Height_in_cm;
        public int Weight_in_kilos;
        public User(string pName, Sex pSex, DateTime pDOB, int pHeightCentimeters, int pWeightInKilos)
        {
            // Constructor - create the user profile
            DOB = pDOB;
            Name = pName;
            SexGender = pSex;
            Height_in_cm = pHeightCentimeters;
            Weight_in_kilos = pWeightInKilos;
        }
    }
}
