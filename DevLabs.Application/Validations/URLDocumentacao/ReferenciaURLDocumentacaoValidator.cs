using DevLabs.Application.DTOs.URLDocumentacao;
using DevLabs.Application.Interfaces;
using FluentValidation;
using System;

namespace DevLabs.Application.Validations.URLDocumentacao
{
    public class ReferenciaUrlDocumentacaoValidator : AbstractValidator<PutUrlDocumentacaoDto>
    {
        private readonly IApplicationProjeto applicationProjeto;

        public ReferenciaUrlDocumentacaoValidator(IApplicationProjeto applicationProjeto)
        {
            this.applicationProjeto = applicationProjeto;

            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty()
                .Must((putURLDocumentacaoDTO, cancelar) =>
                {
                    return ValidateIdURLDocumentacaoPut(putURLDocumentacaoDTO.Id);
                }).WithMessage("Nenhuma url de documentação foi encontrada com o id informado.");
        }

        private bool ValidateIdURLDocumentacaoPut(Guid id)
        {
            return applicationProjeto.ValidateIdURLDocumentacaoPut(id);
        }
    }
}