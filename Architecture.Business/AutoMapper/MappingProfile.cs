using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Architecture.Entities.Concrete;
using Architecture.Entities.Dtos.AuthDtos;
using Architecture.Entities.Dtos.CategoryDtos;

namespace Architecture.Business.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category,CategoryCreateDto>().ReverseMap();
        CreateMap<User, RegisterDto>().ReverseMap();
        CreateMap<User, LoginUserDto>().ReverseMap();
    }
}
