using System.Collections.Generic;

namespace KimShop.Web.Models
{
    public class MenuGroupViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<MenuViewModel> Menus { get; set; }
    }
}