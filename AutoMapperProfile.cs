using AutoMapper;
using BackEnd_DotNetCoreAPI.DTOs;
using BackEnd_DotNetCoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd_DotNetCoreAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Role, RoleDto>()
                .ForMember(x => x.RoleName, x => x.MapFrom(x => x.Name));
            CreateMap<RoleDtoAdd, Role>()
                .ForMember(x => x.Name, x => x.MapFrom(x => x.RoleName)); ;
            CreateMap<UserRole, UserRoleDto>();
            CreateMap<Product, GetProductDto>();
            //CreateMap<GetProductDto, Product>();
            CreateMap<ProductGroup, GetProductGroupDto>();
            //CreateMap<GetProductGroupDto, ProductGroup>();
            CreateMap<MovementStock, GetMovementStockDto>();
            CreateMap<MovementType, GetMovementTypeDto>();
        }
    }
}