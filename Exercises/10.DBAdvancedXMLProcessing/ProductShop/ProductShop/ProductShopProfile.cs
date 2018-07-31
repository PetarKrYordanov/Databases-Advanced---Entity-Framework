using AutoMapper;
using ProductShop.Dtos;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile:Profile
    {
        public ProductShopProfile()
        {
            CreateMap<ProductDto,Product>();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
        }
    }
}