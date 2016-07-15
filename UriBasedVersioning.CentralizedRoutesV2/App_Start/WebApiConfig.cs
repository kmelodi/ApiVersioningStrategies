using System.Web.Http;
using System.Web.Http.Dispatcher;
using Common.Routing;

namespace UriBasedVersioning.CentralizedRoutesV2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Services.Replace(typeof(IHttpControllerSelector),new VersionAwareControllerSelector(config));
            // Web API routes
            config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute(
                "defaultVersioned",
                "api/v{version}/{controller}/{id}",
                new { id = RouteParameter.Optional }, new { version = @"\d+" });

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional }
                );
        }
    }
}