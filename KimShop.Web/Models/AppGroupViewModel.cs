using System.Collections.Generic;

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