/*
 * By: voidotexe
 * https://www.github.com/voidotexe
*/

using FavoriteVideoMicroService.Data;
using FavoriteVideoMicroService.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FavoriteVideoMicroService.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class FavoriteVideoController : ControllerBase
    {
        private readonly IFavoriteVideoService _favoriteVideoService;

        public FavoriteVideoController(IFavoriteVideoService favoriteVideoService)
        {
            _favoriteVideoService = favoriteVideoService;
        }

        [HttpPost]
        public IActionResult Post(FavoriteVideo favoriteVideo)
        {
            _favoriteVideoService.Create(favoriteVideo);

            return NoContent();
        }

        [HttpGet("{videoId}/{userId}")]
        public IActionResult Get(int videoId, string userId)
        {
            return Ok(_favoriteVideoService.CheckUserHasSingleFavoriteVideo(videoId, userId));
        }

        [HttpGet("{userId?}")]
        public async Task<IActionResult> Get(string userId)
        {
            if (userId != null)
            {
                return Ok(await _favoriteVideoService.ReadByUserId(userId));
            }

            return Ok(_favoriteVideoService.Read());
        }
    }
}
