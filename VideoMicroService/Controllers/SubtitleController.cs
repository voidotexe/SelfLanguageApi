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
    public class SubtitleController : ControllerBase
    {
        private readonly ISubtitleService _subtitleService;

        public SubtitleController(ISubtitleService subtitleService)
        {
            _subtitleService = subtitleService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Subtitle subtitle)
        {
            await _subtitleService.Create(subtitle);

            return NoContent();
        }
    }
}
