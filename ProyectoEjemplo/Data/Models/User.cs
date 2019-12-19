using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoEjemplo.Data.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Column("Username")]
        [MaxLength(20)]
        public string Login { get; set; }

        [MaxLength(200)]
        public string Password { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        public virtual UserProfile Perfil { get; set; }

        public virtual IEnumerable<Follower> UsuariosSeguidos { get; set; }

        public virtual IEnumerable<Follower> UsuariosMeSiguen { get; set; }

        public virtual IEnumerable<Post> Posts { get; set; }
    }
}