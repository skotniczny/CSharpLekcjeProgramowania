using System.Numerics;

namespace RównanieKwadratoweZespolone
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // pobieranie współczynników
            Console.Write("a = ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b = ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("c = ");
            double c = double.Parse(Console.ReadLine());
            Console.WriteLine($"Równanie: {a}x^2 + {b}x + {c} = 0");
            // wyróżnik
            double delta = b * b - 4 * a * c;
            Console.WriteLine($"Delta {delta}");
            // obliczanie i wyświetlanie wyniku
            Complex x1 = (-b - Complex.Sqrt(delta)) / (2 * a);
            Complex x2 = (-b + Complex.Sqrt(delta)) / (2 * a);
            Console.WriteLine("Rozwiązania x1=" + x1 + ", x2=" + x2);
        }
    }
}
