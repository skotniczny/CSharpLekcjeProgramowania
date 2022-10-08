namespace LiczbaEulera
{
    internal class Program
    {
        static long silnia(byte n)
        {
            if (n <= 1) return 1;
            long wartość = 1;
            for (byte i = 2; i <= n; i++)
                wartość *= i;
            return wartość;
        }
        //static double liczbaEulera(int n = 20) //naiwna implementacja
        //{
        //    double e = 0;
        //    for (byte i = 0; i <= n; ++i) e += 1.0 / silnia(i);
        //    return e;
        //}

        static double liczbaEulera(int n = 20)
        {
            double e = 0;
            double silnia = 1;
            for (byte i = 0; i <= n; ++i)
            {
                e += 1.0 / silnia;
                silnia *= (i + 1);
            }
            return e;
        }

        static void Main(string[] args)
        {
            double e = liczbaEulera();
            Console.WriteLine($"E: {e}, błąd: {e - Math.E}");
        }
    }
}