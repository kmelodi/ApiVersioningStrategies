using System.Web.Http;
using System.Web.Http.Description;
using UriBasedVersioning.Namespace.Models;
using UriBasedVersioning.Namespace.Models.V1;

namespace UriBasedVersioning.Namespace.Controllers.V1
{
    [RoutePrefix("api/{version:VersionConstraint(v1)}/items")]
    public class ItemsController : ApiController
    {
        [ResponseType(typeof(ItemViewModel))]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var viewModel = new ItemViewModel { Id = id, Name = "PS4", Country = "Japan" };
            return Ok(viewModel);
        }
    }
}