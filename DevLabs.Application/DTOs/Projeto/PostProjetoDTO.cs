using DevLabs.Application.DTOs.Conta;
using DevLabs.Application.DTOs.URLDocumentacao;
using DevLabs.Application.DTOs.URLHomologacao;
using DevLabs.Application.DTOs.URLProducao;
using DevLabs.Domain.Enums;
using System;
using System.Collections.Generic;

namespace DevLabs.Application.DTOs.Projeto
{
    public class PostProjetoDto
    {
        public string ImagemBase64 { get; set; }

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

        public Status Status { get; set; }

        public List<PostUrlHomologacaoDto> URLSHomologacao { get; set; }

        public List<PostUrlProducaoDto> URLSProducao { get; set; }

        public List<PostUrlDocumentacaoDto> URLSDocumentacao { get; set; }

        public List<PostContaDto> Contas { get; set; }
    }
}