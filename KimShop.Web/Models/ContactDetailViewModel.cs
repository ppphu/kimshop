using System.ComponentModel.DataAnnotations;

namespace KimShop.Web.Models
{
    public class ContactDetailViewModel
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [MaxLength(50,ErrorMessage ="Số điện thoại không được vượt quá 50 ký tự.")]
        public string Phone { get; set; }
        [MaxLength(250, ErrorMessage = "Email không được vượt quá 250 ký tự.")]
        public string Email { get; set; }
        [MaxLength(250, ErrorMessage = "Địa chỉ không được vượt quá 250 ký tự.")]
        public string Address { get; set; }
        [MaxLength(250, ErrorMessage = "Domain website không được vượt quá 250 ký tự.")]
        public string Website { get; set; }
        public string Other { get; set; }
        public double? Lat { get; set; }
        public double? Lng { get; set; }
        public bool Status { get; set; }
    }
}