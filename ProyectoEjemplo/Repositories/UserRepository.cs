using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProyectoEjemplo.Data;
using ProyectoEjemplo.Data.Dto;
using ProyectoEjemplo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<UserInfoDto> Create (UserDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Password))
            {
                throw new Exception("Password vacío");
            }

            if (await this._context.Users.AnyAsync(x => x.Login == dto.Login))
            {
                throw new Exception("El usuario " + dto.Login + " ya existe");
            }

            dto.Password = EncryptPassword(dto.Password);

            var model = this._mapper.Map<User>(dto);

            this._context.Users.Add(model);
            await this._context.SaveChangesAsync();

            return this._mapper.Map<UserInfoDto>(model);
        }

        public async Task<UserInfoDto> Update(int userId, UserDto userDto)
        {
            var user = await this._context.Users.FindAsync(userId);

            if (user == null)
            {
                throw new Exception("Usuario no encontrado");
            }

            if (!string.IsNullOrWhiteSpace(userDto.Password))
            {
                userDto.Password = EncryptPassword(userDto.Password);
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

        public async Task<UserInfoDto> Delete(int userId)
        {
            var model = await this._context.Users.FindAsync(userId);

            if (model != null)
            {
                var followers = this._context.Followers.Where(x => x.FollowerId == userId);
                this._context.Followers.RemoveRange(followers);

                var following = this._context.Followers.Where(x => x.UserId == userId);
                this._context.Followers.RemoveRange(following);

                this._context.Users.Remove(model);

                await this._context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("No existe el usuario");
            }

            return this._mapper.Map<UserInfoDto>(model);
        }

        private string EncryptPassword(string pw)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(pw);

            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);

            return System.Text.Encoding.ASCII.GetString(data);
        }
    }
}
