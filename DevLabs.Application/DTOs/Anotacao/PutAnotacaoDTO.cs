using System;

namespace DevLabs.Application.DTOs.Anotacao
{
    public class PutAnotacaoDto : PostAnotacaoDto
    {
        public Guid Id { get; set; }
    }
}