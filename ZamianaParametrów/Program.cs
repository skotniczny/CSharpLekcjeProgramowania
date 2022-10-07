namespace ZamianaParametrów
{
    internal class Program
    {
        static void swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }

        static void Main(string[] args)
        {
            int a = 1, b = 2;
            Console.WriteLine($"a={a} b={b}");
            swap(ref a, ref b);
            Console.WriteLine($"a={a} b={b}");
        }
    }
}