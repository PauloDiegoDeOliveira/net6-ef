using DevLabs.Application.DTOs.Projeto;
using DevLabs.Application.Interfaces;
using DevLabs.Application.Validations.Conta;
using DevLabs.Application.Validations.URLDocumentacao;
using DevLabs.Application.Validations.URLHomologacao;
using DevLabs.Application.Validations.URLProducao;
using FluentValidation;
using System;

namespace DevLabs.Application.Validations.Projeto
{
    public class PutProjetoValidator : AbstractValidator<PutProjetoDto>
    {
        private readonly IApplicationProjeto applicationProjeto;

        public PutProjetoValidator(IApplicationProjeto applicationProjeto)
        {
            this.applicationProjeto = applicationProjeto;

            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("O id do título não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O id do título não pode ser vazio.")

                .Must((putProjetoDTO, cancelar) =>
                {
                    return ValidateIdProjectPut(putProjetoDTO.Id);
                }).WithMessage("Nenhum projeto foi encontrado com o id informado.");

            RuleFor(x => x.Titulo)
                .NotNull()
                .WithMessage("O título não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O título não pode ser vazio.");

            When(x => x.Titulo != null, () =>
            {
                RuleFor(x => x)
                    .Must((dto, cancellation) =>
                    {
                        return !ValidateNamePut(dto);
                    }).WithMessage("Já existe um projeto cadastrado com o nome informado.");
            });

            RuleFor(x => x.Situacao)
                .NotNull()
                .WithMessage("A situação não pode ser nulo.")

                .NotEmpty()
                .WithMessage("A situação não pode ser vazio.");

            RuleFor(x => x.Prioridade)
                .NotNull()
                .WithMessage("A prioridade não pode ser nulo.")

                .NotEmpty()
                .WithMessage("A prioridade não pode ser vazio.");

            RuleFor(x => x.EstadoProjeto)
                .NotNull()
                .WithMessage("O estado do projeto não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O estado do projeto não pode ser vazio.");

            RuleFor(x => x.Status)
                .NotNull()
                .WithMessage("O status do projeto não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O status do projeto não pode ser vazio.");

            RuleForEach(x => x.URLSHomologacao)
                .SetValidator(new ReferenciaUrlHomologacaoValidator(applicationProjeto));

            RuleForEach(x => x.URLSProducao)
                .SetValidator(new ReferenciaUrlProducaoValidator(applicationProjeto));

            RuleForEach(x => x.URLSDocumentacao)
                .SetValidator(new ReferenciaUrlDocumentacaoValidator(applicationProjeto));

            RuleForEach(x => x.Contas)
                .SetValidator(new ReferenciaContaValidator(applicationProjeto));
        }

        private bool ValidateIdProjectPut(Guid id)
        {
            return applicationProjeto.ValidateIdProjectPut(id);
        }

        private bool ValidateNamePut(PutProjetoDto dto)
        {
            return applicationProjeto.ValidateNamePut(dto);
        }
    }
}