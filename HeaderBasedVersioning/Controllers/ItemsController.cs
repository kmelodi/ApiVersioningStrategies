using System.Web.Http;
using System.Web.Http.Description;
using Common.Routing;
using HeaderBasedVersioning.Models;

namespace HeaderBasedVersioning.Controllers
{
    [RoutePrefix("api/items")]
    public class ItemsController : ApiController
    {
        [ResponseType(typeof(ItemViewModel))]
        [HeaderVersionedRoute("{id}", Version = 1)]
        public IHttpActionResult Get(int id)
        {
            var viewModel = new ItemViewModel { Id = id, Name = "PS4", Country = "Japan" };
            return Ok(viewModel);
        }
    }
}