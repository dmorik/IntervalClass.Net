// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;

namespace IntervalClass.Net.Testing.Functions.Mignitude
{
    internal sealed class Mignitude : TestBase
    {
        [Test]
        [Repeat(RepeatCount)]
        public void Point_Success()
        {
            var interval = Generate.Interval.Point();
            var mignitude = interval.Mignitude();

            Assert.That(mignitude, Is.EqualTo(Math.Abs(interval.LowerBound)));
        }

        [Test]
        public void Infinity_Success()
        {
            var mignitude = Interval.Infinity.Mignitude();

            Assert.That(mignitude, Is.EqualTo(0.0));
        }

        [Test]
        public void NegativeInfinity_Success()
        {
            var mignitude = Interval.NegativeInfinity.Mignitude();

            Assert.That(mignitude, Is.EqualTo(0.0));
        }

        [Test]
        public void PositiveInfinity_Success()
        {
            var mignitude = Interval.PositiveInfinity.Mignitude();

            Assert.That(mignitude, Is.EqualTo(0.0));
        }

        [Test]
        [Repeat(RepeatCount)]
        public void PositiveInterval_Success()
        {
            var interval = Generate.Interval.Positive();
            var mignitude = interval.LowerBound;

            Assert.That(interval.Mignitude, Is.EqualTo(mignitude));
        }

        [Test]
        [Repeat(RepeatCount)]
        public void NegativeInterval_Success()
        {
            var interval = Generate.Interval.Negative();
            var mignitude = Math.Abs(interval.UpperBound);

            Assert.That(interval.Mignitude, Is.EqualTo(mignitude));
        }

        [Test]
        [Repeat(RepeatCount)]
        public void ZeroContainedInterval_Success()
        {
            var interval = Generate.Interval.WithZero();

            Assert.That(interval.Mignitude, Is.EqualTo(0.0));
        }

        [Test]
        public void Empty_Failure()
        {
            var error = ShouldCatchIntervalClassException(()
                => Interval.Empty.Mignitude());

            Assert.That(error, Is.True);
        }
    }
}