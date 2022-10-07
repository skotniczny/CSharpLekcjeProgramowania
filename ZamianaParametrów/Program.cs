namespace ZamianaParametrów
{
    internal class Program
    {
        static void swap<T>(ref T a, ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }

        static void Main(string[] args)
        {
            int a = 1, b = 2;
            Console.WriteLine($"a={a} b={b}");
            swap<int>(ref a, ref b);
            Console.WriteLine($"a={a} b={b}");
             
            double c = 1, d = 2;
            Console.WriteLine($"c={c} d={d}");
            swap<double>(ref c, ref d);
            Console.WriteLine($"c={c} d={d}");

            string e = "jeden", f = "dwa";
            Console.WriteLine($"e={e} f={f}");
            swap(ref e, ref f);
            Console.WriteLine($"e={e} f={f}");
        }
    }
}