using Microsoft.EntityFrameworkCore;
using ProyectoEjemplo.Data;
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

        public UserProfileRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<UserProfile>> GetAll()
        {
            return await this._context.UsersProfiles.ToListAsync();
        }

        public async Task<UserProfile> GetById(int id)
        {
            var model = await this._context.UsersProfiles.FirstOrDefaultAsync(x => x.Id == id);

            if (model == null)
            {
                throw new Exception("Perfil de usuario no encontrado");
            }

            return model;
        }
    }
}
