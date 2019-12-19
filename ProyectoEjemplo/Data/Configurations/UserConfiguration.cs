using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoEjemplo.Data.Models;

namespace ProyectoEjemplo.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(x => x.UsuariosSeguidos)
                   .WithOne(x => x.UsuarioSigue)
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.UsuariosMeSiguen)
                   .WithOne(x => x.UsuarioSeguido)
                   .HasForeignKey(x => x.FollowerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Posts)
                   .WithOne(x => x.User)
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
