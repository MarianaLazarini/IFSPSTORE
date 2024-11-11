using FluentValidation;
using IFSPStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSPStore.Service.Validators
{
    public class CidadeValidator : AbstractValidator<Cidade>
    {
        public CidadeValidator() 
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Por favor informe o nome.")
                .NotNull().WithMessage("Por favor infome o nome.")
                .Length(50)
                .WithMessage("Nome pode ter no máximo 50 caractéres.");

            RuleFor(c => c.Estado)
                .NotEmpty().WithMessage("Por favor informe o Estado.")
                .NotNull().WithMessage("Por favor infome o Estado.")
                .Length(2);
        }
    }
}
