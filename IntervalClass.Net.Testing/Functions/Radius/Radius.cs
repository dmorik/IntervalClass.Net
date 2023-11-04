// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace IntervalClass.Net.Testing.Functions.Width
{
    internal sealed class Radius : TestBase
    {
        [Test]
        [Repeat(RepeatCount)]
        public void Point_Success()
        {
            var interval = Generate.Interval.Point();
            var radius = interval.Radius();
            
            Assert.That(radius.Contains(0.0), Is.True);
        }

        [Test]
        public void Infinity_Failure()
        {
            var error = ShouldCatchIntervalClassException(()
                => Interval.Infinity.Radius());

            Assert.That(error, Is.True);
        }

        [Test]
        public void NegativeInfinity_Failure()
        {
            var error = ShouldCatchIntervalClassException(()
                => Interval.NegativeInfinity.Radius());

            Assert.That(error, Is.True);
        }

        [Test]
        public void PositiveInfinity_Failure()
        {
            var error = ShouldCatchIntervalClassException(()
                => Interval.PositiveInfinity.Radius());

            Assert.That(error, Is.True);
        }

        [Test]
        [Repeat(RepeatCount)]
        public void Common_Success()
        {
            var interval = Generate.Interval.Any();
            var radius = (interval.UpperBound - interval.LowerBound) * 0.5;

            Assert.That(interval.Radius().Contains(radius), Is.True);
        }

        [Test]
        public void Empty_Failure()
        {
            var error = ShouldCatchIntervalClassException(()
                => Interval.Empty.Radius());

            Assert.That(error, Is.True);
        }

        [Test]
        public void MaxValue_Success()
        {
            var interval = new Interval(double.MinValue, double.MaxValue);
            var radius = double.MaxValue;

            Assert.That(interval.Radius().Contains(radius), Is.True);
        }
    }
}