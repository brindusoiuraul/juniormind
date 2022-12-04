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
            return
                !StartsWithZero(input) &&
                !ContainsLetters(input) &&
                !ContainsMultipleFractionParts(input) &&
                !EndsWithADot(input);
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

        private static bool StartsWithZero(string input)
        {
            return input.Length > 1 && input[0] == '0' && input[1] != '.';
        }

        private static bool EndsWithADot(string input)
        {
            return input[^1] == '.';
        }

        private static bool ContainsMultipleFractionParts(string input)
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
