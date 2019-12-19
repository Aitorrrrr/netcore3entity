using System;

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
