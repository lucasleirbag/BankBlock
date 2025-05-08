using System.Collections.ObjectModel;

namespace BankBlock.Domain.Notifications
{
    public abstract class Notificavel
    {
        private readonly List<Notificacao> _notificacoes = new();
        public IReadOnlyCollection<Notificacao> Notificacoes 
            => new ReadOnlyCollection<Notificacao>(_notificacoes);

        public bool EstaValido => !_notificacoes.Any();

        protected void AdicionarNotificacao(string mensagem, string propriedade = "")
            => _notificacoes.Add(new Notificacao(mensagem, propriedade));

        protected void AdicionarNotificacoes(IEnumerable<Notificacao> notificacoes)
            => _notificacoes.AddRange(notificacoes);

        public void LimparNotificacoes() => _notificacoes.Clear();
    }
}