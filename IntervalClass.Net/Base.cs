// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace IntervalClass.Net
{
    /// <summary>
    /// Implements the interval class.
    /// </summary>
    public readonly partial struct Interval
    {
        private double InternalLowerBound { get; }
        /// <summary>
        /// The lower bound of the interval.
        /// </summary>
        public double LowerBound 
            => IsEmpty ? double.NaN : InternalLowerBound;

        private double InternalUpperBound { get; }
        /// <summary>
        /// The upper bound of the interval.
        /// </summary>
        public double UpperBound 
            => IsEmpty ? double.NaN : InternalUpperBound;
        
        private bool IsNotEmpty { get; }
        private bool IsEmpty => !IsNotEmpty;

        /// <summary>
        /// Create the interval by two numbers.
        /// </summary>
        /// <param name="lowerBound">The lower bound of the interval.</param>
        /// <param name="upperBound">The upper bound of the interval.</param>
        /// <returns>The interval with specified lower and upper bounds.</returns>
        public Interval(double lowerBound, double upperBound)
        {
            if (double.IsNaN(lowerBound))
                throw new IntervalClassException(ErrorMessages.LowerBoundIsNan(lowerBound, upperBound));

            if (double.IsNaN(upperBound))
                throw new IntervalClassException(ErrorMessages.UpperBoundIsNan(lowerBound, upperBound));

            if (lowerBound > upperBound)
                throw new IntervalClassException(ErrorMessages.UpperBoundLessThanLowerBound(lowerBound, upperBound));

            if (double.IsNegativeInfinity(lowerBound) && double.IsNegativeInfinity(upperBound)
                || double.IsPositiveInfinity(lowerBound) && double.IsPositiveInfinity(upperBound))
            {
                throw new IntervalClassException(ErrorMessages.UpperBoundLessThanLowerBound(lowerBound, upperBound));
            }
            
            InternalLowerBound = lowerBound;
            InternalUpperBound = upperBound;
            IsNotEmpty = true;
        }
        
        /// <summary>
        /// Create the interval by the single number.
        /// </summary>
        /// <param name="number">Number.</param>
        /// <returns>The interval consisting of the single number.</returns>
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
