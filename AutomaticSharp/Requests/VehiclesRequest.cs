using System;
using System.Collections.Generic;
using System.Globalization;

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
                parameters.Add("created_at__lte", (CreatedBefore.Value.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString(CultureInfo.InvariantCulture));

            if (CreatedAfter.HasValue)
                parameters.Add("created_at__gte", (CreatedAfter.Value.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString(CultureInfo.InvariantCulture));

            if (UpdatedBefore.HasValue)
                parameters.Add("updated_at__lte", (UpdatedBefore.Value.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString(CultureInfo.InvariantCulture));

            if (UpdatedAfter.HasValue)
                parameters.Add("updated_at__gte", (UpdatedAfter.Value.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString(CultureInfo.InvariantCulture));

            if (string.IsNullOrEmpty(Vin))
                parameters.Add("vin", Vin);

            return parameters;
        }
    }
}