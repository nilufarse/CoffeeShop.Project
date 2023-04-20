using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DAL.Dtos
{
    public class ProductCategoryDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
