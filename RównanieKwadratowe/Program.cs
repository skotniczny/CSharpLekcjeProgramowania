namespace RównanieKwadratowe
{
    internal class Program
    {
        static (double x1, double x2) rozwiążRównanieKwadratowe(double a, double b, double c)
        {
            double delta = b * b - 4 * a * c;
            if (delta >= 0)
            {
                double x1 = (-b - Math.Sqrt(delta)) / (2 * a);
                double x2 = (-b + Math.Sqrt(delta)) / (2 * a);
                return (x1, x2);
            }
            else throw new Exception("Równanie nie posiada rozwiązań");
        }

        static double wczytajLiczbę(string zachęta)
        {
            double liczba = 0;
            bool czyLiczbaPoprawna;
            do
            {
                Console.Write(zachęta);
                string s = Console.ReadLine();
                czyLiczbaPoprawna = double.TryParse(s, out liczba);
                if (!czyLiczbaPoprawna) Console.Error.WriteLine("Niepoprawny łańcuch. Wprowadź liczbę jeszcze raz");
            }
            while (!czyLiczbaPoprawna);
            return liczba;
        }
        static void Main(string[] args)
        {
            try
            {
                // pobieranie współczynników
                double a = wczytajLiczbę("a = ");
                double b = wczytajLiczbę("b = ");
                double c = wczytajLiczbę("c = ");
                Console.WriteLine($"Równanie: {a}x^2 + {b}x + {c} = 0");
                // wyróżnik
                double delta = b * b - 4 * a * c;
                // obliczanie i wyświetlanie wyniku
                (double x1, double x2) rozwiązania = rozwiążRównanieKwadratowe(a, b, c);
                Console.WriteLine("Rozwiązania x1=" + rozwiązania.x1 + ", x2=" + rozwiązania.x2);
            }
            catch (Exception exc)
            {
                Console.Error.WriteLine(exc.Message);
            }
        }
    }
}