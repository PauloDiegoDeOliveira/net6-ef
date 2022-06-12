using DevLabs.Domain.Entitys.Base;
using System;
using System.Collections.Generic;

namespace DevLabs.Domain.Entitys
{
    public class Projeto : UploadB64Base
    {
        public string Titulo { get; private set; }

        public string Descricao { get; private set; }

        public string Observacao { get; private set; }

        public int Situacao { get; private set; }

        public int Ordem { get; private set; }

        public DateTime DataLancamento { get; private set; }

        public int Progresso { get; private set; }

        public string SubTitulo { get; private set; }

        public int Prioridade { get; private set; }

        public int EstadoProjeto { get; set; }

        public int Instituto { get; set; }

        public List<URLHomologacao> URLSHomologacao { get; private set; }

        public List<URLProducao> URLSProducao { get; private set; }

        public List<URLDocumentacao> URLSDocumentacao { get; private set; }

        public List<Conta> Contas { get; private set; }

        protected Projeto()
        { }
    }
}