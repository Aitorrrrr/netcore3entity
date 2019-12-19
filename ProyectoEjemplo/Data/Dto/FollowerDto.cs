using System;

namespace ProyectoEjemplo.Data.Dto
{
    public class FollowerDto
    {
        public int UserId { get; set; }

        public int FollowerId { get; set; }

        public DateTime Date { get; set; }
    }
}
