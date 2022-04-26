/*
 * By: voidotexe
 * https://www.github.com/voidotexe
*/

using FavoriteVideoMicroService.Data;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FavoriteVideoMicroService.Services
{
    public class FavoriteVideoService : IFavoriteVideoService
    {
        private readonly FavoriteVideoContext _context;

        public FavoriteVideoService(FavoriteVideoContext context)
        {
            _context = context;
        }

        public async Task Create(FavoriteVideo favoriteVideo)
        {
            _context.FavoriteVideos.Add(favoriteVideo);
            await _context.SaveChangesAsync();
        }

        public string CheckUserHasSingleFavoriteVideo(int videoId, string userId)
        {
            var favoriteVideo = (from fv in _context.FavoriteVideos
                                where fv.VideoId == videoId && fv.UserId == userId
                                select new
                                {
                                    fv.Id
                                }).SingleOrDefault();

            if (favoriteVideo != null)
            {
                return "true";
            }

            return "false";
        }

        public object Read()
        {
            object favoriteVideos = from fv in _context.FavoriteVideos
                                    select new
                                    {
                                        fv.Id,
                                        fv.VideoId,
                                        fv.UserId
                                    };

            return favoriteVideos;
        }

        public async Task<object> ReadByUserId(string userId)
        {
            IEnumerable<int> favoriteVideos = from fv in _context.FavoriteVideos
                                              where fv.UserId == userId
                                              select fv.VideoId;

            string url = $"https://localhost:5002/video/getbyids?";

            for (var i = 0; i < favoriteVideos.Count(); i++)
            {
                if (i == favoriteVideos.Count() - 1)
                {
                    url += $"videoIds={favoriteVideos.ElementAt(i)}";

                    break;
                }

                url += $"videoIds={favoriteVideos.ElementAt(i)}&";
            }

            var client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(url);
            string json = await response.Content.ReadAsStringAsync();

            return json;
        }
    }
}
