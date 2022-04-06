/*
 * By: voidotexe
 * https://www.github.com/voidotexe
*/

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VideoMicroService.Data;
using VideoMicroService.Services;

namespace VideoMicroService.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IVideoService _videoService;

        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        // Video/Get
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_videoService.Read());
        }

        // Video/Post
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Video video)
        {
            int videoId = await _videoService.Create(video);

            return Ok(videoId);
        }
    }
}
