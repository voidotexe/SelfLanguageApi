/*
 * By: voidotexe
 * https://www.github.com/voidotexe
*/

using System.Threading.Tasks;
using VideoMicroService.Data;

namespace VideoMicroService.Services
{
    public interface ISubtitleService
    {
        Task Create(Subtitle subtitle);
        Subtitle ReadSingleByVideoId(int videoId);
    }
}
