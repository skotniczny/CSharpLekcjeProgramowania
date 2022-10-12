bool success;
do
{
    Console.Write("Napisz liczbę z zakresu 1-10:");
    success = int.TryParse(Console.ReadLine(), out int liczba);
    if (liczba < 1 || liczba > 10)
    {
        Console.WriteLine("Podano wartość spoza zakresu!");
        success = false;
    } else
    {
        Console.WriteLine($"Kwadrat wpisanej liczby: {liczba * liczba}");
    }
}
while (!success);
