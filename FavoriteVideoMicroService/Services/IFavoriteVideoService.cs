/*
 * By: voidotexe
 * https://www.github.com/voidotexe
*/

using FavoriteVideoMicroService.Data;
using System.Threading.Tasks;

namespace FavoriteVideoMicroService.Services
{
    public interface IFavoriteVideoService
    {
        Task Create(FavoriteVideo favoriteVideo);
        string CheckUserHasSingleFavoriteVideo(int videoId, string userId);
        object Read();
        Task<object> ReadByUserId(string userId);
    }
}
