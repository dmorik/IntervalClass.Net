using System;
using System.Linq;
using IntervalType = IntervalClass.Net.Interval;

namespace IntervalClass.Net.Testing
{
    internal static class Generate
    {
        internal static class Interval
        {
            public static IntervalType Any()
            {
                var orderedNumbers = Number.Double.Any(2)
                    .OrderBy(x => x)
                    .ToArray();
                var lowerBound = orderedNumbers[0];
                var upperBound = orderedNumbers[1];

                return new IntervalType(lowerBound, upperBound);
            }

            public static IntervalType Positive()
            {
                var orderedNumbers = Number.Double.Any(2)
                    .Select(x => Math.Abs(x))
                    .OrderBy(x => x)
                    .ToArray();
                var lowerBound = orderedNumbers[0];
                var upperBound = orderedNumbers[1];

                return new IntervalType(lowerBound, upperBound);
            }

            public static IntervalType Negative()
            {
                var orderedNumbers = Number.Double.Any(2)
                    .Select(x => -Math.Abs(x))
                    .OrderBy(x => x)
                    .ToArray();
                var lowerBound = orderedNumbers[0];
                var upperBound = orderedNumbers[1];

                return new IntervalType(lowerBound, upperBound);
            }

            public static IntervalType WithZero()
            {
                var orderedNumbers = Number.Double.Any(2)
                    .Select(x => Math.Abs(x))
                    .OrderBy(x => x)
                    .ToArray();
                var lowerBound = -orderedNumbers[0];
                var upperBound = orderedNumbers[1];

                return new IntervalType(lowerBound, upperBound);
            }

            public static IntervalType Point()
            {
                var number = Number.Double.Any();

                return (IntervalType)number;
            }
        }

        internal static class Number
        {
            private static readonly Random Random = Random.Shared;

            internal static class Double
            {
                public static double Any()
                {
                    var bytes = new byte[sizeof(double)];

                    Random.NextBytes(bytes);

                    var result = BitConverter.ToDouble(bytes);

                    while (!double.IsNormal(result))
                    {
                        Random.NextBytes(bytes);

                        result = BitConverter.ToDouble(bytes);
                    }

                    return result;
                }

                public static double[] Any(int count)
                {
                    if (count <= 0)
                        throw new ArgumentOutOfRangeException(nameof(count));

                    var result = Array.Empty<double>();

                    while (result.Length != count)
                    {
                        result = Enumerable
                            .Range(0, count)
                            .Select(x => Any())
                            .ToArray();
                    }

                    return result;
                }
            }

            internal static class Int
            {
                public static int Any()
                {
                    var bytes = new byte[sizeof(double)];

                    Random.NextBytes(bytes);

                    var result = BitConverter.ToInt32(bytes);

                    while (!double.IsNormal(result)
                        // for middle calculating
                        || result < double.MinValue * 0.5
                        // for middle calculating
                        || result > double.MaxValue * 0.5)
                    {
                        Random.NextBytes(bytes);

                        result = BitConverter.ToInt32(bytes);
                    }

                    return result;
                }
            }
        }
    }
}
