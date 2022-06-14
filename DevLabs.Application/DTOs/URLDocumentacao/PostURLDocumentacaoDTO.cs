using DevLabs.Domain.Enums;

namespace DevLabs.Application.DTOs.URLDocumentacao
{
    public class PostUrlDocumentacaoDto
    {
        public string URL { get; set; }

        public Tipo Tipo { get; set; }

        public Status Status { get; set; }
    }
}