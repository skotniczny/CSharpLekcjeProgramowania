void ciągFibonacciego(int[] tablica)
{
    if (tablica.Length < 2) throw new ArgumentException();
    int a = 0;
    int b = 1;
    int sum;
    tablica[0] = a;
    tablica[1] = b;

    for (int i = 2; i < tablica.Length; i++)
    {
        sum = a + b;
        a = b;
        b = sum;
        tablica[i] = sum;
    }
}

int[] tablica = new int[11];
ciągFibonacciego(tablica);
Console.WriteLine(string.Join(',', tablica));
