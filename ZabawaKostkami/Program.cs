int[] ZbiórSumOczekZDwóchKostek(int liczbaRzutówKostką = 100)
{
    Random r = new Random();
    int[] wyniki = new int[liczbaRzutówKostką];
    for (int i = 0; i < wyniki.Length; ++i)
    {
        int pierwszaKostka = r.Next(1, 7);
        int drugaKostka = r.Next(1, 7);
        wyniki[i] = pierwszaKostka + drugaKostka;
    }
    return wyniki;
}

double Suma(double[] wartości)
{
    double suma = 0;
    foreach (double wartość in wartości) suma += wartość;
    return suma;
}

double Średnia(double[] wartości)
{
    if (wartości == null) throw new ArgumentNullException("Przesłano obiekt pusty");
    if (wartości.Length == 0) throw new ArgumentException("W tablicy nie ma elementów");
    return Suma(wartości) / wartości.Length;
}

double Wariancja(double[] wartości)
{
    double średnia = Średnia(wartości);
    double wariancja = 0;
    foreach (double wartość in wartości)
    {
        double odchylenie = wartość - średnia;
        wariancja += odchylenie * odchylenie;
    }
    return wariancja / wartości.Length;
}

double OdchylenieStandardowe(double[] wartości)
{
    return Math.Sqrt(Wariancja(wartości));
}

void Ekstrema(double[] wartości, out int indeksMinimum, out int indeksMaksimum)
{
    if (wartości == null) throw new ArgumentNullException("Przesłano obiekt pusty");
    if (wartości.Length == 0) throw new ArgumentException("W tablicy nie ma elementów");

    indeksMinimum = 0;
    indeksMaksimum = 0;
    double minimum = wartości[0], maximum = wartości[0];
    for (int i = 0; i < wartości.Length; ++i)
    {
        if (wartości[i] < minimum)
        {
            indeksMinimum = i;
            minimum = wartości[i];
        }
        if (wartości[i] > maximum)
        {
            indeksMaksimum = i;
            maximum = wartości[i];
        }
    }
}

double Zakres(double[] wartości)
{
    Ekstrema(wartości, out int indeksMinimum, out int indeksMaksimum);
    return wartości[indeksMaksimum] - wartości[indeksMinimum];
}

double Mediana(double[] wartości)
{
    if (wartości == null) throw new ArgumentNullException("Przesłano obiekt pusty");
    if (wartości.Length == 0) throw new ArgumentException("W tablicy nie ma elementów");

    double[] _wartości = (double[])wartości.Clone();
    Array.Sort(_wartości);

    if (_wartości.Length % 2 != 0) return _wartości[_wartości.Length / 2];
    else return (_wartości[_wartości.Length / 2 - 1] + _wartości[_wartości.Length / 2]) / 2.0;
}

double Skośność(double[] wartości)
{
    return (Średnia(wartości) - Mediana(wartości)) / OdchylenieStandardowe(wartości);
}

int[] wartości = ZbiórSumOczekZDwóchKostek(100);
foreach (int wartość in wartości) Console.Write($"{wartość}; ");
double[] tablica = Array.ConvertAll<int, double>(wartości, i => (double)i);
Console.WriteLine($"Liczba elementów: {tablica.Length}");
Console.WriteLine($"Suma: {Suma(tablica)}");
Console.WriteLine($"Średnia: {Średnia(tablica)}");
Console.WriteLine($"Wariancja: {Wariancja(tablica)}");
Console.WriteLine($"Odchylenie standardowe: {OdchylenieStandardowe(tablica)}");
Ekstrema(tablica, out int indeksMinimum, out int indeksMaksimum);
Console.WriteLine($"Wartości od {tablica[indeksMinimum]} do {tablica[indeksMaksimum]}");
Console.WriteLine($"Zakres: {Zakres(tablica)}");
Console.WriteLine($"Mediana: {Mediana(tablica)}");
Console.WriteLine($"Skośność: {Skośność(tablica)}");
