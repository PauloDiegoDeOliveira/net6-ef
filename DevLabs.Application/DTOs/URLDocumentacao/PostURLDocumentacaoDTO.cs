using DevLabs.Domain.Enums;

namespace DevLabs.Application.DTOs.URLDocumentacao
{
    public class PostURLDocumentacaoDTO
    {
        public string URL { get; set; }

        public Tipo Tipo { get; set; }

        public Status Status { get; set; }
    }
}