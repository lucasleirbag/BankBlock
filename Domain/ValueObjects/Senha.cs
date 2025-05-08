using System.Security.Cryptography;
using System.Text;
using BankBlock.Domain.Notifications;

namespace BankBlock.Domain.ValueObjects
{
    public class Senha : Notificavel
    {
        private const int _tamanhoMinimo = 6;
        public string Hash { get; }

        public Senha(string textoPuro)
        {
            if (string.IsNullOrWhiteSpace(textoPuro) || textoPuro.Length < _tamanhoMinimo)
            {
                AdicionarNotificacao($"Senha deve ter ao menos {_tamanhoMinimo} caracteres.", nameof(Senha));
                Hash = "";
                return;
            }

            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(textoPuro));
            Hash = Convert.ToBase64String(bytes);
        }

        public bool Verificar(string textoPuro)
        {
            var comparacao = new Senha(textoPuro);
            return comparacao.EstaValido && comparacao.Hash == Hash;
        }
    }
}