using System;

namespace DevLabs.Application.DTOs.URLProducao
{
    public class PutURLProducaoDTO : PostURLProducaoDTO
    {
        public Guid Id { get; set; }
    }
}