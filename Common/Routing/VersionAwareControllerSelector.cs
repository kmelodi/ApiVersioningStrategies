using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Common.Routing
{
    public class VersionAwareControllerSelector : DefaultHttpControllerSelector
    {
        public VersionAwareControllerSelector(HttpConfiguration configuration) : base(configuration) { }
        public override string GetControllerName(HttpRequestMessage request)
        {
            var controllerName = base.GetControllerName(request);
            var version = VersionFinder.GetVersionFromRequest(request);
                
        return version > 0 ? GetVersionedControllerName(request, controllerName, version) : controllerName;
        }
        private string GetVersionedControllerName(HttpRequestMessage request, string baseControllerName,
        int version)
        {
            var versionControllerName = $"{baseControllerName}v{version}";
            HttpControllerDescriptor descriptor;
            if (GetControllerMapping().TryGetValue(versionControllerName, out descriptor))
            {
                return versionControllerName;
            }

            throw new HttpResponseException(request.CreateErrorResponse(
            HttpStatusCode.NotFound,
                $"No HTTP resource was found that matches the URI {request.RequestUri} and version number {version}"));
        }
    }
}