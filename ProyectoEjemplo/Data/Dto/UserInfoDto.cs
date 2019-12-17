using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoEjemplo.Data.Dto
{
    public class UserInfoDto
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public UserProfileDto Perfil { get; set; }
    }
}
