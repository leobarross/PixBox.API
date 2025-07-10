using System.ComponentModel.DataAnnotations;

namespace PixBox.API.Dtos
{
    public class UsuarioInputDto
    {
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF deve conter 11 dígitos, sem pontos ou traço.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório.")]
        [RegularExpression(@"^\d{10,11}$", ErrorMessage = "Telefone deve conter somente números, com DDD (10 ou 11 dígitos).")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória.")]
        [MinLength(6, ErrorMessage = "Senha deve ter no mínimo 6 caracteres.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Data de nascimento é obrigatória.")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Endereço é obrigatório.")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Bairro é obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Cidade é obrigatória")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "UF é obrigatória")]
        public string UF {  get; set; }
    }

}
