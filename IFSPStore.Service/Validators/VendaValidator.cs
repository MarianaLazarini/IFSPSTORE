using FluentValidation;
using IFSPStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSPStore.Service.Validators
{
    public class VendaValidator : AbstractValidator<Venda>
    {
        public VendaValidator()
        {
            RuleFor(v => v.ValorTotal)
                .NotEmpty().WithMessage("Por Favor informe o valor.")
                .NotNull().WithMessage("Por Favor informe o valor.");

        }
    }

    public class VendaItemValidator : AbstractValidator<VendaItem>
    {
        public VendaItemValidator()
        {
            RuleFor(v => v.Quantidade)
                .NotEmpty().WithMessage("Por Favor informe o quantidade.")
                .NotNull().WithMessage("Por Favor informe o quantidade.");

        }
    }
}
