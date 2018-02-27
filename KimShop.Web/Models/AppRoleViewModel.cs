using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KimShop.Web.Models
{
    public class AppRoleViewModel
    {
        public string Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Discriminator { set; get; }
        
    }
}