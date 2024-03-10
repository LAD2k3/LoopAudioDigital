/*using LoopAudioDigital.Entity;
using System.ComponentModel.DataAnnotations;

namespace LoopAudioDigital.Models
{
    public class ARTISTEditViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Artist Name is required"), StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"^[A-Z][a-zA-Z""'\s-]*$"), Display(Name = "Artist Name")]
        public string ArtistName { get; set; }
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
        
        [DataType(DataType.Date), Display(Name = "Date Participate")]
        public DateTime DateParticipate { get; set; } = DateTime.UtcNow;
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}*/
