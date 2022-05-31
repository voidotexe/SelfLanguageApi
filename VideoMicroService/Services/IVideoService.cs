/*
 * By: voidotexe
 * https://www.github.com/voidotexe
*/

using System.Collections.Generic;
using System.Threading.Tasks;
using VideoMicroService.Data;

namespace VideoMicroService.Services
{
    public interface IVideoService
    {
        Task<int> Create(Video video);
        object Read();
        object ReadSingle(int id);
    }
}
