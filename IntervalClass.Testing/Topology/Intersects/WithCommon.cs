using System.Linq;
using NUnit.Framework;

namespace IntervalClass.Testing.Topology.Intersects
{
    [TestFixture]
    internal sealed class WithCommon : TestBase
    {
        [Test]
        [Repeat(RepeatCount)]
        public void OneSharedPoint_Common()
        {
            var orderedNumbers = GenerateDoubleNumbers(3)
                .OrderBy(x => x)
                .ToArray();

            var firstInterval = new Interval(orderedNumbers[0], orderedNumbers[1]);
            var secondInterval = new Interval(orderedNumbers[1], orderedNumbers[2]);

            var intersection = firstInterval.Intersect(secondInterval);
            
            Assert.IsTrue(intersection == orderedNumbers[1]);
            
            intersection = secondInterval.Intersect(firstInterval);
            
            Assert.IsTrue(intersection == orderedNumbers[1]);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void NotIntersects_Common()
        {
            var orderedNumbers = GenerateDoubleNumbers(4)
                .OrderBy(x => x)
                .ToArray();

            var firstInterval = new Interval(orderedNumbers[0], orderedNumbers[1]);
            var secondInterval = new Interval(orderedNumbers[2], orderedNumbers[3]);

            var intersection = firstInterval.Intersect(secondInterval);
            
            Assert.IsTrue(intersection.IsEmpty);
            
            intersection = secondInterval.Intersect(firstInterval);
            
            Assert.IsTrue(intersection.IsEmpty);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Contains_Common()
        {
            var orderedNumbers = GenerateDoubleNumbers(4)
                .OrderBy(x => x)
                .ToArray();

            var firstInterval = new Interval(orderedNumbers[0], orderedNumbers[3]);
            var secondInterval = new Interval(orderedNumbers[1], orderedNumbers[2]);

            var intersection = firstInterval.Intersect(secondInterval);
            
            Assert.IsTrue(intersection == secondInterval);
            
            intersection = secondInterval.Intersect(firstInterval);
            
            Assert.IsTrue(intersection == secondInterval);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Same_Common()
        {
            var orderedNumbers = GenerateDoubleNumbers(2)
                .OrderBy(x => x)
                .ToArray();
            var interval = new Interval(orderedNumbers[0], orderedNumbers[1]);
            var intersection = interval.Intersect(interval);
            
            Assert.IsTrue(intersection == interval);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Intersects_Common()
        {
            var orderedNumbers = GenerateDoubleNumbers(4)
                .OrderBy(x => x)
                .ToArray();

            var firstInterval = new Interval(orderedNumbers[0], orderedNumbers[2]);
            var secondInterval = new Interval(orderedNumbers[1], orderedNumbers[3]);
            var shouldIntersection = new Interval(orderedNumbers[1], orderedNumbers[2]);
            var intersection = firstInterval.Intersect(secondInterval);
            
            Assert.IsTrue(intersection == shouldIntersection);
            
            intersection = secondInterval.Intersect(firstInterval);
            
            Assert.IsTrue(intersection == shouldIntersection);
        }
    }
}