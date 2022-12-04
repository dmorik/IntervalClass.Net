using System.Linq;
using NUnit.Framework;

namespace IntervalClass.Testing.Topology
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
    }
}