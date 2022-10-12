static double sumaSzeregu(Func<long, double> f, long n)
{
    double sum = 0;
    for (long i = 1; i < n; i++)
    {
        sum += f(i);
    }
    return sum;
}

double sum = sumaSzeregu((x) => 1.0 / (x * x), 1000000);
Console.WriteLine($"PI = {Math.Sqrt(sum * 6)}");
Console.WriteLine($"Błąd = {Math.PI - Math.Sqrt(sum * 6)}");
