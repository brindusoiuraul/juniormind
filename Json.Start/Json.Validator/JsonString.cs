using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return
                !string.IsNullOrEmpty(input) &&
                IsWrappedInQuotes(input) &&
                !ContainsControlCharacters(input);
        }

        private static bool IsWrappedInQuotes(string input)
        {
            return input[^1] == '"' && input[0] == '"';
        }

        private static bool ContainsControlCharacters(string input)
        {
            foreach (char character in input)
            {
                if (char.IsControl(character))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
