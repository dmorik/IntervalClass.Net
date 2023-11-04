// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;

namespace IntervalClass.Net
{
    public readonly partial struct Interval
    {
        /// <summary>
        /// Indicates that the interval is the point.
        /// </summary>
        /// <returns>True if the interval is the point, False - otherwise.</returns>
        public bool IsPoint()
        {
            if (IsEmpty)
                return false;
            
            return LowerBound.Equals(UpperBound);
        }
        
        /// <summary>
        /// Indicates that the interval contains any integer number.
        /// </summary>
        /// <returns>True if the interval contains any integer number, False - otherwise.</returns>
        public bool IsContainsAnyInteger()
        {
            if (IsEmpty)
                return false;

            if (double.IsInfinity(LowerBound) || double.IsInfinity(UpperBound))
                return true;
            
            return Math.Floor(UpperBound) >= Math.Ceiling(LowerBound);
        }
        
        /// <summary>
        /// Returns the width of the interval.
        /// </summary>
        /// <returns>Width of the interval.</returns>
        /// <exception cref="IntervalClassException">Argument is the empty interval.</exception>
        public Interval Width()
        {
            if (IsEmpty)
                throw new IntervalClassException(ErrorMessages.ArgumentIsEmptyInterval);

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
                throw new IntervalClassException(ErrorMessages.ArgumentIsEmptyInterval);

            if (IsPoint())
                return (Interval)0.0;

            var radius = (Interval)UpperBound * (Interval)0.5 - (Interval)LowerBound * (Interval)0.5;

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
                throw new IntervalClassException(ErrorMessages.ArgumentIsEmptyInterval);

            if (double.IsInfinity(LowerBound) || double.IsInfinity(UpperBound))
                throw new IntervalClassException($"todo error exception message");

            var middle = (Interval)LowerBound * (Interval)0.5 + (Interval)UpperBound * (Interval)0.5;
            
            // intersects because middle must be into interval
            return middle.Intersect(this);
        }

        /// <summary>
        /// Returns the magnitude of the interval.
        /// </summary>
        /// <returns>The magnitude of the interval.</returns>
        /// <exception cref="IntervalClassException">Argument is the empty interval.</exception>
        public double Magnitude()
        {
            if (IsEmpty)
                throw new IntervalClassException(ErrorMessages.ArgumentIsEmptyInterval);

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
                throw new IntervalClassException(ErrorMessages.ArgumentIsEmptyInterval);

            if (Contains(0.0))
                return 0.0;

            return Math.Min(Math.Abs(LowerBound), Math.Abs(UpperBound));
        }
    }
}