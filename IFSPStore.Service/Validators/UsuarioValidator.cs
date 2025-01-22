using FluentValidation;
using IFSPStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSPStore.Service.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(u => u.Nome)
               .NotEmpty().WithMessage("Por Favor informe o nome.")
               .NotNull().WithMessage("Por Favor informe o nome.");

            RuleFor(u => u.Login)
               .NotEmpty().WithMessage("Por Favor informe o login.")
               .NotNull().WithMessage("Por Favor informe o login.");

            RuleFor(u => u.Email)
                .EmailAddress().WithMessage("Email Inválido")
               .NotEmpty().WithMessage("Por Favor informe o email.")
               .NotNull().WithMessage("Por Favor informe o email.");

            RuleFor(u => u.Senha)
               .MinimumLength(8).WithMessage("Senha deve ter no mínimo 8 caracteres.")
               .MaximumLength(16).WithMessage("Senha deve ter no máximo 16 caracteres.")
               .Matches(@"[A-Z]+").WithMessage("O campo deve conter pelo menos uma letra maiúscula.")
               .Matches(@"[a-z]+").WithMessage("O campo deve conter pelo menos uma letra minúscula.")
               .Matches(@"[0-9]+").WithMessage("O campo deve conter pelo menos um número.")
               .NotEmpty().WithMessage("Por Favor informe o senha.")
               .NotNull().WithMessage("Por Favor informe o senha.");

            RuleFor(u => u.DataCadastro)
                 .Must(data => data != null && data.Value <= DateTime.Now).WithMessage("A data de cadastro deve ser válida e não pode ser no futuro.")
                 .NotEmpty().WithMessage("A data de cadastro é obrigatória.");

        }
    }
}