using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DAL.DBModel
{
   public class Order:BaseEntity
    {
        public int ProductId { get; set; }
        public int Count { get; set; }
        public Product Product { get; set; }
        public DateTime OrderDate { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
    }
}
