using System.Text.RegularExpressions;
using BankBlock.Domain.Notifications;

namespace BankBlock.Domain.ValueObjects
{
    public class Email : Notificavel
    {
        private static readonly Regex _regexEmail = 
            new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

        public string Endereco { get; }

        public Email(string endereco)
        {
            endereco = endereco?.Trim() ?? "";
            if (string.IsNullOrEmpty(endereco) || !_regexEmail.IsMatch(endereco))
                AdicionarNotificacao("E-mail inválido.", nameof(Email));
            Endereco = endereco;
        }
    }
}