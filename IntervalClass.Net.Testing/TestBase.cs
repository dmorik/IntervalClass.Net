// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Linq;

namespace IntervalClass.Net.Testing
{
    internal class TestBase
    {
        protected const int RepeatCount = (int)1e3;
        
        private static readonly Random Random = new Random(DateTime.Now.Millisecond);
        private static readonly double MinDoubleLogValue = Math.Log(double.Epsilon) + 1.0;
        private static readonly double MaxDoubleLogValue = Math.Log(double.MaxValue) - 1.0;
        private static readonly double MinIntLogValue = Math.Log(1) + 1.0;
        private static readonly double MaxIntLogValue = Math.Log(int.MaxValue) - 1.0;

        private static double GenerateNumberByLogInterval(double minLog, double maxLog)
        {
            var numberSign = Random.NextDouble() >= 0.5 ? 1.0 : -1.0;
            var randomNumber = Random.NextDouble();
            var numberLogValue = minLog * (1.0 - randomNumber) + maxLog * randomNumber;
            var numberAbsValue = Math.Exp(numberLogValue);

            return numberSign * numberAbsValue;
        }
        
        protected static double GenerateDoubleNumber()
        {
            return GenerateNumberByLogInterval(MinDoubleLogValue, MaxDoubleLogValue);
        }

        protected static int GenerateIntNumber()
        {
            return (int)GenerateNumberByLogInterval(MinIntLogValue, MaxIntLogValue);
        }
        
        protected static double[] GenerateDoubleNumbers(int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            var result = new List<double>();

            foreach (var _ in Enumerable.Range(0, count))
            {
                var candidate = GenerateDoubleNumber();
                
                if (result.Contains(candidate))
                    continue;
                
                result.Add(candidate);
            }

            return result.ToArray();
        }

        protected static Interval GenerateInterval()
        {
            var orderedNumbers = GenerateDoubleNumbers(2)
                .OrderBy(x => x)
                .ToArray();
            var lowerBound = orderedNumbers[0];
            var upperBound = orderedNumbers[1];

            return new Interval(lowerBound, upperBound);
        }
        
        protected static bool ShouldCatchIntervalClassException(Action action)
        {
            try
            {
                action();
            }
            catch (IntervalClassException)
            {
                return true;
            }

            return false;
        }
    }
}