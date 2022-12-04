using System;
using NextAfter.Net;

namespace IntervalClass
{
    public readonly partial struct Interval
    {
        /// <summary>
        /// Returns sum of two intervals.
        /// </summary>
        /// <param name="firstInterval">First interval.</param>
        /// <param name="secondInterval">Second interval.</param>
        /// <returns>Sum of intervals.</returns>
        public static Interval operator +(Interval firstInterval, Interval secondInterval)
        {
            var lowerBound = Previous.Double(firstInterval.LowerBound + secondInterval.LowerBound);
            var upperBound = Next.Double(firstInterval.UpperBound + secondInterval.UpperBound);

            return new Interval(lowerBound, upperBound);
        }

        /// <summary>
        /// Returns the same interval (unary plus).
        /// </summary>
        /// <param name="interval"></param>
        /// <returns></returns>
        public static Interval operator +(Interval interval)
        {
            return new Interval(interval.LowerBound, interval.UpperBound);
        }

        /// <summary>
        /// Returns the negative interval (unary minus).
        /// </summary>
        /// <param name="interval"></param>
        /// <returns></returns>
        public static Interval operator -(Interval interval)
        {
            return new Interval(-interval.UpperBound, -interval.LowerBound);
        }

        public static Interval operator -(Interval firstInterval, Interval secondInterval)
        {
            var lowerBound = Previous.Double(firstInterval.LowerBound - secondInterval.UpperBound);
            var upperBound = Next.Double(firstInterval.UpperBound - secondInterval.LowerBound);

            return new Interval(lowerBound, upperBound);
        }

        public static Interval operator *(Interval firstInterval, Interval secondInterval)
        {
            var lowerLower = firstInterval.LowerBound * secondInterval.LowerBound;
            var lowerUpper = firstInterval.LowerBound * secondInterval.UpperBound;
            var upperLower = firstInterval.UpperBound * secondInterval.LowerBound;
            var upperUpper = firstInterval.UpperBound * secondInterval.UpperBound;

            var lowerBound = Previous.Double(Math.Min(Math.Min(lowerLower, lowerUpper), Math.Min(upperLower, upperUpper)));
            var upperBound = Next.Double(Math.Max(Math.Max(lowerLower, lowerUpper), Math.Max(upperLower, upperUpper)));

            return new Interval(lowerBound, upperBound);
        }

        public static Interval operator /(Interval firstInterval, Interval secondInterval)
        {
            if (secondInterval.Contains(0.0))
                throw new IntervalClassException($"Division by zero");

            var lowerLower = firstInterval.LowerBound / secondInterval.LowerBound;
            var lowerUpper = firstInterval.LowerBound / secondInterval.UpperBound;
            var upperLower = firstInterval.UpperBound / secondInterval.LowerBound;
            var upperUpper = firstInterval.UpperBound / secondInterval.UpperBound;

            var lowerBound = Previous.Double(Math.Min(Math.Min(lowerLower, lowerUpper), Math.Min(upperLower, upperUpper)));
            var upperBound = Next.Double(Math.Max(Math.Max(lowerLower, lowerUpper), Math.Max(upperLower, upperUpper)));

            return new Interval(lowerBound, upperBound);
        }
    }
}