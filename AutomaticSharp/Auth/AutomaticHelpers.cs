using System;
using Newtonsoft.Json.Linq;

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

        public static string GetId(JObject user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return user.Value<string>("id");
        }

        public static string GetFirstName(JObject user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return user.Value<string>("first_name");
        }

        public static string GetLastName(JObject user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return user.Value<string>("last_name");
        }

        public static string GetUserName(JObject user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return user.Value<string>("username");
        }

        public static string GetEmail(JObject user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return user.Value<string>("email");
        }
        
        public static string GetUrl(JObject user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return user.Value<string>("url");
        }
    }
}