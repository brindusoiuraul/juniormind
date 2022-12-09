using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            if (input == null)
            {
                return false;
            }

            var indexOfDot = input.IndexOf('.');
            var indexOfExponent = input.IndexOfAny("eE".ToCharArray());

            return
                IsInteger(Integer(input, indexOfDot, indexOfExponent)) &&
                IsFraction(Fraction(input, indexOfDot, indexOfExponent)) &&
                IsExponent(Exponent(input, indexOfExponent));
        }

        private static bool IsExponent(string input)
        {
            const int exponentDigitsStart = 2;

            if (input.Length > 2 && (input[1] == '+' || input[1] == '-'))
            {
                return ContainsOnlyDigits(input[exponentDigitsStart..]);
            }

            return input == string.Empty || ContainsOnlyDigits(input[1..]);
        }

        private static string Exponent(string input, int indexOfExponent)
        {
            if (indexOfExponent == -1)
            {
                return string.Empty;
            }

            return input[indexOfExponent..];
        }

        private static bool IsFraction(string input)
        {
            return input == string.Empty || ContainsOnlyDigits(input[1..]);
        }

        private static string Fraction(string input, int indexOfDot, int indexOfExponent)
        {
            if (indexOfDot == -1)
            {
                return string.Empty;
            }

            if (indexOfExponent != -1)
            {
                return input[indexOfDot.. indexOfExponent];
            }

            return input[indexOfDot.. input.Length];
        }

        private static bool IsInteger(string integer)
        {
            if (integer.StartsWith('-'))
            {
                integer = integer[1..];
            }

            if (integer.Length > 1 && integer[0] == '0')
            {
                 return false;
            }

            return ContainsOnlyDigits(integer);
        }

        private static string Integer(string input, int indexOfDot, int indexOfExponent)
        {
            if (indexOfDot != -1)
            {
                return input[..indexOfDot];
            }

            if (indexOfExponent != -1)
            {
                return input[..indexOfExponent];
            }

            return input;
        }

        private static bool ContainsOnlyDigits(string input)
        {
            foreach (var c in input)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return input.Length > 0;
        }
    }
}
