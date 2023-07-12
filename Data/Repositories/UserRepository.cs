using AutoMapper;
using Data.Mappings;
using Data.Models;
using Data.Models.DTO;
using Data.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data.Repositories
{
    public class UserRepository
    {
        private readonly ECommerceDBContext _dbContext;
        private readonly IMapper _mapper;
        public UserRepository(ECommerceDBContext eCommerceDBContext)
        {
            _dbContext = eCommerceDBContext;
            _mapper = AutoMapperConfig.Configure(); //Se inyecta acá porque la configuración no está en Program, está en una clase. Llama a la clase y al método.
        }
        public List<UserDTO> GetUsers()
        {
            //var listUsuarios = _dbContext.Usuario.ToList();
            return _mapper.Map<List<UserDTO>>(_dbContext.Usuario.ToList());
            //List<Usuario> users = _dbContext.Usuario.ToList();
            //List<UserDTO> response = new List<UserDTO>();
            //foreach (var user in users)
            //{
            //    UserDTO usuario = _mapper.Map<UserDTO>(user);
            //    response.Add(usuario);
            //}
            //return response;
        }

        public UserDTO GetUserById(int id)
        {
            return _mapper.Map<UserDTO>(_dbContext.Usuario.Where(x => x.Id == id).FirstOrDefault());
            //UserDTO response = new UserDTO();
            //Usuario user = _dbContext.Usuario.FirstOrDefault(x => x.Id == id);
            //if (user != null)
            //{
            //    response.Id = user.Id;
            //    response.Nombre = user.Nombre;
            //    response.Apellido = user.Apellido;
            //    response.Correo = user.Correo;
            //    response.IdRol = user.IdRol;
            //}
            //return response;
        }

        public UserDTO GetUserByEmail(string email)
        {
            return _mapper.Map<UserDTO>(_dbContext.Usuario.FirstOrDefault(x => x.Correo.ToLower() == email.ToLower()));
        }
        public UserDTO PostUser(UserViewModel usuario)
        {

            _dbContext.Usuario.Add(new Usuario()
            {
              Apellido = usuario.Apellido,
              Nombre = usuario.Nombre,
              Correo = usuario.Correo,
              Contrasenia = usuario.Contrasenia,
              IdRol = usuario.IdRol
            });
            _dbContext.SaveChanges();

            var lastUser = _dbContext.Usuario.OrderBy(x => x.Id).Last();

            return _mapper.Map<UserDTO>(lastUser);

        }
        public UserDTO PutUser(UserViewModel usuario)
        {
            Usuario usuarioDataBase = _dbContext.Usuario.Single(f => f.Id == usuario.Id);
            usuarioDataBase.Nombre = usuario.Nombre;
            usuarioDataBase.Correo = usuario.Correo;
            usuarioDataBase.Apellido = usuario.Apellido;
            usuarioDataBase.Contrasenia = usuario.Contrasenia;
            usuarioDataBase.IdRol = usuario.IdRol; //Modificar DB, rol not null

            _dbContext.SaveChanges();

            var lastUser = _dbContext.Usuario.OrderBy(x => x.Id).Last();
            return _mapper.Map<UserDTO>(lastUser);
        }
        public void DeleteUser(int id)
        {
            _dbContext.Usuario.Remove(_dbContext.Usuario.Single(w => w.Id == id));
            _dbContext.SaveChanges();
        }

    }
}
