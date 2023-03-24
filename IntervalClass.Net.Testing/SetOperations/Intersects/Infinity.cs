// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using NUnit.Framework;

namespace IntervalClass.Net.Testing.SetOperations.Intersects
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
            var interval = GenerateInterval();
            var intersection = Interval.Infinity.Intersect(interval);
            
            Assert.IsTrue(intersection == interval);
        }
    }
}