using System;

namespace ProyectoEjemplo.Data.Dto
{
    public class FollowerInfoDto
    {
        public int UserId { get; set; }

        public int FollowerId { get; set; }

        public DateTime Date { get; set; }


        public UserInfoDto UsuarioSigue { get; set; }
        public UserInfoDto UsuarioSeguido { get; set; }
    }
}
