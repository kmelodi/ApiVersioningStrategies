using System.Collections.Generic;
using System.Web.Http.Routing;

namespace Common.Routing
{
    public sealed class MediaTypeVersionedRouteAttribute : RouteFactoryAttribute
    {
        public MediaTypeVersionedRouteAttribute(string template) : base(template)
        {
            Order = -1;
        }

        public int Version { get; set; }

        public override IDictionary<string, object> Constraints => new HttpRouteValueDictionary
        {
            {"", new MediaTypeVersionConstraint(Version)}
        };
    }
}