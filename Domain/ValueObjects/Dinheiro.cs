using System.Globalization;

namespace BankBlock.Domain.ValueObjects
{
    public readonly struct Dinheiro : IEquatable<Dinheiro>, IComparable<Dinheiro>
    {
        public decimal Montante { get; }
        public string CodigoMoeda { get; } = "BRL";

        private const int CasasDecimais = 2;

        public Dinheiro(decimal montante)
        {
            Montante = Math.Round(montante, CasasDecimais, MidpointRounding.ToEven);
        }

        public static Dinheiro operator +(Dinheiro a, Dinheiro b)
        {
            return new Dinheiro(a.Montante + b.Montante);
        }

        public static Dinheiro operator -(Dinheiro a, Dinheiro b)
        {
            return new Dinheiro(a.Montante - b.Montante);
        }

        public static bool operator ==(Dinheiro a, Dinheiro b)
        {
            return a.Montante == b.Montante;
        }

        public static bool operator !=(Dinheiro a, Dinheiro b)
        {
            return !(a == b);
        }

        public static bool operator <(Dinheiro a, Dinheiro b)
        {
            return a.Montante < b.Montante;
        }

        public static bool operator >(Dinheiro a, Dinheiro b)
        {
            return a.Montante > b.Montante;
        }

        public static bool operator <=(Dinheiro a, Dinheiro b)
        {
            return a.Montante <= b.Montante;
        }

        public static bool operator >=(Dinheiro a, Dinheiro b)
        {
            return a.Montante >= b.Montante;
        }

        public bool Equals(Dinheiro outra)
        {
            return Montante == outra.Montante && CodigoMoeda == outra.CodigoMoeda;
        }

        public override bool Equals(object? obj)
        {
            return obj is Dinheiro outra && Equals(outra);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Montante, CodigoMoeda);
        }

        public int CompareTo(Dinheiro outra)
        {
            return Montante.CompareTo(outra.Montante);
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", Montante) + " " + CodigoMoeda;
        }
    }
} 