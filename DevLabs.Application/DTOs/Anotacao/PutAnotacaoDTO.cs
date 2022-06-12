using System;

namespace DevLabs.Application.DTOs.Anotacao
{
    public class PutAnotacaoDTO : PostAnotacaoDTO
    {
        public Guid Id { get; set; }
    }
}