using DevLabs.Application.DTOs.URLDocumentacao;
using DevLabs.Application.Interfaces;
using FluentValidation;
using System;

namespace DevLabs.Application.Validations.URLDocumentacao
{
    public class ReferenciaURLDocumentacaoValidator : AbstractValidator<PutURLDocumentacaoDTO>
    {
        private readonly IApplicationProjeto applicationProjeto;

        public ReferenciaURLDocumentacaoValidator(IApplicationProjeto applicationProjeto)
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