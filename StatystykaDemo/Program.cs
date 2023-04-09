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

            Statystyka.ParametryStatystyczne parametryStatystyczne = new Statystyka.ParametryStatystyczne(tablica);
            Console.WriteLine(parametryStatystyczne.ToString());

            Console.WriteLine(Statystyka.ParametryStatystyczne.Opis(tablica));

            Console.WriteLine("Z Histogramem");

            Statystyka.ParametryStatystyczneZHistogramem parametryStatystyczneZHistogramem = new Statystyka.ParametryStatystyczneZHistogramem(tablica, 11);
            Console.WriteLine(parametryStatystyczneZHistogramem.ToString());
        }
    }
}