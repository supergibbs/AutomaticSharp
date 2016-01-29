using System;
using System.Collections.Generic;

namespace AutomaticSharp.Requests
{
    public abstract class Request
    {
        protected abstract IEnumerable<Exception> IsValid();

        public abstract Dictionary<string, string> CreateParameters();
    }
}