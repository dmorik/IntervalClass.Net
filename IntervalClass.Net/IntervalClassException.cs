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