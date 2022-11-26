namespace IntervalClass
{
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

        public bool IsEmpty => !IsNotEmpty;

        /// <summary>
        /// Create interval by two numbers.
        /// </summary>
        /// <param name="leftBound">Lower bound number.</param>
        /// <param name="rightBound">Upper bound number.</param>
        public Interval(double leftBound, double rightBound)
        {
            if (double.IsNaN(leftBound))
                throw new IntervalClassException($"Left bound of interval is 'NaN'");

            if (double.IsNaN(rightBound))
                throw new IntervalClassException($"Right bound of interval is 'NaN'");

            if (leftBound > rightBound)
                throw new IntervalClassException($"Left interval bound must be less or equal than right interval bound ({leftBound}, {rightBound})");

            LowerBound = leftBound;
            UpperBound = rightBound;
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
    }
}
