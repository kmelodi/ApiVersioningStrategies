using System.Web.Http;
using System.Web.Http.Routing;
using Common.Routing;

namespace MediaTypeBasedVersioning
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var constraintsResolver = new DefaultInlineConstraintResolver();
            constraintsResolver.ConstraintMap.Add(nameof(MediaTypeVersionConstraint), typeof
            (MediaTypeVersionConstraint));

            config.MapHttpAttributeRoutes(constraintsResolver);

        }
    }
}
