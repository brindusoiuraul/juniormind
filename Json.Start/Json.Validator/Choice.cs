﻿using System;

namespace Json
{
    public class Choice
    {
        readonly IPattern[] patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public bool Match(string text)
        {
            throw new NotImplementedException();
        }
    }
}
