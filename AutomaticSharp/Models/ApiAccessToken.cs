namespace AutomaticSharp.Models
{
    public class ApiAccessToken
    {
        public string AccessToken { get; set; }

        public int ExpiresIn { get; set; }

        public string Scope { get; set; }

        public string RefreshToken { get; set; }

        public string TokenType { get; set; }
    }
}