using Microsoft.EntityFrameworkCore;
using ProyectoEjemplo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoEjemplo.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UsersProfiles { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }
    }
}