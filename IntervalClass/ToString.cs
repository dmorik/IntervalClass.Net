using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace IntervalClass
{
    public readonly partial struct Interval
    {
        private const int DefaultDigitsAfterPoint = 2;
        
        private static IReadOnlyList<string> CachedNumberFormatStrings { get; } 
            = Enumerable
                .Range(0, 16)
                .Select(x => $"{{0:0.{new string('0', x)}}}")
                .ToArray();
        private static IReadOnlyList<string> CachedNumberScientificFormatStrings { get; } 
            = Enumerable
                .Range(0, 16)
                .Select(x => $"0.{new string('0', x)}e0")
                .ToArray();

        private string ToString(int digitsAfterPoint)
        {
            if (IsEmpty)
                return "[ Empty ]";

            if (digitsAfterPoint < 0)
                digitsAfterPoint = DefaultDigitsAfterPoint;

            if (digitsAfterPoint > 15)
                digitsAfterPoint = 15;

            var formatString = CachedNumberFormatStrings[digitsAfterPoint];
            var scientificFormatString = CachedNumberScientificFormatStrings[digitsAfterPoint];
            var stringBuilder = new StringBuilder();

            stringBuilder.Append("[");

            void addNumber(double number)
            {
                var absNumber = Math.Abs(number);
                
                if (absNumber > Math.Pow(10.0, -digitsAfterPoint))
                {
                    var signString = number < 0.0 
                        ? "-" 
                        : "+";
                    
                    stringBuilder.Append(signString);
                }

                if (double.IsInfinity(number))
                {
                    stringBuilder.Append("Inf");

                    return;
                }
                
                var numberAbsString = absNumber < Math.Pow(10.0, DefaultDigitsAfterPoint)
                    ? string.Format(CultureInfo.InvariantCulture, formatString, absNumber)
                    : Math.Abs(number).ToString(scientificFormatString, CultureInfo.InvariantCulture);

                stringBuilder.Append(numberAbsString);
            }

            addNumber(LowerBound);

            stringBuilder.Append(", ");

            addNumber(UpperBound);

            stringBuilder.Append("]");

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Returns the string representation of the interval.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ToString(DefaultDigitsAfterPoint);
        }
    }
}