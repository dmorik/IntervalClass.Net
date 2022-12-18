using System.Linq;
using NUnit.Framework;

// ReSharper disable ObjectCreationAsStatement

namespace IntervalClass.Testing.Create
{
    [TestFixture]
    internal sealed class FromNumber : TestBase
    {
        [Test]
        [Repeat(RepeatCount)]
        public void Number_Success()
        {
            var number = GenerateDoubleNumber();
            var createdInterval = new Interval(number);

            Assert.IsTrue(createdInterval != Interval.Empty);
            Assert.IsTrue(createdInterval.LowerBound.Equals(number));
            Assert.IsTrue(createdInterval.UpperBound.Equals(number));
        }

        [Test]
        [Repeat(RepeatCount)]
        public void Number_Number_Ordered_Success()
        {
            var orderedNumbers = GenerateDoubleNumbers(2)
                .OrderBy(x => x)
                .ToArray();
            var lowerBound = orderedNumbers[0];
            var upperBound = orderedNumbers[1];
            var createdInterval = new Interval(lowerBound, upperBound);

            Assert.IsTrue(createdInterval != Interval.Empty);
            Assert.IsTrue(createdInterval.LowerBound.Equals(lowerBound));
            Assert.IsTrue(createdInterval.UpperBound.Equals(upperBound));
        }

        [Test]
        [Repeat(RepeatCount)]
        public void Number_Number_ReverseOrdered_Failure()
        {
            var numbers = GenerateDoubleNumbers(2);
            var reverseOrderedNumbers = numbers
                .OrderByDescending(x => x)
                .ToArray();
            var error = ShouldCatchIntervalClassException(() 
                => new Interval(reverseOrderedNumbers[0], reverseOrderedNumbers[1]));
            
            Assert.IsTrue(error);
        }

        [Test]
        [Repeat(RepeatCount)]
        public void Number_NaN_Failure()
        {
            var number = GenerateDoubleNumber();
            var error = ShouldCatchIntervalClassException(()
                => new Interval(number, double.NaN));

            Assert.IsTrue(error);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Number_PositiveInfinity_Success()
        {
            var number = GenerateDoubleNumber();
            var createdInterval = new Interval(number, double.PositiveInfinity);

            Assert.IsTrue(createdInterval != Interval.Empty);
            Assert.IsTrue(createdInterval.LowerBound.Equals(number));
            Assert.IsTrue(double.IsPositiveInfinity(createdInterval.UpperBound));
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Number_NegativeInfinity_Failure()
        {
            var number = GenerateDoubleNumber();
            var error = ShouldCatchIntervalClassException(() 
                => new Interval(number, double.NegativeInfinity));

            Assert.IsTrue(error);
        }
    }
}