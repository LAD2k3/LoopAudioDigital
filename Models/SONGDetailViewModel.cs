using LoopAudioDigital.Entity;

namespace LoopAudioDigital.Models
{
    public class SONGDetailViewModel
    {
        public int Id { get; set; }
        public string SongName { get; set; }
        public string SongUrl { get; set; }
        public string ImageUrl { get; set; }
        public int ListenCount { get; set; }
        public DateTime DateUpload { get; set; }
        public string ArtistName { get; set; }
        public bool Status { get; set; }
    }
}
