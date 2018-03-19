using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KimShop.Model.Models
{
    [Table("UserGroups")]
    public class UserGroup
    {
        [Key]
        [Column(Order = 1)]
        [StringLength(128)]
        public string UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int GroupId { get; set; }

        [ForeignKey("UserId")]
        public AppUser AppUser { get; set; }

        [ForeignKey("GroupId")]
        public AppGroup AppGroup { get; set; }
    }
}