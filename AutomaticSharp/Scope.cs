using System.ComponentModel;

namespace AutomaticSharp
{
    public enum Scope
    {
        /// <summary>
        /// Access to public information about user.
        /// </summary>
        [Description("scope:public")]
        Public,

        /// <summary>
        /// Access to user's profile (i.e. first_name, last_name, email).
        /// </summary>
        [Description("scope:user:profile")]
        UserProfile,

        /// <summary>
        /// Access to historical location. Applies to all events.
        /// </summary>
        [Description("scope:location")]
        Location,

        /// <summary>
        /// Access heartbeat location updates in real-time during a drive.
        /// </summary>
        [Description("scope:current_location")]
        CurrentLocation,

        /// <summary>
        /// Access to vehicle information (i.e. year, make, model). Applies to all events.
        /// </summary>
        [Description("scope:vehicle:profile")]
        VehicleProfile,

        /// <summary>
        /// Access to vehicle events details (i.e. hard_brake, hard_accel).
        /// </summary>
        [Description("scope:vehicle:events")]
        VehicleEvents,

        /// <summary>
        /// Access to VIN (Vehicle Identification Number).
        /// </summary>
        [Description("scope:vehicle:vin")]
        VehicleVin,

        /// <summary>
        /// Access to trips that are visible to a user. 
        /// </summary>
        [Description("scope:trip")]
        Trip,

        /// <summary>
        /// Access to user's driving behavior summary stats.
        /// </summary>
        [Description("scope:behavior")]
        Behavior,

        /// <summary>
        /// Direct bluetooth access to all adapters on the user's account. **BETA**
        /// </summary>
        [Description("scope:adapter:basic")]
        AdapterBasic
    }
}