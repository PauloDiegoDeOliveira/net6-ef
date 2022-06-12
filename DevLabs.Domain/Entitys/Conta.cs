using DevLabs.Domain.Entitys.Base;
using System;

namespace DevLabs.Domain.Entitys
{
    public class Conta : EntityBase
    {
        public Guid ProjetoId { get; private set; }

        public string Usuario { get; private set; }

        public string Senha { get; private set; }

        public int Tipo { get; private set; }

        public Projeto Projeto { get; private set; }

        protected Conta()
        { }
    }
}