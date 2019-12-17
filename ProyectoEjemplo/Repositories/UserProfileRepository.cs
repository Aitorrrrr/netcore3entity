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
    public class UserProfileRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserProfileRepository(DataContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<UserProfileDto>> GetAll()
        {
            var model = await this._context.UsersProfiles.ToListAsync();
            var result = this._mapper.Map<List<UserProfile>, List<UserProfileDto>>(model);

            return result;
        }

        public async Task<UserProfileDto> GetById(int id)
        {
            var model = await this._context.UsersProfiles.FirstOrDefaultAsync(x => x.Id == id);

            if (model == null)
            {
                throw new Exception("Perfil de usuario no encontrado");
            }

            var result = this._mapper.Map<UserProfileDto>(model);

            return result;
        }
    }
}
