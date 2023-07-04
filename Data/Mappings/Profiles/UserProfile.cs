using AutoMapper;
using Data.Models;
using Data.Models.DTO;
using Data.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<Usuario, UserDTO>()
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre)); //Si no matchean las propiedades, se utiliza este método.

            CreateMap<UserViewModel, Usuario>();

            CreateMap<List<Usuario>, List<UserDTO>>()
                .ConvertUsing(src => src.Select(e => new UserDTO { Nombre = e.Nombre, Id = e.Id, Apellido = e.Apellido, Correo = e.Correo}).ToList());
                 //Indicar todas las propiedades
        }
    }
}
