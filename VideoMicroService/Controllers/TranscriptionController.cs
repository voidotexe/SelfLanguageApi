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
    public class TranscriptionController : ControllerBase
    {
        private readonly ITranscriptionService _transcriptionService;

        public TranscriptionController(ITranscriptionService transcriptionService)
        {
            _transcriptionService = transcriptionService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Transcription transcription)
        {
            await _transcriptionService.Create(transcription);

            return NoContent(); // HTTP 204
        }
    }
}
