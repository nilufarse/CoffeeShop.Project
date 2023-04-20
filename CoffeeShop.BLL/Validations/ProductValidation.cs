using CoffeeShop.DAL.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.BLL.Validations
{
    public class ProductValidation : AbstractValidator<ProductDto>
    {
        public ProductValidation()
        {
            RuleFor(d => d.Name).NotNull().WithMessage("Xahiş edirem  {PropertyName} alanı daxil ediniz")
                .NotEmpty().WithMessage("Xahiş edirem  {PropertyName} alanı daxil ediniz");
            //  RuleFor(d => d.t).EmailAddress().WithMessage("Xahiş edirem  {PropertyName} alanın düzgün dəyər daxil ediniz"); ;
        }
    }
}
