using System;
using System.Collections.Generic;

// ReSharper disable CompareOfFloatsByEqualityOperator

namespace IntervalClass
{
    public readonly partial struct Interval
    {
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
        /// Indicates that the interval is the point.
        /// </summary>
        /// <returns>True if the interval is the point, False - otherwise.</returns>
        public bool IsPoint()
        {
            if (IsEmpty)
                return false;
            
            return LowerBound == UpperBound;
        }
        
        /// <summary>
        /// Indicates that the interval contains any integer number.
        /// </summary>
        /// <returns>True if the interval contains any integer number, False - otherwise.</returns>
        public bool ContainsAnyInteger()
        {
            if (IsEmpty)
                return false;

            if (double.IsInfinity(LowerBound) || double.IsInfinity(UpperBound))
                return true;
            
            return Math.Floor(UpperBound) >= Math.Ceiling(LowerBound);
        }

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
        /// Returns the width of the interval.
        /// </summary>
        /// <returns>Width of the interval.</returns>
        /// <exception cref="IntervalClassException">Argument is the empty interval.</exception>
        public Interval Width()
        {
            if (IsEmpty)
                throw new IntervalClassException($"Argument is the empty interval");

            if (IsPoint())
                return (Interval)0.0;

            return (Interval)UpperBound - (Interval)LowerBound;
        }

        /// <summary>
        /// Returns the radius of the interval.
        /// </summary>
        /// <returns>The radius of the interval.</returns>
        /// <exception cref="IntervalClassException">Argument is the empty interval.</exception>
        public Interval Radius()
        {
            if (IsEmpty)
                throw new IntervalClassException($"Argument is the empty interval");

            var width = Width();
            var radius = width / (Interval)2.0;
            
            return radius;
        }

        /// <summary>
        /// Returns the middle of the interval.
        /// </summary>
        /// <returns>The middle of the interval.</returns>
        /// <exception cref="IntervalClassException">Argument is the empty interval.</exception>
        public Interval Middle()
        {
            if (IsEmpty)
                throw new IntervalClassException($"Argument is the empty interval");

            if (this == Infinity)
                return (Interval)0.0;

            if (double.IsInfinity(LowerBound) || double.IsInfinity(UpperBound))
                throw new IntervalClassException($"todo error exception message");

            var middle = ((Interval)LowerBound + (Interval)UpperBound) / (Interval)2.0;
            
            // intersects because middle must be into interval
            return middle.Intersect(this);
        }

        public Interval[] Dichotomy()
        {
            if (IsEmpty)
                return Array.Empty<Interval>();

            var middle = Middle();
            var middlePoint = middle.LowerBound;
            var leftPart = new Interval(LowerBound, middlePoint);
            var rightPart = new Interval(middlePoint, UpperBound);

            var result = new List<Interval>();
            
            if (!leftPart.IsPoint())
                result.Add(leftPart);
            
            if (!rightPart.IsPoint())
                result.Add(rightPart);

            return result.Count > 0
                ? result.ToArray()
                : new Interval[] { leftPart };
        }

        public bool IsIntersects(Interval interval)
        {
            return !Intersect(interval).IsEmpty;
        }

        /// <summary>
        /// Returns the magnitude of the interval.
        /// </summary>
        /// <returns>The magnitude of the interval.</returns>
        /// <exception cref="IntervalClassException">Argument is the empty interval.</exception>
        public double Magnitude()
        {
            if (IsEmpty)
                throw new IntervalClassException($"Argument is the empty interval");

            return Math.Max(Math.Abs(LowerBound), Math.Abs(UpperBound));
        }

        /// <summary>
        /// Returns the mignitude of the interval.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="IntervalClassException">Argument is the empty interval.</exception>
        public double Mignitude()
        {
            if (IsEmpty)
                throw new IntervalClassException($"Argument is the empty interval");

            if (Contains(0.0))
                return 0.0;

            return Math.Min(Math.Abs(LowerBound), Math.Abs(UpperBound));
        }
    }
}