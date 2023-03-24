// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using NUnit.Framework;

namespace IntervalClass.Net.Testing.Functions.IsPoint
{
    internal sealed class IsPoint : TestBase
    {
        [Test]
        [Repeat(RepeatCount)]
        public void Point_Success()
        {
            var number = GenerateDoubleNumber();
            var interval = (Interval)number;
            
            Assert.IsTrue(interval.IsPoint());
        }

        [Test]
        public void Empty_Failure()
        {
            Assert.IsFalse(Interval.Empty.IsPoint());
        }
        
        [Test]
        public void Infinity_Failure()
        {
            Assert.IsFalse(Interval.Infinity.IsPoint());
        }
        
        [Test]
        public void NegativeInfinity_Failure()
        {
            Assert.IsFalse(Interval.Infinity.IsPoint());
        }
        
        [Test]
        public void PositiveInfinity_Failure()
        {
            Assert.IsFalse(Interval.Infinity.IsPoint());
        }

        [Test]
        [Repeat(RepeatCount)]
        public void Common_Failure()
        {
            var interval = GenerateInterval();
 
            Assert.IsFalse(interval.IsPoint());
        }
    }
}