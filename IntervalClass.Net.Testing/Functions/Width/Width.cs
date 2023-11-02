// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

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

            Assert.Multiple(() =>
            {
                Assert.That(width.LowerBound, Is.EqualTo(0.0));
                Assert.That(width.UpperBound, Is.EqualTo(0.0));
            });
        }

        [Test]
        public void Infinity_Failure()
        {
            var error = ShouldCatchIntervalClassException(()
                => Interval.Infinity.Width());

            Assert.That(error, Is.True);
        }

        [Test]
        public void NegativeInfinity_Failure()
        {
            var error = ShouldCatchIntervalClassException(()
                => Interval.NegativeInfinity.Width());

            Assert.That(error, Is.True);
        }

        [Test]
        public void PositiveInfinity_Failure()
        {
            var error = ShouldCatchIntervalClassException(()
                => Interval.PositiveInfinity.Width());

            Assert.That(error, Is.True);
        }

        [Test]
        [Repeat(RepeatCount)]
        public void Common_Success()
        {
            var interval = GenerateInterval();
            var width = interval.UpperBound - interval.LowerBound;

            Assert.That(interval.Width().Contains(width), Is.True);
        }

        [Test]
        public void Empty_Failure()
        {
            var error = ShouldCatchIntervalClassException(()
                => Interval.Empty.Width());

            Assert.That(error, Is.True);
        }
    }
}