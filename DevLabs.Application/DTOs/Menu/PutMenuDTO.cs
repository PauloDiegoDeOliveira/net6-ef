using System;

namespace DevLabs.Application.DTOs.Menu
{
    public class PutMenuDTO : PostMenuDTO
    {
        public Guid Id { get; set; }
    }
}