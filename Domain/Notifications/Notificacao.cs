namespace BankBlock.Domain.Notifications
{
    public class Notificacao
    {
        public string Mensagem { get; }
        public string Propriedade { get; }

        public Notificacao(string mensagem, string propriedade = "")
        {
            Mensagem = mensagem;
            Propriedade = propriedade;
        }
    }
}