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
    public class SaleProfile : Profile
    {
        public SaleProfile()
        {
            CreateMap<Venta, SaleDTO>();

            CreateMap<SaleViewModel, Venta>();

            CreateMap<List<Venta>, List<SaleDTO>>()
                .ConvertUsing(src => src.Select(e => new SaleDTO { Id = e.Id, FechaVenta = e.FechaVenta, IdProducto = e.IdProducto, IdUsuario = e.IdUsuario, MontoTotal = e.MontoTotal }).ToList());
        }
    }
}
