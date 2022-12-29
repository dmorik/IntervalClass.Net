namespace IntervalClass.Net
{
    internal static class ErrorMessagesFactory
    {
        public static string ArgumentIsEmptyInterval
            => "Argument is the empty interval";

        public static string LowerBoundIsNan(double lowerBound, double upperBound)
            => $"The lower bound of the interval is 'NaN' {IntervalToString(lowerBound, upperBound)}";

        public static string UpperBoundIsNan(double lowerBound, double upperBound)
            => $"The upper bound of the interval is 'NaN' {IntervalToString(lowerBound, upperBound)}";

        public static string UpperBoundLessThanLowerBound(double lowerBound, double upperBound)
            => $"The lower interval bound must be less or equal than the upper interval bound {IntervalToString(lowerBound, upperBound)}";
        
        private static string NumberToString(double number)
            => Interval.NumberToString(number, Interval.DefaultDigitsAfterPoint);

        private static string IntervalToString(double lowerBound, double upperBound)
            => $"[{NumberToString(lowerBound)}, {NumberToString(upperBound)}]";
    }
}