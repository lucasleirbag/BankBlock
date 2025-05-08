using BankBlock.Domain.Notifications;
using BankBlock.Domain.ValueObjects;

namespace BankBlock.Domain.Entidades
{
    public class Carteira : Notificavel
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Nome { get; }
        public Dinheiro Saldo { get; private set; }
        public Guid UsuarioId { get; }
        public Usuario Dono { get; }
        public List<Transacao> Transacoes { get; } = new();

        public Carteira(string nome, Usuario dono, decimal saldoInicialDecimal = 0m)
        {
            Nome = nome?.Trim() ?? "Carteira";
            Dono = dono;
            UsuarioId = dono?.Id ?? Guid.Empty;

            Dinheiro saldoInicial = new Dinheiro(saldoInicialDecimal);
            if (saldoInicial.Montante < 0)
                AdicionarNotificacao("Saldo inicial não pode ser negativo.", nameof(Saldo));
            else
                Saldo = saldoInicial;
        }

        public bool PodeDebitar(Dinheiro valor)
        {
            return (this.Saldo - valor).Montante >= 0;
        }

        public void Creditar(Dinheiro valor)
        {
            this.Saldo += valor;
        }

        public void Debitar(Dinheiro valor)
        {
            if (!PodeDebitar(valor))
                AdicionarNotificacao("Saldo insuficiente.", nameof(Saldo));
            else
                this.Saldo -= valor;
        }
    }
}