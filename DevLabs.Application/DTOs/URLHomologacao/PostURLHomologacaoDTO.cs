using DevLabs.Domain.Enums;

namespace DevLabs.Application.DTOs.URLHomologacao
{
    public class PostURLHomologacaoDTO
    {
        public string URL { get; set; }

        public Tipo Tipo { get; set; }

        public Status Status { get; set; }
    }
}