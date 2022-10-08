int[] zbiórSumOczekZDwóchKostek(int liczbaRzutówKostką = 100)
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

int[] wartości = zbiórSumOczekZDwóchKostek(100);
foreach (int wartość in wartości) Console.Write($"{wartość}; ");
