// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

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
            
            Assert.That(interval.IsPoint(), Is.True);
        }

        [Test]
        public void Empty_Failure()
        {
            Assert.That(Interval.Empty.IsPoint(), Is.False);
        }
        
        [Test]
        public void Infinity_Failure()
        {
            Assert.That(Interval.Infinity.IsPoint(), Is.False);
        }
        
        [Test]
        public void NegativeInfinity_Failure()
        {
            Assert.That(Interval.Infinity.IsPoint(), Is.False);
        }
        
        [Test]
        public void PositiveInfinity_Failure()
        {
            Assert.That(Interval.Infinity.IsPoint(), Is.False);
        }

        [Test]
        [Repeat(RepeatCount)]
        public void Common_Failure()
        {
            var interval = GenerateInterval();
 
            Assert.That(interval.IsPoint(), Is.False);
        }
    }
}