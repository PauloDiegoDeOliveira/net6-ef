using DevLabs.Domain.Entitys.Base;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DevLabs.Application.Utilities
{
    public class UploadB64Methods<TEntity> where TEntity : UploadB64Base
    {
        public async Task UploadImagem(string caminho, string base64string)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), caminho);
            await File.WriteAllBytesAsync(filePath, Convert.FromBase64String(base64string));
        }

        public async Task DeleteImage(TEntity uploadB64)
        {
            if (File.Exists(uploadB64.CaminhoFisico))
                File.Delete(uploadB64.CaminhoFisico);

            await Task.CompletedTask;
        }
    }
}