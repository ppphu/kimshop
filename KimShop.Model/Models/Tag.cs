using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KimShop.Model.Models
{
    [Table("Tags")]
    public class Tag
    {
        [Key]
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string ID { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(10)]
        [Column(TypeName = "varchar")]
        public string Type { get; set; }
    }
}