using BankBlock.Domain.Notifications;
using BankBlock.Domain.ValueObjects;

namespace BankBlock.Domain.Entidades
{
    public enum TipoTransacao
    {
        Deposito,
        Transferencia,
        Saque
    }

    public class Transacao : Notificavel
    {
        public Guid Id { get; } = Guid.NewGuid();
        public TipoTransacao Tipo { get; }
        public Dinheiro Valor { get; }
        public DateTime DataHora { get; } = DateTime.UtcNow;

        public Guid? CarteiraOrigemId { get; }
        public Guid? CarteiraDestinoId { get; }
        public Carteira? CarteiraOrigem { get; }
        public Carteira? CarteiraDestino { get; }

        public Transacao(
            TipoTransacao tipo,
            decimal valorDecimal,
            Carteira? origem,
            Carteira? destino)
        {
            this.Tipo = tipo;
            this.Valor = new Dinheiro(valorDecimal);
            this.CarteiraOrigem = origem;
            this.CarteiraDestino = destino;
            this.CarteiraOrigemId = origem?.Id;
            this.CarteiraDestinoId = destino?.Id;

            // Validações gerais
            if (this.Valor.Montante <= 0)
                AdicionarNotificacao("Valor da transação deve ser positivo.", nameof(this.Valor));

            // Regras por tipo
            if (this.Tipo == TipoTransacao.Deposito)
            {
                if (this.CarteiraOrigem != null)
                    AdicionarNotificacao("Depósito não deve ter carteira de origem.", nameof(this.CarteiraOrigem));
                if (this.CarteiraDestino == null)
                    AdicionarNotificacao("Depósito requer carteira de destino.", nameof(this.CarteiraDestino));
            }
            else if (this.Tipo == TipoTransacao.Saque)
            {
                if (this.CarteiraDestino != null)
                    AdicionarNotificacao("Saque não deve ter carteira de destino.", nameof(this.CarteiraDestino));
                if (this.CarteiraOrigem == null)
                    AdicionarNotificacao("Saque requer carteira de origem.", nameof(this.CarteiraOrigem));
                else if (origem != null && !origem.PodeDebitar(this.Valor))
                    AdicionarNotificacao("Saldo insuficiente para saque.", nameof(this.CarteiraOrigem));
            }
            else if (this.Tipo == TipoTransacao.Transferencia)
            {
                if (this.CarteiraOrigem == null || this.CarteiraDestino == null)
                    AdicionarNotificacao("Transferência requer origens e destino.", nameof(Transacao));
                else if (this.CarteiraOrigemId == this.CarteiraDestinoId)
                    AdicionarNotificacao("Origem e destino não podem ser a mesma carteira.", nameof(Transacao));
                else if (origem != null && !origem.PodeDebitar(this.Valor))
                    AdicionarNotificacao("Saldo insuficiente para transferência.", nameof(this.CarteiraOrigem));
            }
        }
    }
}