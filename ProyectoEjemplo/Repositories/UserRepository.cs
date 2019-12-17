using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProyectoEjemplo.Data;
using ProyectoEjemplo.Data.Dto;
using ProyectoEjemplo.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoEjemplo.Repositories
{
    public class UserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserRepository(DataContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<UserInfoDto>> GetAll()
        {
            var model = await _context.Users.ToListAsync();
            var result = this._mapper.Map<List<User>, List<UserInfoDto>>(model);

            return result;
        }

        public async Task<UserInfoDto> GetById(int id)
        {
            //var model = await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            var model = await _context.Users.Include(x => x.Perfil).FirstOrDefaultAsync(x => x.Id == id);

            if (model == null)
            {
                throw new Exception("Usuario no encontrado");
            }

            var result = this._mapper.Map<UserInfoDto>(model);

            return result;
        }

        public async Task<UserInfoDto> Update(int userId, UserDto userDto)
        {
            var user = await this._context.Users.FindAsync(userId);

            if (user == null)
            {
                throw new Exception("Usuario no encontrado");
            }

            //Versión 1
            //var model = this._mapper.Map<User>(userDto);

            //this._context.Entry(user).CurrentValues.SetValues(userDto);
            //this._context.Users.Update(user);

            //await this._context.SaveChangesAsync();

            //return this._mapper.Map<UserInfoDto>(user);

            //Versión 2
            this._context.Entry<User>(user).State = EntityState.Detached;

            var model = this._mapper.Map<User>(userDto);
            this._context.Update(model);

            return this._mapper.Map<UserInfoDto>(model);
        }
    }
}
