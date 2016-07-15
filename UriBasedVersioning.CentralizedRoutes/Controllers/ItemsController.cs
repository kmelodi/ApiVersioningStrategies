using System.Web.Http;
using System.Web.Http.Description;
using UriBasedVersioning.CentralizedRoutes.Models;

namespace UriBasedVersioning.CentralizedRoutes.Controllers
{
    public class ItemsController : ApiController
    {
        [ResponseType(typeof(ItemViewModel))]
        public IHttpActionResult Get(int id)
        {
            var viewModel = new ItemViewModel { Id = id, Name = "PS4", Country = "Japan" };
            return Ok(viewModel);
        }
    }
}