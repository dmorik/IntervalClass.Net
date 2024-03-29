﻿// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Linq;

namespace IntervalClass.Net.Testing.SetOperations.ContainsNumber
{
    internal sealed class ContainsNumber : TestBase
    {
        [Test]
        [Repeat(RepeatCount)]
        public void Point_Success()
        {
            var interval = Generate.Interval.Point();
            
            Assert.That(interval.Contains(interval.LowerBound), Is.True);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Point_Failure()
        {            
            var interval = Generate.Interval.Point();
            var anotherNumber = Generate.Number.Double.Any();
            
            Assert.That(interval.Contains(anotherNumber), Is.False);
        }

        [Test]
        [Repeat(RepeatCount)]
        public void Common_Success()
        {
            var numbers = Generate.Number.Double.Any(3)
                .OrderBy(x => x)
                .ToArray();
            var interval = new Interval(numbers[0], numbers[2]);
            var number = numbers[1];
            
            Assert.That(interval.Contains(number), Is.True);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Common_Failure()
        {
            var numbers = Generate.Number.Double.Any(3)
                .OrderBy(x => x)
                .ToArray();
            var interval = new Interval(numbers[0], numbers[1]);
            var number = numbers[2];
            
            Assert.That(interval.Contains(number), Is.False);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Empty_Failure()
        {
            var number = Generate.Number.Double.Any();
            
            Assert.That(Interval.Empty.Contains(number), Is.False);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Infinity_Success()
        {
            var number = Generate.Number.Double.Any();
            
            Assert.That(Interval.Infinity.Contains(number), Is.True);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void PositiveInfinity_Success()
        {
            var number = Generate.Number.Double.Any();

            if (number < 0.0)
                number = -number;
            
            Assert.That(Interval.PositiveInfinity.Contains(number), Is.True);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void PositiveInfinity_Failure()
        {
            var number = Generate.Number.Double.Any();

            if (number > 0.0)
                number = -number;
            
            Assert.That(Interval.PositiveInfinity.Contains(number), Is.False);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void NegativeInfinity_Success()
        {
            var number = Generate.Number.Double.Any();

            if (number > 0.0)
                number = -number;
            
            Assert.That(Interval.NegativeInfinity.Contains(number), Is.True);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void NegativeInfinity_Failure()
        {
            var number = Generate.Number.Double.Any();

            if (number < 0.0)
                number = -number;
            
            Assert.That(Interval.NegativeInfinity.Contains(number), Is.False);
        }
    }
}