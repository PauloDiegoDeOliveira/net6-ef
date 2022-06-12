using DevLabs.Domain.Core.Notificacoes;
using System.Collections.Generic;

namespace DevLabs.Domain.Core.Interfaces.Service
{
    public interface INotificador
    {
        bool TemNotificacao();

        List<Notificacao> ObterNotificacoes();

        void Handle(Notificacao notificacao);
    }
}