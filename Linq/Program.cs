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
}
