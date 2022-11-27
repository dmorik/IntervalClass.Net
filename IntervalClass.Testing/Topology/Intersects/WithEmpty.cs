using System.Linq;
using NUnit.Framework;

namespace IntervalClass.Testing.Topology.Intersects
{
    [TestFixture]
    internal sealed class WithEmpty : TestBase
    {
        [Test]
        public void Empty()
        {
            var intersection = Interval.Empty.Intersect(Interval.Empty);
            
            Assert.IsTrue(intersection.IsEmpty);
        }
        
        [Test]
        public void Infinity()
        {
            var intersection = Interval.Empty.Intersect(Interval.Infinity);
            
            Assert.IsTrue(intersection.IsEmpty);
            
            intersection = Interval.Infinity.Intersect(Interval.Empty);
            
            Assert.IsTrue(intersection.IsEmpty);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Common()
        {
            var orderedNumbers = GenerateDoubleNumbers(2)
                .OrderBy(x => x)
                .ToArray();

            var interval = new Interval(orderedNumbers[0], orderedNumbers[1]);
            var intersection = interval.Intersect(Interval.Empty);
            
            Assert.IsTrue(intersection.IsEmpty);
            
            intersection = Interval.Empty.Intersect(interval);
            
            Assert.IsTrue(intersection.IsEmpty);
        }
    }
}