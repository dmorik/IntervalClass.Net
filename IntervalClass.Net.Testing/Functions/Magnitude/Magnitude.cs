// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;

namespace IntervalClass.Net.Testing.Functions.Mignitude
{
    internal sealed class Magnitude : TestBase
    {
        [Test]
        [Repeat(RepeatCount)]
        public void Point_Success()
        {
            var interval = Generate.Interval.Point();
            var magnitude = interval.Magnitude();

            Assert.That(magnitude, Is.EqualTo(Math.Abs(interval.LowerBound)));
        }

        [Test]
        public void Infinity_Success()
        {
            var magnitude = Interval.Infinity.Magnitude();

            Assert.That(magnitude, Is.EqualTo(double.PositiveInfinity));
        }

        [Test]
        public void NegativeInfinity_Success()
        {
            var magnitude = Interval.NegativeInfinity.Magnitude();

            Assert.That(magnitude, Is.EqualTo(double.PositiveInfinity));
        }

        [Test]
        public void PositiveInfinity_Success()
        {
            var magnitude = Interval.PositiveInfinity.Magnitude();

            Assert.That(magnitude, Is.EqualTo(double.PositiveInfinity));
        }

        [Test]
        [Repeat(RepeatCount)]
        public void PositiveInterval_Success()
        {
            var interval = Generate.Interval.Positive();
            var magnitude = interval.UpperBound;

            Assert.That(interval.Magnitude, Is.EqualTo(magnitude));
        }

        [Test]
        [Repeat(RepeatCount)]
        public void NegativeInterval_Success()
        {
            var interval = Generate.Interval.Negative();
            var magnitude = Math.Abs(interval.LowerBound);

            Assert.That(interval.Magnitude, Is.EqualTo(magnitude));
        }

        [Test]
        [Repeat(RepeatCount)]
        public void ZeroContainedInterval_Success()
        {
            var interval = Generate.Interval.WithZero();
            var magnitude = Math.Max(interval.LowerBound, interval.UpperBound);

            Assert.That(interval.Magnitude, Is.EqualTo(magnitude));
        }

        [Test]
        public void Empty_Failure()
        {
            var error = ShouldCatchIntervalClassException(()
                => Interval.Empty.Magnitude());

            Assert.That(error, Is.True);
        }
    }
}