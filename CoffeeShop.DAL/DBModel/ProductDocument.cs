using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DAL.DBModel
{
    public class ProductDocument : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string DocumentUrl { get; set; }
    }
}
