using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http.Routing;

namespace Common.Routing
{
    public class MediaTypeVersionConstraint : IHttpRouteConstraint
    {
        private const string VersionMediaType = "vnd.mediatype.versioning";

        public MediaTypeVersionConstraint(int allowedVersion)
        {
            AllowedVersion = allowedVersion;
        }

        public int AllowedVersion { get; }

        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName, IDictionary<string, object> values,
            HttpRouteDirection routeDirection)
        {
            if (!request.Headers.Accept.Any()) return false;

            var acceptHeaderVersion =
                request.Headers.Accept.FirstOrDefault(x => x.MediaType.Contains(VersionMediaType));

            //Accept: application/vnd.mediatype.versioning+json
            if (acceptHeaderVersion == null || !acceptHeaderVersion.MediaType.Contains("-v") ||
                !acceptHeaderVersion.MediaType.Contains("+"))
                return false;

            var version = acceptHeaderVersion.MediaType.Between("-v", "+");
            return VersionToInt(version)==AllowedVersion;
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