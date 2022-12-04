using System.Linq;
using NUnit.Framework;

namespace IntervalClass.Testing.Topology.IsPoint
{
    internal sealed class IsPoint : TestBase
    {
        [Test]
        [Repeat(RepeatCount)]
        public void Point_Success()
        {
            var number = GenerateDoubleNumber();
            var interval = (Interval)number;
            
            Assert.IsTrue(interval.IsPoint());
        }

        [Test]
        public void Empty_Failure()
        {
            Assert.IsFalse(Interval.Empty.IsPoint());
        }
        
        [Test]
        public void Infinity_Failure()
        {
            Assert.IsFalse(Interval.Infinity.IsPoint());
        }
        
        [Test]
        public void NegativeInfinity_Failure()
        {
            Assert.IsFalse(Interval.Infinity.IsPoint());
        }
        
        [Test]
        public void PositiveInfinity_Failure()
        {
            Assert.IsFalse(Interval.Infinity.IsPoint());
        }

        [Test]
        [Repeat(RepeatCount)]
        public void Common_Failure()
        {
            var numbers = GenerateDoubleNumbers(2)
                .OrderBy(x => x)
                .ToArray();
            var interval = new Interval(numbers[0], numbers[1]);
 
            Assert.IsFalse(interval.IsPoint());
        }
    }
}