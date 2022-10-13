namespace RównanieKwadratowe
{
    class RównanieKwadratowe
    {
        private double a, b, c;
        private double? x1, x2;

        bool konieczneObliczenieRozwiązań = true;

        public double A
        {
            get => a;
            set {
                if (value != a)
                {
                    konieczneObliczenieRozwiązań = true;
                    a = value;
                }
            }
        }
        public double B
        {
            get => b;
            set
            {
                if (value != b)
                {
                    konieczneObliczenieRozwiązań = true;
                    b = value;
                }
            }
        }
        public double C
        {
            get => c;
            set
            {
                if (value != c)
                {
                    konieczneObliczenieRozwiązań = true;
                    c = value;
                }
            }
        }

        public double? X1
        {
            get
            {
                rozwiąż();
                return x1;
            }
        }
        public double? X2
        {
            get
            {
                rozwiąż();
                return x2;
            }
        }

        public bool MaRozwiązania
        {
            get => X1.HasValue && X2.HasValue;
        }

        private void rozwiąż()
        {
            if (!konieczneObliczenieRozwiązań) return;
            konieczneObliczenieRozwiązań = false;

            double delta = b * b - 4 * a * c;

            if (delta >= 0)
            {
                x1 = (-b - Math.Sqrt(delta)) / (2 * a);
                x2 = (-b + Math.Sqrt(delta)) / (2 * a);
            }
            else
            {
                x1 = null;
                x2 = null;
            }
        }

        public RównanieKwadratowe(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }
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

        private static long testWydajności(long liczbaPowtórzeń, long liczbaZmianWspółczynników, long liczbaOdczytówRozwiązań)
        {
            long N = liczbaPowtórzeń;
            long n1 = N / liczbaZmianWspółczynników;
            long n2 = N / liczbaOdczytówRozwiązań;
            RównanieKwadratowe równanie = new RównanieKwadratowe(1, 2, 1);
            long start = Environment.TickCount64;
            for (long i = 0; i < N; ++i)
            {
                if (i % n1 == 0)
                {
                    równanie.A = 1;
                    równanie.B = 2;
                    równanie.C = 1;
                }
                if (i % n2 == 0)
                {
                    double x1 = równanie.X1.Value;
                    double x2 = równanie.X2.Value;
                }
            }
            long end = Environment.TickCount64;
            return end - start;
        }

        static void Main(string[] args)
        {
            long N = 100000000;
            Console.WriteLine($"Przeważa odczyt rozwiązań: {testWydajności(N, N / 100, N)}");
            Console.WriteLine($"Przeważa zmiana współczynników: {testWydajności(N, N, N / 100)}");
        }
    }
}