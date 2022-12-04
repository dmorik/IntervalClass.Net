using System;
using NextAfter.Net;

namespace IntervalClass
{
    public readonly partial struct Interval
    {
        /// <summary>
        /// Empty interval.
        /// </summary>
        public static Interval Empty { get; } = new Interval();
        /// <summary>
        /// Interval from the negative infinity to the positive infinity.
        /// </summary>
        public static Interval Infinity { get; } = new Interval(double.NegativeInfinity, double.PositiveInfinity);
        /// <summary>
        /// Interval from the negative infinity to the zero.
        /// </summary>
        public static Interval NegativeInfinity { get; } = new Interval(double.NegativeInfinity, 0.0);
        /// <summary>
        /// Interval from the zero to the positive infinity.
        /// </summary>
        public static Interval PositiveInfinity { get; } = new Interval(0.0, double.PositiveInfinity);
        /// <summary>
        /// Pi.
        /// </summary>
        public static Interval Pi { get; } = new Interval(Previous.Double(Math.PI), Next.Double(Math.PI));
        /// <summary>
        /// E.
        /// </summary>
        public static Interval E { get; } = new Interval(Previous.Double(Math.E), Next.Double(Math.E));
    }
}