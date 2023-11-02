// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Linq;

namespace IntervalClass.Net.Testing.SetOperations.Intersects
{
    [TestFixture]
    internal sealed class Common : TestBase
    {
        [Test]
        [Repeat(RepeatCount)]
        public void Common_OneSharedPointCommon()
        {
            var orderedNumbers = GenerateDoubleNumbers(3)
                .OrderBy(x => x)
                .ToArray();

            var firstInterval = new Interval(orderedNumbers[0], orderedNumbers[1]);
            var secondInterval = new Interval(orderedNumbers[1], orderedNumbers[2]);

            var intersection = firstInterval.Intersect(secondInterval);
            
            Assert.Multiple(() =>
            {
                Assert.That(intersection.LowerBound, Is.EqualTo(orderedNumbers[1]));
                Assert.That(intersection.UpperBound, Is.EqualTo(orderedNumbers[1]));
            });

            intersection = secondInterval.Intersect(firstInterval);
            
            Assert.Multiple(() =>
            {
                Assert.That(intersection.LowerBound, Is.EqualTo(orderedNumbers[1]));
                Assert.That(intersection.UpperBound, Is.EqualTo(orderedNumbers[1]));
            });
        }

        [Test]
        [Repeat(RepeatCount)]
        public void Common_NotIntersectingCommon()
        {
            var orderedNumbers = GenerateDoubleNumbers(4)
                .OrderBy(x => x)
                .ToArray();

            var firstInterval = new Interval(orderedNumbers[0], orderedNumbers[1]);
            var secondInterval = new Interval(orderedNumbers[2], orderedNumbers[3]);

            var intersection = firstInterval.Intersect(secondInterval);
            
            Assert.That(intersection, Is.EqualTo(Interval.Empty));
            
            intersection = secondInterval.Intersect(firstInterval);
            
            Assert.That(intersection, Is.EqualTo(Interval.Empty));
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Common_ContainingCommon()
        {
            var orderedNumbers = GenerateDoubleNumbers(4)
                .OrderBy(x => x)
                .ToArray();

            var firstInterval = new Interval(orderedNumbers[0], orderedNumbers[3]);
            var secondInterval = new Interval(orderedNumbers[1], orderedNumbers[2]);

            var intersection = firstInterval.Intersect(secondInterval);
            
            Assert.That(intersection, Is.EqualTo(secondInterval));
            
            intersection = secondInterval.Intersect(firstInterval);
            
            Assert.That(intersection, Is.EqualTo(secondInterval));
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Common_SameCommon()
        {
            var interval = GenerateInterval();
            var intersection = interval.Intersect(interval);
            
            Assert.That(intersection, Is.EqualTo(interval));
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Common_IntersectingCommon()
        {
            var orderedNumbers = GenerateDoubleNumbers(4)
                .OrderBy(x => x)
                .ToArray();

            var firstInterval = new Interval(orderedNumbers[0], orderedNumbers[2]);
            var secondInterval = new Interval(orderedNumbers[1], orderedNumbers[3]);
            var shouldIntersection = new Interval(orderedNumbers[1], orderedNumbers[2]);
            var intersection = firstInterval.Intersect(secondInterval);
            
            Assert.That(intersection, Is.EqualTo(shouldIntersection));
            
            intersection = secondInterval.Intersect(firstInterval);
            
            Assert.That(intersection, Is.EqualTo(shouldIntersection));
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Common_Empty()
        {
            var interval = GenerateInterval();
            var intersection = interval.Intersect(Interval.Empty);
            
            Assert.That(intersection, Is.EqualTo(Interval.Empty));
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Common_Infinity()
        {
            var interval = GenerateInterval();
            var intersection = interval.Intersect(Interval.Infinity);
            
            Assert.That(intersection, Is.EqualTo(interval));
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Common_NegativeInfinity()
        {
            var interval = GenerateInterval();
            var intersection = interval.Intersect(Interval.NegativeInfinity);
            var shouldIntersection = interval > 0.0
                ? Interval.Empty
                : new Interval(interval.LowerBound, interval.UpperBound > 0.0 ? 0.0 : interval.UpperBound);
            
            Assert.That(intersection, Is.EqualTo(shouldIntersection));
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Common_PositiveInfinity()
        {
            var interval = GenerateInterval();
            var intersection = interval.Intersect(Interval.PositiveInfinity);
            var shouldIntersection = interval < 0.0
                ? Interval.Empty
                : new Interval(interval.LowerBound < 0.0 ? 0.0 : interval.LowerBound, interval.UpperBound);
            
            Assert.That(intersection, Is.EqualTo(shouldIntersection));
        }
    }
}