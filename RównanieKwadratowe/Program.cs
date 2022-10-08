namespace RównanieKwadratowe
{
    internal class Program
    {
        static void rozwiążRównanieKwadratowe(double a, double b, double c, out double x1, out double x2)
        {
            double delta = b * b - 4 * a * c;
            if (delta >= 0)
            {
                x1 = (-b - Math.Sqrt(delta)) / (2 * a);
                x2 = (-b + Math.Sqrt(delta)) / (2 * a);
            }
            else throw new Exception("Równanie nie posiada rozwiązań");
        }
        static void Main(string[] args)
        {
            try
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
                double x1, x2;
                rozwiążRównanieKwadratowe(a, b, c, out x1, out x2);
                Console.WriteLine("Rozwiązania x1=" + x1 + ", x2=" + x2);
            }
            catch (Exception exc)
            {
                Console.Error.WriteLine(exc.Message);
            }
        }
    }
}