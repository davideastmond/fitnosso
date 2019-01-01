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
        public Sex SexGender
        {
            get; set;
        }

        // This just keeps track of the Users height and weight. It will auto-calculate
        public double MetricHeight;
        public double MetricWeight;
        public double ImperialHeight;
        public double ImperialWeight;

        // Keeps track of the preferred primary units of measurement
        public UnitsMode Pref_HeightMeasurementUnit;
        public UnitsMode Pref_WeightMeasurementUnit;


        public User(string pName, Sex pSex, DateTime pDOB)
        {
            // Constructor - create the user profile
            DOB = pDOB;
            Name = pName;
            SexGender = pSex;      
        }
    }
}
