using System.Linq;
using NUnit.Framework;

namespace IntervalClass.Testing.Topology.Intersects
{
    [TestFixture]
    internal sealed class Infinity : TestBase
    {
        [Test]
        public void Infinity_Infinity()
        {
            var intersection = Interval.Infinity.Intersect(Interval.Infinity);
            
            Assert.IsTrue(intersection == Interval.Infinity);
        }
        
        [Test]
        public void Infinity_Empty()
        {
            var intersection = Interval.Infinity.Intersect(Interval.Empty);
            
            Assert.IsTrue(intersection == Interval.Empty);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Infinity_Common()
        {
            var orderedNumbers = GenerateDoubleNumbers(2)
                .OrderBy(x => x)
                .ToArray();

            var interval = new Interval(orderedNumbers[0], orderedNumbers[1]);
            var intersection = Interval.Infinity.Intersect(interval);
            
            Assert.IsTrue(intersection == interval);
        }
    }
}