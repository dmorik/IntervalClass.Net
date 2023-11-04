// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;

namespace IntervalClass.Net.Testing
{
    [Parallelizable(ParallelScope.All)]
    internal class TestBase
    {
        protected const int RepeatCount = (int)1e5;

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