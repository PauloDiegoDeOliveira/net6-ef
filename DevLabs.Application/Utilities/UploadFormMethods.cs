﻿using DevLabs.Domain.Entitys.Base;
using System.IO;
using System.Threading.Tasks;

namespace DevLabs.Application.Utilities
{
    public class UploadFormMethods<TEntity> where TEntity : UploadFormBase
    {
        public async Task UploadImage(TEntity uploadForm)
        {
            string root = Path.Combine(Directory.GetCurrentDirectory(), uploadForm.CaminhoFisico);
            using (var stream = new FileStream(root, FileMode.Create))
            {
                await uploadForm.ImagemUpload.CopyToAsync(stream);
            }
        }

        public async Task DeleteImage(TEntity uploadForm)
        {
            if (File.Exists(uploadForm.CaminhoFisico))
            {
                File.Delete(uploadForm.CaminhoFisico);
            }
            await Task.CompletedTask;
        }
    }
}