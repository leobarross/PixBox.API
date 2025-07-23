using System.ComponentModel.DataAnnotations;

namespace PixBox.API.Dtos.Login
{
    public class LoginInputDto
    {
        public string Telefone { get; set; }
        public string Senha { get; set; }
    }
}
