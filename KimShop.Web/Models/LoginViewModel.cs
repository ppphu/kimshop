using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KimShop.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Bạn cần nhập vào tài khoản.")]
        public string UserName {get;set;}
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Bạn cần nhập vào mật khẩu.")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}