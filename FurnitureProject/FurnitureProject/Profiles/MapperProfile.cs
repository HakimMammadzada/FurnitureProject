using AutoMapper;
using FurnitureProject.Data.Entities;
using FurnitureProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureProject.Profiles
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            this.CreateMap<Categoriy, CategoriyModel>().ReverseMap();
            this.CreateMap<Marka, MarkaModel>().ReverseMap();
           // this.CreateMap<Slider, SliderModel>().ReverseMap();
            this.CreateMap<Product, ProductModel>().ReverseMap();
            this.CreateMap<ProductColor, ProductColorModel>().ReverseMap();
            this.CreateMap<ProductCountry, ProductCountryModel>().ReverseMap();
            this.CreateMap<ProductDesinger, ProductDesingerModel>().ReverseMap();
            this.CreateMap<Color, ColorModel>().ReverseMap();
            this.CreateMap<Property, PropertyModel>().ReverseMap();
            this.CreateMap<Image, ImageModel>().ReverseMap();


            this.CreateMap<AppUser, RegisterModel>()
                  .ForMember(t => t.Username, f => f.MapFrom(t => t.UserName))
                   .ForMember(t => t.Email, f => f.MapFrom(t => t.Email))
                   .ReverseMap();
        }
    }
}
