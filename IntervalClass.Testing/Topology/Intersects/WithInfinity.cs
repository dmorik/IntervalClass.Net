using System.Linq;
using NUnit.Framework;

namespace IntervalClass.Testing.Topology.Intersects
{
    [TestFixture]
    internal sealed class WithInfinity : TestBase
    {
        [Test]
        public void Infinity()
        {
            var intersection = Interval.Infinity.Intersect(Interval.Infinity);
            
            Assert.IsTrue(intersection == Interval.Infinity);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Common()
        {
            var orderedNumbers = GenerateDoubleNumbers(2)
                .OrderBy(x => x)
                .ToArray();

            var interval = new Interval(orderedNumbers[0], orderedNumbers[1]);
            var intersection = interval.Intersect(Interval.Infinity);
            
            Assert.IsTrue(intersection == interval);
            
            intersection = Interval.Infinity.Intersect(interval);
            
            Assert.IsTrue(intersection == interval);
        }
    }
}