using System;

namespace DevLabs.Application.DTOs.URLDocumentacao
{
    public class PutURLDocumentacaoDTO : PostURLDocumentacaoDTO
    {
        public Guid Id { get; set; }
    }
}