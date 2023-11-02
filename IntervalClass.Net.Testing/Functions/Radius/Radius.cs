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
            var number = GenerateDoubleNumber();
            var interval = (Interval)number;
            var radius = interval.Radius();
            
            Assert.IsTrue(radius.Contains(0.0));
        }

        [Test]
        public void Infinity_Failure()
        {
            var error = ShouldCatchIntervalClassException(()
                => Interval.Infinity.Radius());

            Assert.IsTrue(error);
        }

        [Test]
        public void NegativeInfinity_Failure()
        {
            var error = ShouldCatchIntervalClassException(()
                => Interval.NegativeInfinity.Radius());

            Assert.IsTrue(error);
        }

        [Test]
        public void PositiveInfinity_Failure()
        {
            var error = ShouldCatchIntervalClassException(()
                => Interval.PositiveInfinity.Radius());

            Assert.IsTrue(error);
        }

        [Test]
        [Repeat(RepeatCount)]
        public void Common_Success()
        {
            var interval = GenerateInterval();
            var width = (interval.UpperBound - interval.LowerBound) * 0.5;

            Assert.IsTrue(interval.Radius().Contains(width));
        }

        [Test]
        public void Empty_Failure()
        {
            var error = ShouldCatchIntervalClassException(()
                => Interval.Empty.Radius());

            Assert.IsTrue(error);
        }
    }
}