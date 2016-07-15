using System.Web.Http;

namespace Common.Routing
{
    public sealed class ApiVersion1RoutePrefixAttribute : RoutePrefixAttribute
    {
        private const string RouteBase = "api/{version:VersionConstraint(v1)}";
        private const string PrefixRouteBase = RouteBase + "/";

        public ApiVersion1RoutePrefixAttribute(string routePrefix)
        : base(string.IsNullOrWhiteSpace(routePrefix) ? RouteBase : PrefixRouteBase + routePrefix)
        {
        }
    }

}