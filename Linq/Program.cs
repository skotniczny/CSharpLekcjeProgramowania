class Osoba
{
    public int Id;
    public string Imię;
    public string Nazwisko;
    public int NumerTelefonu;
    public int Wiek;

    public override string ToString()
    {
        return $"{Id.ToString()}. {Imię} {Nazwisko} ({Wiek}), tel. {NumerTelefonu}";
    }
}

class Program
{
    static List<Osoba> listaOsób = new List<Osoba>()
    {
        new Osoba { Id = 1, Imię = "Jan", Nazwisko = "Kowalski", NumerTelefonu = 7272024, Wiek = 39 },
        new Osoba { Id = 2, Imię = "Andrzej", Nazwisko = "Kowalski", NumerTelefonu = 7272020, Wiek = 29 },
        new Osoba { Id = 3, Imię = "Maciej", Nazwisko = "Bartnicki", NumerTelefonu = 7272021, Wiek = 42 },
        new Osoba { Id = 4, Imię = "Witold", Nazwisko = "Mocarz", NumerTelefonu = 7272022, Wiek = 26 },
        new Osoba { Id = 5, Imię = "Adam", Nazwisko = "Kowalski", NumerTelefonu = 7272023, Wiek = 6 },
        new Osoba { Id = 6, Imię = "Ewa", Nazwisko = "Mocarz", NumerTelefonu = 7272025, Wiek = 11 },
    };

    static void Main(string[] args)
    {
        // Pobieranie danych (filtrowanie i sortowanie)
        var listaOsóbPełnoletnich = from osoba in listaOsób
                                    where osoba.Wiek >= 18
                                    orderby osoba.Wiek
                                    select osoba;

        List<Osoba> podlista = listaOsóbPełnoletnich.ToList<Osoba>();

        Console.WriteLine("Lista osób pełnoletnich:");
        foreach (var osoba in listaOsóbPełnoletnich)
            Console.WriteLine(osoba.ToString());

        // Analiza pobranych danych
        Console.WriteLine();
        Console.WriteLine($"Wiek najstarszej osoby: {listaOsóbPełnoletnich.Max(osoba => osoba.Wiek)}");
        Console.WriteLine($"Średni wiek osób pełnoletnich {listaOsóbPełnoletnich.Average(osoba => osoba.Wiek)}");
        Console.WriteLine($"Suma last osób pełnoletnich {listaOsóbPełnoletnich.Sum(osoba => osoba.Wiek)}");

        // Wybór elementu
        Console.WriteLine();
        var najstarszaOsoba = listaOsóbPełnoletnich.Single(osoba1 => (osoba1.Wiek == listaOsóbPełnoletnich.Max(osoba => osoba.Wiek)));
        Console.WriteLine($"Najstarsza osoba: {najstarszaOsoba.ToString()}");

        // Weryfikowanie danych
        Console.WriteLine();
        bool czyWszystkiePełnoletnie = listaOsóbPełnoletnich.All(osoba => (osoba.Wiek > 18));
        bool czyZawieraPelnoletnią = listaOsób.Any(osoba => osoba.Wiek > 18);
        Console.WriteLine($"Czy wszystkie pełnoletnie: `listaOsóbPełnoletnich` {czyWszystkiePełnoletnie}");
        Console.WriteLine($"Czy zawiera pełnoletnią: `listaOsób` {czyZawieraPelnoletnią}");

        // Prezentacja w grupach
        Console.WriteLine();
        var grupyOsóbOTymSamymNazwisku = from osoba in listaOsób
                                         group osoba by osoba.Nazwisko into grupa
                                         select grupa;
        Console.WriteLine("Lista osób pogrupowanych według nazwisk:");
        foreach (var grupa in grupyOsóbOTymSamymNazwisku)
        {
            Console.WriteLine($"Grupa osób o nazwisku {grupa.Key}");
            foreach (Osoba osoba in grupa) Console.WriteLine($"{osoba.Imię} {osoba.Nazwisko}");
            Console.WriteLine();
        }

        // Łączenie zbiorów danych
        var listaOsóbPełnoletnich1 = from osoba in listaOsób
                                     where osoba.Wiek >= 18
                                     orderby osoba.Wiek
                                     select new { osoba.Imię, osoba.Nazwisko, osoba.Wiek };
        var listaKobiet = from osoba in listaOsób
                          where osoba.Imię.EndsWith("a")
                          select new { osoba.Imię, osoba.Nazwisko, osoba.Wiek };
        //var listaPełnoletnich_I_Kobiet = listaOsóbPełnoletnich1.Concat(listaKobiet).Distinct();
        var listaPełnoletnich_I_Kobiet = listaOsóbPełnoletnich1.Union(listaKobiet);
        var listaPełnoletnichNieKobiet = listaOsóbPełnoletnich1.Except(listaKobiet);

        // Łączenie danych z różnych źródeł (operator join)
        var listaTelefonów = from osoba in listaOsób
                             select new { osoba.Id, osoba.NumerTelefonu };
        var listaPersonaliów = from osoba in listaOsób
                               select new { osoba.Id, osoba.Imię, osoba.Nazwisko };

        var listaPersonaliówZTelefonami = from telefon in listaTelefonów
                                          join personalia in listaPersonaliów
                                          on telefon.Id equals personalia.Id
                                          select new
                                          {
                                              telefon.Id,
                                              personalia.Imię,
                                              personalia.Nazwisko,
                                              telefon.NumerTelefonu
                                          };

        foreach (var telefon in listaTelefonów) Console.WriteLine(telefon.ToString());
        foreach (var osoba in listaPersonaliów) Console.WriteLine(osoba.ToString());
        foreach (var osoba in listaPersonaliówZTelefonami) Console.WriteLine(osoba.ToString());

        // Możliwość modyfikacji danych źródła
        Console.WriteLine();
        var listaOsóbPełnoletnich2 = from osoba in listaOsób
                                     where osoba.Wiek >= 18
                                     orderby osoba.Wiek
                                     select osoba;

        Osoba pierwszyNaLiście = listaOsóbPełnoletnich2.First<Osoba>();
        Console.WriteLine(pierwszyNaLiście.ToString());
        pierwszyNaLiście.Imię = "Karol";
        pierwszyNaLiście.Nazwisko = "Bartnicki";
        pierwszyNaLiście.Wiek = 31;
        foreach (var osoba in listaOsóbPełnoletnich2)
        {
            Console.WriteLine(osoba.ToString());
        }

        var listaOsóbPełnoletnich3 = from osoba in listaOsób
                                     where osoba.Wiek >= 18
                                     orderby osoba.Wiek
                                     select new Osoba
                                     {
                                         Id = osoba.Id,
                                         Imię = osoba.Imię,
                                         Nazwisko = osoba.Nazwisko,
                                         NumerTelefonu = osoba.NumerTelefonu,
                                         Wiek = osoba.Wiek,
                                     };
    }
}
