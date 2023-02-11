using System;
using System.Collections.Generic;

namespace IntervalClass.Net
{
    public readonly partial struct Interval
    {
        /// <summary>
        /// Returns the interval intersection with specified interval.
        /// </summary>
        /// <param name="interval">Specified interval.</param>
        /// <returns>Interval intersection with specified interval.</returns>
        public Interval Intersect(Interval interval)
        {
            if (IsEmpty || interval.IsEmpty)
                return Empty;

            var lowerIntersectionBound = Math.Max(LowerBound, interval.LowerBound);
            var upperIntersectionBound = Math.Min(UpperBound, interval.UpperBound);

            if (lowerIntersectionBound > upperIntersectionBound)
                return Empty;

            return new Interval(lowerIntersectionBound, upperIntersectionBound);
        }

        /// <summary>
        /// Returns the interval union with the specified interval.
        /// </summary>
        /// <param name="interval">The specified interval.</param>
        /// <returns>The interval union with the specified interval.</returns>
        public Interval UnityWith(Interval interval)
        {
            if (IsEmpty)
                return interval;

            if (interval.IsEmpty)
                return this;

            var lowerBound = Math.Min(LowerBound, interval.LowerBound);
            var upperBound = Math.Max(UpperBound, interval.UpperBound);

            return new Interval(lowerBound, upperBound);
        }

        /// <summary>
        /// Indicates that the interval contains the specified number.
        /// </summary>
        /// <param name="number">The specified number.</param>
        /// <returns>True if the interval contains the specified number, False - otherwise.</returns>
        public bool Contains(double number)
        {
            if (IsEmpty)
                return false;

            return LowerBound <= number && UpperBound >= number;
        }

        /// <summary>
        /// Indicates that the interval contains the specified interval.
        /// </summary>
        /// <param name="interval">The specified interval.</param>
        /// <returns>True if the interval contains the specified interval, False - otherwise.</returns>
        public bool Contains(Interval interval)
        {
            if (IsEmpty)
                return false;

            if (interval.IsEmpty)
                return false;

            return Contains(interval.LowerBound) && Contains(interval.UpperBound);
        }

        /// <summary>
        /// Returns the set of intervals excluding the specified one.
        /// </summary>
        /// <param name="interval">The specified interval.</param>
        /// <returns></returns>
        public Interval[] Except(Interval interval)
        {
            var intersection = Intersect(interval);

            if (intersection.IsEmpty)
                return new Interval[] { this };

            var leftPart = new Interval(LowerBound, intersection.LowerBound);
            var rightPart = new Interval(intersection.UpperBound, UpperBound);
            var result = new List<Interval>();
            
            if (!leftPart.IsPoint())
                result.Add(leftPart);
            
            if (!rightPart.IsPoint())
                result.Add(rightPart);

            return result.ToArray();
        }
        
        /// <summary>
        /// Returns the interval array consisting of subintervals of the interval.
        /// </summary>
        /// <returns>Empty array if the interval is empty. One element array if it is impossible to make dichotomy. Two elements array otherwise.</returns>
        public Interval[] Dichotomy()
        {
            if (IsEmpty)
                return Array.Empty<Interval>();

            if (IsPoint())
                return new Interval[] { this };
            
            var middle = Middle();
            var middlePoint = middle.LowerBound;
            var middlePointInterval = new Interval(middlePoint);

            return Except(middlePointInterval);
        }

        /// <summary>
        /// Indicates that the interval intersects with specified interval.
        /// </summary>
        /// <param name="interval">The specified interval.</param>
        /// <returns>True if the interval intersects the specified interval, False - otherwise.</returns>
        public bool IsIntersects(Interval interval)
        {
            return !Intersect(interval).IsEmpty;
        }
    }
}