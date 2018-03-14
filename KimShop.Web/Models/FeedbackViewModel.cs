using System;
using System.ComponentModel.DataAnnotations;

namespace KimShop.Web.Models
{
    public class FeedbackViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Phải nhập vào họ tên.")]
        [MaxLength(250, ErrorMessage = "Họ tên không vượt quá 250 ký tự.")]
        public string Name { get; set; }

        [MaxLength(250, ErrorMessage = "Email không vượt quá 250 ký tự.")]
        public string Email { get; set; }

        [MaxLength(500, ErrorMessage = "Nội dung phản hồi không vượt quá 500 ký tự.")]
        public string Message { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "Phải nhập trạng thái")]
        public bool Status { get; set; }

        public ContactDetailViewModel ContactDetail { get; set; }
    }
}