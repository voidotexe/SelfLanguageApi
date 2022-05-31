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
                          select new
                          {
			                  v.Id,
                              v.Title,
                              v.Link,
                              v.Language,
                              v.Difficulty,
                              v.CreatedBy,
                              v.CreatedAt
                          }).ToList();

            return videos;
        }

        public object ReadSingle(int id)
        {
            var video = (from v in _context.Videos
                         where v.Id == id
                         select new
                         {
			                 v.Id,
                             v.Title,
                             v.Link,
                             v.Language,
                             v.Difficulty,
                             v.CreatedBy,
                             v.CreatedAt
                         }).FirstOrDefault();
            
            return video;
        }
    }
}
