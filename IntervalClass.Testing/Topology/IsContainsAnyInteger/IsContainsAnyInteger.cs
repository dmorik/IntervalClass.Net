using NUnit.Framework;

namespace IntervalClass.Testing.Topology.ContainsAnyInteger
{
    internal sealed class ContainsAnyInteger : TestBase
    {
        [Test]
        [Repeat(RepeatCount)]
        public void Empty_Failure()
        {
            Assert.IsFalse(Interval.Empty.IsContainsAnyInteger());
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Infinity_Success()
        {
            Assert.IsTrue(Interval.Infinity.IsContainsAnyInteger());
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void NegativeInfinity_Success()
        {
            Assert.IsTrue(Interval.NegativeInfinity.IsContainsAnyInteger());
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void PositiveInfinity_Success()
        {
            Assert.IsTrue(Interval.PositiveInfinity.IsContainsAnyInteger());
        }
    }
}