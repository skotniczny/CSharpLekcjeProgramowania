namespace StatystykaDemo
{
    using static Statystyka.Statystyka;

    internal class Program
    {
        static int[] ZbiórSumOczekZDwóchKostek(int liczbaRzutówKostką = 100)
        {
            Random r = new Random();
            int[] wyniki = new int[liczbaRzutówKostką];
            for (int i = 0; i < wyniki.Length; ++i)
            {
                int pierwszaKostka = r.Next(1, 7);
                int drugaKostka = r.Next(1, 7);
                wyniki[i] = pierwszaKostka + drugaKostka;
            }
            return wyniki;
        }

        static void Main(string[] args)
        {
            int[] wartości = ZbiórSumOczekZDwóchKostek(10000);
            double[] tablica = Array.ConvertAll<int, double>(wartości, i => (double)i);
            Console.WriteLine("Liczba elementów: " + tablica.Length);
            Console.WriteLine("Suma: " + Suma(tablica));
            Console.WriteLine("Średnia: " + Średnia(tablica));
            Console.WriteLine("Wariancja: " + Wariancja(tablica));
            Console.WriteLine("Odchylenie standardowe: " + OdchylenieStandardowe(tablica));

            double minimum, maksimum;
            Ekstrema(tablica, out minimum, out maksimum);
            Console.WriteLine("Wartości od " + minimum + " do " + maksimum);
            Console.WriteLine("Zakres: " + Zakres(tablica));
            Console.WriteLine("Mediana: " + Mediana(tablica));
            Console.WriteLine("Skośność: " + Skośność(tablica));
            int[] histogram = Histogram(tablica, 11);
            foreach (int liczbaWartości in histogram)
                Console.Write(liczbaWartości.ToString() + " ");
        }
    }
}