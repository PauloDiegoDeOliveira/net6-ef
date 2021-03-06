using DevLabs.Application.DTOs.URLProducao;
using DevLabs.Application.Interfaces;
using FluentValidation;
using System;

namespace DevLabs.Application.Validations.URLProducao
{
    public class ReferenciaUrlProducaoValidator : AbstractValidator<PutUrlProducaoDto>
    {
        private readonly IApplicationProjeto applicationProjeto;

        public ReferenciaUrlProducaoValidator(IApplicationProjeto applicationProjeto)
        {
            this.applicationProjeto = applicationProjeto;

            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty()
                .Must((putURLProducaoDTO, cancelar) =>
                {
                    return ValidateIdURLProducaoPut(putURLProducaoDTO.Id);
                }).WithMessage("Nenhuma url de produção foi encontrada com o id informado.");
        }

        private bool ValidateIdURLProducaoPut(Guid id)
        {
            return applicationProjeto.ValidateIdURLProducaoPut(id);
        }
    }
}