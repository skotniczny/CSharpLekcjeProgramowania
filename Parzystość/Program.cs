namespace Parzystość
{
    internal class Program
    {
        static bool czyLiczbaJestParztysta(int a)
        {
            return a % 2 == 0;
        }
        static void Main(string[] args)
        {

            Console.WriteLine($"0: {czyLiczbaJestParztysta(0)}");
            Console.WriteLine($"1: {czyLiczbaJestParztysta(1)}");
            Console.WriteLine($"2: {czyLiczbaJestParztysta(2)}");
            Console.WriteLine($"3: {czyLiczbaJestParztysta(3)}");
            Console.WriteLine($"4: {czyLiczbaJestParztysta(4)}");
            Console.WriteLine($"5: {czyLiczbaJestParztysta(5)}");
        }
    }
}