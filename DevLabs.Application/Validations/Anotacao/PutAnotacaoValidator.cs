using DevLabs.Application.DTOs.Anotacao;
using DevLabs.Application.Interfaces;
using FluentValidation;
using System;

namespace DevLabs.Application.Validations.Anotacao
{
    public class PutAnotacaoValidator : AbstractValidator<PutAnotacaoDTO>
    {
        private readonly IApplicationAnotacao applicationAnotacao;

        public PutAnotacaoValidator(IApplicationAnotacao applicationAnotacao)
        {
            this.applicationAnotacao = applicationAnotacao;

            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("O id da anotação não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O id da anotação não pode ser vazio.")

                .Must((dto, cancelar) =>
                {
                    return ValidateIdAnotacaoPut(dto.Id);
                }).WithMessage("Nenhuma anotação foi encontrada com o id informado.");

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
                    }).WithMessage("Já existe uma anotação cadastrada com o nome informado.");
            });

            RuleFor(x => x.Status)
                .NotNull()
                .WithMessage("O status do projeto não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O status do projeto não pode ser vazio.");

            RuleFor(x => x.ImagemUpload)
                .NotEmpty()
                .WithMessage("Insira uma imagem!");

            When(x => x.ImagemUpload != null, () =>
            {
                RuleFor(m => m.ImagemUpload.Length)
                    .GreaterThan(0)
                    .WithMessage("O tamanho da imagem é muito pequeno");

                RuleFor(x => x.ImagemUpload.Length)
                    .NotNull()
                    .NotEmpty()
                    .LessThanOrEqualTo(10996999)
                    .WithMessage("O tamanho da imagem é maior que o permitido (10 Mb)");

                RuleFor(x => x.ImagemUpload.ContentType)
                    .NotNull()
                    .NotEmpty()
                    .Must(x => x.Equals("image/jpeg") || x.Equals("image/jpg") || x.Equals("image/png"))
                    .WithMessage("Extensões permitidas jpg, jpeg e png.");
            });
        }

        private bool ValidateIdAnotacaoPut(Guid id)
        {
            return applicationAnotacao.ValidateIdAnotacaoPut(id);
        }

        private bool ValidateNamePut(PutAnotacaoDTO dto)
        {
            return applicationAnotacao.ValidateNamePut(dto);
        }
    }
}