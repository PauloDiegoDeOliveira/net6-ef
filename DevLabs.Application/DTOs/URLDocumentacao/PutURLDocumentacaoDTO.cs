using System;

namespace DevLabs.Application.DTOs.URLDocumentacao
{
    public class PutUrlDocumentacaoDto : PostUrlDocumentacaoDto
    {
        public Guid Id { get; set; }
    }
}