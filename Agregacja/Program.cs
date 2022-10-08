namespace Agregacja
{
    internal class Program
    {
        static int[] zbiórSumOczekZDwóchKostek(int liczbaRzutówKostką = 100)
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
            int[] wartości = zbiórSumOczekZDwóchKostek(10000);
            double[] tablica = Array.ConvertAll<int, double>(wartości, i => (double)i);
            int liczbaElementów = tablica.Count();
            double suma = tablica.Sum();
            double średnia = tablica.Average();
            double wariancja = tablica.Sum(element => (element - średnia) * (element - średnia));
            wariancja /= liczbaElementów;
            double odchylenieStandardowe = Math.Sqrt(wariancja);
    
            Console.WriteLine("Liczba elementów: " + liczbaElementów);
            Console.WriteLine("Suma: " + suma);
            Console.WriteLine("Średnia: " + średnia);
            Console.WriteLine("Wariancja: " + wariancja);
            Console.WriteLine("Odchylenie standardowe: " + odchylenieStandardowe);
   
            double minimum = tablica.Min();
            double maksimum = tablica.Max();
  
            Console.WriteLine("Wartości od " + minimum + " do " + maksimum);
            Console.WriteLine("Zakres: " + (maksimum - minimum));
        }
    }
}