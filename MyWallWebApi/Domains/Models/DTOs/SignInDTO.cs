using System.ComponentModel.DataAnnotations;

namespace MyWallWebApi.Domains.DTOs
{
    public class SignInDTO
    {
        [Required(ErrorMessage ="Nome de Usuário é obrigatório")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Senha é obrigatória")]
        public string Password { get; set; }
    }
}
