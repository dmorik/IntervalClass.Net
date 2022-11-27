using NUnit.Framework;

// ReSharper disable ObjectCreationAsStatement

namespace IntervalClass.Testing.Create
{
    [TestFixture]
    internal sealed class FromNan : TestBase
    {
        [Test]
        public void NaN_Failure()
        {
            var error = ShouldCatchException<IntervalClassException>(() => new Interval(double.NaN));

            Assert.IsTrue(error);
        }
        
        [Test]
        public void NaN_NaN_Failure()
        {
            var error = ShouldCatchException<IntervalClassException>(() 
                => new Interval(double.NaN, double.NaN));

            Assert.IsTrue(error);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void NaN_Number_Failure()
        {
            var number = GenerateDoubleNumber();
            var error = ShouldCatchException<IntervalClassException>(()
                => new Interval(double.NaN, number));

            Assert.IsTrue(error);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void NaN_NegativeInfinity_Failure()
        {
            var error = ShouldCatchException<IntervalClassException>(()
                => new Interval(double.NaN, double.NegativeInfinity));

            Assert.IsTrue(error);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void NaN_PositiveInfinity_Failure()
        {
            var error = ShouldCatchException<IntervalClassException>(()
                => new Interval(double.NaN, double.PositiveInfinity));

            Assert.IsTrue(error);
        }
    }
}