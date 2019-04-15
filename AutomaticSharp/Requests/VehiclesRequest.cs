using System;
using System.Collections.Generic;

namespace AutomaticSharp.Requests
{
    public class VehiclesRequest : RequestWithPaging
    {
        public DateTime? CreatedBefore { get; set; }

        public DateTime? CreatedAfter { get; set; }

        public DateTime? UpdatedBefore { get; set; }

        public DateTime? UpdatedAfter { get; set; }

        public string Vin { get; set; }

        public override Dictionary<string, string> CreateParameters()
        {
            var parameters = base.CreateParameters();

            if (CreatedBefore.HasValue)
                parameters.Add("created_at__lte", ToUnixTimeSecondsString(CreatedBefore.Value));

            if (CreatedAfter.HasValue)
                parameters.Add("created_at__gte", ToUnixTimeSecondsString(CreatedAfter.Value));

            if (UpdatedBefore.HasValue)
                parameters.Add("updated_at__lte", ToUnixTimeSecondsString(UpdatedBefore.Value));

            if (UpdatedAfter.HasValue)
                parameters.Add("updated_at__gte", ToUnixTimeSecondsString(UpdatedAfter.Value));

            if (string.IsNullOrEmpty(Vin))
                parameters.Add("vin", Vin);

            return parameters;
        }
    }
}