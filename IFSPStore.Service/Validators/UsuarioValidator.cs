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
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Por favor informe o nome.")
                .NotNull().WithMessage("Por favor infome o nome.")
                .Length(50);

            RuleFor(c => c.Email)
                .EmailAddress().WithMessage("E-Mail inválido.")
                .NotEmpty().WithMessage("Por favor infome o email.")
                .NotNull().WithMessage("Por favor infome o email.");

            RuleFor(c => c.Senha)
                    .MinimumLength(8).WithMessage("Sua senha deve ter no mínimo 8 caractéres.")
                    .MinimumLength(16).WithMessage("Sua senha não deve exceder 16 caractéres")
                    .Matches(@"|A Z|+").WithMessage("Sua senha deve ter ao menos uma letra Maiúscula")
                    .Matches(@"|a z|+").WithMessage("Sua senha deve ter ao menos uma letra Minúscula")
                    .Matches(@"|0 9|+").WithMessage("Sua senha deve ter ao menos uma letra")
                    .Matches(@"|\!\?\*\.|+").WithMessage("Sua senha deve ter ao menos (!? *.).")
                    .NotEmpty().WithMessage("Por favor informa a senha.")
                    .NotNull().WithMessage("Por favor informa a senha.");
        }
    }
}