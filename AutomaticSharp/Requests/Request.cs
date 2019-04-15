using System;
using System.Collections.Generic;
using System.Globalization;

namespace AutomaticSharp.Requests
{
    public abstract class Request
    {
        protected abstract IEnumerable<Exception> IsValid();

        public abstract Dictionary<string, string> CreateParameters();

        protected string ToUnixTimeSecondsString(DateTime dateTime)
        {
            return new DateTimeOffset(dateTime.ToUniversalTime()).ToUnixTimeSeconds().ToString("0", CultureInfo.InvariantCulture);
        }
    }
}