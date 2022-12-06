using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return !string.IsNullOrEmpty(input) && IsNumberContentCorrect(input);
        }

        private static bool IsNumberContentCorrect(string input)
        {
            if (HasExponent(input.ToLower()))
            {
                return StartsAndEndsCorrectly(input) && AreCharsValid(input) && IsExponentCorrect(GetExponent(input.ToLower()));
            }

            return StartsAndEndsCorrectly(input) && AreCharsValid(input);
        }

        private static bool AreCharsValid(string input)
        {
            return !ContainsLetters(input) && !ContainsMultipleChars(input);
        }

        private static bool StartsAndEndsCorrectly(string input)
        {
            return !StartsWithZero(input) && !EndsWithADot(input);
        }

        private static bool StartsWithZero(string input)
        {
            return input.Length > 1 && input[0] == '0' && input[1] != '.';
        }

        private static bool EndsWithADot(string input)
        {
            return input[^1] == '.';
        }

        private static bool ContainsLetters(string input)
        {
            foreach (char character in input.ToLower())
            {
                if (char.IsLetter(character) && character != 'e')
                {
                    return true;
                }
            }

            return false;
        }

        private static bool ContainsMultipleChars(string input)
        {
            return NumberOfEncounters('.', input) > 1 || NumberOfEncounters('e', input) > 1;
        }

        private static int NumberOfEncounters(char characterToCount, string input)
        {
            int numberOfEncounters = 0;

            foreach (char c in input.ToLower())
            {
                if (c == characterToCount)
                {
                    numberOfEncounters++;
                }
            }

            return numberOfEncounters;
        }

        private static bool HasExponent(string input)
        {
            return input.Contains("e");
        }

        private static string GetExponent(string input)
        {
            int exponentStartIndex = input.IndexOf("e") + 1;
            int exponentLength = input.Length - exponentStartIndex;

            return input.Substring(exponentStartIndex, exponentLength);
        }

        private static bool IsExponentCorrect(string exponent)
        {
            return !exponent.Contains(".") && IsExponentComplete(exponent);
        }

        private static bool IsExponentComplete(string exponent)
        {
            if (exponent.Length == 1 && char.IsDigit(exponent[0]))
            {
                return true;
            }

            if (exponent.Length > 1 && char.IsDigit(exponent[1]))
            {
                return true;
            }

            return false;
        }
    }
}
