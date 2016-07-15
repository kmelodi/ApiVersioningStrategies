using System.Web.Http;
using System.Web.Http.Description;
using UriBasedVersioning.AttributeRouting.Models;

namespace UriBasedVersioning.AttributeRouting.Controllers
{
    [RoutePrefix("api/v2/items")]
    public class ItemsV2Controller : ApiController
    {
        [ResponseType(typeof(ItemV2ViewModel))]
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var viewModel = new ItemV2ViewModel { Id = id, Name = "Xbox One", Country = "USA", Price = 529.99 };
            return Ok(viewModel);
        }
    }
}