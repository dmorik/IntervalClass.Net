using System;
using NextAfter.Net;

namespace IntervalClass
{
    public readonly partial struct Interval
    {
        public static Interval Infinity { get; } = new Interval(double.NegativeInfinity, double.PositiveInfinity);
        public static Interval NegativeInfinity { get; } = new Interval(double.NegativeInfinity, 0.0);
        public static Interval PositiveInfinity { get; } = new Interval(0.0, double.PositiveInfinity);

        /// <summary>
        /// Empty interval.
        /// </summary>
        public static Interval Empty { get; } = new Interval();
        /// <summary>
        /// Pi.
        /// </summary>
        public static Interval Pi { get; } = new Interval(Previous.Double(Math.PI), Next.Double(Math.PI));
    }
}