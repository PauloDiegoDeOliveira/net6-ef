using DevLabs.Domain.Entitys.Base;
using System;

namespace DevLabs.Domain.Entitys
{
    public class UrlProducao : EntityBase
    {
        public Guid ProjetoId { get; private set; }

        public string URL { get; private set; }

        public int Tipo { get; private set; }

        public Projeto Projeto { get; private set; }

        protected UrlProducao()
        { }
    }
}