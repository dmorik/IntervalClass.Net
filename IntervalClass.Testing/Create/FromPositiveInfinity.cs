using IntervalClass.Net;
using NUnit.Framework;

// ReSharper disable ObjectCreationAsStatement

namespace IntervalClass.Testing.Create
{
    [TestFixture]
    internal sealed class FromPositiveInfinity : TestBase
    {
        [Test]
        public void PositiveInfinity_Failure()
        {
            var error = ShouldCatchIntervalClassException(()
                => new Interval(double.PositiveInfinity));

            Assert.IsTrue(error);
        }
        
        [Test]
        public void PositiveInfinity_PositiveInfinity_Failure()
        {
            var error = ShouldCatchIntervalClassException(()
                => new Interval(double.PositiveInfinity));

            Assert.IsTrue(error);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void PositiveInfinity_Number_Failure()
        {
            var number = GenerateDoubleNumber();
            var error = ShouldCatchIntervalClassException(()
                => new Interval(double.PositiveInfinity, number));

            Assert.IsTrue(error);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void PositiveInfinity_NaN_Failure()
        {
            var error = ShouldCatchIntervalClassException(() 
                => new Interval(double.PositiveInfinity, double.NaN));

            Assert.IsTrue(error);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void PositiveInfinity_NegativeInfinity_Failure()
        {
            var error = ShouldCatchIntervalClassException(() 
                => new Interval(double.PositiveInfinity, double.NegativeInfinity));

            Assert.IsTrue(error);
        }
    }
}