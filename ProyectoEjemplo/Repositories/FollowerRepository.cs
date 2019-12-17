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
    public class FollowerRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public FollowerRepository(DataContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<FollowerInfoDto>> GetFollowers(int userId)
        {
            var user = await this._context.Users.FindAsync(userId);

            if (user == null)
            {
                throw new Exception("El usuario no existe");
            }

            var model = await this._context.Followers
                                        .Where(x => x.UserId == userId)
                                        .Include(x => x.UsuarioSeguido)
                                            .ThenInclude(x => x.Perfil)
                                        .OrderBy(x => x.UsuarioSeguido.Login)
                                        .ToListAsync();

            return this._mapper.Map<List<Follower>, List<FollowerInfoDto>>(model);
        }

        public async Task<IEnumerable<FollowerInfoDto>> GetFollowings(int userId)
        {
            var user = await this._context.Users.FindAsync(userId);

            if (user == null)
            {
                throw new Exception("El usuario no existe");
            }

            var model = await this._context.Followers
                                        .Where(x => x.FollowerId == userId)
                                        .Include(x => x.UsuarioSigue)
                                            .ThenInclude(x => x.Perfil)
                                        .OrderBy(x => x.UsuarioSigue.Login)
                                        .ToListAsync();

            return this._mapper.Map<List<Follower>, List<FollowerInfoDto>>(model);
        }
    }
}