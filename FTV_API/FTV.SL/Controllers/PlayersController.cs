using ForniteApi;
using System.Threading.Tasks;
using System.Web.Http;
using FTV.BL;

namespace FTV.SL.Controllers
{
    public class PlayersController : ApiController
    {
        // GET: api/Player
        [HttpGet]
        [Route("~/api/Players/{username}")]
        public async Task<IHttpActionResult> Get(string userName)
        {
            var player = await FortniteApi.GetPlayerData(userName);

            return Ok(player);
        }
    }
}