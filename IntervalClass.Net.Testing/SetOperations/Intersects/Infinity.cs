// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace IntervalClass.Net.Testing.SetOperations.Intersects
{
    [TestFixture]
    internal sealed class Infinity : TestBase
    {
        [Test]
        public void Infinity_Infinity()
        {
            var intersection = Interval.Infinity.Intersect(Interval.Infinity);
            
            Assert.That(intersection, Is.EqualTo(Interval.Infinity));
        }
        
        [Test]
        public void Infinity_Empty()
        {
            var intersection = Interval.Infinity.Intersect(Interval.Empty);
            
            Assert.That(intersection, Is.EqualTo(Interval.Empty));
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Infinity_Common()
        {
            var interval = GenerateInterval();
            var intersection = Interval.Infinity.Intersect(interval);
            
            Assert.That(intersection, Is.EqualTo(interval));
        }
    }
}