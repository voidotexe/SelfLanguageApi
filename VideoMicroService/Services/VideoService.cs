/*
 * By: voidotexe
 * https://www.github.com/voidotexe
*/

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoMicroService.Data;

namespace VideoMicroService.Services
{
    public class VideoService : IVideoService
    {
        private readonly VideoContext _context;

        public VideoService(VideoContext context)
        {
            _context = context;
        }

        public async Task<int> Create(Video video)
        {
            _context.Videos.Add(video);
            await _context.SaveChangesAsync();

            return video.Id;
        }

        public object Read()
        {
            var videos = (from v in _context.Videos
                          join t in _context.Transcriptions on v.Id equals t.VideoId
                          join s in _context.Subtitles on v.Id equals s.VideoId
                          select new
                          {
                              v.Title,
                              v.Link,
                              VideoLanguage = v.Language,
                              v.Difficulty,
                              TranscriptionContent = t.Content,
                              SubtitleContent = s.Content,
                              SubtitleLanguage = s.Language,
                              v.CreatedBy,
                              v.CreatedAt
                          }).ToList();

            return videos;
        }

        public object ReadSingle(string link)
        {
            var video = (from v in _context.Videos
                         where v.Link == link
                         join t in _context.Transcriptions on v.Id equals t.VideoId
                         join s in _context.Subtitles on v.Id equals s.VideoId
                         select new
                         {
                             v.Title,
                             v.Link,
                             VideoLanguage = v.Language,
                             v.Difficulty,
                             TranscriptionContent = t.Content,
                             SubtitleContent = s.Content,
                             SubtitleLanguage = s.Language,
                             v.CreatedBy,
                             v.CreatedAt
                         }).FirstOrDefault();
            
            return video;
        }
    }
}
