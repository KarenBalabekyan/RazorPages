using System.Net;

namespace SimpleStore.DataAccess.Errors
{
    public static class ErrorsResult
    {
        public static dynamic HandleError(HttpStatusCode status)
        {
            switch (status)
            {
                case HttpStatusCode.Forbidden:
                    return new { status = (int)status, reason = "FORBIDDEN" };
                case HttpStatusCode.Unauthorized:
                    return new { status = (int)status, reason = "LOGIN_REQUIRED" };
                case HttpStatusCode.NonAuthoritativeInformation:
                    return new { status = (int)status, reason = "PROVIDED CREDENTIALS ARE NOT VALID" };
                default:
                    return new { status = (int)status, reason = "UNDEFINED_ERROR" };
            }
        }

        public static dynamic GetResourceMessage(string key)
        {
            return "Resource value ...";
        }
    }
}
