// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace IntervalClass.Net.Testing.SetOperations.Intersects
{
    [TestFixture]
    internal sealed class Empty : TestBase
    {
        [Test]
        public void Empty_Empty()
        {
            var intersection = Interval.Empty.Intersect(Interval.Empty);
            
            Assert.That(intersection, Is.EqualTo(Interval.Empty));
        }
        
        [Test]
        public void Empty_Infinity()
        {
            var intersection = Interval.Empty.Intersect(Interval.Infinity);
            
            Assert.That(intersection, Is.EqualTo(Interval.Empty));
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Empty_Common()
        {
            var interval = GenerateInterval();
            var intersection = Interval.Empty.Intersect(interval);
            
            Assert.That(intersection, Is.EqualTo(Interval.Empty));
        }
    }
}