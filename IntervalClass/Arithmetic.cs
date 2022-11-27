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
            var leftBound = Previous.Double(firstInterval.LowerBound + secondInterval.LowerBound);
            var rightBound = Next.Double(firstInterval.UpperBound + secondInterval.UpperBound);

            return new Interval(leftBound, rightBound);
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
            var leftBound = Previous.Double(firstInterval.LowerBound - secondInterval.UpperBound);
            var rightBound = Next.Double(firstInterval.UpperBound - secondInterval.LowerBound);

            return new Interval(leftBound, rightBound);
        }

        public static Interval operator *(Interval firstInterval, Interval secondInterval)
        {
            var leftLeft = firstInterval.LowerBound * secondInterval.LowerBound;
            var leftRight = firstInterval.LowerBound * secondInterval.UpperBound;
            var rightLeft = firstInterval.UpperBound * secondInterval.LowerBound;
            var rightRight = firstInterval.UpperBound * secondInterval.UpperBound;

            var leftBound = Previous.Double(Math.Min(Math.Min(leftLeft, leftRight), Math.Min(rightLeft, rightRight)));
            var rightBound = Next.Double(Math.Max(Math.Max(leftLeft, leftRight), Math.Max(rightLeft, rightRight)));

            return new Interval(leftBound, rightBound);
        }

        public static Interval operator /(Interval firstInterval, Interval secondInterval)
        {
            if (secondInterval.Contains(0.0))
                throw new IntervalClassException($"Division by zero");

            var leftLeft = firstInterval.LowerBound / secondInterval.LowerBound;
            var leftRight = firstInterval.LowerBound / secondInterval.UpperBound;
            var rightLeft = firstInterval.UpperBound / secondInterval.LowerBound;
            var rightRight = firstInterval.UpperBound / secondInterval.UpperBound;

            var leftBound = Previous.Double(Math.Min(Math.Min(leftLeft, leftRight), Math.Min(rightLeft, rightRight)));
            var rightBound = Next.Double(Math.Max(Math.Max(leftLeft, leftRight), Math.Max(rightLeft, rightRight)));

            return new Interval(leftBound, rightBound);
        }
    }
}