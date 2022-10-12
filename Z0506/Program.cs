bool success;
int liczba;
do
{
    Console.Write("Napisz liczbę z zakresu 1-10:");
    success = int.TryParse(Console.ReadLine(), out liczba);
    if (liczba < 1 || liczba > 10)
    {
        Console.WriteLine("Podano wartość spoza zakresu!");
        success = false;
    }
    else
    {
        Console.WriteLine($"Kwadrat wpisanej liczby: {liczba * liczba}");
    }
}
while (!success);

bool exit = false;
do
{
    Console.WriteLine("Menu:");
    Console.WriteLine("1. Dodaj do liczby 10");
    Console.WriteLine("2. Pomnóż liczbę przez 2");
    Console.WriteLine("3. Odejmij od liczby 1");
    Console.WriteLine("4. Wyjdź z programu");
    string command = Console.ReadLine();
    switch (command)
    {
        case "1":
            liczba += 10;
            break;
        case "2":
            liczba *= 2;
            break;
        case "3":
            liczba -= 1;
            break;
        case "4":
            exit = true;
            break;
        default:
            break;
    }
    Console.WriteLine($"Rezultat: {liczba}\n");
} while (!exit);


