using NUnit.Framework;

namespace IntervalClass.Testing.Create
{
    [TestFixture]
    internal sealed class Default : TestBase
    {
        [Test]
        public void Default_Success()
        {
            var createdInterval = new Interval();

            Assert.IsTrue(createdInterval == Interval.Empty);
            Assert.IsTrue(double.IsNaN(createdInterval.LowerBound));
            Assert.IsTrue(double.IsNaN(createdInterval.UpperBound));
        }
    }
}