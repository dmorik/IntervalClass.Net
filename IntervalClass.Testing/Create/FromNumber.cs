using System.Linq;
using NUnit.Framework;

// ReSharper disable ObjectCreationAsStatement
// ReSharper disable CompareOfFloatsByEqualityOperator

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

            Assert.IsTrue(!createdInterval.IsEmpty);
        }

        [Test]
        [Repeat(RepeatCount)]
        public void Number_Number_Ordered_Success()
        {
            var numbers = GenerateDoubleNumbers(2);
            var orderedNumber = numbers.OrderBy(x => x).ToArray();
            var createdInterval = new Interval(orderedNumber[0], orderedNumber[1]);

            Assert.IsTrue(!createdInterval.IsEmpty);
        }

        [Test]
        [Repeat(RepeatCount)]
        public void Number_Number_ReverseOrdered_Failure()
        {
            var numbers = GenerateDoubleNumbers(2);
            var reverseOrderedNumbers = numbers.OrderByDescending(x => x).ToArray();
            
            var error = ShouldCatchException<IntervalClassException>(() 
                => new Interval(reverseOrderedNumbers[0], reverseOrderedNumbers[1]));
            
            Assert.IsTrue(error);
        }

        [Test]
        [Repeat(RepeatCount)]
        public void Number_NaN_Failure()
        {
            var number = GenerateDoubleNumber();
            var error = ShouldCatchException<IntervalClassException>(()
                => new Interval(number, double.NaN));

            Assert.IsTrue(error);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Number_PositiveInfinity_Success()
        {
            var number = GenerateDoubleNumber();
            var createdInterval = new Interval(number, double.PositiveInfinity);

            Assert.IsTrue(!createdInterval.IsEmpty);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Number_NegativeInfinity_Failure()
        {
            var number = GenerateDoubleNumber();
            var error = ShouldCatchException<IntervalClassException>(() 
                => new Interval(number, double.NegativeInfinity));

            Assert.IsTrue(error);
        }
    }
}