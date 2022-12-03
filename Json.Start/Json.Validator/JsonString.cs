using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return
                HasContent(input) &&
                !ContainsControlCharacters(input) &&
                !ContainsUnrecognizedEscapeCharacters(input);
        }

        private static bool HasContent(string input)
        {
            return !string.IsNullOrEmpty(input) && IsWrappedInQuotes(input);
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

        private static bool ContainsUnrecognizedEscapeCharacters(string input)
        {
            const string escapeCharsLetters = "tbnrfs'\\\"u/ ";

            for (int index = 0; index < input.Length - 1; index++)
            {
                if (input[index] == '\\' && !escapeCharsLetters.Contains(input[index + 1]))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
