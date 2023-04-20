using CoffeeShop.DAL.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.BLL.Validations
{
    public class ProductCategoryValidation : AbstractValidator<ProductCategoryDto>
    {
        public ProductCategoryValidation()
        {
            RuleFor(d => d.Name).NotNull().WithMessage("Xahiş edirem  {PropertyName} alanı daxil ediniz")
                .NotEmpty().WithMessage("Xahiş edirem  {PropertyName} alanı daxil ediniz");
        }
    }
}
