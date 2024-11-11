using FluentValidation;
using IFSPStore.Domain.Entities;

namespace CenciAdv.Service.Validators
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Por favor informe o nome.")
                .NotNull().WithMessage("Por favor informe o nome.");

            RuleFor(c => c.Endereco)
                .NotEmpty().WithMessage("Por favor informe o Endereco.")
                .NotNull().WithMessage("Por favor informe o Endereco.");

            RuleFor(c => c.Bairro)
                .NotEmpty().WithMessage("Por favor informe o bairro.")
                .NotNull().WithMessage("Por favor informe o bairro.");

            RuleFor(c => c.Documento)
                .NotEmpty().WithMessage("Por favor informe o documento.")
                .NotNull().WithMessage("Por favor informe o documento.");


            RuleFor(c => c.Cidade)
                .NotEmpty().WithMessage("Por favor informe a cidade.")
                .NotNull().WithMessage("Por favor informe a cidade.");

        }
    }
}