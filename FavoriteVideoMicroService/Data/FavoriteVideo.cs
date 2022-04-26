/*
 * By: voidotexe
 * https://www.github.com/voidotexe
*/

#nullable disable

namespace FavoriteVideoMicroService.Data
{
    public partial class FavoriteVideo
    {
        public int Id { get; set; }
        public int VideoId { get; set; }
        public string UserId { get; set; }
    }
}
