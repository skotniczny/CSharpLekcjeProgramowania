static void Ekstrema(int[] wartości, out int indeksMinimum, out int indeksMaksimum)
{
    if (wartości == null) throw new ArgumentNullException("Przesłano obiekt pusty");
    if (wartości.Length == 0) throw new ArgumentException("W tablicy nie ma elementów");
    indeksMinimum = 0;
    indeksMaksimum = 0;
    int minimum = wartości[0], maximum = wartości[0];
    for (int i = 1; i < wartości.Length; ++i)
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

static int[] Histogram(int[] wartości, int min, int max)
{
    int[] histogram = new int[max + 1- min];
    foreach (int wartość in wartości)
    {
        histogram[wartość - min]++;
    }
    return histogram;
}

static void Dominanta(int[] wartości)
{
    int dominanta = 0;
    Ekstrema(wartości, out int indeksMinimum, out int indeksMaksimum);
    int min = wartości[indeksMinimum];
    int max = wartości[indeksMaksimum];

    int[] histogram = Histogram(wartości, min, max);
    for (int i = 1; i < histogram.Length; i++)
    {
        if (histogram[i] > histogram[dominanta])
        {
            dominanta = i;
        }
    }

    string rezultat = "Dominanta: ";
    int index = 0;
    foreach (int wartość in histogram)
    {
        if (wartość == histogram[dominanta]) rezultat += $"{index + min} ";
        index++;
    }
    Console.WriteLine(rezultat);
}

Random r = new Random();
int[] tablica = new int[10];
for (int i = 0; i < tablica.Length; i++)
{
    tablica[i] = r.Next(-5, 25);
}

Ekstrema(tablica, out int indeksMinimum, out int indeksMaksimum);

Console.WriteLine(string.Join(',', tablica));
int[] histogram = Histogram(tablica, tablica[indeksMinimum], tablica[indeksMaksimum]);
Console.WriteLine(string.Join(',', histogram));

Dominanta(tablica);
