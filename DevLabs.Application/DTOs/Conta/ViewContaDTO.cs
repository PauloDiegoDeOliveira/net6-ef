using DevLabs.Domain.Enums;
using System;

namespace DevLabs.Application.DTOs.Conta
{
    public class ViewContaDto
    {
        public Guid Id { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }

        public Tipo Tipo { get; set; }

        public Status Status { get; set; }
    }
}