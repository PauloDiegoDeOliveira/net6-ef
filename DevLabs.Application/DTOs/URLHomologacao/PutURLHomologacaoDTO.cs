using System;

namespace DevLabs.Application.DTOs.URLHomologacao
{
    public class PutURLHomologacaoDTO : PostURLHomologacaoDTO
    {
        public Guid Id { get; set; }
    }
}