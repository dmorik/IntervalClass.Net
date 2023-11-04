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
            var width = (interval.UpperBound - interval.LowerBound) * 0.5;

            Assert.That(interval.Radius().Contains(width), Is.True);
        }

        [Test]
        public void Empty_Failure()
        {
            var error = ShouldCatchIntervalClassException(()
                => Interval.Empty.Radius());

            Assert.That(error, Is.True);
        }
    }
}