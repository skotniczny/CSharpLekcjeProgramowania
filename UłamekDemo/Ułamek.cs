using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UłamekDemo
{
    public struct Ułamek
    {
        private int mianownik;
        #region Własności
        public int Licznik { get; set; }

        public int Mianownik
        {
            get => mianownik;
            set //zmiana
            {
                if (value == 0)
                {
                    throw new ArgumentException("Mianownik musi być różny od zera");
                }
                mianownik = value;
            }
        }
        #endregion

        public Ułamek(int licznik, int mianiownik = 1) : this()
        {
            Licznik = licznik;
            Mianownik = mianiownik;
        }

        public static readonly Ułamek Zero = new Ułamek(0);
        public static readonly Ułamek Jeden = new Ułamek(1);
        public static readonly Ułamek Połowa = new Ułamek(1, 2);
        public static readonly Ułamek Ćwierć = new Ułamek(1, 4);

        public static string Info()
        {
            return "Struktura Ułamek, (c) Jacek Matulewki 2020";
        }
        public override readonly string ToString()
        {
            return Licznik.ToString() + "/" + mianownik.ToString();
        }

        public readonly double ToDouble()
        {
            return Licznik / (double)mianownik;
        }

        public void Uprość()
        {
            int a = Licznik;
            int b = mianownik;

            //NWD
            int c;
            while (b != 0)
            {
                c = a % b;
                a = b;
                b = c;
            }

            Licznik /= a;
            mianownik /= a;

            //znaki
            if (Licznik * mianownik < 0)
            {
                Licznik = -Math.Abs(Licznik);
                mianownik = Math.Abs(Mianownik);
            }
            else
            {
                Licznik = Math.Abs(Licznik);
                mianownik = Math.Abs(mianownik);
            }
        }

        #region Operatory arytmetyczne
        public static Ułamek operator -(Ułamek u)
        {
            return new Ułamek(-u.Licznik, u.Mianownik);
        }

        public static Ułamek operator +(Ułamek u)
        {
            return u;
        }

        public static Ułamek operator +(Ułamek u1, Ułamek u2)
        {
            Ułamek wynik = new Ułamek(u1.Licznik * u2.Mianownik + u2.Licznik * u1.Mianownik,
            u1.Mianownik * u2.Mianownik);
            wynik.Uprość();
            return wynik;
        }

        public static Ułamek operator -(Ułamek u1, Ułamek u2)
        {
            Ułamek wynik = new Ułamek(
                u1.Licznik * u2.Mianownik - u2.Licznik * u1.Mianownik,
                u1.Mianownik * u2.Mianownik);
            wynik.Uprość();
            return wynik;
        }

        public static Ułamek operator *(Ułamek u1, Ułamek u2)
        {
            Ułamek wynik = new Ułamek(u1.Licznik * u2.Licznik, u1.Mianownik * u2.Mianownik);
            wynik.Uprość();
            return wynik;
        }

        public static Ułamek operator /(Ułamek u1, Ułamek u2)
        {
            Ułamek wynik = new Ułamek(u1.Licznik * u2.Mianownik, u1.Mianownik * u2.Licznik);
            wynik.Uprość();
            return wynik;
        }
        #endregion

        #region Operatory porównania
        public static bool operator ==(Ułamek u1, Ułamek u2)
        {
            return (u1.ToDouble() == u2.ToDouble());
        }

        public static bool operator !=(Ułamek u1, Ułamek u2)
        {
            return !(u1 == u2);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Ułamek)) return false;
            Ułamek u = (Ułamek)obj;
            return (this == u);
        }

        public override int GetHashCode()
        {
            return Licznik ^ Mianownik;
        }

        public static bool operator >(Ułamek u1, Ułamek u2)
        {
            return (u1.ToDouble() > u2.ToDouble());
        }

        public static bool operator >=(Ułamek u1, Ułamek u2)
        {
            return (u1.ToDouble() >= u2.ToDouble());
        }

        public static bool operator <(Ułamek u1, Ułamek u2)
        {
            return (u1.ToDouble() < u2.ToDouble());
        }

        public static bool operator <=(Ułamek u1, Ułamek u2)
        {
            return (u1.ToDouble() <= u2.ToDouble());
        }
        #endregion

        #region Operatory konwersji
        public static explicit operator double(Ułamek u)
        {
            return u.ToDouble();
        }

        public static implicit operator Ułamek(int n)
        {
            return new Ułamek(n);
        }
        #endregion

        public static Ułamek Odwróć(Ułamek u)
        {
            return new Ułamek(u.Mianownik, u.Licznik);
        }

        public void Odwróć()
        {
            int tmp = Licznik;
            Licznik = Mianownik;
            Mianownik = tmp;
        }

        public readonly Ułamek Odwrócony()
        {
            return Ułamek.Odwróć(this);
        }

        public Ułamek Odwrotność
        {
            get
            {
                return Odwrócony();
            }
        }

        public static Ułamek operator ^(Ułamek u, int n)
        {
            if (n == 0) return Ułamek.Jeden;
            if (u.Licznik == 0 && n < 0)
            {
                throw new ArgumentException("Nie można podnosić zere do ujemnej potęgi");
            }
            int _n = Math.Abs(n);
            Ułamek wartość = u;
            for (int i = 1; i < _n; ++i) wartość *= u;
            if (n < 0) wartość = Odwróć(wartość);
            wartość.Uprość();
            return wartość;
        }
    }
}
