using System;

namespace Json
{
    interface IPattern
    {
        bool Match(string pattern);
    }

    class Choice
    {
        public Choice(params IPattern[] patterns)
        {
        }

        public bool Match(string text)
        {
            throw new NotImplementedException();
        }
    }
}
