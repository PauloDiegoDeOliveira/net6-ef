using DevLabs.Domain.Entitys.Base;

namespace DevLabs.Domain.Entitys
{
    public class Menu : UploadFormBase
    {
        public string Titulo { get; private set; }

        public string Descricao { get; private set; }

        public string Rota { get; private set; }

        protected Menu()
        { }
    }
}