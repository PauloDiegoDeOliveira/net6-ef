using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace DevLabs.Domain.Entitys.Base
{
    public class UploadFormBase : EntityBase
    {
        [NotMapped]
        public IFormFile ImagemUpload { get; private set; }

        public Guid NomeArquivoBanco { get; private set; }
        public long TamanhoEmBytes { get; private set; }
        public string ContentType { get; private set; }
        public string ExtensaoArquivo { get; private set; }
        public string NomeArquivoOriginal { get; private set; }
        public string CaminhoRelativo { get; private set; }
        public string CaminhoAbsoluto { get; private set; }
        public string CaminhoFisico { get; private set; }
        public DateTime HoraEnvio { get; private set; }

        protected UploadFormBase()
        { }

        public void PolulateInformations(UploadFormBase uploadForm, string caminhoFisico, string caminhoAbsoluto, string caminhoRelativo)
        {
            NomeArquivoBanco = Guid.NewGuid();
            ImagemUpload = uploadForm.ImagemUpload;
            TamanhoEmBytes = uploadForm.ImagemUpload.Length;
            ContentType = uploadForm.ImagemUpload.ContentType;
            ExtensaoArquivo = Path.GetExtension(uploadForm.ImagemUpload.FileName);
            NomeArquivoOriginal = Path.GetFileNameWithoutExtension(uploadForm.ImagemUpload.FileName);
            CaminhoRelativo = caminhoRelativo + NomeArquivoBanco + ExtensaoArquivo;
            CaminhoAbsoluto = caminhoAbsoluto + NomeArquivoBanco + ExtensaoArquivo;
            CaminhoFisico = caminhoFisico + NomeArquivoBanco + ExtensaoArquivo;
            HoraEnvio = DateTime.Now;
        }

        public void PutInformations(UploadFormBase uploadForm)
        {
            NomeArquivoBanco = uploadForm.NomeArquivoBanco;
            ImagemUpload = uploadForm.ImagemUpload;
            TamanhoEmBytes = uploadForm.TamanhoEmBytes;
            ContentType = uploadForm.ContentType;
            ExtensaoArquivo = uploadForm.ExtensaoArquivo;
            NomeArquivoOriginal = uploadForm.NomeArquivoOriginal;
            CaminhoRelativo = uploadForm.CaminhoRelativo;
            CaminhoAbsoluto = uploadForm.CaminhoAbsoluto;
            CaminhoFisico = uploadForm.CaminhoFisico;
            HoraEnvio = uploadForm.HoraEnvio;
        }
    }
}