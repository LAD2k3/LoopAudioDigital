using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LoopAudioDigital.Entity
{
    public class Songs
    {
        [Key]
        public int songid { get; set; }
        public string songname { get; set; }
        //[ForeignKey("AspNetUser")]
        //public string artistid { get; set; }
        //public  IdentityUser User { get; set; }
        public string artistname { get; set; }
        public int listen_count { get; set; }
        public DateTime date_upload { get; set; }
        public string imageURL { get; set; }
        public string songURL { get; set; }
        public bool status { get; set; }
    }
}
