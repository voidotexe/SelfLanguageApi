using FavoriteVideoMicroService.Data;
using System.Threading.Tasks;

namespace FavoriteVideoMicroService.Services
{
    public interface IFavoriteVideoService
    {
        Task Create(FavoriteVideo favoriteVideo);
        string CheckUserHasSingleFavoriteVideo(int videoId, string userId);
        object Read();
    }
}
