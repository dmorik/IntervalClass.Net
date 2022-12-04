using System.Linq;
using NUnit.Framework;

namespace IntervalClass.Testing.Topology
{
    internal sealed class ContainsInterval : TestBase
    {
        [Test]
        [Repeat(RepeatCount)]
        public void Point_Success()
        {
            var number = GenerateDoubleNumber();
            var interval = (Interval)number;
            
            Assert.IsTrue(interval.Contains(interval));
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Point_Failure()
        {
            var number = GenerateDoubleNumber();
            var interval = (Interval)number;
            var anotherNumber = GenerateDoubleNumber();
            var anotherInterval = (Interval)anotherNumber;
            
            Assert.IsFalse(interval.Contains(anotherInterval));
        }

        [Test]
        [Repeat(RepeatCount)]
        public void Common_Success()
        {
            var numbers = GenerateDoubleNumbers(4)
                .OrderBy(x => x)
                .ToArray();
            var outerInterval = new Interval(numbers[0], numbers[3]);
            var innerInterval = new Interval(numbers[1], numbers[2]);
            
            Assert.IsTrue(outerInterval.Contains(innerInterval));
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Common_Failure()
        {
            var numbers = GenerateDoubleNumbers(4)
                .OrderBy(x => x)
                .ToArray();
            var interval = new Interval(numbers[0], numbers[2]);
            var anotherInterval = new Interval(numbers[1], numbers[3]);
            
            Assert.IsFalse(interval.Contains(anotherInterval));
            Assert.IsFalse(anotherInterval.Contains(interval));
        }

        [Test]
        [Repeat(RepeatCount)]
        public void Empty_Failure()
        {
            var numbers = GenerateDoubleNumbers(2)
                .OrderBy(x => x)
                .ToArray();
            var interval = new Interval(numbers[0], numbers[1]);
            
            Assert.IsFalse(interval.Contains(Interval.Empty));
            Assert.IsFalse(Interval.Empty.Contains(interval));
        }
    }
}