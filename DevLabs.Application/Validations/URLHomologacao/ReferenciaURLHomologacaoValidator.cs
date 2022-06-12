﻿using DevLabs.Application.DTOs.URLHomologacao;
using DevLabs.Application.Interfaces;
using FluentValidation;
using System;

namespace DevLabs.Application.Validations.URLHomologacao
{
    public class ReferenciaURLHomologacaoValidator : AbstractValidator<PutURLHomologacaoDTO>
    {
        private readonly IApplicationProjeto applicationProjeto;

        public ReferenciaURLHomologacaoValidator(IApplicationProjeto applicationProjeto)
        {
            this.applicationProjeto = applicationProjeto;

            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty()
                .Must((putURLHomologacaoDTO, cancelar) =>
                {
                    return ValidateIdURLHomologacaoPut(putURLHomologacaoDTO.Id);
                }).WithMessage("Nenhuma url de homologação foi encontrada com o id informado.");
        }

        private bool ValidateIdURLHomologacaoPut(Guid id)
        {
            return applicationProjeto.ValidateIdURLHomologacaoPut(id);
        }
    }
}