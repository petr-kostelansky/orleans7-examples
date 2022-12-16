using GrainServiceApp.Grains;
using Microsoft.AspNetCore.Mvc;

namespace GrainServiceApp.Controllers
{
    [ApiController]
    [Route("/api")]
    public class AlfaController : Controller
    {
        private readonly IGrainFactory grainFactory;

        public AlfaController(
            IGrainFactory grainFactory)
        {
            this.grainFactory = grainFactory;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Index([FromRoute] string id)
        {
            try
            {
                var grain = grainFactory.GetGrain<IAlfaGrain>(id);
                var data = await grain.LoadData();

                return Ok(data);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
