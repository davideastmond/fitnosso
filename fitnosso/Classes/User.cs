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
        private int BMR_Gender_value_Male = 5;
        private int BMR_Gender_value_Female = -161;

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
                    double bmr_male_return_other = (this._metricHeight * 6.25) + (_metricWeight * 9.99) - (Age * 4.92) + BMR_Gender_value_Male;
                    return Math.Round(bmr_male_return_other, 2);
                } else
                {
                    double bmr_female_return = (this._metricHeight * 6.25) + (_metricWeight * 9.99) - (Age * 4.92) + BMR_Gender_value_Female;
                    return Math.Round(bmr_female_return, 2);
                }
            }
        }
        // private ImperialHeight _ImperialHeightInFeet_Inches;
        public ImperialHeight ImperialHeightInFeet_Inches
        {
            get
            {
                return MetricConverter.ToEmperialHeightFromInches(_IHeight);
            }
        }
        // This just keeps track of the Users height and weight. It will auto-calculate
        private double _metricHeight;
        private double _metricWeight;
        private double _IHeight;
        private double _IWeight;
        
        public double MetricHeight
        {
            get
            {
                // Auto calculate the imperial
                _IHeight = MetricConverter.ToInches(_metricHeight);
                return _metricHeight;
              
            }
            set
            {
                _metricHeight = value;
            }
        }
        public double MetricWeight
        {
            set
            {
                _metricWeight = value;
            }
            get
            {

                _IWeight = MetricConverter.ToPoundsFromKilos(_metricWeight);
                return _metricWeight;
            }
        }


        public double ImperialHeight
        {
            get
            {
                _metricHeight = MetricConverter.ToCentimeters(_IHeight);
                return _IHeight;
            }
            set
            {
                _IHeight = value;
            }
        }
        public double ImperialWeight
        {
            get
            {
                _metricWeight = MetricConverter.ToKilosFromPounds(_IWeight);
                return _IWeight;
            }
            set
            {
                _IWeight = value;
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
        public void SetMetricMeasurements(double mHeight, double mWeight)
        {
            // Helper method to set the heights and weights
            _metricWeight = mWeight;
            _metricHeight = mHeight;
            _IHeight = MetricConverter.ToInches(mHeight);
            _IWeight = MetricConverter.ToPoundsFromKilos(mWeight);
        }
        public void SetImperialMeasurements(double iHeight, double iWeight)
        {
            _IHeight = iHeight;
            _IWeight = iWeight;
            _metricHeight = MetricConverter.ToCentimeters(iHeight);
            _metricWeight = MetricConverter.ToKilosFromPounds(iWeight);

        }
    }
}
