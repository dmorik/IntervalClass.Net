namespace IntervalClass
{
    /// <summary>
    /// Implements the interval class.
    /// </summary>
    public readonly partial struct Interval
    {
        /// <summary>
        /// Lower bound of interval.
        /// </summary>
        public double LowerBound { get; }
        /// <summary>
        /// Upper bound of interval.
        /// </summary>
        public double UpperBound { get; }
        
        private bool IsNotEmpty { get; }

        /// <summary>
        /// Indicates that interval is empty.
        /// </summary>
        private bool IsEmpty => !IsNotEmpty;

        /// <summary>
        /// Create interval by two numbers.
        /// </summary>
        /// <param name="lowerBound">Lower bound number.</param>
        /// <param name="upperBound">Upper bound number.</param>
        public Interval(double lowerBound, double upperBound)
        {
            if (double.IsNaN(lowerBound))
                throw new IntervalClassException($"Lower bound of interval is 'NaN'");

            if (double.IsNaN(upperBound))
                throw new IntervalClassException($"Upper bound of interval is 'NaN'");

            if (lowerBound > upperBound)
                throw new IntervalClassException($"Lower interval bound must be less or equal than upper interval bound ({lowerBound}, {upperBound})");

            if (double.IsNegativeInfinity(lowerBound) && double.IsNegativeInfinity(upperBound)
                || double.IsPositiveInfinity(lowerBound) && double.IsPositiveInfinity(upperBound))
            {
                throw new IntervalClassException($"todo error message");
            }
            
            LowerBound = lowerBound;
            UpperBound = upperBound;
            IsNotEmpty = true;
        }
        
        /// <summary>
        /// Create interval by single number.
        /// </summary>
        /// <param name="number">Number.</param>
        /// <returns>Interval consisting of a single number.</returns>
        public Interval(double number)
            : this(number, number)
        { }
        
        public static explicit operator Interval(double number)
        {
            return new Interval(number);
        }
    }
}
