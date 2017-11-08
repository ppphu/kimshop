using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KimShop.Model.Models
{
    [Table("VisitorStatistics")]
    public class VisitorStatistic
    {
        [Key]
        public Guid ID { get; set; }

        public DateTime? VisitedDate { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string IPAddress { get; set; }
    }
}