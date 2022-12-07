using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
            => HasContent(input) && IsStringContentValid(input);

        private static bool HasContent(string input)
            => !string.IsNullOrEmpty(input) && IsWrappedInQuotes(input);

        private static bool IsStringContentValid(string input)
            => !ContainsInvalidHexNumber(input) && AreAllCharsValid(input) && !EndsWithReverseSolidus(input);

        private static bool IsWrappedInQuotes(string input)
            => input[^1] == '"' && input[0] == '"';

        private static bool EndsWithReverseSolidus(string input)
        {
            const int lastStringIndex = 2;
            return input[^lastStringIndex] == '\\' && input[^(lastStringIndex + 1)] != '\\';
        }

        private static bool AreAllCharsValid(string input)
            => !ContainsControlChars(input) && !ContainsInvalidEscapeChars(input);

        private static bool ContainsInvalidEscapeChars(string input)
        {
            int step = 1;
            for (int index = 0; index < input.Length; index += step)
            {
                step = 1;
                if (input[index] == '\\')
                {
                    if (!IsValidEscapeChar(input[index + 1]))
                    {
                        return true;
                    }

                    step++;
                }
            }

            return false;
        }

        private static bool ContainsControlChars(string input)
        {
            foreach (char c in input)
            {
                if (IsControlChar(c))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsValidEscapeChar(char escapeChar)
            => "bfnrtu\"\\/".Contains(escapeChar);

        private static bool IsControlChar(char character)
        {
            const int controlCharsMaxCode = 32;
            return character < controlCharsMaxCode;
        }

        private static bool ContainsInvalidHexNumber(string input)
        {
            for (int index = 0; index < input.Length; index++)
            {
                if (IsHexNumber(index, input) && !IsValidHex(GetHexNumber(index + 1, input.ToLower())))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsHexNumber(int currentIndex, string input)
            => input[currentIndex] == 'u' && input[currentIndex - 1] == '\\';

        private static bool IsValidHex(string hexNumber)
        {
            foreach (char c in hexNumber)
            {
                if (!IsHexChar(c))
                {
                    return false;
                }
            }

            return hexNumber.Length == 4;
        }

        private static string GetHexNumber(int startIndex, string input)
        {
            int hexNumberLength = input.Length - startIndex - 4 >= 0 ? 4 : input.Length - startIndex;

            return input.Substring(startIndex, hexNumberLength);
        }

        private static bool IsHexChar(char c)
            => (c >= 'a' && c <= 'f') || (c >= '0' && c <= '9');
    }
}
