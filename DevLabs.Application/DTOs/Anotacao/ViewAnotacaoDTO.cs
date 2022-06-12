using DevLabs.Domain.Enums;
using System;

namespace DevLabs.Application.DTOs.Anotacao
{
    public class ViewAnotacaoDTO
    {
        public Guid Id { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public string Rota { get; set; }

        public string CaminhoAbsoluto { get; set; }

        public string CaminhoRelativo { get; set; }

        public Status Status { get; set; }
    }
}