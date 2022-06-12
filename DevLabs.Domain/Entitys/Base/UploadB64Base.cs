using System;

namespace DevLabs.Domain.Entitys.Base
{
    public class UploadB64Base : EntityBase
    {
        public Guid NomeArquivo { get; private set; }
        public string CaminhoRelativo { get; private set; }
        public string CaminhoAbsoluto { get; private set; }
        public string CaminhoFisico { get; private set; }
        public DateTime HoraEnvio { get; private set; }

        protected UploadB64Base()
        {
            NomeArquivo = Guid.NewGuid();
        }

        public void PolulateInformations(string caminhoFisico, string caminhoAbsoluto, string caminhoRelativo, string extensao)
        {
            CaminhoRelativo = caminhoRelativo + NomeArquivo.ToString() + "." + extensao;
            CaminhoAbsoluto = caminhoAbsoluto + NomeArquivo.ToString() + "." + extensao;
            CaminhoFisico = caminhoFisico + NomeArquivo.ToString() + "." + extensao;
            HoraEnvio = DateTime.Now;
        }

        public void PutInformations(Projeto putProjeto)
        {
            CaminhoRelativo = putProjeto.CaminhoRelativo;
            CaminhoAbsoluto = putProjeto.CaminhoAbsoluto;
            CaminhoFisico = putProjeto.CaminhoFisico;
            HoraEnvio = putProjeto.HoraEnvio;
        }
    }
}