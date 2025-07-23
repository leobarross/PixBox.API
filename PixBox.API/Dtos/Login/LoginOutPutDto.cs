using PixBox.Dados.Entidades;
using System.ComponentModel.DataAnnotations;

namespace PixBox.API.Dtos.Login
{
    public class LoginOutPutDto
    {
        public string Status { get; set; } 
        public string Token { get; set; }
        public dynamic User { get; set; }
        public DateTime SessionExpiration { get; set; }
    }
}
