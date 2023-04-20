using CoffeeShop.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DAL.Dtos
{
    public class ProductDto : BaseDto
    {
        [DisplayName("Ad")]
        public string Name { get; set; }
        [DisplayName("Açıqlama")]
        public string Description { get; set; }
        [DisplayName("Kateqori adi")]
        public int ProductCategoryId { get; set; }
        [DisplayName("Ədəd qiyməti")]
        public decimal UnitOfPrice { get; set; }
        [DisplayName("Toplam miqdarı")]
        public int TotalCount { get; set; }
        [DisplayName("Rəsim")]
        public string ProfileDocPath { get; set; }

        public List<ProductDocumentDto> ProductDocuments { get; set; }
        public List<ProductCategoryDto> CategoryDtos { get; set; }
    }
}
