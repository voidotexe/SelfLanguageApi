/*
 * By: voidotexe
 * https://www.github.com/voidotexe
*/

using VideoMicroService.Data;
using System.Threading.Tasks;

namespace VideoMicroService.Services
{
    public interface IVideoService
    {
        Task<int> Create(Video video);
        object Read();
    }
}
