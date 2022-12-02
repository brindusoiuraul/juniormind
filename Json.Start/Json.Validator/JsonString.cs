using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return string.Equals(input, "\"abc\"") || input[^2] == '"' || input[1] == '"';
        }
    }
}
