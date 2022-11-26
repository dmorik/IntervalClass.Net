using NUnit.Framework;
using System.Runtime.InteropServices;
// ReSharper disable EqualExpressionComparison

namespace IntervalClass.Testing
{
    [TestFixture]
    internal sealed class EqualityTest : TestBase
    {
        private void TestEqualIntervals(Interval firstInterval, Interval secondInterval)
        {
            Assert.IsTrue(firstInterval.Equals(firstInterval));
            Assert.IsTrue(firstInterval.Equals(secondInterval));
            Assert.IsTrue(secondInterval.Equals(firstInterval));
            Assert.IsTrue(secondInterval.Equals(secondInterval));
            
            Assert.IsTrue(firstInterval == firstInterval);
            Assert.IsTrue(firstInterval == secondInterval);
            Assert.IsTrue(secondInterval == firstInterval);
            Assert.IsTrue(secondInterval == secondInterval);
            
            Assert.IsFalse(firstInterval != firstInterval);
            Assert.IsFalse(firstInterval != secondInterval);
            Assert.IsFalse(secondInterval != firstInterval);
            Assert.IsFalse(secondInterval != secondInterval);
        }
        
        [Test]
        public void Empty_Equals_Empty() 
        {
            var emptyInterval = Interval.Empty;
            var anotherEmptyInterval = new Interval();

            TestEqualIntervals(emptyInterval, anotherEmptyInterval);
        }

        [Test]
        public void Inf_Equals_Inf()
        {
            var infInterval = Interval.Infinity;
            var anotherInfInterval = new Interval(double.NegativeInfinity, double.PositiveInfinity);

            TestEqualIntervals(infInterval, anotherInfInterval);
        }
    }
}
