using DevLabs.Domain.Enums;

namespace DevLabs.Application.DTOs.Conta
{
    public class PostContaDTO
    {
        public string Usuario { get; set; }

        public string Senha { get; set; }

        public Tipo Tipo { get; set; }

        public Status Status { get; set; }
    }
}