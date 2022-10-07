namespace RównanieKwadratowe
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
            // obliczanie i wyświetlanie wyniku
            if (delta >= 0)
            {
                double x1 = (-b - Math.Sqrt(delta)) / (2 * a);
                double x2 = (-b + Math.Sqrt(delta)) / (2 * a);
                Console.WriteLine("Rozwiązania x1=" + x1 + ", x2=" + x2);
            }
            else Console.WriteLine("Brak rozwiązań");
        }
    }
}