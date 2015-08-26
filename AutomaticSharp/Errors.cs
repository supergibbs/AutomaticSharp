using System.ComponentModel;

namespace AutomaticSharp
{
    public enum Errors
    {
        /// <summary>
        /// Request is malformed.
        /// </summary>
        [Description("err_bad_request")]
        BadRequest = 400,

        /// <summary>
        /// No token or an invalid token is attached to the request.
        /// </summary>
        [Description("err_unauthorized")]
        Unauthorized = 401,

        /// <summary>
        /// The token attached to the request doesn't have the scope needed to access this endpoint.
        /// </summary>
        [Description("err_forbidden")]
        Forbidden = 403,

        /// <summary>
        /// The specified endpoint cannot be found.
        /// </summary>
        [Description("err_page_not_found")]
        PageNotFound = 404,

        /// <summary>
        /// Conflict found.
        /// </summary>
        [Description("err_conflict")]
        Conflict = 409,

        /// <summary>
        /// There is an issue processing the body of the request.
        /// </summary>
        [Description("err_unprocessable_data")]
        UnprocessableData = 422,

        /// <summary>
        /// We have a problem with our server. Please try again later.
        /// </summary>
        [Description("err_internal_error")]
        InternalError = 500
    }
}