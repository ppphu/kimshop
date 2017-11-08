﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KimShop.Model.Models
{
    [Table("SupportOnlines")]
    public class SupportOnline
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [MaxLength(256)]
        public string Department { get; set; }

        [MaxLength(256)]
        public string Skype { get; set; }

        [MaxLength(256)]
        public string Facebook { get; set; }

        [MaxLength(50)]
        public string Mobile { get; set; }

        [MaxLength(256)]
        public string Yahoo { get; set; }

        public bool Status { get; set; }
    }
}
