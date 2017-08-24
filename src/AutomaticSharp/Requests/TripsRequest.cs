using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AutomaticSharp.Requests
{
    public class TripsRequest : RequestWithPaging
    {
        /// <summary>
        /// Time the trip started on or before
        /// </summary>
        public DateTime? StartedBefore { get; set; }

        /// <summary>
        /// Time the trip started on or after
        /// </summary>
        public DateTime? StartedAfter { get; set; }

        /// <summary>
        /// Time the trip ended on or before
        /// </summary>
        public DateTime? EndedBefore { get; set; }

        /// <summary>
        /// Time the trip ended on or after
        /// </summary>
        public DateTime? EndedAfter { get; set; }

        /// <summary>
        /// Filter by vehicle
        /// </summary>
        public string VehicleId { get; set; }
        
        /// <summary>
        /// Filter by tags
        /// </summary>
        public IEnumerable<string> Tags { get; set; }

        public override Dictionary<string, string> CreateParameters()
        {
            var parameters = base.CreateParameters();

            if (StartedBefore.HasValue)
                parameters.Add("started_at__lte", (StartedBefore.Value.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString(CultureInfo.InvariantCulture));

            if (StartedAfter.HasValue)
                parameters.Add("started_at__gte", (StartedAfter.Value.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString(CultureInfo.InvariantCulture));

            if (EndedBefore.HasValue)
                parameters.Add("ended_at__lte", (EndedBefore.Value.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString(CultureInfo.InvariantCulture));

            if (EndedAfter.HasValue)
                parameters.Add("ended_at__gte", (EndedAfter.Value.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString(CultureInfo.InvariantCulture));

            if (!string.IsNullOrEmpty(VehicleId))
                parameters.Add("vehicle", VehicleId);

            if (Tags != null && Tags.Any())
                parameters.Add("tags__in", string.Join(",", Tags));

            return parameters;
        }
    }
}
