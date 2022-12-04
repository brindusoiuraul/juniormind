using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return input != null && !ContainsLetters(input);
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
    }
}
