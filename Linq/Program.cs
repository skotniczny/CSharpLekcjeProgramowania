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
    }
}
