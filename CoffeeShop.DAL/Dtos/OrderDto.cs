using CoffeeShop.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DAL.Dtos
{
    public class OrderDto:BaseDto
    {
        public int? UserId { get; set; }
        public AppUser User { get; set; }
        public DateTime OrderDate { get; set; }
        public string Address { get; set; }
        public virtual ICollection<ProductDto> ProductDtos { get; set; }
    }
}
