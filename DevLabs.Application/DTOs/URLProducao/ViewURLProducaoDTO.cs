using DevLabs.Domain.Enums;
using System;

namespace DevLabs.Application.DTOs.URLProducao
{
    public class ViewURLProducaoDTO
    {
        public Guid Id { get; set; }

        public string URL { get; set; }

        public Tipo Tipo { get; set; }

        public Status Status { get; set; }
    }
}