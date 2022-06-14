using System;

namespace DevLabs.Application.DTOs.URLProducao
{
    public class PutUrlProducaoDto : PostUrlProducaoDto
    {
        public Guid Id { get; set; }
    }
}