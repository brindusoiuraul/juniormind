using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return !string.IsNullOrEmpty(input) && IsNumberContentCorrect(input);
        }

        public static bool IsNumberContentCorrect(string input)
        {
            return
                !StartsWithZero(input) &&
                !ContainsLetters(input) &&
                !ContainsMultipleFractionParts(input) &&
                !EndsWithADot(input);
        }

        public static bool ContainsLetters(string input)
        {
            foreach (char character in input)
            {
                if (char.IsLetter(character))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool StartsWithZero(string input)
        {
            return input.Length > 1 && input[0] == '0' && input[1] != '.';
        }

        public static bool EndsWithADot(string input)
        {
            return input[^1] == '.';
        }

        public static bool ContainsMultipleFractionParts(string input)
        {
            int numberOfDots = 0;

            foreach (char character in input)
            {
                if (character == '.')
                {
                    numberOfDots++;
                }
            }

            return numberOfDots > 1;
        }
    }
}
