/*
 * By: voidotexe
 * https://www.github.com/voidotexe
*/

using System;
using System.Collections.Generic;

#nullable disable

namespace VideoMicroService.Data
{
    public partial class Video
    {
        public Video()
        {
            Subtitles = new HashSet<Subtitle>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Language { get; set; }
        public string Difficulty { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Transcription Transcription { get; set; }
        public virtual ICollection<Subtitle> Subtitles { get; set; }
    }
}
