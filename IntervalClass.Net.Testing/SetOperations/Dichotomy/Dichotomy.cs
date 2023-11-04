// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using NextAfter.Net;

namespace IntervalClass.Net.Testing.SetOperations.Dichotomy
{
    internal sealed class Dichotomy : TestBase
    {
        [Test]
        public void Empty_Success()
        {
            var result = Interval.Empty.Dichotomy();
            
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void Infinity_Success()
        {
            var error = ShouldCatchIntervalClassException(()
               => Interval.Infinity.Dichotomy());

            Assert.That(error, Is.True);
        }
        
        [Test]
        public void NegativeInfinity_Failure()
        {
            var error = ShouldCatchIntervalClassException(()
                => Interval.NegativeInfinity.Dichotomy());
            
            Assert.That(error, Is.True);
        }
        
        [Test]
        public void PositiveInfinity_Failure()
        {
            var error = ShouldCatchIntervalClassException(()
                => Interval.PositiveInfinity.Dichotomy());
            
            Assert.That(error, Is.True);
        }

        [Test]
        [Repeat(RepeatCount)]
        public void Point_Success()
        {
            var interval = Generate.Interval.Point();
            var dichotomyResult = interval.Dichotomy();
            
            Assert.That(dichotomyResult, Has.Length.EqualTo(1));
            Assert.That(dichotomyResult[0], Is.EqualTo(interval));
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Common_Success()
        {
            var interval = Generate.Interval.Any();
            var dichotomyResult = interval.Dichotomy();           
            
            Assert.Multiple(() =>
            {
                Assert.That(dichotomyResult, Has.Length.EqualTo(2));
                Assert.That(dichotomyResult[0].LowerBound, Is.EqualTo(interval.LowerBound));
                Assert.That(dichotomyResult[1].UpperBound, Is.EqualTo(interval.UpperBound));
                Assert.That(dichotomyResult[0].UpperBound, Is.EqualTo(dichotomyResult[1].LowerBound));
            });
        }

        [Test]
        [Repeat(RepeatCount)]
        public void TwoNeighboursDoubleInterval_Success()
        {
            var number = Generate.Number.Double.Any();
            var nextNumber = Next.Double(number);
            var interval = new Interval(number, nextNumber);
            var dichotomyResult = interval.Dichotomy();
            
            Assert.That(dichotomyResult, Has.Length.EqualTo(1));
            Assert.That(dichotomyResult[0], Is.EqualTo(interval));
        }
    }
}