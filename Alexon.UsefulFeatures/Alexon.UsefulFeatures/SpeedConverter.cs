namespace Alexon.UsefulFeatures
{
    public class SpeedConverter
    {
        public static double ConvertToKilometersPerHour(double milesPerHour) => milesPerHour * 1.60934;
        public static double ConvertToMilesPerHour(double kilometersPerHour) => kilometersPerHour / 1.60934;   
        
        public static double ConvertToMetersPerSecondFromMilesPerHour(double milesPerHour) => milesPerHour / 2.23694;       
        public static double ConvertToMilesPerHourFromMetersPerSecond(double metersPerSecond) => metersPerSecond * 2.23694;
        public static double ConvertToMilesPerHourFromKilometersPerHour(double kilometersPerHour) => kilometersPerHour * 0.621371;
    
        public static double ConvertToToKilometersPerHourFromKnots(double knots) => knots * 1.852;
        public static double ConvertToKnotsFromKilometersPerHour(double kilometersPerHour) => kilometersPerHour / 1.852;
    }
}
