
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoopAudioDigital.Entity
{
    public class Artists : IdentityUser
    {
        public string artistimgURL { get; set; }
        public DateTime date_participate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public ICollection<PaymentRecords> PaymentRecords { get; set; }
        public string? description { get; set; }
    }
}
