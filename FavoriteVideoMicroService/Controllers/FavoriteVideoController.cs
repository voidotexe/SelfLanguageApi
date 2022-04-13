using FavoriteVideoMicroService.Data;
using FavoriteVideoMicroService.Services;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_favoriteVideoService.Read());
        }
    }
}
