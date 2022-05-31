/*
 * By: voidotexe
 * https://www.github.com/voidotexe
*/

using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
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

        public IEnumerable<Transcription> Read() {
            return _context.Transcriptions.ToList();
        }

        public Transcription ReadSingle(int id) {
            return _context.Transcriptions.Where(t => t.Id == id).FirstOrDefault();
        }

        public Transcription ReadSingleByVideoId(int videoId) {
            return _context.Transcriptions.Where(t => t.VideoId == videoId).FirstOrDefault();
        }
    }
}
