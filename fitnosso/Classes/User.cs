using System;
using Foundation;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters;
using UIKit;
namespace fitnosso
{
    /* This is the user who owns the fitness journal */
    public enum Sex {Male, Female, Other}
    [Serializable]
    public class User
    {
        public string Name;
        private int BMR_Gender_value_Male = 5;
        private int BMR_Gender_value_Female = -161;

        public UIImage Photo
        {
            // Holds the user profile image
            get; set;
        }
        public int Age
        {
            get
            {
                TimeSpan _Age = DateTime.Today - DateOfBirth;
                return ((int) _Age.TotalDays / 365);
            }
        }
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
        private string _UserID; // Uniqud id used to tag this user
        public string ID
        {
            get
            {
                return _UserID;
            }
        }

        // private double _BMR;
        public double BasalMetabolicRate
        {
            // This calculation is from livestrong.com / article# 184215
            get
            {
                if (this.SexGender == Sex.Male || this.SexGender == Sex.Other)
                {
                    double bmr_male_return_other = (this.MetricHeight * 6.25) + (MetricWeight * 9.99) - (Age * 4.92) + BMR_Gender_value_Male;
                    return Math.Round(bmr_male_return_other, 2);
                } else
                {
                    double bmr_female_return = (this.MetricHeight * 6.25) + (MetricWeight * 9.99) - (Age * 4.92) + BMR_Gender_value_Female;
                    return Math.Round(bmr_female_return, 2);
                }
            }
        }
        // private ImperialHeight _ImperialHeightInFeet_Inches;
        public ImperialHeight ImperialHeightInFeet_Inches
        {
            get
            {
                return MetricConverter.ToEmperialHeightFromInches(ImperialHeight);
            }
        }
        // This just keeps track of the Users height and weight. It will auto-calculate
        private double _MetricHeight, _MetricWeight, _ImperialHeight, _ImperialWeight;

        public double MetricHeight
        {
            get
            {
                return _MetricHeight;
            }
        }
        public double MetricWeight
        {
            get
            {
                return _MetricWeight;
            }
        }

        public double ImperialHeight
        {
            get
            {
                return _ImperialHeight;
            }
        }

        public double ImperialWeight
        {
            get
            {
                return _ImperialWeight;
            }
        }


        // Keeps track of the preferred primary units of measurement
        public UnitsMode Pref_HeightMeasurementUnit;
        public UnitsMode Pref_WeightMeasurementUnit;


        public User(string pName, Sex pSex, DateTime pDOB)
        {
            // Constructor - create the user profile
            DOB = pDOB;
            Name = pName;
            SexGender = pSex;
            _UserID = RandomString.Generate();    
        }

        public void SetMetricWeight (double value)
        {
            _MetricWeight = value;
            // Convert
            _ImperialWeight = MetricConverter.ToPoundsFromKilos(value);

        }
        public void SetMetricHeight (double value)
        {
            _MetricHeight = value;
            _ImperialHeight = MetricConverter.ToInches(value);
        }
        public void SetImperialWeight (double value)
        {
            _ImperialWeight = value;
            _MetricWeight = MetricConverter.ToKilosFromPounds(value);
        }
        public void SetImperialHeight (double value)
        {
            _ImperialHeight = value;
            _MetricHeight = MetricConverter.ToCentimeters(value);
        }
    }
}
