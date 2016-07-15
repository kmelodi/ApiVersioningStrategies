using System.Linq;
using System.Net.Http;

namespace Common.Routing
{
    public class VersionFinder
    {
        private const string VersionHeaderName = "api-version";
      
        private static bool NeedsUriVersioning(HttpRequestMessage request, out string version)
        {
            var routeData = request.GetRouteData();
            if (routeData != null)
            {
                object versionFromRoute;
                if (routeData.Values.TryGetValue(nameof(version), out versionFromRoute))
                {
                    version = versionFromRoute as string;
                    if (!string.IsNullOrWhiteSpace(version))
                    {
                        return true;
                    }
                }
            }
            version = null;
            return false;
        }
        private static int VersionToInt(string versionString)
        {
            int version;
            if (string.IsNullOrEmpty(versionString) || !int.TryParse(versionString, out version))
                return 0;
            return version;
        }
        //private static bool NeedsAcceptVersioning(HttpRequestMessage request, out string version)
        //{
        //    if (request.Headers.Accept.Any())
        //    {
        //        var acceptHeaderVersion =
        //        request.Headers.Accept.FirstOrDefault(x => x.MediaType.Contains("vnd.apress.recipes.webapi"));
        //        if (acceptHeaderVersion != null && acceptHeaderVersion.MediaType.Contains("-v") &&
        //        acceptHeaderVersion.MediaType.Contains("+"))
        //        {
        //            version = acceptHeaderVersion.MediaType.Between("-v", "+");
        //            return true;
        //        }
        //    }
        //    version = null;
        //    return false;
        //}
        public static int GetVersionFromRequest(HttpRequestMessage request)
        {
            string version;
            if (NeedsUriVersioning(request, out version))
            {
                return VersionToInt(version);
            }
            //if (NeedsAcceptVersioning(request, out version))
            //{
            //    return VersionToInt(version);
            //}
            if (NeedsHeaderVersioning(request, out version))
            {
                return VersionToInt(version);
            }
            return 0;
        }

        private static bool NeedsHeaderVersioning(HttpRequestMessage request, out string version)
        {
            if (request.Headers.Contains(VersionHeaderName))
            {
                version = request.Headers.GetValues(VersionHeaderName).FirstOrDefault();

                {
                    return true;
                }
            }
            version = null;
            return false;
        }

    }
}