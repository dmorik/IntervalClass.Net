using NUnit.Framework;

// ReSharper disable ObjectCreationAsStatement

namespace IntervalClass.Testing.Create
{
    [TestFixture]
    internal sealed class FromNegativeInfinity : TestBase
    {
        [Test]
        public void NegativeInfinity_Success()
        {
            var createdInterval = new Interval(double.NegativeInfinity);

            Assert.IsTrue(!createdInterval.IsEmpty);
        }
        
        [Test]
        public void NegativeInfinity_NegativeInfinity_Success()
        {
            var createdInterval = new Interval(double.NegativeInfinity, double.NegativeInfinity);

            Assert.IsTrue(!createdInterval.IsEmpty);
        }
        
        [Test]
        public void NegativeInfinity_PositiveInfinity_Success()
        {
            var createdInterval = new Interval(double.NegativeInfinity, double.PositiveInfinity);

            Assert.IsTrue(!createdInterval.IsEmpty);
        }

        [Test]
        [Repeat(RepeatCount)]
        public void NegativeInfinity_Number_Success()
        {
            var number = GenerateDoubleNumber();
            var createdInterval = new Interval(double.NegativeInfinity, number);

            Assert.IsTrue(!createdInterval.IsEmpty);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void NegativeInfinity_NaN_Failure()
        {
            var error = ShouldCatchException<IntervalClassException>(() =>
                new Interval(double.NegativeInfinity, double.NaN));

            Assert.IsTrue(error);
        }
    }
}