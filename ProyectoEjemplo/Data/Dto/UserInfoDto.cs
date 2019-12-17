namespace ProyectoEjemplo.Data.Dto
{
    public class UserInfoDto
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public UserProfileDto Perfil { get; set; }
    }
}
