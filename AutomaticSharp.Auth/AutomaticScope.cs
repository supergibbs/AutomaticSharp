namespace AutomaticSharp.Auth
{
    public enum AutomaticScope
    {
        /// <summary>
        /// Access to public information about user.
        /// </summary>
        Public,

        /// <summary>
        /// Access to user's profile (i.e. first_name, last_name, email).
        /// </summary>
        UserProfile,

        /// <summary>
        /// Access to historical location. Applies to all events.
        /// </summary>
        Location,

        /// <summary>
        /// Access heartbeat location updates in real-time during a drive.
        /// </summary>
        CurrentLocation,

        /// <summary>
        /// Access to vehicle information (i.e. year, make, model). Applies to all events.
        /// </summary>
        VehicleProfile,

        /// <summary>
        /// Access to vehicle events details (i.e. hard_brake, hard_accel).
        /// </summary>
        VehicleEvents,

        /// <summary>
        /// Access to VIN (Vehicle Identification Number).
        /// </summary>
        VehicleVin,

        /// <summary>
        /// Access to trips that are visible to a user. 
        /// </summary>
        Trip,

        /// <summary>
        /// Access to user's driving behavior summary stats.
        /// </summary>
        Behavior,

        /// <summary>
        /// Direct bluetooth access to all adapters on the user's account. **BETA**
        /// </summary>
        AdapterBasic
    }
}