// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace IntervalClass.Net.Testing.Functions.IsContainsAnyInteger
{
    internal sealed class ContainsAnyInteger : TestBase
    {
        [Test]
        public void Empty_Failure()
        {
            Assert.IsFalse(Interval.Empty.IsContainsAnyInteger());
        }
        
        [Test]
        public void Infinity_Success()
        {
            Assert.IsTrue(Interval.Infinity.IsContainsAnyInteger());
        }
        
        [Test]
        public void NegativeInfinity_Success()
        {
            Assert.IsTrue(Interval.NegativeInfinity.IsContainsAnyInteger());
        }
        
        [Test]
        public void PositiveInfinity_Success()
        {
            Assert.IsTrue(Interval.PositiveInfinity.IsContainsAnyInteger());
        }

        [Test]
        [Repeat(RepeatCount)]
        public void IntegerNumber_Success()
        {
            var integer = GenerateIntNumber();
            var interval = new Interval(integer);

            Assert.IsTrue(interval.IsContainsAnyInteger());
        }
    }
}