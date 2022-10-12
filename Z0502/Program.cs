Random r = new Random();
int n = r.Next(1, 11);
int? strzał = null;
int liczbaPrób = 0;
do
{
    if (strzał != null)
    {
        string podpowiedź = string.Empty;
        if (strzał > n) podpowiedź = "mniejsza";
        if (strzał < n) podpowiedź = "większa";
        Console.WriteLine($"Wylosowana liczba jest {podpowiedź}");
    }
    Console.WriteLine("Zgadnij wylosowaną liczbę z zakresu 1-10");
    Console.Write("Podaj liczbę: ");
    strzał = int.Parse(Console.ReadLine());
    liczbaPrób++;
}
while (strzał != n);

Console.WriteLine($"Brawo! Wylosowana liczba to {n}. Liczba prób: {liczbaPrób}");
