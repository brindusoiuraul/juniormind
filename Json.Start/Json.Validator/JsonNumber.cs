using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            if (!IsInputValid(input))
            {
                return false;
            }

            var indexOfDot = input.IndexOf('.');
            var indexOfExponent = input.IndexOfAny("eE".ToCharArray());

            return IsInteger(Integer(input, indexOfDot, indexOfExponent));
        }

        private static bool IsInteger(string integer)
        {
            bool isValidInteger = true;
            const string validChars = "+-0123456789";

            foreach (char c in integer)
            {
                if (!validChars.Contains(c))
                {
                    isValidInteger = false;
                }
            }

            if (integer.Length > 1 && integer[0] == '0')
            {
                isValidInteger = false;
            }

            return isValidInteger;
        }

        private static string Integer(string input, int indexOfDot, int indexOfExponent)
        {
            int integerEndIndex = GetEndIndex(input, indexOfDot, indexOfExponent);

            return input.Substring(0, integerEndIndex + 1);
        }

        private static int GetEndIndex(string input, int indexOfDot, int indexOfExponent)
        {
            int integerEndIndex = input.Length - 1;

            if (indexOfExponent != -1)
            {
                integerEndIndex = indexOfExponent - 1;
            }

            if (indexOfDot != -1)
            {
                integerEndIndex = indexOfDot - 1;
            }

            return integerEndIndex;
        }

        private static bool IsInputValid(string input)
        {
            if (input == null)
            {
                return false;
            }

            int numberOfDigits = 0;

            for (int index = 0; index < input.Length; index++)
            {
                if (char.IsDigit(input[index]))
                {
                    numberOfDigits++;
                }
            }

            return numberOfDigits > 0;
        }
    }
}
