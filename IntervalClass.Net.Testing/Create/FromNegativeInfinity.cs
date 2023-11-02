// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com


// ReSharper disable ObjectCreationAsStatement

namespace IntervalClass.Net.Testing.Create
{
    [TestFixture]
    internal sealed class FromNegativeInfinity : TestBase
    {
        [Test]
        public void NegativeInfinity_Failure()
        {
            var error = ShouldCatchIntervalClassException(()
                => new Interval(double.NegativeInfinity));

            Assert.That(error, Is.True);
        }
        
        [Test]
        public void NegativeInfinity_NegativeInfinity_Failure()
        {
            var error = ShouldCatchIntervalClassException(()
                => new Interval(double.NegativeInfinity, double.NegativeInfinity));

            Assert.That(error, Is.True);
        }
        
        [Test]
        public void NegativeInfinity_PositiveInfinity_Success()
        {
            var createdInterval = new Interval(double.NegativeInfinity, double.PositiveInfinity);
            
            Assert.Multiple(() =>
            {
                Assert.That(createdInterval, Is.Not.EqualTo(Interval.Empty));
                Assert.That(double.IsNegativeInfinity(createdInterval.LowerBound), Is.True);
                Assert.That(double.IsPositiveInfinity(createdInterval.UpperBound), Is.True);
            });
        }

        [Test]
        [Repeat(RepeatCount)]
        public void NegativeInfinity_Number_Success()
        {
            var number = GenerateDoubleNumber();
            var createdInterval = new Interval(double.NegativeInfinity, number);
            
            Assert.Multiple(() =>
            {
                Assert.That(createdInterval, Is.Not.EqualTo(Interval.Empty));
                Assert.That(double.IsNegativeInfinity(createdInterval.LowerBound), Is.True);
                Assert.That(createdInterval.UpperBound, Is.EqualTo(number));
            });
        }

        [Test]
        [Repeat(RepeatCount)]
        public void NegativeInfinity_NaN_Failure()
        {
            var error = ShouldCatchIntervalClassException(() 
                => new Interval(double.NegativeInfinity, double.NaN));

            Assert.That(error, Is.True);
        }
    }
}