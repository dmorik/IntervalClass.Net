// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using NextAfter.Net;

namespace IntervalClass.Net
{
    public readonly partial struct Interval
    {
        /// <summary>
        /// Returns the same interval (unary plus).
        /// </summary>
        /// <param name="interval"></param>
        /// <returns></returns>
        public static Interval operator +(Interval interval)
        {
            if (interval.IsEmpty)
                throw new IntervalClassException(ErrorMessagesFactory.ArgumentIsEmptyInterval);
            
            return new Interval(interval.LowerBound, interval.UpperBound);
        }

        /// <summary>
        /// Returns the negative interval (unary minus).
        /// </summary>
        /// <param name="interval"></param>
        /// <returns></returns>
        public static Interval operator -(Interval interval)
        {
            if (interval.IsEmpty)
                throw new IntervalClassException(ErrorMessagesFactory.ArgumentIsEmptyInterval);
            
            return new Interval(-interval.UpperBound, -interval.LowerBound);
        }
        
        /// <summary>
        /// Calculates the result of an addition operation between two intervals.
        /// </summary>
        /// <param name="firstInterval">First interval.</param>
        /// <param name="secondInterval">Second interval.</param>
        /// <returns>Sum of intervals.</returns>
        public static Interval operator +(Interval firstInterval, Interval secondInterval)
        {
            if (firstInterval.IsEmpty)
                throw new IntervalClassException(ErrorMessagesFactory.ArgumentIsEmptyInterval);
            
            if (secondInterval.IsEmpty)
                throw new IntervalClassException(ErrorMessagesFactory.ArgumentIsEmptyInterval);
            
            var lowerBound = Previous.Double(firstInterval.LowerBound + secondInterval.LowerBound);
            var upperBound = Next.Double(firstInterval.UpperBound + secondInterval.UpperBound);

            return new Interval(lowerBound, upperBound);
        }

        /// <summary>
        /// Calculates the result of a subtraction operation between two intervals.
        /// </summary>
        /// <param name="firstInterval">The first interval.</param>
        /// <param name="secondInterval">The second interval.</param>
        /// <returns>The result of a subtraction.</returns>
        public static Interval operator -(Interval firstInterval, Interval secondInterval)
        {
            if (firstInterval.IsEmpty)
                throw new IntervalClassException(ErrorMessagesFactory.ArgumentIsEmptyInterval);
            
            if (secondInterval.IsEmpty)
                throw new IntervalClassException(ErrorMessagesFactory.ArgumentIsEmptyInterval);
            
            var lowerBound = Previous.Double(firstInterval.LowerBound - secondInterval.UpperBound);
            var upperBound = Next.Double(firstInterval.UpperBound - secondInterval.LowerBound);

            return new Interval(lowerBound, upperBound);
        }

        /// <summary>
        /// Calculates the result of a multiplication operation between two intervals.
        /// </summary>
        /// <param name="firstInterval">The first interval.</param>
        /// <param name="secondInterval">The second interval.</param>
        /// <returns>The result of a multiplication.</returns>
        public static Interval operator *(Interval firstInterval, Interval secondInterval)
        {
            if (firstInterval.IsEmpty)
                throw new IntervalClassException(ErrorMessagesFactory.ArgumentIsEmptyInterval);
            
            if (secondInterval.IsEmpty)
                throw new IntervalClassException(ErrorMessagesFactory.ArgumentIsEmptyInterval);
            
            var lowerLower = firstInterval.LowerBound * secondInterval.LowerBound;
            var lowerUpper = firstInterval.LowerBound * secondInterval.UpperBound;
            var upperLower = firstInterval.UpperBound * secondInterval.LowerBound;
            var upperUpper = firstInterval.UpperBound * secondInterval.UpperBound;

            var lowerBound = Previous.Double(Math.Min(Math.Min(lowerLower, lowerUpper), Math.Min(upperLower, upperUpper)));
            var upperBound = Next.Double(Math.Max(Math.Max(lowerLower, lowerUpper), Math.Max(upperLower, upperUpper)));

            return new Interval(lowerBound, upperBound);
        }

        /// <summary>
        /// Calculates the result of a division operation between two intervals.
        /// </summary>
        /// <param name="firstInterval">The first interval.</param>
        /// <param name="secondInterval">The second interval.</param>
        /// <returns>The result of a division.</returns>
        public static Interval operator /(Interval firstInterval, Interval secondInterval)
        {
            if (firstInterval.IsEmpty)
                throw new IntervalClassException(ErrorMessagesFactory.ArgumentIsEmptyInterval);
            
            if (secondInterval.IsEmpty)
                throw new IntervalClassException(ErrorMessagesFactory.ArgumentIsEmptyInterval);
            
            if (secondInterval.Contains(0.0))
                throw new IntervalClassException($"Division by an interval containing zero");

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