using System.Linq;
using NUnit.Framework;

namespace IntervalClass.Testing.Topology
{
    internal sealed class ContainsAnyInteger : TestBase
    {
        [Test]
        [Repeat(RepeatCount)]
        public void Empty_Failure()
        {
            Assert.IsFalse(Interval.Empty.ContainsAnyInteger());
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Infinity_Success()
        {
            Assert.IsFalse(Interval.Infinity.ContainsAnyInteger());
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void NegativeInfinity_Success()
        {
            Assert.IsFalse(Interval.NegativeInfinity.ContainsAnyInteger());
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void PositiveInfinity_Success()
        {
            Assert.IsFalse(Interval.PositiveInfinity.ContainsAnyInteger());
        }
    }
}