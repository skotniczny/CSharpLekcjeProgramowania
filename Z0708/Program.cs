double Mediana(double[] wartości)
{
    if (wartości == null) throw new ArgumentNullException("Przesłano obiekt pusty");
    if (wartości.Length == 0) throw new ArgumentException("W tablicy nie ma elementów");

    double[] _wartości = (double[])wartości.Clone();
    Array.Sort(_wartości);

    if (_wartości.Length % 2 != 0) return _wartości[_wartości.Length / 2];
    else return (_wartości[_wartości.Length / 2 - 1] + _wartości[_wartości.Length / 2]) / 2.0;
}

double PierwszyKwartyl(double[] wartości)
{
    if (wartości == null) throw new ArgumentNullException("Przesłano obiekt pusty");
    if (wartości.Length == 0) throw new ArgumentException("W tablicy nie ma elementów");

    double[] _wartości = (double[])wartości.Clone();
    Array.Sort(_wartości);

    double[] połowa = _wartości[0..(_wartości.Length / 2)];

    if (połowa.Length % 2 != 0) return połowa[połowa.Length / 2];
    return (połowa[połowa.Length / 2 - 1] + połowa[połowa.Length / 2]) / 2.0;
}

double TrzeciKwartyl(double[] wartości)
{
    if (wartości == null) throw new ArgumentNullException("Przesłano obiekt pusty");
    if (wartości.Length == 0) throw new ArgumentException("W tablicy nie ma elementów");

    double[] _wartości = (double[])wartości.Clone();
    Array.Sort(_wartości);

    double[] połowa;
    if (_wartości.Length % 2 != 0) połowa = _wartości[(_wartości.Length / 2 + 1).._wartości.Length];
    else połowa = _wartości[(_wartości.Length / 2).._wartości.Length];

    if (połowa.Length % 2 != 0) return połowa[połowa.Length / 2];
    return (połowa[połowa.Length / 2 - 1] + połowa[połowa.Length / 2]) / 2.0;
}

double[] wyniki1 = { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0};

Console.WriteLine(string.Join(',', wyniki1));
Console.WriteLine($"Q1 = {PierwszyKwartyl(wyniki1)}");
Console.WriteLine($"Q2 = {Mediana(wyniki1)}");
Console.WriteLine($"Q3 = {TrzeciKwartyl(wyniki1)}");

double[] wyniki2 = { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0};

Console.WriteLine(string.Join(',', wyniki2));
Console.WriteLine($"Q1 = {PierwszyKwartyl(wyniki2)}");
Console.WriteLine($"Q2 = {Mediana(wyniki2)}");
Console.WriteLine($"Q3 = {TrzeciKwartyl(wyniki2)}");

