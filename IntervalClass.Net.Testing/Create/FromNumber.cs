// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Linq;

// ReSharper disable ObjectCreationAsStatement

namespace IntervalClass.Net.Testing.Create
{
    [TestFixture]
    internal sealed class FromNumber : TestBase
    {
        [Test]
        [Repeat(RepeatCount)]
        public void Number_Success()
        {
            var number = Generate.Number.Double.Any();
            var createdInterval = new Interval(number);
            
            Assert.Multiple(() =>
            {
                Assert.That(createdInterval, Is.Not.EqualTo(Interval.Empty));
                Assert.That(createdInterval.LowerBound, Is.EqualTo(number));
                Assert.That(createdInterval.UpperBound, Is.EqualTo(number));
            });
        }

        [Test]
        [Repeat(RepeatCount)]
        public void Number_Number_Ordered_Success()
        {
            var orderedNumbers = Generate.Number.Double.Any(2)
                .OrderBy(x => x)
                .ToArray();
            var lowerBound = orderedNumbers[0];
            var upperBound = orderedNumbers[1];
            var createdInterval = new Interval(lowerBound, upperBound);
            
            Assert.Multiple(() =>
            {
                Assert.That(createdInterval, Is.Not.EqualTo(Interval.Empty));
                Assert.That(createdInterval.LowerBound, Is.EqualTo(lowerBound));
                Assert.That(createdInterval.UpperBound, Is.EqualTo(upperBound));
            });
        }

        [Test]
        [Repeat(RepeatCount)]
        public void Number_Number_ReverseOrdered_Failure()
        {
            var numbers = Generate.Number.Double.Any(2);
            var reverseOrderedNumbers = numbers
                .OrderByDescending(x => x)
                .ToArray();
            var error = ShouldCatchIntervalClassException(() 
                => new Interval(reverseOrderedNumbers[0], reverseOrderedNumbers[1]));
            
            Assert.That(error, Is.True);
        }

        [Test]
        [Repeat(RepeatCount)]
        public void Number_NaN_Failure()
        {
            var number = Generate.Number.Double.Any();
            var error = ShouldCatchIntervalClassException(()
                => new Interval(number, double.NaN));

            Assert.That(error, Is.True);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Number_PositiveInfinity_Success()
        {
            var number = Generate.Number.Double.Any();
            var createdInterval = new Interval(number, double.PositiveInfinity);
            
            Assert.Multiple(() =>
            {
                Assert.That(createdInterval, Is.Not.EqualTo(Interval.Empty));
                Assert.That(createdInterval.LowerBound, Is.EqualTo(number));
                Assert.That(double.IsPositiveInfinity(createdInterval.UpperBound), Is.True);
            });
        }

        [Test]
        [Repeat(RepeatCount)]
        public void Number_NegativeInfinity_Failure()
        {
            var number = Generate.Number.Double.Any();
            var error = ShouldCatchIntervalClassException(() 
                => new Interval(number, double.NegativeInfinity));

            Assert.That(error, Is.True);
        }
    }
}