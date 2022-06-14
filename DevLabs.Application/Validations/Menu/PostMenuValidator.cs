using DevLabs.Application.DTOs.Menu;
using DevLabs.Application.Interfaces;
using FluentValidation;

namespace DevLabs.Application.Validations.Menu
{
    public class PostMenuValidator : AbstractValidator<PostMenuDto>
    {
        private readonly IApplicationMenu applicationMenu;

        public PostMenuValidator(IApplicationMenu applicationMenu)
        {
            this.applicationMenu = applicationMenu;

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
                    }).WithMessage("Já existe um menu cadastrado com o nome informado.");
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

        private bool ValidateNamePost(PostMenuDto dto)
        {
            return applicationMenu.ValidateNamePost(dto);
        }
    }
}