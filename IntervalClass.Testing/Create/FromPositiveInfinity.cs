using NUnit.Framework;

// ReSharper disable ObjectCreationAsStatement

namespace IntervalClass.Testing.Create
{
    [TestFixture]
    internal sealed class FromPositiveInfinity : TestBase
    {
        [Test]
        public void PositiveInfinity_Success()
        {
            var createdInterval = new Interval(double.PositiveInfinity);

            Assert.IsTrue(!createdInterval.IsEmpty);
        }
        
        [Test]
        public void PositiveInfinity_PositiveInfinity_Success()
        {
            var createdInterval = new Interval(double.PositiveInfinity);

            Assert.IsTrue(!createdInterval.IsEmpty);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void PositiveInfinity_Number_Success()
        {
            var number = GenerateDoubleNumber();
            var error = ShouldCatchException<IntervalClassException>(() =>
                new Interval(double.PositiveInfinity, number));

            Assert.IsTrue(error);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void PositiveInfinity_NaN_Failure()
        {
            var error = ShouldCatchException<IntervalClassException>(() =>
                new Interval(double.PositiveInfinity, double.NaN));

            Assert.IsTrue(error);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void PositiveInfinity_NegativeInfinity_Failure()
        {
            var error = ShouldCatchException<IntervalClassException>(() =>
                new Interval(double.PositiveInfinity, double.NegativeInfinity));

            Assert.IsTrue(error);
        }
    }
}