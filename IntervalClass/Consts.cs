using System;
using NextAfter.Net;

namespace IntervalClass
{
    public readonly partial struct Interval
    {
        /// <summary>
        /// The empty interval.
        /// </summary>
        public static Interval Empty { get; } = new Interval();
        /// <summary>
        /// The interval from the negative infinity to the positive infinity.
        /// </summary>
        public static Interval Infinity { get; } = new Interval(double.NegativeInfinity, double.PositiveInfinity);
        /// <summary>
        /// The interval from the negative infinity to the zero.
        /// </summary>
        public static Interval NegativeInfinity { get; } = new Interval(double.NegativeInfinity, 0.0);
        /// <summary>
        /// The interval from the zero to the positive infinity.
        /// </summary>
        public static Interval PositiveInfinity { get; } = new Interval(0.0, double.PositiveInfinity);
        /// <summary>
        /// The Pi interval.
        /// </summary>
        public static Interval Pi { get; } = new Interval(Previous.Double(Math.PI), Next.Double(Math.PI));
        /// <summary>
        /// The (2*Pi) interval.
        /// </summary>
        public static Interval TwoPi { get; } = (Interval)2.0 * Pi;
        /// <summary>
        /// The (Pi/2) interval.
        /// </summary>
        public static Interval Pi2 { get; } = Pi / (Interval)2.0;
        /// <summary>
        /// The E interval.
        /// </summary>
        public static Interval E { get; } = new Interval(Previous.Double(Math.E), Next.Double(Math.E));
    }
}