/*
 * By: voidotexe
 * https://www.github.com/voidotexe
*/

using System.Threading.Tasks;
using System.Collections.Generic;
using VideoMicroService.Data;

namespace VideoMicroService.Services
{
    public interface ITranscriptionService
    {
        Task Create(Transcription transcription);
        Transcription ReadSingle(int id);
        Transcription ReadSingleByVideoId(int videoId);
        IEnumerable<Transcription> Read();
    }
}
