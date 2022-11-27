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

        /// <inheritdoc/>
        public static bool operator ==(Interval firstInterval, Interval secondInterval)
        {
            return firstInterval.Equals(secondInterval);
        }

        /// <inheritdoc/>
        public static bool operator !=(Interval firstInterval, Interval secondInterval)
        {
            return !(firstInterval == secondInterval);
        }

        /// <inheritdoc/>
        public static bool operator ==(Interval interval, double number)
        {
            if (interval.IsEmpty)
                return false;
            
            return interval.LowerBound.Equals(number)
                && interval.UpperBound.Equals(number);
        }

        /// <inheritdoc/>
        public static bool operator !=(Interval interval, double number)
        {
            return !(interval == number);
        }

        /// <inheritdoc/>
        public static bool operator ==(double number, Interval interval)
        {
            return interval == number;
        }

        /// <inheritdoc/>
        public static bool operator !=(double number, Interval interval)
        {
            return !(interval == number);
        }
    }
}