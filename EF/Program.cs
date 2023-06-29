namespace EF
{
    using BazaDanych;

    internal class Program
    {
        static void podglądBazyDanych(BazaDanychOsób db)
        {
            try
            {
                Console.WriteLine("\nPodgląd danych:");
                Console.WriteLine("Osoby");
                foreach (Osoba osoba in db.Osoby)
                {
                    Console.WriteLine(osoba);
                }
                Console.WriteLine("Adresy:");
                foreach (Adres adres in db.Adresy)
                {
                    Console.WriteLine(adres);
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine($"Błąd podglądu bazy danych: {exc.Message}");
            }
        }

        static void dodajPrzykładoweOsoby(BazaDanychOsób db)
        {
            Adres adres1 = new Adres()
            {
                Miasto = "Toruń",
                Ulica = "Pod Mostem",
                NumerDomu = 1
            };
            Adres adres2 = new Adres()
            {
                Miasto = "Toruń",
                Ulica = "Gałczyńskiego",
                NumerDomu = 5,
                NumerMieszkania = 34
            };
            Osoba osoba1 = new Osoba()
            {
                Imię = "Antoni",
                Nazwisko = "Gburek",
                NumerTelefonu = 123456789,
                Adres = adres1,
            };
            Osoba osoba2 = new Osoba()
            {
                Imię = "Karol",
                Nazwisko = "Gacek",
                NumerTelefonu = 9876543,
                Adres = adres2
            };
            Osoba osoba3 = new Osoba()
            {
                Imię = "Wincenty",
                Nazwisko = "Patyk",
                NumerTelefonu = 34658307,
                Adres = adres1
            };

            db.DodajOsobę(osoba1);
            db.DodajOsobę(osoba2);
            db.DodajOsobę(osoba3);
        }

        static void pokażIdentyfikatoryOsób(BazaDanychOsób db)
        {
            string s = "Identyfikatory osób: ";
            foreach (int idOsoby in db.IdentyfikatoryOsób)
                s += idOsoby.ToString() + "; ";
            Console.WriteLine(s.Trim(' ', ';'));
        }

        static void pokażOsoby(BazaDanychOsób db)
        {
            foreach (int idOsoby in db.IdentyfikatoryOsób)
                Console.WriteLine(db[idOsoby].ToString());
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Usuwam plik bazy danych...");
            string dbName = "osoby.db";
            if (File.Exists(dbName))
            {
                File.Delete(dbName); //zaczynamy na czysto
            }

            BazaDanychOsób db = new BazaDanychOsób();
            dodajPrzykładoweOsoby(db);
            pokażIdentyfikatoryOsób(db);
            podglądBazyDanych(db);

            Console.WriteLine("\nOsoby:");
            pokażOsoby(db);
        }
    }
}

