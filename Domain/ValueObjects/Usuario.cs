using BankBlock.Domain.Notifications;
using BankBlock.Domain.ValueObjects;

namespace BankBlock.Domain.Entidades
{
    public class Usuario : Notificavel
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Nome { get; }
        public string Cpf { get; }
        public Email Email { get; }
        public Senha Senha { get; }
        public List<Carteira> Carteiras { get; } = new();

        public Usuario(string nome, string cpf, string email, string senha)
        {
            Nome = nome?.Trim() ?? "";
            Cpf = cpf?.Trim() ?? "";

            // Validação de CPF: 11 dígitos numéricos
            if (!System.Text.RegularExpressions.Regex.IsMatch(Cpf, @"^\d{11}$"))
                AdicionarNotificacao("CPF inválido. Deve conter 11 dígitos.", nameof(Cpf));

            Email = new Email(email);
            Senha = new Senha(senha);

            if (!Email.EstaValido)
                AdicionarNotificacoes(Email.Notificacoes);
            if (!Senha.EstaValido)
                AdicionarNotificacoes(Senha.Notificacoes);
        }

        public void AdicionarCarteira(Carteira carteira)
        {
            if (carteira != null) 
                Carteiras.Add(carteira);
        }
    }
}
