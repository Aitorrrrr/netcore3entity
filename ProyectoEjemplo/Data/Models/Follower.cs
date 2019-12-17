using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoEjemplo.Data.Models
{
    public class Follower
    {
        public int UserId { get; set; }
        public User UsuarioSigue { get; set; }

        public int FollowerId { get; set; }
        public User UsuarioSeguido { get; set; }

        public DateTime Date { get; set; }
    }
}
