namespace Statystyka
{
    public class Statystyka
    {
        public static double Suma(IEnumerable<double> wartości)
        {
            double suma = 0;
            foreach (double wartość in wartości) suma += wartość;
            return suma;
        }

        public static int Liczba(IEnumerable<double> wartości)
        {
            int liczba = 0;
            foreach (double wartość in wartości) liczba++;
            return liczba;
        }

        public static double Średnia(IEnumerable<double> wartości)
        {
            if (wartości == null) throw new ArgumentNullException("Przesłano obiekt pusty");
            int liczba = Liczba(wartości);
            if (liczba == 0) throw new ArgumentException("W tablicy nie ma elementów");
            return Suma(wartości) / liczba;
        }

        //tu nie korzystam z meotdy Suma, żeby uniknąć dwóch pętli zamiast jednej
        public static double Średnia2(IEnumerable<double> wartości)
        {
            if (wartości == null) throw new ArgumentNullException("Przesłano obiekt pusty");
            int liczba = 0;
            double suma = 0;
            foreach (double wartość in wartości)
            {
                liczba++;
                suma += wartość;
            }
            if (liczba == 0) throw new ArgumentException("W tablicy nie ma elementów");
            return suma / liczba;
        }

        public static double Wariancja(IEnumerable<double> wartości)
        {
            double średnia = Średnia(wartości);
            double wariancja = 0;
            foreach (double wartość in wartości)
            {
                double odchylenie = wartość - średnia;
                wariancja += odchylenie * odchylenie;
            }
            return wariancja / Liczba(wartości);
        }

        public static double OdchylenieStandardowe(IEnumerable<double> wartości)
        {
            return Math.Sqrt(Wariancja(wartości));
        }

        public static void Ekstrema(IEnumerable<double> wartości, out double minimum, out double maksimum)
        {
            if (wartości == null) throw new ArgumentNullException("Przesłano obiekt pusty");
            if (Liczba(wartości) == 0) throw new ArgumentException("W tablicy nie ma elementów");

            IEnumerator<double> iterator = wartości.GetEnumerator();
            iterator.MoveNext();
            double wartości0 = iterator.Current;
            minimum = wartości0;
            maksimum = wartości0;
            while (iterator.MoveNext())
            {
                double element = iterator.Current;
                if (element < minimum)
                {
                    minimum = element;
                }
                if (element > maksimum)
                {
                    maksimum = element;
                }
            }
        }

        public static double Zakres(IEnumerable<double> wartości)
        {
            double minimum, maksimum;
            Ekstrema(wartości, out minimum, out maksimum);
            return maksimum - minimum;
        }

        public static double Skośność(IEnumerable<double> wartości)
        {
            return (Średnia(wartości) - Mediana(wartości)) / OdchylenieStandardowe(wartości);
        }

        public static double[] KopiujDoTablicy(IEnumerable<double> wartości)
        {
            double[] tablica = new double[Liczba(wartości)];
            int i = 0;
            foreach (double wartość in wartości)
            {
                tablica[i] = wartość;
                i++;
            }
            return tablica;
        }

        public static double Mediana(IEnumerable<double> wartości)
        {
            if (wartości == null) throw new ArgumentNullException("Przesłano obiekt pusty");
            if (Liczba(wartości) == 0) throw new ArgumentException("W tablicy nie ma elementów");

            double[] _wartości = KopiujDoTablicy(wartości);
            Array.Sort(_wartości);

            if (_wartości.Length % 2 != 0) return _wartości[_wartości.Length / 2];
            else return (_wartości[_wartości.Length / 2 - 1] + _wartości[_wartości.Length / 2]) / 2.0;
        }

        public static int[] Histogram(IEnumerable<double> wartości, int liczbaPrzedziałów)
        {
            double rozmiarPrzediału = Zakres(wartości) / liczbaPrzedziałów;
            if (rozmiarPrzediału == 0) throw new Exception("Niepoprawne dane");

            double minimum, maksimum;
            Ekstrema(wartości, out minimum, out maksimum);

            int[] histogram = new int[liczbaPrzedziałów];
            foreach (double wartość in wartości)
            {
                int i = (int)((wartość - minimum) / rozmiarPrzediału);
                if (i == liczbaPrzedziałów) i = liczbaPrzedziałów - 1; //skrajnu punkt wkładamy do ostatniego przedziału
                histogram[i]++;
            }
            return histogram;
        }
    }
}