void Ekstrema(double[] wartości, out int[] indeksyMinimum, out int[] indeksyMaksimum)
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

    int liczbaMinimum = 0;
    int liczbaMaksimum = 0;
    foreach (int wartość in wartości)
    {
        if (wartość == wartości[indeksMinimum]) liczbaMinimum++;
        if (wartość == wartości[indeksMaksimum]) liczbaMaksimum++;
    }

    indeksyMinimum = new int[liczbaMinimum];
    indeksyMaksimum = new int[liczbaMaksimum];
    int iMin = 0;
    int iMax = 0;
    for (int i = 0; i < wartości.Length; i++)
    {
        if (wartości[i] == wartości[indeksMinimum])
        {
            indeksyMinimum[iMin] = i;
            iMin++;
        }
        if (wartości[i] == wartości[indeksMaksimum])
        {
            indeksyMaksimum[iMax] = i;
            iMax++;
        }
    }
}

Random r = new Random();
double[] wartości = new double[15];
for (int i = 0; i < wartości.Length; i++) wartości[i] = (double)r.Next(10);

Console.WriteLine(string.Join(',', wartości));
for (int i = 0; i < wartości.Length; i++) Console.Write(i % 10 + ",");
Console.WriteLine();

Ekstrema(wartości, out int[] indeksyMinimum, out int[] indeksyMaksimum);
Console.WriteLine($"Indeksy minimum: {string.Join(',', indeksyMinimum)}");
Console.WriteLine($"Indeksy maksimum: {string.Join(',', indeksyMaksimum)}");
