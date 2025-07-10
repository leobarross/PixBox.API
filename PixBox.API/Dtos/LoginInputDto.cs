using System.ComponentModel.DataAnnotations;

namespace PixBox.API.Dtos
{
    public class LoginInputDto
    {
        [Required(ErrorMessage = "Telefone é obrigatório.")]
        [RegularExpression(@"^\d{10,11}$", ErrorMessage = "Telefone deve conter somente números, com DDD (10 ou 11 dígitos).")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória.")]
        [MinLength(6, ErrorMessage = "Senha deve ter no mínimo 6 caracteres.")]
        public string Senha { get; set; }
    }
}
