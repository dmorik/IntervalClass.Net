// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using NextAfter.Net;

namespace IntervalClass.Net
{
    public readonly partial struct Interval
    {
        /// <summary>
        /// Calculate the absolute value of the interval.
        /// </summary>
        /// <returns>The absolute value of the interval.</returns>
        /// <exception cref="IntervalClassException">Argument is the empty interval.</exception>
        public Interval Abs()
        {
            if (IsEmpty)
                throw new IntervalClassException(ErrorMessagesFactory.ArgumentIsEmptyInterval);

            var lowerBound = Mignitude();
            var upperBound = Magnitude();

            return new Interval(lowerBound, upperBound);
        }
        
        /// <summary>
        /// Calculate the square value of the interval.
        /// </summary>
        /// <returns>The square value of the interval.</returns>
        /// <exception cref="IntervalClassException">Argument is the empty interval.</exception>
        public Interval Sqr()
        {
            if (IsEmpty)
                throw new IntervalClassException(ErrorMessagesFactory.ArgumentIsEmptyInterval);

            var lowerBoundSqr = LowerBound * LowerBound;
            var upperBoundSqr = UpperBound * UpperBound;
            var upperBound = Next.Double(Math.Max(lowerBoundSqr, upperBoundSqr));
            var lowerBound = Contains(0.0)
                ? 0.0
                : Previous.Double(Math.Min(lowerBoundSqr, upperBoundSqr));

            return new Interval(lowerBound, upperBound);
        }
        
        /// <summary>
        /// Calculate the exponent of the interval.
        /// </summary>
        /// <returns>The exponent of the interval.</returns>
        /// <exception cref="IntervalClassException">Argument is the empty interval.</exception>
        public Interval Exp()
        {
            if (IsEmpty)
                throw new IntervalClassException(ErrorMessagesFactory.ArgumentIsEmptyInterval);

            var lowerBound = Previous.Double(Math.Exp(LowerBound));
            var upperBound = Next.Double(Math.Exp(UpperBound));

            return new Interval(lowerBound, upperBound);
        }

        /// <summary>
        /// Calculate the sinus of the interval.
        /// </summary>
        /// <returns>The sinus of the interval.</returns>
        /// <exception cref="IntervalClassException">Argument is the empty interval.</exception>
        public Interval Sin()
        {
            if (IsEmpty)
                throw new IntervalClassException(ErrorMessagesFactory.ArgumentIsEmptyInterval);

            var leftSin = Math.Sin(LowerBound);
            var rightSin = Math.Sin(UpperBound);

            var lowerBound = (this / TwoPi + (Interval)0.25).IsContainsAnyInteger()
                ? -1.0
                : Previous.Double(Math.Min(leftSin, rightSin));

            var upperBound = (this / TwoPi - (Interval)0.25).IsContainsAnyInteger()
                ? 1.0
                : Next.Double(Math.Max(leftSin, rightSin));

            return new Interval(lowerBound, upperBound);
        }

        /// <summary>
        /// Calculate the cosine of the interval.
        /// </summary>
        /// <returns>The cosine of the interval.</returns>
        /// <exception cref="IntervalClassException">Argument is the empty interval.</exception>
        public Interval Cos()
        {
            if (IsEmpty)
                throw new IntervalClassException(ErrorMessagesFactory.ArgumentIsEmptyInterval);

            return (this + Pi2).Sin();
        }

        /// <summary>
        /// Calculate the tangent of the interval.
        /// </summary>
        /// <returns>The tangent of the interval.</returns>
        /// <exception cref="IntervalClassException">Argument is the empty interval.</exception>
        public Interval Tan()
        {
            if (IsEmpty)
                throw new IntervalClassException(ErrorMessagesFactory.ArgumentIsEmptyInterval);

            return Sin() / Cos();
        }

        /// <summary>
        /// Calculate the square root of the interval.
        /// </summary>
        /// <returns>The square root of the interval.</returns>
        /// <exception cref="IntervalClassException">Argument is the empty interval.</exception>
        public Interval Sqrt()
        {
            if (IsEmpty)
                throw new IntervalClassException(ErrorMessagesFactory.ArgumentIsEmptyInterval);
            
            if (LowerBound < 0.0)
                throw new IntervalClassException($"Invalid argument for sqrt function");

            var lowerBound = Previous.Double(Math.Sqrt(LowerBound));

            if (lowerBound < 0.0)
                lowerBound = 0.0;
            
            var upperBound = Next.Double(Math.Sqrt(UpperBound));

            return new Interval(lowerBound, upperBound);
        }

        /// <summary>
        /// Calculate the sign of the interval.
        /// </summary>
        /// <returns>The sign of the interval.</returns>
        /// <exception cref="IntervalClassException">Argument is the empty interval.</exception>
        public Interval Sign()
        {
            if (IsEmpty)
                throw new IntervalClassException(ErrorMessagesFactory.ArgumentIsEmptyInterval);

            if (UpperBound < 0.0)
                return new Interval(-1.0);

            if (UpperBound <= 0.0)
                return new Interval(-1.0, 0.0);

            if (LowerBound > 0.0)
                return new Interval(1.0);

            if (LowerBound >= 0.0)
                return new Interval(0.0, 1.0);

            return new Interval(-1.0, 1.0);
        }

        /// <summary>
        /// Calculate the arcsine of the interval.
        /// </summary>
        /// <returns>The arcsine of the interval.</returns>
        /// <exception cref="IntervalClassException">Argument is the empty interval.</exception>
        public Interval ArcSin()
        {
            if (IsEmpty)
                throw new IntervalClassException(ErrorMessagesFactory.ArgumentIsEmptyInterval);

            if (LowerBound < -1.0
                || UpperBound > 1.0)
            {
                throw new IntervalClassException($"Invalid argument for arcsin function");
            }

            var lowerBound = Previous.Double(Math.Asin(LowerBound));
            var upperBound = Next.Double(Math.Asin(UpperBound));

            return new Interval(lowerBound, upperBound);
        }

        /// <summary>
        /// Calculate the integer power of the interval.
        /// </summary>
        /// <returns>The integer power of the interval.</returns>
        /// <exception cref="IntervalClassException">Argument is the empty interval.</exception>
        public Interval PowInt(int power)
        {
            if (IsEmpty)
                throw new IntervalClassException(ErrorMessagesFactory.ArgumentIsEmptyInterval);

            if (power < 0)
                return (Interval)1.0 / PowInt(-power);

            var factor = this;
            var result = new Interval(1.0);
            var isEvenPower = power % 2 == 0;

            while (power > 0)
            {
                if (power % 2 == 1)
                {
                    result *= factor;
                }

                factor *= factor;
                power /= 2;
            }

            if (isEvenPower)
                return result.Intersect(PositiveInfinity);

            return result;
        }
    }
}