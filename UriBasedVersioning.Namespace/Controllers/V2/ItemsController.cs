using System.Web.Http;
using System.Web.Http.Description;


namespace UriBasedVersioning.Namespace.Controllers.V2
{
    using Models.V2;
    [RoutePrefix("api/{version:VersionConstraint(v2)}/items")]
    public class ItemsController : ApiController
    {
        [ResponseType(typeof(ItemViewModel))]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var viewModel = new ItemViewModel { Id = id, Name = "Xbox One", Country = "USA", Price = 529.99 };
            return Ok(viewModel);
        }
    }
}