using DevLabs.Application.DTOs.Projeto;
using DevLabs.Application.Interfaces;
using FluentValidation;

namespace DevLabs.Application.Validations.Projeto
{
    public class PostProjetoValidator : AbstractValidator<PostProjetoDto>
    {
        private readonly IApplicationProjeto applicationProjeto;

        public PostProjetoValidator(IApplicationProjeto applicationProjeto)
        {
            this.applicationProjeto = applicationProjeto;

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
                        return !ValidateNamePost(dto);
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
        }

        private bool ValidateNamePost(PostProjetoDto dto)
        {
            return applicationProjeto.ValidateNamePost(dto);
        }
    }
}