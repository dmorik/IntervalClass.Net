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
            var firstNumber = GenerateDoubleNumber();
            var secondNumber = GenerateDoubleNumber();
            var createdInterval = firstNumber <= secondNumber
                ? new Interval(firstNumber, secondNumber)
                : new Interval(secondNumber, firstNumber);

            Assert.IsTrue(!createdInterval.IsEmpty);
        }

        [Test]
        [Repeat(RepeatCount)]
        public void Number_Number_Unordered_Failure()
        {
            var firstNumber = GenerateDoubleNumber();
            var secondNumber = GenerateDoubleNumber();

            while (secondNumber == firstNumber)
            {
                secondNumber = GenerateDoubleNumber();
            }

            var error = ShouldCatchException<IntervalClassException>(() =>
            {
                if (firstNumber <= secondNumber)
                    new Interval(secondNumber, firstNumber);
                else
                    new Interval(firstNumber, secondNumber);
            });

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
            var error = ShouldCatchException<IntervalClassException>(() =>
                new Interval(number, double.NegativeInfinity));

            Assert.IsTrue(error);
        }
    }
}