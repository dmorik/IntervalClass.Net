// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using NUnit.Framework;

namespace IntervalClass.Net.Testing.Functions.Width
{
    internal sealed class Width : TestBase
    {
        [Test]
        [Repeat(RepeatCount)]
        public void Point_Success()
        {
            var number = GenerateDoubleNumber();
            var interval = (Interval)number;
            var width = interval.Width();
            
            Assert.IsTrue(width == 0.0);
        }

        [Test]
        public void Infinity_Failure()
        {
            var error = ShouldCatchIntervalClassException(()
                => Interval.Infinity.Width());

            Assert.IsTrue(error);
        }

        [Test]
        public void NegativeInfinity_Failure()
        {
            var error = ShouldCatchIntervalClassException(()
                => Interval.NegativeInfinity.Width());

            Assert.IsTrue(error);
        }

        [Test]
        public void PositiveInfinity_Failure()
        {
            var error = ShouldCatchIntervalClassException(()
                => Interval.PositiveInfinity.Width());

            Assert.IsTrue(error);
        }

        [Test]
        [Repeat(RepeatCount)]
        public void Common_Success()
        {
            var interval = GenerateInterval();
            var width = interval.UpperBound - interval.LowerBound;

            Assert.IsTrue(interval.Width().Contains(width));
        }

        [Test]
        public void Empty_Failure()
        {
            var error = ShouldCatchIntervalClassException(()
                => Interval.Empty.Width());

            Assert.IsTrue(error);
        }
    }
}