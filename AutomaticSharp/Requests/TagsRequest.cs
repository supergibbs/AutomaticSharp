using System.Collections.Generic;
using System.Linq;

namespace AutomaticSharp.Requests
{
    public class TagsRequest : RequestWithPaging
    {
                public IEnumerable<string> StartsWith { get; set; }

      public override Dictionary<string, string> CreateParameters()
        {
            var parameters = base.CreateParameters();

            if (StartsWith != null && StartsWith.Any())
                parameters.Add("tag__istartswith", string.Join(",", StartsWith));

            return parameters;
        }
    }
}
