using AutoMapper;
using Data.Models.DTO;
using Data.Models.ViewModel;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Producto, ProductDTO>();

            CreateMap<ProductViewModel, Producto>();

            CreateMap<List<Producto>, List<ProductDTO>>()
                .ConvertUsing(src => src.Select(e => new ProductDTO { Id = e.Id, Descripcion = e.Descripcion, PrecioUnitario = e.PrecioUnitario, SubTotal = e.SubTotal }).ToList());
        }
    }
}
