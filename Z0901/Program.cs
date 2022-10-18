(int[] indeksyMinimum, int[] indeksyMaksimum) Ekstrema(double[] wartości)
{
    if (wartości == null) throw new ArgumentNullException("Przesłano obiekt pusty");
    if (wartości.Length == 0) throw new ArgumentException("W tablicy nie ma elementów");

    int indeksMinimum = 0;
    int indeksMaksimum = 0;
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

    List<int> indeksyMinimum = new List<int>();
    List<int> indeksyMaksimum = new List<int>();
    for (int i = 0; i < wartości.Length; i++)
    {
        if (wartości[i] == wartości[indeksMinimum])
        {
            indeksyMinimum.Add(i);
        }
        if (wartości[i] == wartości[indeksMaksimum])
        {
            indeksyMaksimum.Add(i);
        }
    }
    return (indeksyMinimum.ToArray(), indeksyMaksimum.ToArray());
}

Random r = new Random();
double[] wartości = new double[15];
for (int i = 0; i < wartości.Length; i++) wartości[i] = (double)r.Next(10);

Console.WriteLine(string.Join(',', wartości));
for (int i = 0; i < wartości.Length; i++) Console.Write(i % 10 + ",");
Console.WriteLine();

(int[] indeksyMinimum, int[] indeksyMaksimum) wynik = Ekstrema(wartości);
Console.WriteLine($"Indeksy minimum: {string.Join(',', wynik.indeksyMinimum)}");
Console.WriteLine($"Indeksy maksimum: {string.Join(',', wynik.indeksyMaksimum)}");
