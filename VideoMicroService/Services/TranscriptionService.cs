/*
 * By: voidotexe
 * https://www.github.com/voidotexe
*/

using System.Threading.Tasks;
using VideoMicroService.Data;

namespace VideoMicroService.Services
{
    public class TranscriptionService : ITranscriptionService
    {
        private readonly VideoContext _context;

        public TranscriptionService(VideoContext context)
        {
            _context = context;
        }

        public async Task Create(Transcription transcription)
        {
            _context.Transcriptions.Add(transcription);
            await _context.SaveChangesAsync();
        }
    }
}
