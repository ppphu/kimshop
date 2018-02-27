using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KimShop.Web.Models
{
    public class AppGroupViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Descripton { get; set; }
        public IEnumerable<AppRoleViewModel> Roles { set; get; }
    }
}