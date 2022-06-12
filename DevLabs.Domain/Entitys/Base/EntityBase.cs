using System;

namespace DevLabs.Domain.Entitys.Base
{
    public abstract class EntityBase
    {
        public Guid Id { get; private set; }

        public int Status { get; private set; }

        public DateTime? CriadoEm { get; private set; } = DateTime.Now;

        public DateTime? AlteradoEm { get; private set; }

        protected EntityBase()
        { }

        public void ChangeStatusValue(int status)
        {
            Status = status;
        }
    }
}