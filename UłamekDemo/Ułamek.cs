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
    }
}
