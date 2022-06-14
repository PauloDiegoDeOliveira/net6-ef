using System;

namespace DevLabs.Application.DTOs.Conta
{
    public class PutContaDto : PostContaDto
    {
        public Guid Id { get; set; }
    }
}