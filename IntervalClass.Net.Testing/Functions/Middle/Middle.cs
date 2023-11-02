﻿// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using NUnit.Framework;

namespace IntervalClass.Net.Testing.Functions.Middle
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
            var interval = GenerateInterval();
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