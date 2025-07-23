using FluentValidation;
using PixBox.API.Dtos.Login;

namespace PixBox.API.Validators
{
    public class LoginInputDtoValidator : AbstractValidator<LoginInputDto>
    {
        public LoginInputDtoValidator()
        {
            RuleFor(l => l.Telefone)
                .NotEmpty().WithMessage("Telefone é obrigatório.")
                .Matches(@"^\d{10,11}$").WithMessage("Telefone deve conter 10 ou 11 dígitos numéricos.");

            RuleFor(l => l.Senha)
                .NotEmpty().WithMessage("Senha é obrigatória.")
                .MinimumLength(6).WithMessage("Senha deve ter no mínimo 6 caracteres.");
        }
    }
}
