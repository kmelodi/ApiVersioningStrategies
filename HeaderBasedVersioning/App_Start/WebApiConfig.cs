using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;
using Common.Routing;

namespace HeaderBasedVersioning
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var constraintsResolver = new DefaultInlineConstraintResolver();
            constraintsResolver.ConstraintMap.Add(nameof(HeaderVersionConstraint), typeof
            (HeaderVersionConstraint));

            config.MapHttpAttributeRoutes(constraintsResolver);

        }
    }
}
