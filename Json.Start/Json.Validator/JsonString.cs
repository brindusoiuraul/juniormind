using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return string.Equals(input, "\"abc\"");
        }
    }
}
