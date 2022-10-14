int[] inc(int[] tablica)
{
    for (int i = 0; i < tablica.Length; i++)
    {
        tablica[i] = ++tablica[i];
    }
    return tablica;
}

int[] dec(int[] tablica)
{
    for (int i = 0; i < tablica.Length; i++)
    {
        tablica[i] = --tablica[i];
    }
    return tablica;
}

int[] incCopy(int[] tablica)
{
    int[] inc = new int[tablica.Length];
    for (int i = 0; i < tablica.Length; i++)
    {
        int el = tablica[i];
        inc[i] = ++el;
    }
    return inc;
}

int[] decCopy(int[] tablica)
{
    int[] dec = new int[tablica.Length];
    for (int i = 0; i < tablica.Length; i++)
    {
        int el = tablica[i];
        dec[i] = --el;
    }
    return dec;
}

Random r = new Random();
int[] dane = new int[10];

for (int i = 0; i < dane.Length; i++)
{
    dane[i] = r.Next(100);
}

Console.WriteLine(string.Join(',', dane));
inc(dane);
inc(dane);
Console.WriteLine(string.Join(',', dane));
dec(dane);
Console.WriteLine(string.Join(',', dane));

Console.WriteLine("Zmodyfikowana kopia:");
Console.WriteLine($"{string.Join(',', incCopy(dane))} => incCopy");
Console.WriteLine($"{string.Join(',', incCopy(dane))} => incCopy");
Console.WriteLine(string.Join(',', dane));
Console.WriteLine($"{string.Join(',', decCopy(dane))} => decCopy");
Console.WriteLine(string.Join(',', dane));
