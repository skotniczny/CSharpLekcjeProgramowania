namespace Pochodna
{
    internal class Program
    {
        static double pochodna1(Func<double, double> f, double x, double dx)
        {
            return (f(x + dx) - f(x - dx)) / (2 * dx);
        }
        static double pochodna2(Func<double, double> f, double x, double dx)
        {
            return (f(x + dx) - 2 * f(x) + f(x - dx)) / (dx * dx);
        }
        static void testuj(double x, double dx = 0.0001)
        {
            Func<double, double> f = (double x) => { return 2 * x * x - 3 * x + 1; };
            double y0 = f(x);
            Console.WriteLine($"Wartość funkcji w x = {x}: {y0}");
            double y1 = pochodna1(f, x, dx);
            Console.WriteLine($"Pochodna funkcji w x = {x}: {y1}");
            double y2 = pochodna2(f, x, dx);
            Console.WriteLine($"Druga pochodna funkcji w x = {x}: {y2}");
        }
        static void Main(string[] args)
        {
            testuj(0.5);
            Console.WriteLine();
            testuj(2);
        }
    }
}