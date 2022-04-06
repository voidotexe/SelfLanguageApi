/*
 * By: voidotexe
 * https://www.github.com/voidotexe
*/

using System.Threading.Tasks;
using VideoMicroService.Data;

namespace VideoMicroService.Services
{
    public class SubtitleService : ISubtitleService
    {
        private readonly VideoContext _context;

        public SubtitleService(VideoContext context)
        {
            _context = context;
        }

        public async Task Create(Subtitle subtitle)
        {
            _context.Subtitles.Add(subtitle);
            await _context.SaveChangesAsync();
        }
    }
}
