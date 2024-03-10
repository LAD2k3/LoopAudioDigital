using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopAudioDigital.Entity
{
    public class PaymentRecords
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Artist")]
        public string artistid { get; set; }
        public Artists? Artists { get; set; }
        public string? ArtistName { get; set; }

        [ForeignKey("TaxYear")]
        public int TaxYearId { get; set; }
        public TaxYear? TaxYear { get; set; }
        [Column(TypeName = "money")]
        public decimal Tax { get; set; }
        [Column(TypeName = "money")]
        public decimal NIC { get; set; }
        [Column(TypeName = "money")]
        public Nullable<decimal> SLC { get; set; }
        [Column(TypeName = "money")]
        public decimal TotalEarnings { get; set; }
        [Column(TypeName = "money")]
        public decimal TotalDeduction { get; set; }
        [Column(TypeName = "money")]
        public decimal Netpayment { get; set; }

    }
}
