using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Architecture.Entities.Concrete;
using Architecture.Entities.Dtos.AuthDtos;
using Architecture.Entities.Dtos.CategoryDtos;
using Architecture.Entities.Dtos.ProductDtos;
using Architecture.Entities.Dtos.SpecificationDtos;
using MassTransit;
using Architecture.Entities.Dtos.WishlistDtos;
using Architecture.Entities.Dtos.OrderDtos;
using Architecture.Entities.Dtos.UserDtos;

namespace Architecture.Business.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
			CreateMap<User, UserInfoDto>();
			CreateMap<RegisterDto, User>();

			CreateMap<CategoryCreateDto, Category>();
			CreateMap<CategoryUpdateDto, Category>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryHomeDto>();
            CreateMap<Category, CategoryNavbarDto>();


			CreateMap<Product, ProductDetailDto>();
			CreateMap<ProductUpdateDto, Product>();
			CreateMap<ProductCreateDto, Product>();

			CreateMap<Product, ProductRecentDto>();
			CreateMap<Product, ProductFilterDto>();
			CreateMap<Product, ProductFeaturedDto>();
			CreateMap<Product, ProductDto>();

			CreateMap<SpecificationCreateDto, Specification>();
			CreateMap<Specification, SpecificationListDto>();

			CreateMap<UserWishListDto, User>().ReverseMap();
			CreateMap<WishList, WishlistItemDto>()
				.ForMember(x=>x.ProductName, o=>o.MapFrom(s=>s.Product.Title))
				.ForMember(x=>x.Price, o=>o.MapFrom(s=>s.Product.Price));

			CreateMap<WishListAddItemDto, WishList>();


			CreateMap<OrderCreateDto, Order>();

			CreateMap<User, UserOrderDto>();
        

			CreateMap<Order, OrderUserDto>()
						.ForMember(x => x.ProductName, o => o.MapFrom(x => x.Product.Title))
						.ForMember(x => x.OrderEnum, o => o.MapFrom(x => Enum.GetName(x.OrderEnum)));
        }
}
