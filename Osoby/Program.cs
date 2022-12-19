using System.Reflection.Metadata.Ecma335;

namespace Osoby
{
    class Osoba
    {
        public string Imię;
        public string Nazwisko;
        public int Wiek;

        protected bool czyKobieta()
        {
            if (string.IsNullOrEmpty(Imię))
            {
                throw new Exception("Brak imienia");
            }
            else
            {
                bool niewiasta = Imię.ToLower()[Imię.Length - 1] == 'a';
                if (Imię == "Kuba" || Imię == "Barnaba")
                {
                    niewiasta = false;
                }
                return niewiasta;
            }
        }

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

    interface IPosiadaTelefonStacjonarny
    {
        int? NumerTelefonu { get; set; }
    }

    class OsobaZameldowana : Osoba, IPosiadaTelefonStacjonarny
    {
        public Adres AdresZameldowania;

        public new string ToString()
        {
            return $"{base.ToString()}; {(czyKobieta() ? "zameldowana w" : "zameldowany w")} {AdresZameldowania.ToString()}";
        }

        public int? NumerTelefonu { get; set; }

        public bool CzyPosiadaTelefonStacjonarny
        {
            get
            {
                return NumerTelefonu.HasValue;
            }
        }
    }

    class Instytucja : IPosiadaTelefonStacjonarny
    {
        public int? NumerTelefonu { get; set; }
    }

    internal class Program
    {
        static void WyświetlNumerTelefonu(IPosiadaTelefonStacjonarny telefon)
        {
            Console.WriteLine($"Numer telefonu: {telefon.NumerTelefonu}");
        }
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
            Osoba jkb = jk;
            Console.WriteLine(jkb.ToString());

            List<IPosiadaTelefonStacjonarny> listaTelefonów = new List<IPosiadaTelefonStacjonarny>();
            listaTelefonów.Add(new OsobaZameldowana() { NumerTelefonu = 123456789 });
            listaTelefonów.Add(new OsobaZameldowana() { NumerTelefonu = 987654321 });
            listaTelefonów.Add(new Instytucja() { NumerTelefonu = 111111111 });
            foreach (IPosiadaTelefonStacjonarny telefon in listaTelefonów)
            {
                WyświetlNumerTelefonu(telefon);
            }
        }
    }
}