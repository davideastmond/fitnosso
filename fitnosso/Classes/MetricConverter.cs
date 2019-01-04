using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace fitnosso
{
    public struct ImperialHeight
    {
        public int Feet;
        public int Inches;

        public string StringRepresentation
        {
            get
            {
                return Feet.ToString() + "'" + Inches + "\"";
            }
        }
    }
    public static class MetricConverter
    {
        // Easy converter that converts  lbs <-> kilos
        // Inches <-> cm
        // struct ft-inches 

        public static double ToCentimeters(double inches)
        {
            // Converts to Centimeters
            double finalValue = inches * 2.54f;
            return Math.Round(finalValue, 2);
        }
        public static double ToInches(double centimeters)
        {
            double finalValue = centimeters / 2.54f;
            return Math.Round(finalValue, 2);
        }
        public static ImperialHeight ToEmperialHeightFromCentimeters(double centimeters)
        {
            // Converts to ft-inches format
            // First get the inches from the centimeters

            double getInches = MetricConverter.ToInches(centimeters);
            ImperialHeight finalValue;
            finalValue.Feet = (int)(getInches / 12);
            finalValue.Inches = (int)(getInches % 12);
            return finalValue;

        }

        public static ImperialHeight ToEmperialHeightFromInches(double inches)
        {
            ImperialHeight finalValue;
            finalValue.Feet = (int)(inches / 12);
            finalValue.Inches = (int)(inches % 12);
            return finalValue;
        }
        public static double ToKilosFromPounds (double fromPounds)
        {
            double finalValue = fromPounds / 2.205f;
            return Math.Round(finalValue, 2);
        }
        public static double ToPoundsFromKilos(double fromKilos)
        {
            double finalValue = fromKilos * 2.205f;
            return Math.Round(finalValue, 2);
        }
        public static List<double> ConvertListOfHeightsFromCentimetersToInches(List<double> objKind)
        {
            // Get a list of heights in centimeters and return a list of the same heights in inches


            List<double> returnList = new List<double>();
            foreach(int item in objKind)
            {
                double convertedItem = MetricConverter.ToInches((double)item);
                returnList.Add(convertedItem);
            }
            return returnList;

        }
        public static List<int> ConvertListOfHeightsFromCentimetersToInchesInt64(List<double> objKind)
        {
            // Get a list of heights in centimeters and return a list of the same heights in inches


            List<int> returnList = new List<int>();
            foreach (int item in objKind)
            {
                int convertedItem = (int)MetricConverter.ToInches(item);
                returnList.Add(convertedItem);
            }
            List<int> distinctList = returnList.Distinct<int>().ToList();
            return returnList;

        }
        public static List<double> ConvertListOfWeightsFromKilosToPounds(List<double> objKind)
        {
            List<double> returnList = new List<double>();
            foreach (int item in objKind)
            {
                double convertedItem = MetricConverter.ToPoundsFromKilos((double)item);
                returnList.Add(convertedItem);
            }
            
            return returnList;
        }
    }
}
