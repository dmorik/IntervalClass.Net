namespace IntervalClass
{
    /// <summary>
    /// Implements the interval class.
    /// </summary>
    public readonly partial struct Interval
    {
        private double InternalLowerBound { get; }
        /// <summary>
        /// Lower bound of interval.
        /// </summary>
        public double LowerBound 
            => IsEmpty ? double.NaN : InternalLowerBound;

        private double InternalUpperBound { get; }
        /// <summary>
        /// Upper bound of interval.
        /// </summary>
        public double UpperBound 
            => IsEmpty ? double.NaN : InternalUpperBound;
        
        private bool IsNotEmpty { get; }
        private bool IsEmpty => !IsNotEmpty;

        /// <summary>
        /// Create interval by two numbers.
        /// </summary>
        /// <param name="lowerBound">Lower bound of the interval.</param>
        /// <param name="upperBound">Upper bound of the interval.</param>
        /// <returns>The interval with specified lower and upper bounds.</returns>
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
            
            InternalLowerBound = lowerBound;
            InternalUpperBound = upperBound;
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
        
        /// <summary>
        /// Represents the double number as the interval.
        /// </summary>
        /// <param name="number">The double number.</param>
        /// <returns>The interval whose boundaries are equal to the number.</returns>
        public static explicit operator Interval(double number)
        {
            return new Interval(number);
        }
    }
}
