using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FurnitureProject.Data.Entities;
using FurnitureProject.Areas.Admin.Models;

namespace FurnitureProject.Areas.Admin.AdminProfile
{
    public class AdminProfile:Profile
    {
        public AdminProfile()
        {
            this.CreateMap<Categoriy, CategoriyModel>().ReverseMap();
            this.CreateMap<Color, ColorModel>().ReverseMap();
            this.CreateMap<ProductColor, ProductColorModel>().ReverseMap();
            this.CreateMap<ProductDesinger, ProductDesingerModel>().ReverseMap();
            this.CreateMap<Image, ImageModel>().ReverseMap();
            this.CreateMap<ProductCountry, ProductCountryModel>().ReverseMap();
            this.CreateMap<Property, PropertyModel>().ReverseMap();
            this.CreateMap<Marka, MarkaModel>().ReverseMap();
            this.CreateMap<Product, ProductModel>().ReverseMap()
               .ForMember(t => t.Mainimage, f => f.MapFrom(u => u.Mainimage));


        }
    }
}
