using FluentValidation;
using PixBox.API.Dtos.Usuario;

namespace PixBox.API.Validators
{
    public class UsuarioInputDtoValidator : AbstractValidator<UsuarioInputDto>
    {
        public UsuarioInputDtoValidator()
        {
            RuleFor(u => u.Nome)
            .NotEmpty().WithMessage("Nome é obrigatório.")
            .MaximumLength(100).WithMessage("Nome deve ter no máximo 100 caracteres.");

            RuleFor(u => u.Cpf)
                .NotEmpty().WithMessage("CPF é obrigatório.")
                .Length(11, 14).WithMessage("CPF deve ter entre 11 e 14 caracteres."); // se estiver com pontuação

            RuleFor(u => u.Telefone)
                .NotEmpty().WithMessage("Telefone é obrigatório.")
                .Matches(@"^\d{10,11}$").WithMessage("Telefone deve conter 10 ou 11 dígitos numéricos.");

            RuleFor(u => u.Senha)
                .NotEmpty().WithMessage("Senha é obrigatória.")
                .MinimumLength(6).WithMessage("Senha deve ter no mínimo 6 caracteres.");

            RuleFor(u => u.DataNascimento)
                .Must(TemPeloMenos18Anos).WithMessage("Usuário deve ter no mínimo 18 anos.");
        }

        private bool TemPeloMenos18Anos(DateOnly dataNascimento)
        {
            var hoje = DateOnly.FromDateTime(DateTime.Today);
            var idade = hoje.Year - dataNascimento.Year;

            if (dataNascimento > hoje.AddYears(-idade))
                idade--;

            return idade >= 18;
        }
    }
}
