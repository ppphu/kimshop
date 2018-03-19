using System;
using System.Collections.Generic;

namespace KimShop.Web.Models
{
    public class AppUserViewModel
    {
        public string Id { set; get; }
        public string FullName { set; get; }
        public DateTime Birthday { set; get; }
        public string Address { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public string UserName { set; get; }
        public string PhoneNumber { set; get; }

        public IEnumerable<AppGroupViewModel> AppGroups { set; get; }
    }
}