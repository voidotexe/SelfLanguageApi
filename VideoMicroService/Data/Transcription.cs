/*
 * By: voidotexe
 * https://www.github.com/voidotexe
*/

using System;

#nullable disable

namespace VideoMicroService.Data
{
    public partial class Transcription
    {
        public int Id { get; set; }
        public int VideoId { get; set; }
        public string Content { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Video Video { get; set; }
    }
}
