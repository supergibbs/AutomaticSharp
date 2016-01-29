namespace AutomaticSharp.Models
{
    public class ApiAccessToken
    {
        /// <summary>
        /// Access token
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Expires in (milliseconds)
        /// </summary>
        public int ExpiresIn { get; set; }

        /// <summary>
        /// Scopes allowed
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        /// Refresh token
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// Token type
        /// </summary>
        public string TokenType { get; set; }
    }
}