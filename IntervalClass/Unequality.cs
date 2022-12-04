namespace IntervalClass
{
    public readonly partial struct Interval
    {
        public static bool operator >(Interval firstInterval, Interval secondInterval)
        {
            if (firstInterval.IsEmpty)
                return false;

            if (secondInterval.IsEmpty)
                return false;
            
            return firstInterval.LowerBound > secondInterval.UpperBound;
        }
        public static bool operator <(Interval firstInterval, Interval secondInterval)
        {
            return secondInterval > firstInterval;
        }

        public static bool operator >=(Interval firstInterval, Interval secondInterval)
        {
            if (firstInterval.IsEmpty)
                return false;

            if (secondInterval.IsEmpty)
                return false;
            
            return firstInterval.LowerBound >= secondInterval.UpperBound;
        }

        public static bool operator <=(Interval firstInterval, Interval secondInterval)
        {
            return secondInterval >= firstInterval;
        }

        public static bool operator >(Interval interval, double number)
        {
            if (interval.IsEmpty)
                return false;
            
            return interval.LowerBound > number;
        }

        public static bool operator <(Interval interval, double number)
        {
            return interval.UpperBound < number;
        }

        public static bool operator >(double number, Interval interval)
        {
            return interval > number;
        }

        public static bool operator <(double number, Interval interval)
        {
            return interval < number;
        }

        public static bool operator >=(Interval interval, double number)
        {
            return interval.LowerBound >= number;
        }

        public static bool operator <=(Interval interval, double number)
        {
            return interval.UpperBound <= number;
        }

        public static bool operator >=(double number, Interval interval)
        {
            return interval >= number;
        }

        public static bool operator <=(double number, Interval interval)
        {
            return interval <= number;
        }
    }
}