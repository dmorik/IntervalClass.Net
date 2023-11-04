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
            var interval = Generate.Interval.Point();
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
            // if width > double.maxvalue then error
            var interval = Generate.Interval.Any() * (Interval)0.5;
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

        [Test]
        public void MaxValue_Failure()
        {
            var error = ShouldCatchIntervalClassException(()
                => new Interval(double.MinValue, double.MaxValue).Width());

            Assert.That(error, Is.True);
        }
    }
}