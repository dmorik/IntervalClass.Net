// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com


// ReSharper disable EqualExpressionComparison

namespace IntervalClass.Net.Testing
{
    [TestFixture]
    internal sealed class EqualityTest : TestBase
    {
        private static void TestEqualIntervals(Interval firstInterval, Interval secondInterval)
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
        public void Infinity_Equals_Infinity()
        {
            var infInterval = Interval.Infinity;
            var anotherInfInterval = new Interval(double.NegativeInfinity, double.PositiveInfinity);

            TestEqualIntervals(infInterval, anotherInfInterval);
        }
        
        [Test]
        public void PositiveInfinity_Equals_PositiveInfinity()
        {
            var positiveInfinityInterval = Interval.PositiveInfinity;
            var anotherPositiveInfinityInterval = new Interval(0.0, double.PositiveInfinity);

            TestEqualIntervals(positiveInfinityInterval, anotherPositiveInfinityInterval);
        }
        
        [Test]
        public void NegativeInfinity_Equals_NegativeInfinity()
        {
            var negativeInfinityInterval = Interval.PositiveInfinity;
            var anotherNegativeInfinityInterval = new Interval(0.0, double.PositiveInfinity);

            TestEqualIntervals(negativeInfinityInterval, anotherNegativeInfinityInterval);
        }

        [Test]
        [Repeat(RepeatCount)]
        public void Common_Equals_SameCommon()
        {
            var interval = GenerateInterval();
            var anotherInterval = new Interval(interval.LowerBound, interval.UpperBound);
            
            TestEqualIntervals(interval, anotherInterval);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Point_Equals_SamePoint()
        {
            var number = GenerateDoubleNumber();
            var interval = new Interval(number);
            var anotherInterval = new Interval(interval.LowerBound, interval.UpperBound);
            
            TestEqualIntervals(interval, anotherInterval);
        }
    }
}
