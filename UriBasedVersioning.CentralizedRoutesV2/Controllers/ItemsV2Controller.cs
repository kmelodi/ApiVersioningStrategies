using System.Web.Http;
using System.Web.Http.Description;
using UriBasedVersioning.CentralizedRoutesV2.Models;

namespace UriBasedVersioning.CentralizedRoutesV2.Controllers
{
    public class ItemsV2Controller : ApiController
    {
        [ResponseType(typeof(ItemV2ViewModel))]
        public IHttpActionResult Get(int id)
        {
            var viewModel = new ItemV2ViewModel { Id = id, Name = "Xbox One", Country = "USA", Price = 529.99 };
            return Ok(viewModel);
        }
    }
}