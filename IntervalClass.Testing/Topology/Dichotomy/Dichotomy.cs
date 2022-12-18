using System.Linq;
using NextAfter.Net;
using NUnit.Framework;

namespace IntervalClass.Testing.Topology.Dichotomy
{
    internal sealed class Dichotomy : TestBase
    {
        [Test]
        public void Empty_Success()
        {
            var error = ShouldCatchIntervalClassException(()
                => Interval.Empty.Dichotomy());
            
            Assert.IsTrue(error);
        }

        [Test]
        public void Infinity_Success()
        {
            var result = Interval.Infinity.Dichotomy();
            
            Assert.IsTrue(result.Length == 2);
            Assert.IsTrue(result[0] == Interval.NegativeInfinity);
            Assert.IsTrue(result[1] == Interval.PositiveInfinity);
        }
        
        [Test]
        public void NegativeInfinity_Failure()
        {
            var error = ShouldCatchIntervalClassException(()
                => Interval.NegativeInfinity.Dichotomy());
            
            Assert.IsTrue(error);
        }
        
        [Test]
        public void PositiveInfinity_Failure()
        {
            var error = ShouldCatchIntervalClassException(()
                => Interval.NegativeInfinity.Dichotomy());
            
            Assert.IsTrue(error);
        }

        [Test]
        [Repeat(RepeatCount)]
        public void Point_Success()
        {
            var number = GenerateDoubleNumber();
            var interval = new Interval(number);
            var dichotomyResult = interval.Dichotomy();
            
            Assert.IsTrue(dichotomyResult.Length == 1);
            Assert.IsTrue(dichotomyResult[0] == interval);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Common_Success()
        {
            var orderedNumbers = GenerateDoubleNumbers(2)
                .OrderBy(x => x)
                .ToArray();
            var lowerBound = orderedNumbers[0];
            var upperBound = orderedNumbers[1];
            var interval = new Interval(lowerBound, upperBound);
            var dichotomyResult = interval.Dichotomy();
            
            Assert.IsTrue(dichotomyResult.Length == 2);
            Assert.IsTrue(dichotomyResult[0].LowerBound.Equals(lowerBound));
            Assert.IsTrue(dichotomyResult[1].UpperBound.Equals(upperBound));
            Assert.IsTrue(dichotomyResult[0].UpperBound.Equals(dichotomyResult[1].LowerBound));
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void TwoNeighboursDoubleInterval_Success()
        {
            var number = GenerateDoubleNumber();
            var nextNumber = Next.Double(number);
            var interval = new Interval(number, nextNumber);
            var dichotomyResult = interval.Dichotomy();
            
            Assert.IsTrue(dichotomyResult.Length == 1);
            Assert.IsTrue(dichotomyResult[0].Equals(interval));
        }
    }
}