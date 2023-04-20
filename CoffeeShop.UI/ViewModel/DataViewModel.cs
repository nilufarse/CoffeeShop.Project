using CoffeeShop.DAL.DBModel;
using CoffeeShop.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.UI.ViewModel
{
    public class DataViewModel
    {
            public IEnumerable<Product> Products { get; set; }
            public IEnumerable<ProductCategory> ProductCategories { get; set; }
            public IEnumerable<ProductDocument> ProductDocuments { get; set; }
            public IEnumerable<Order> Orders { get; set; }
            public IEnumerable<Contact> Contacts { get; set; }
            public IEnumerable<SiteSocialLink> SiteSocialLinks { get; set; }
            public IEnumerable<SiteInfo> SiteInfos { get; set; }
    }
}
