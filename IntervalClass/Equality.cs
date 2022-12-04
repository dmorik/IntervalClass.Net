namespace IntervalClass
{
    public readonly partial struct Interval
    {
        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (!(obj is Interval anotherInterval))
                return false;

            if (IsEmpty && anotherInterval.IsEmpty)
                return true;

            if (IsEmpty || anotherInterval.IsEmpty)
                return false;
            
            return LowerBound.Equals(anotherInterval.LowerBound) 
                && UpperBound.Equals(anotherInterval.UpperBound);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            if (IsEmpty)
                return double.NaN.GetHashCode();
            
            return LowerBound.GetHashCode() & UpperBound.GetHashCode();
        }
        
        /// <summary>
        /// Indicates equality between first and second intervals. 
        /// </summary>
        /// <param name="firstInterval">The first interval.</param>
        /// <param name="secondInterval">The second interval.</param>
        /// <returns>True if the first interval equals the second interval, False - otherwise.</returns>
        public static bool operator ==(Interval firstInterval, Interval secondInterval)
        {
            return firstInterval.Equals(secondInterval);
        }

        /// <summary>
        /// Indicates inequality between first and second intervals. 
        /// </summary>
        /// <param name="firstInterval">The first interval.</param>
        /// <param name="secondInterval">The second interval.</param>
        /// <returns>True if the first interval unequals the second interval, False - otherwise.</returns>
        public static bool operator !=(Interval firstInterval, Interval secondInterval)
        {
            return !(firstInterval == secondInterval);
        }

        /// <summary>
        /// Indicates equality between the interval and the number intervals. 
        /// </summary>
        /// <param name="interval">The interval.</param>
        /// <param name="number">The number.</param>
        /// <returns>True if the interval equals the number, False - otherwise.</returns>
        public static bool operator ==(Interval interval, double number)
        {
            if (interval.IsEmpty)
                return false;
            
            return interval.LowerBound.Equals(number)
                && interval.UpperBound.Equals(number);
        }

        /// <summary>
        /// Indicates inequality between the interval and the number intervals. 
        /// </summary>
        /// <param name="interval">The interval.</param>
        /// <param name="number">The number.</param>
        /// <returns>True if the interval unequals the number, False - otherwise.</returns>
        public static bool operator !=(Interval interval, double number)
        {
            return !(interval == number);
        }

        /// <summary>
        /// Indicates equality between the interval and the number intervals. 
        /// </summary>
        /// <param name="interval">The interval.</param>
        /// <param name="number">The number.</param>
        /// <returns>True if the interval equals the number, False - otherwise.</returns>
        public static bool operator ==(double number, Interval interval)
        {
            return interval == number;
        }

        /// <summary>
        /// Indicates inequality between the interval and the number intervals. 
        /// </summary>
        /// <param name="interval">The interval.</param>
        /// <param name="number">The number.</param>
        /// <returns>True if the interval unequals the number, False - otherwise.</returns>
        public static bool operator !=(double number, Interval interval)
        {
            return !(interval == number);
        }
    }
}