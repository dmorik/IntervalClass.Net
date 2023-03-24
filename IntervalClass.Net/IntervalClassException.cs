// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;

namespace IntervalClass.Net
{
    /// <summary>
    /// Represents interval class exception.
    /// </summary>
    public class IntervalClassException : Exception
    {
        /// <summary>
        /// Create interval class exception with message.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public IntervalClassException(string message)
            : base(message)
        { }
    }
}