using Microsoft.EntityFrameworkCore;
using ProyectoEjemplo.Data.Models;

namespace ProyectoEjemplo.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UsersProfiles { get; set; }
        public DbSet<Follower> Followers { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Follower>(ent =>
            {
                ent.ToTable("Followers")
                    .HasKey(x => new { x.UserId, x.FollowerId });
            });

            modelBuilder.Entity<User>(ent =>
            {
                ent.HasMany(x => x.UsuariosSeguidos)
                   .WithOne(x => x.UsuarioSigue)
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

                ent.HasMany(x => x.UsuariosMeSiguen)
                   .WithOne(x => x.UsuarioSeguido)
                   .HasForeignKey(x => x.FollowerId)
                   .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}