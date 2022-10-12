static double Całka(Func<double, double> f, double a, double b, uint N)
{
    double h = (b - a) / N;
    double sum = 0;
    for (int i = 0; i < N; i++)
    {
        sum += f(a + h / 2 + i * h);
    }
    return h * sum;
}

double wynik = Całka(x => x * x, 0, 1, 1000);
Console.WriteLine("Wynik: " + wynik);
