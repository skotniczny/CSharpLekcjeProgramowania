namespace RównanieKwadratowe
{
    class RównanieKwadratowe
    {
        private double a, b, c;

        public double? X1 { get; private set; }
        public double? X2 { get; private set; }

        public bool MaRozwiązania
        {
            get => X1.HasValue && X2.HasValue;
        }

        private void rozwiąż()
        {
            double delta = b * b - 4 * a * c;

            if (delta >= 0)
            {
                X1 = (-b - Math.Sqrt(delta)) / (2 * a);
                X2 = (-b + Math.Sqrt(delta)) / (2 * a);
            }
            else
            {
                X1 = null;
                X2 = null;
            }
        }

        public RównanieKwadratowe(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            rozwiąż();
        }

        public double A { get => a; }
        public double B { get => b; }
        public double C { get => c; }
    }

    internal class Program
    {
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

                // obliczanie i wyświetlanie wyniku
                RównanieKwadratowe równanie = new RównanieKwadratowe(a, b, c);
                if (równanie.MaRozwiązania)
                {
                    Console.WriteLine("Rozwiązania x1=" + równanie.X1 + ", x2=" + równanie.X2);
                } else
                {
                    Console.WriteLine("Równanie nie posiada rozwiązań");
                }
            }
            catch (Exception exc)
            {
                Console.Error.WriteLine(exc.Message);
            }
        }
    }
}