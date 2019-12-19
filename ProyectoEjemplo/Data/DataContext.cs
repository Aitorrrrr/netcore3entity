using Microsoft.EntityFrameworkCore;
using ProyectoEjemplo.Data.Configurations;
using ProyectoEjemplo.Data.Models;

namespace ProyectoEjemplo.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UsersProfiles { get; set; }
        public DbSet<Follower> Followers { get; set; }
        public DbSet<Post> Posts { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Con assemblys de nuevo las aplicamos
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.Entity<Follower>(ent =>
            {
                ent.ToTable("Followers")
                    .HasKey(x => new { x.UserId, x.FollowerId });
            });
        }
    }
}