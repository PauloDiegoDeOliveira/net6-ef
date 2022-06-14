using DevLabs.Domain.Enums;
using System;

namespace DevLabs.Application.DTOs.URLDocumentacao
{
    public class ViewUrlDocumentacaoDto
    {
        public Guid Id { get; set; }

        public string URL { get; set; }

        public Tipo Tipo { get; set; }

        public Status Status { get; private set; }
    }
}