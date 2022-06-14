using System;

namespace DevLabs.Application.DTOs.URLHomologacao
{
    public class PutUrlHomologacaoDto : PostUrlHomologacaoDto
    {
        public Guid Id { get; set; }
    }
}