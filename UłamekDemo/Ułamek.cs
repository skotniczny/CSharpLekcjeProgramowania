using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UłamekDemo
{
    public struct Ułamek
    {
        private int licznik, mianownik;

        public Ułamek(int licznik, int mianiownik = 1)
        {
            if (mianiownik == 0)
            {
                throw new ArgumentException("Mianiwnik musi być różny od zera");
            }
            this.licznik = licznik;
            this.mianownik = mianiownik;
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
            return licznik.ToString() + "/" + mianownik.ToString();
        }

        public readonly double ToDouble()
        {
            return licznik / (double)mianownik;
        }

        public void Uprość()
        {
            int a = licznik;
            int b = mianownik;

            //NWD
            int c;
            while (b != 0)
            {
                c = a % b;
                a = b;
                b = c;
            }

            licznik /= a;
            mianownik /= a;

            //znaki
            if (licznik * mianownik < 0)
            {
                licznik = -Math.Abs(licznik);
                mianownik = Math.Abs(mianownik);
            }
            else
            {
                licznik = Math.Abs(licznik);
                mianownik = Math.Abs(mianownik);
            }
        }
    }
}
