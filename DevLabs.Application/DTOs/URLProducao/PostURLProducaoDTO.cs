using DevLabs.Domain.Enums;

namespace DevLabs.Application.DTOs.URLProducao
{
    public class PostUrlProducaoDto
    {
        public string URL { get; set; }

        public Tipo Tipo { get; set; }

        public Status Status { get; set; }
    }
}