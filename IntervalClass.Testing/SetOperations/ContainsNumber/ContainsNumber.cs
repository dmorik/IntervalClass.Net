using System.Linq;
using IntervalClass.Net;
using NUnit.Framework;

namespace IntervalClass.Testing.SetOperations
{
    internal sealed class ContainsNumber : TestBase
    {
        [Test]
        [Repeat(RepeatCount)]
        public void Point_Success()
        {
            var number = GenerateDoubleNumber();
            var interval = (Interval)number;
            
            Assert.IsTrue(interval.Contains(number));
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Point_Failure()
        {
            var number = GenerateDoubleNumber();
            var interval = (Interval)number;
            var anotherNumber = GenerateDoubleNumber();
            
            Assert.IsFalse(interval.Contains(anotherNumber));
        }

        [Test]
        [Repeat(RepeatCount)]
        public void Common_Success()
        {
            var numbers = GenerateDoubleNumbers(3)
                .OrderBy(x => x)
                .ToArray();
            var interval = new Interval(numbers[0], numbers[2]);
            var number = numbers[1];
            
            Assert.IsTrue(interval.Contains(number));
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Common_Failure()
        {
            var numbers = GenerateDoubleNumbers(3)
                .OrderBy(x => x)
                .ToArray();
            var interval = new Interval(numbers[0], numbers[1]);
            var number = numbers[2];
            
            Assert.IsFalse(interval.Contains(number));
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Empty_Failure()
        {
            var number = GenerateDoubleNumber();
            
            Assert.IsFalse(Interval.Empty.Contains(number));
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Infinity_Success()
        {
            var number = GenerateDoubleNumber();
            
            Assert.IsTrue(Interval.Infinity.Contains(number));
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void PositiveInfinity_Success()
        {
            var number = GenerateDoubleNumber();

            if (number < 0.0)
                number = -number;
            
            Assert.IsTrue(Interval.PositiveInfinity.Contains(number));
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void PositiveInfinity_Failure()
        {
            var number = GenerateDoubleNumber();

            if (number > 0.0)
                number = -number;
            
            Assert.IsFalse(Interval.PositiveInfinity.Contains(number));
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void NegativeInfinity_Success()
        {
            var number = GenerateDoubleNumber();

            if (number > 0.0)
                number = -number;
            
            Assert.IsTrue(Interval.NegativeInfinity.Contains(number));
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void NegativeInfinity_Failure()
        {
            var number = GenerateDoubleNumber();

            if (number < 0.0)
                number = -number;
            
            Assert.IsFalse(Interval.NegativeInfinity.Contains(number));
        }
    }
}