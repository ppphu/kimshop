using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KimShop.Web.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Bạn phải nhập vào họ tên.")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập vào tên đăng nhập.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập vào mật khẩu.")]
        [MinLength(6,ErrorMessage ="Mật khẩu ít nhất 6 ký tự.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập email.")]
        [EmailAddress(ErrorMessage ="Địa chỉ email chưa chính xác.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập số điện thoại.")]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
      
        
    }
}