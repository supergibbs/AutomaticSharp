using System;
using System.Collections.Generic;
using System.Linq;

namespace AutomaticSharp.Requests
{
    public abstract class RequestWithPaging : Request
    {
        protected RequestWithPaging()
        {
            Page = 1;
            Limit = 10;
        }

        public int Page { get; set; }
        public int Limit { get; set; }

        protected override IEnumerable<Exception> IsValid()
        {
            if (Page < 1)
                yield return new ArgumentOutOfRangeException(nameof(Page), "Page must greater than 0");

            if (Limit < 1 || Limit > 250)
                yield return new ArgumentOutOfRangeException(nameof(Limit), "Limit must be between 1 and 250");
        }

        public override Dictionary<string, string> CreateParameters()
        {
            var errors = IsValid().ToArray();

            if (errors.Any())
                throw new AggregateException("Invalid ", errors);

            var parameters = new Dictionary<string, string>();

            if (Page != 1)
                parameters.Add("page", Page.ToString());

            if (Limit != 10)
                parameters.Add("limit", Limit.ToString());

            return parameters;
        }
    }
}