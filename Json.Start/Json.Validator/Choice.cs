using System;

namespace Json
{
    public class Choice : IPattern
    {
        readonly IPattern[] patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            IMatch match = new Match(false, text);

            foreach (IPattern pattern in patterns)
            {
                match = pattern.Match(match.RemainingText());

                if (match.Success())
                {
                    return match;
                }
            }

            return new Match(false, text);
        }
    }
}
