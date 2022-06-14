using System;

namespace DevLabs.Application.DTOs.Menu
{
    public class PutMenuDto : PostMenuDto
    {
        public Guid Id { get; set; }
    }
}