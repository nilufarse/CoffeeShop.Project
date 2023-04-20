using AutoMapper;
using CoffeeShop.DAL.DBModel;
using CoffeeShop.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.BLL.Mapping
{
    public class CustomMapping : Profile
    {
        public CustomMapping()
        {
            CreateMap<ProductCategory, ProductCategoryDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductDocument, ProductDocumentDto>().ReverseMap();
            CreateMap<Contact, ContactDto>().ReverseMap();
            CreateMap<SiteSocialLink, SiteSocialLinkDto>().ReverseMap();
            CreateMap<SiteInfo, SiteInfoDto>().ReverseMap();
        }
    }
}
