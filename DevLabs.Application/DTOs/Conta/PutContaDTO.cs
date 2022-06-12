using System;

namespace DevLabs.Application.DTOs.Conta
{
    public class PutContaDTO : PostContaDTO
    {
        public Guid Id { get; set; }
    }
}