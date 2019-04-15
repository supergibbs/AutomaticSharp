using System;
using System.Collections.Generic;
using System.Linq;

namespace AutomaticSharp.Requests
{
    public class TripsRequest : RequestWithPaging
    {
        /// <summary>
        /// Default contructor
        /// </summary>
        public TripsRequest() : base()
        {
        }

        /// <summary>
        /// Gets the recents trips in the past specified duration
        /// </summary>
        /// <param name="duration"></param>
        /// <param name="vehicleId"></param>
        public TripsRequest(TimeSpan duration, string vehicleId = null) : base()
        {
            VehicleId = vehicleId;
            StartedAfter = DateTime.UtcNow - duration;
            StartedBefore = DateTime.UtcNow;
        }

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
                parameters.Add("started_at__lte", ToUnixTimeSecondsString(StartedBefore.Value));

            if (StartedAfter.HasValue)
                parameters.Add("started_at__gte", ToUnixTimeSecondsString(StartedAfter.Value));

            if (EndedBefore.HasValue)
                parameters.Add("ended_at__lte", ToUnixTimeSecondsString(EndedBefore.Value));

            if (EndedAfter.HasValue)
                parameters.Add("ended_at__gte", ToUnixTimeSecondsString(EndedAfter.Value));

            if (!string.IsNullOrEmpty(VehicleId))
                parameters.Add("vehicle", VehicleId);

            if (Tags != null && Tags.Any())
                parameters.Add("tags__in", string.Join(",", Tags));

            return parameters;
        }
    }
}
