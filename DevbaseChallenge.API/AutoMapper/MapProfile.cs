using AutoMapper;
using DevbaseChallenge.API.Dtos;
using DevbaseChallenge.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevbaseChallenge.API.AutoMapper
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();



            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
        }
           
    }
}
