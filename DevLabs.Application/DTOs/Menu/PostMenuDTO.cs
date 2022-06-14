using DevLabs.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace DevLabs.Application.DTOs.Menu
{
    public class PostMenuDto
    {
        public IFormFile ImagemUpload { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public string Rota { get; set; }

        public Status Status { get; set; }
    }
}