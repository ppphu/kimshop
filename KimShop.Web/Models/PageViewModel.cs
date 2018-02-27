using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KimShop.Web.Models
{
    public class PageViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Content { get; set; }
        public string MetaDiscription { get; set; }
        public string MetaKeyword { get; set; }
        public bool Status { get; set; }
    }
}