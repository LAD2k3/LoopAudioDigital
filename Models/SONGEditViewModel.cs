using LoopAudioDigital.Entity;
using System.ComponentModel.DataAnnotations;

namespace LoopAudioDigital.Models
{
    public class SONGEditViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Song Name is required"), StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"^[A-Z][a-zA-Z""'\s-]*$"), Display(Name = "Song Name")]
        public string SongName { get; set; }
        //public string ArtistId { get; set; }
        [Display(Name = " Artist Name")]
        public string ArtistName { get; set; }
        [Display(Name = " SongURL")]
        public IFormFile SongUrl { get; set; }
        [Display(Name = "Image")]
        public IFormFile ImageUrl { get; set; }
        [Display(Name = "Listen Count")]
        public DateTime DateUpload { get; set; } = DateTime.UtcNow;
    }
}