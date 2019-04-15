using System;

namespace AutomaticSharp.Auth
{
    public static class AutomaticHelper
    {
        public static string GetScopeDescription(this AutomaticScope value)
        {
            switch (value)
            {
                case AutomaticScope.Public:
                    return "scope:public";

                case AutomaticScope.UserProfile:
                    return "scope:user:profile";

                case AutomaticScope.Location:
                    return "scope:location";

                case AutomaticScope.CurrentLocation:
                    return "scope:current_location";

                case AutomaticScope.VehicleProfile:
                    return "scope:vehicle:profile";

                case AutomaticScope.VehicleEvents:
                    return "scope:vehicle:events";

                case AutomaticScope.VehicleVin:
                    return "scope:vehicle:vin";

                case AutomaticScope.Trip:
                    return "scope:trip";

                case AutomaticScope.Behavior:
                    return "scope:behavior";

                case AutomaticScope.AdapterBasic:
                    return "scope:adapter:basic";

                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Invalid Scope");
            }
        }
    }
}