using System;

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
        /// <param name="internalLowerBound">Lower bound of the interval.</param>
        /// <param name="internalUpperBound">Upper bound of the interval.</param>
        /// <returns>The interval with specified lower and upper bounds.</returns>
        public Interval(double internalLowerBound, double internalUpperBound)
        {
            if (double.IsNaN(internalLowerBound))
                throw new IntervalClassException($"Lower bound of interval is 'NaN'");

            if (double.IsNaN(internalUpperBound))
                throw new IntervalClassException($"Upper bound of interval is 'NaN'");

            if (internalLowerBound > internalUpperBound)
                throw new IntervalClassException($"Lower interval bound must be less or equal than upper interval bound ({internalLowerBound}, {internalUpperBound})");

            if (double.IsNegativeInfinity(internalLowerBound) && double.IsNegativeInfinity(internalUpperBound)
                || double.IsPositiveInfinity(internalLowerBound) && double.IsPositiveInfinity(internalUpperBound))
            {
                throw new IntervalClassException($"todo error message");
            }
            
            InternalLowerBound = internalLowerBound;
            InternalUpperBound = internalUpperBound;
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
