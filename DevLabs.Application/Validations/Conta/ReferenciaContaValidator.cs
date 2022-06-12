using DevLabs.Application.DTOs.Conta;
using DevLabs.Application.Interfaces;
using FluentValidation;
using System;

namespace DevLabs.Application.Validations.Conta
{
    public class ReferenciaContaValidator : AbstractValidator<PutContaDTO>
    {
        private readonly IApplicationProjeto applicationProjeto;

        public ReferenciaContaValidator(IApplicationProjeto applicationProjeto)
        {
            this.applicationProjeto = applicationProjeto;

            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty()
                .Must((putURLProducaoDTO, cancelar) =>
                {
                    return ValidateIdContaPut(putURLProducaoDTO.Id);
                }).WithMessage("Nenhuma conta foi encontrada com o id informado.");
        }

        private bool ValidateIdContaPut(Guid id)
        {
            return applicationProjeto.ValidateIdContaPut(id);
        }
    }
}