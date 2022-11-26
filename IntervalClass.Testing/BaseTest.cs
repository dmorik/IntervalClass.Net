﻿using System;
using NUnit.Framework;
using System.Runtime.InteropServices;
// ReSharper disable EqualExpressionComparison
// ReSharper disable ObjectCreationAsStatement

namespace IntervalClass.Testing
{
    [TestFixture]
    internal sealed class BaseTest : TestBase
    {
        private bool ShouldCatchException<T>(Action action)
            where T : Exception
        {
            try
            {
                action();
            }
            catch (T)
            {
                return true;
            }

            return false;
        }
        
        [Test]
        public void Create_Empty()
        {
            var createdInterval = new Interval();
            
            Assert.IsTrue(createdInterval.IsEmpty);
        }
        
        [Test]
        public void Create_NaN()
        {
            var error = ShouldCatchException<IntervalClassException>(() => new Interval(double.NaN));
            
            Assert.IsTrue(error);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Create_Number()
        {
            var number = GenerateDoubleNumber();
            var createdInterval = new Interval(number);
            
            Assert.IsTrue(!createdInterval.IsEmpty);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Create_Number_Number_Ordered()
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
        public void Create_Number_Number_Unordered()
        {
            var firstNumber = GenerateDoubleNumber();
            var secondNumber = GenerateDoubleNumber();

            while (secondNumber == firstNumber)
            {
                secondNumber = GenerateDoubleNumber();
            }

            var error = ShouldCatchException<IntervalClassException>(() =>
            {
                var createdInterval = firstNumber <= secondNumber
                    ? new Interval(secondNumber, firstNumber)
                    : new Interval(firstNumber, secondNumber);
            });
            
            Assert.IsTrue(error);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Create_Number_NaN()
        {
            var number = GenerateDoubleNumber();
            var error = ShouldCatchException<IntervalClassException>(()
                => new Interval(number, double.NaN));
            
            Assert.IsTrue(error);
        }
        
        [Test]
        [Repeat(RepeatCount)]
        public void Create_NaN_Number()
        {
            var number = GenerateDoubleNumber();
            var error = ShouldCatchException<IntervalClassException>(()
                => new Interval(double.NaN, number));
            
            Assert.IsTrue(error);
        }
    }
}
