using DevLabs.Domain.Enums;
using System;

namespace DevLabs.Application.DTOs.Projeto
{
    public class ViewProjetoPadraoDTO
    {
        public Guid Id { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public string Observacao { get; set; }

        public Situacao Situacao { get; set; }

        public int Ordem { get; set; }

        public DateTime DataLancamento { get; set; }

        public int Progresso { get; set; }

        public string SubTitulo { get; set; }

        public Prioridade Prioridade { get; set; }

        public EstadoProjeto EstadoProjeto { get; set; }

        public Instituto Instituto { get; set; }

        public string CaminhoAbsoluto { get; set; }

        public string CaminhoRelativo { get; set; }

        public Status Status { get; set; }
    }
}