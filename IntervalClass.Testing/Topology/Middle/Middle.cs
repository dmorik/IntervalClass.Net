using System.Linq;
using NUnit.Framework;

namespace IntervalClass.Testing.Topology.Middle
{
    internal sealed class Middle : TestBase
    {
        [Test]
        [Repeat(RepeatCount)]
        public void Point_Success()
        {
            var number = GenerateDoubleNumber();
            var interval = (Interval)number;
            var middle = interval.Middle();
            
            Assert.IsTrue(middle == interval);
        }

        [Test]
        [Repeat(RepeatCount)]
        public void Common_Success()
        {
            var numbers = GenerateDoubleNumbers(2)
                .OrderBy(x => x)
                .ToArray();
            var interval = new Interval(numbers[0], numbers[1]);
            var middle = interval.Middle();
            var middleNumber = (interval.LowerBound + interval.UpperBound) * 0.5;

            Assert.IsTrue(middle.Contains(middleNumber));
        }
        
        [Test]
        public void Infinity_Success()
        {
            var middle = Interval.Infinity.Middle();

            Assert.IsTrue(middle.Contains(0.0));
        }
        
        [Test]
        public void Empty_Failure()
        {
            var error = ShouldCatchIntervalClassException(()
                => Interval.Empty.Middle());

            Assert.IsTrue(error);
        }

        [Test]
        public void PositiveInfinity_Failure()
        {
            var error = ShouldCatchIntervalClassException(()
                => Interval.PositiveInfinity.Middle());
            
            Assert.IsTrue(error);
        }
        
        [Test]
        public void NegativeInfinity_Failure()
        {
            var error = ShouldCatchIntervalClassException(()
                => Interval.NegativeInfinity.Middle());
            
            Assert.IsTrue(error);
        }
    }
}