using Microsoft.EntityFrameworkCore;
using ProyectoEjemplo.Data;
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

        public UserRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            //var model = await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            var model = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (model == null)
            {
                throw new Exception("Usuario no encontrado");
            }

            return model;
        }
    }
}
