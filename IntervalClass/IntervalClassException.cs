using System;

namespace IntervalClass
{
    /// <summary>
    /// Represents interval class exceptions.
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