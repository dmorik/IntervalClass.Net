// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Linq;

namespace IntervalClass.Net.Testing.SetOperations.ContainsInterval
{
    internal sealed class ContainsInterval : TestBase
    {
        [Test]
        [Repeat(RepeatCount)]
        public void Point_Success()
        {
            var interval = Generate.Interval.Point();
            
            Assert.That(interval.Contains(interval), Is.True);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Point_Failure()
        {
            var interval = Generate.Interval.Point();
            var anotherInterval = Generate.Interval.Point();

            Assert.That(interval.Contains(anotherInterval), Is.False);
        }

        [Test]
        [Repeat(RepeatCount)]
        public void Common_Success()
        {
            var numbers = Generate.Number.Double.Any(4)
                .OrderBy(x => x)
                .ToArray();
            var outerInterval = new Interval(numbers[0], numbers[3]);
            var innerInterval = new Interval(numbers[1], numbers[2]);
            
            Assert.That(outerInterval.Contains(innerInterval), Is.True);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Common_Failure()
        {
            var numbers = Generate.Number.Double.Any(4)
                .OrderBy(x => x)
                .ToArray();
            var interval = new Interval(numbers[0], numbers[2]);
            var anotherInterval = new Interval(numbers[1], numbers[3]);

            Assert.Multiple(() =>
            {
                Assert.That(interval.Contains(anotherInterval), Is.False);
                Assert.That(anotherInterval.Contains(interval), Is.False);
            });
        }

        [Test]
        [Repeat(RepeatCount)]
        public void Empty_Failure()
        {
            var interval = Generate.Interval.Any();

            Assert.Multiple(() =>
            {
                Assert.That(interval.Contains(Interval.Empty), Is.False);
                Assert.That(Interval.Empty.Contains(interval), Is.False);
            });
        }
    }
}