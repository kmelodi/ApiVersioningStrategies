using System.Web.Http;
using System.Web.Http.Description;
using UriBasedVersioning.AttributeRouting.Models;

namespace UriBasedVersioning.AttributeRouting.Controllers
{
    [RoutePrefix("api/v1/items")]
    public class ItemsController : ApiController
    {
        [ResponseType(typeof(ItemViewModel))]
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var viewModel = new ItemViewModel { Id = id, Name = "PS4", Country = "Japan" };
            return Ok(viewModel);
        }
    }
}