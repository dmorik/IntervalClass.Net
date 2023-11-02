// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace IntervalClass.Net.Testing.Functions.IsContainsAnyInteger
{
    internal sealed class ContainsAnyInteger : TestBase
    {
        [Test]
        public void Empty_Failure()
        {
            Assert.That(Interval.Empty.IsContainsAnyInteger(), Is.False);
        }
        
        [Test]
        public void Infinity_Success()
        {
            Assert.That(Interval.Infinity.IsContainsAnyInteger(), Is.True);
        }
        
        [Test]
        public void NegativeInfinity_Success()
        {
            Assert.That(Interval.NegativeInfinity.IsContainsAnyInteger(), Is.True);
        }
        
        [Test]
        public void PositiveInfinity_Success()
        {
            Assert.That(Interval.PositiveInfinity.IsContainsAnyInteger(), Is.True);
        }

        [Test]
        [Repeat(RepeatCount)]
        public void IntegerNumber_Success()
        {
            var integer = GenerateIntNumber();
            var interval = new Interval(integer);

            Assert.That(interval.IsContainsAnyInteger(), Is.True);
        }
    }
}