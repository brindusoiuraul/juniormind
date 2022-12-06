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
                !ContainsMultipleChars(input) &&
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
    }
}
