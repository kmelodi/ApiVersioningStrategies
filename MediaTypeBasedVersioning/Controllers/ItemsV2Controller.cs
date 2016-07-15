using System;
using System.Web.Http;
using System.Web.Http.Description;
using Common.Routing;
using MediaTypeBasedVersioning.Models;

namespace MediaTypeBasedVersioning.Controllers
{
    [RoutePrefix("api/items")]
    public class ItemsV2Controller : ApiController
    {
        [ResponseType(typeof(ItemV2ViewModel))]
        [MediaTypeVersionedRoute("{id}", Version = 2)]
        public IHttpActionResult Get(int id)
        {
            var viewModel = new ItemV2ViewModel { Id = id, Name = "Xbox One", Country = "USA", Price = 529.99 };
            return Ok(viewModel);
        }
    }
}