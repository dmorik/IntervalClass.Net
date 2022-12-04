using NUnit.Framework;

namespace IntervalClass.Testing.Topology
{
    internal sealed class Dichotomy : TestBase
    {
        [Test]
        public void Empty()
        {
            var result = Interval.Empty.Dichotomy();
            
            Assert.IsTrue(result.Length == 0);
        }

        [Test]
        public void Infinity()
        {
            var result = Interval.Infinity.Dichotomy();
            
            Assert.IsTrue(result.Length == 2);
            Assert.IsTrue(result[0] == Interval.NegativeInfinity);
            Assert.IsTrue(result[1] == Interval.PositiveInfinity);
        }
        
        [Test]
        public void NegativeInfinity()
        {
            var error = ShouldCatchIntervalClassException(()
                => Interval.NegativeInfinity.Dichotomy());
            
            Assert.IsTrue(error);
        }
        
        [Test]
        public void PositiveInfinity()
        {
            var error = ShouldCatchIntervalClassException(()
                => Interval.NegativeInfinity.Dichotomy());
            
            Assert.IsTrue(error);
        }
    }
}