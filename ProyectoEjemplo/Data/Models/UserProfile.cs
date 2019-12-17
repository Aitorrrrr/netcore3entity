using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoEjemplo.Data.Models
{
    [Table("UsersProfiles")]
    public class UserProfile
    {
        [Key]
        [ForeignKey("User")]
        public int Id { get; set; }

        [Column("FullName")]
        [MaxLength(50)]
        public string FullName { get; set; }

        [Column("Image")]
        [MaxLength(200)]
        public string Image { get; set; }

        public virtual User User { get; set; }
    }
}