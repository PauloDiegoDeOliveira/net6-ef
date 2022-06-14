using DevLabs.Domain.Enums;

namespace DevLabs.Application.DTOs.URLHomologacao
{
    public class PostUrlHomologacaoDto
    {
        public string URL { get; set; }

        public Tipo Tipo { get; set; }

        public Status Status { get; set; }
    }
}