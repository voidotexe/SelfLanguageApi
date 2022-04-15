using FavoriteVideoMicroService.Data;
using Newtonsoft.Json;
using System.Linq;
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
    }
}
