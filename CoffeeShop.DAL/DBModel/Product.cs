using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DAL.DBModel
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public decimal UnitOfPrice { get; set; }
        public int TotalCount { get; set; }
        public string ProfileDocPath { get; set; }
   
       

        public virtual ICollection<ProductDocument> ProductDocuments { get; set; }
    }
}
