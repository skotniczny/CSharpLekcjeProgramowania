int IncreaseIntByPercent(int number, int percent)
{
    return number + number * percent / 100;
}

int city1 = 100000;
int city2 = 300000;
int counter = 0;

while (city1 < city2)
{
    city1 = IncreaseIntByPercent(city1, 3);
    city2 = IncreaseIntByPercent(city2, 2);
    counter++;
    Console.WriteLine($"{counter}.");
    Console.WriteLine($"Populacja miasta 1: {city1}");
    Console.WriteLine($"Populacja miasta 2: {city2}");
}

Console.WriteLine($"Rezultat:");
Console.WriteLine($"Populacja miasta 1: {city1}");
Console.WriteLine($"Populacja miasta 2: {city2}");
Console.WriteLine($"Iteracje: {counter}.");

