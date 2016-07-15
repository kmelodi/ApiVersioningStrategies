using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http.Routing;

namespace Common.Routing
{
    public class HeaderVersionConstraint : IHttpRouteConstraint
    {
        private const string VersionHeaderName = "api-version";

        public HeaderVersionConstraint(int allowedVersion)
        {
            AllowedVersion = allowedVersion;
        }

        public int AllowedVersion { get; }

        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName,
            IDictionary<string, object> values,
            HttpRouteDirection routeDirection)
        {
            if (!request.Headers.Contains(VersionHeaderName)) return false;

            var version = request.Headers.GetValues(VersionHeaderName).FirstOrDefault();

            return VersionToInt(version) == AllowedVersion;
        }
        private static int VersionToInt(string versionString)
        {
            int version;
            if (string.IsNullOrEmpty(versionString) || !int.TryParse(versionString, out version))
                return 0;
            return version;
        }
    }
}