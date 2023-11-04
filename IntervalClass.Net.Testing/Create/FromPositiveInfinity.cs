// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com


// ReSharper disable ObjectCreationAsStatement

namespace IntervalClass.Net.Testing.Create
{
    [TestFixture]
    internal sealed class FromPositiveInfinity : TestBase
    {
        [Test]
        public void PositiveInfinity_Failure()
        {
            var error = ShouldCatchIntervalClassException(()
                => new Interval(double.PositiveInfinity));

            Assert.That(error, Is.True);
        }
        
        [Test]
        public void PositiveInfinity_PositiveInfinity_Failure()
        {
            var error = ShouldCatchIntervalClassException(()
                => new Interval(double.PositiveInfinity, double.PositiveInfinity));

            Assert.That(error, Is.True);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void PositiveInfinity_Number_Failure()
        {
            var number = Generate.Number.Double.Any();
            var error = ShouldCatchIntervalClassException(()
                => new Interval(double.PositiveInfinity, number));

            Assert.That(error, Is.True);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void PositiveInfinity_NaN_Failure()
        {
            var error = ShouldCatchIntervalClassException(() 
                => new Interval(double.PositiveInfinity, double.NaN));

            Assert.That(error, Is.True);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void PositiveInfinity_NegativeInfinity_Failure()
        {
            var error = ShouldCatchIntervalClassException(() 
                => new Interval(double.PositiveInfinity, double.NegativeInfinity));

            Assert.That(error, Is.True);
        }
    }
}