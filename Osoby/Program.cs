﻿using System.Reflection.Metadata.Ecma335;

namespace Osoby
{
    class Osoba
    {
        public string Imię;
        public string Nazwisko;
        public int Wiek;

        public override string ToString()
        {
            return $"{Imię} {Nazwisko} ({Wiek})";
        }
    }

    class Adres
    {
        public string Miasto;
        public string Ulica;
        public int NumerDomu;
        public int? NumberMieszkania;

        public override string ToString()
     {
            return $"{Miasto}, ul. {Ulica} {NumerDomu}{(NumberMieszkania.HasValue ? "/" + NumberMieszkania : "")}";
        }
    }

    class OsobaZameldowana : Osoba
    {
        public Adres AdresZameldowania;

        public override string ToString()
        {
            return $"{base.ToString()}; {AdresZameldowania.ToString()}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            OsobaZameldowana jk = new OsobaZameldowana()
            {
                Imię = "Jan",
                Nazwisko = "Kowalski",
                Wiek = 42,
                AdresZameldowania = new Adres
                {
                    Miasto = "Toruń",
                    Ulica = "Grudziadzka",
                    NumerDomu = 5,
                    NumberMieszkania = null
                }
            };

            Console.WriteLine(jk.ToString());
        }
    }
}