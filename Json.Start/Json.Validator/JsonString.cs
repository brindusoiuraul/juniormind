using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return HasContent(input) && IsStringContentValid(input);
        }

        private static bool HasContent(string input)
        {
            return !string.IsNullOrEmpty(input) && IsWrappedPropperly(input);
        }

        private static bool IsStringContentValid(string input)
        {
            return !ContainsIllegalCharacters(input) && !ContainsInvalidHexNumber(input);
        }

        private static bool IsWrappedPropperly(string input)
        {
            const int lastStringIndex = 2;

            return
                input[^1] == '"' &&
                input[0] == '"' &&
                input[^lastStringIndex] != '\\';
        }

        private static bool ContainsIllegalCharacters(string input)
        {
            for (int index = 0; index < input.Length - 1; index++)
            {
                if (IsEscapeChar(index, input) && !IsValidEscapeChar(input[index + 1]) || IsControlChar(input[index + 1]))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsEscapeChar(int currentIndex, string input)
        {
            return input[currentIndex] == '\\' && input[currentIndex + 1] != ' ';
        }

        private static bool IsValidEscapeChar(char escapeChar)
        {
            return "bfnrtu\"\\/".Contains(escapeChar);
        }

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
        {
            return input[currentIndex] == 'u' && input[currentIndex - 1] == '\\';
        }

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
            string hexNumber = "";

            for (int hexCharIndex = startIndex; hexCharIndex < input.Length && char.IsLetterOrDigit(input[hexCharIndex]); hexCharIndex++)
            {
                hexNumber += input[hexCharIndex];
            }

            return hexNumber;
        }

        private static bool IsHexChar(char c)
        {
            return (c >= 'a' && c <= 'f') || (c >= '0' && c <= '9');
        }
    }
}
