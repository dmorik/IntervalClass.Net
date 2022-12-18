namespace IntervalClass
{
    public readonly partial struct Interval
    {
        /// <summary>
        /// Indicates that the first interval is greater than the second interval.
        /// </summary>
        /// <param name="firstInterval">The first interval.</param>
        /// <param name="secondInterval">The second interval.</param>
        /// <returns>True if the first interval is greater than the second interval, False - otherwise.</returns>
        public static bool operator >(Interval firstInterval, Interval secondInterval)
        {
            if (firstInterval.IsEmpty)
                return false;

            if (secondInterval.IsEmpty)
                return false;
            
            return firstInterval.LowerBound > secondInterval.UpperBound;
        }
        
        /// <summary>
        /// Indicates that the first interval is less than the second interval.
        /// </summary>
        /// <param name="firstInterval">The first interval.</param>
        /// <param name="secondInterval">The second interval.</param>
        /// <returns>True if the first interval is less than the second interval, False - otherwise.</returns>
        public static bool operator <(Interval firstInterval, Interval secondInterval)
        {
            return secondInterval > firstInterval;
        }

        /// <summary>
        /// Indicates that the first interval is greater or equal than the second interval.
        /// </summary>
        /// <param name="firstInterval">The first interval.</param>
        /// <param name="secondInterval">The second interval.</param>
        /// <returns>True if the first interval is greater or equal than the second interval, False - otherwise.</returns>
        public static bool operator >=(Interval firstInterval, Interval secondInterval)
        {
            if (firstInterval.IsEmpty)
                return false;

            if (secondInterval.IsEmpty)
                return false;
            
            return firstInterval.LowerBound >= secondInterval.UpperBound;
        }

        /// <summary>
        /// Indicates that the first interval is less or equal than the second interval.
        /// </summary>
        /// <param name="firstInterval">The first interval.</param>
        /// <param name="secondInterval">The second interval.</param>
        /// <returns>True if the first interval is less or equal than the second interval, False - otherwise.</returns>
        public static bool operator <=(Interval firstInterval, Interval secondInterval)
        {
            return secondInterval >= firstInterval;
        }

        /// <summary>
        /// Indicates that the interval is greater than the number.
        /// </summary>
        /// <param name="interval">The interval.</param>
        /// <param name="number">The number.</param>
        /// <returns>True if the interval is greater than the number, False - otherwise.</returns>
        public static bool operator >(Interval interval, double number)
        {
            if (interval.IsEmpty)
                return false;
            
            return interval.LowerBound > number;
        }

        /// <summary>
        /// Indicates that the interval is less than the number.
        /// </summary>
        /// <param name="interval">The interval.</param>
        /// <param name="number">The number.</param>
        /// <returns>True if the interval is less than the number, False - otherwise.</returns>
        public static bool operator <(Interval interval, double number)
        {
            return interval.UpperBound < number;
        }

        /// <summary>
        /// Indicates that the interval is greater or equal than the number.
        /// </summary>
        /// <param name="interval">The interval.</param>
        /// <param name="number">The number.</param>
        /// <returns>True if the interval is greater or equal than the number, False - otherwise.</returns>
        public static bool operator >=(Interval interval, double number)
        {
            return interval.LowerBound >= number;
        }

        /// <summary>
        /// Indicates that the interval is less or equal than the number.
        /// </summary>
        /// <param name="interval">The interval.</param>
        /// <param name="number">The number.</param>
        /// <returns>True if the interval is less or equal than the number, False - otherwise.</returns>
        public static bool operator <=(Interval interval, double number)
        {
            return interval.UpperBound <= number;
        }
        
        /// <summary>
        /// Indicates that the number is greater than the interval.
        /// </summary>
        /// <param name="interval">The interval.</param>
        /// <param name="number">The number.</param>
        /// <returns>True if the number is greater than the interval, False - otherwise.</returns>
        public static bool operator >(double number, Interval interval)
        {
            return interval > number;
        }

        /// <summary>
        /// Indicates that the number is less than the interval.
        /// </summary>
        /// <param name="interval">The interval.</param>
        /// <param name="number">The number.</param>
        /// <returns>True if the number is less than the interval, False - otherwise.</returns>
        public static bool operator <(double number, Interval interval)
        {
            return interval < number;
        }

        /// <summary>
        /// Indicates that the number is greater or equal than the interval.
        /// </summary>
        /// <param name="interval">The interval.</param>
        /// <param name="number">The number.</param>
        /// <returns>True if the number is greater or equal than the interval, False - otherwise.</returns>
        public static bool operator >=(double number, Interval interval)
        {
            return interval >= number;
        }

        /// <summary>
        /// Indicates that the number is less or equal than the interval.
        /// </summary>
        /// <param name="interval">The interval.</param>
        /// <param name="number">The number.</param>
        /// <returns>True if the number is less or equal than the interval, False - otherwise.</returns>
        public static bool operator <=(double number, Interval interval)
        {
            return interval <= number;
        }
    }
}