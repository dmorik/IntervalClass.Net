using NUnit.Framework;
// ReSharper disable CompareOfFloatsByEqualityOperator

// ReSharper disable ObjectCreationAsStatement

namespace IntervalClass.Testing.Create
{
    [TestFixture]
    internal sealed class FromNegativeInfinity : TestBase
    {
        [Test]
        public void NegativeInfinity_Failure()
        {
            var error = ShouldCatchIntervalClassException(()
                => new Interval(double.NegativeInfinity));

            Assert.IsTrue(error);
        }
        
        [Test]
        public void NegativeInfinity_NegativeInfinity_Failure()
        {
            var error = ShouldCatchIntervalClassException(()
                => new Interval(double.NegativeInfinity, double.NegativeInfinity));

            Assert.IsTrue(error);
        }
        
        [Test]
        public void NegativeInfinity_PositiveInfinity_Success()
        {
            var createdInterval = new Interval(double.NegativeInfinity, double.PositiveInfinity);

            Assert.IsTrue(createdInterval != Interval.Empty);
            Assert.IsTrue(double.IsNegativeInfinity(createdInterval.LowerBound));
            Assert.IsTrue(double.IsPositiveInfinity(createdInterval.UpperBound));
        }

        [Test]
        [Repeat(RepeatCount)]
        public void NegativeInfinity_Number_Success()
        {
            var number = GenerateDoubleNumber();
            var createdInterval = new Interval(double.NegativeInfinity, number);

            Assert.IsTrue(createdInterval != Interval.Empty);
            Assert.IsTrue(double.IsNegativeInfinity(createdInterval.LowerBound));
            Assert.IsTrue(createdInterval.UpperBound == number);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void NegativeInfinity_NaN_Failure()
        {
            var error = ShouldCatchIntervalClassException(() 
                => new Interval(double.NegativeInfinity, double.NaN));

            Assert.IsTrue(error);
        }
    }
}