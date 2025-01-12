using DevIO.Business.Notificacoes;

namespace DevIO.Business.Interfaces.Services;

public interface INotificador
{
    bool TemNotificacao();
    List<Notificacao> ObterNotificacaoes();
    void Handle(Notificacao notificacao);
}
