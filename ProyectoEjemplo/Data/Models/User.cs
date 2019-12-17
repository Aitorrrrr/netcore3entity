using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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

        [MaxLength(20)]
        public string Password { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        public virtual UserProfile Perfil { get; set; }
    }
}