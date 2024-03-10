/*using LoopAudioDigital.Entity;
using System.ComponentModel.DataAnnotations;

namespace LoopAudioDigital.Models
{
    public class ARTISTCreateViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Artist Name is required"), StringLength(20, MinimumLength = 2)]
        [RegularExpression(@"^[A-Z][a-zA-Z""'\s-]*$"), Display(Name = "Artist Name")]
        public string ArtistName { get; set; }
        [Display(Name = "Image")]
        public IFormFile ImageUrl { get; set; }
        [Required(ErrorMessage = "Artist Name is required"), StringLength(30, MinimumLength = 2)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Artist Name is required"), StringLength(30, MinimumLength = 2)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [DataType(DataType.Date), Display(Name = "Date Participate")]
        public DateTime DateParticipate { get; set; } = DateTime.UtcNow;
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}*/
