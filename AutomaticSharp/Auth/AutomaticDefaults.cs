namespace AutomaticSharp.Auth
{
    public static class AutomaticDefaults
    {
        public const string AuthenticationScheme = "AutomaticLabs";

        public static readonly string AuthorizationEndpoint = "https://accounts.automatic.com/oauth/authorize";

        public static readonly string TokenEndpoint = "https://accounts.automatic.com/oauth/access_token";

        public static readonly string UserInformationEndpoint = "https://api.automatic.com/user/me/";
    }
}