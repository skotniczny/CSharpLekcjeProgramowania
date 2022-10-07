namespace ŚredniaArytmetyczna
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("a = ");
                int a = int.Parse(Console.ReadLine());
                Console.Write("b = ");
                int b = int.Parse(Console.ReadLine());
                double średnia = (a + b) / 2.0;
                Console.WriteLine($"Średnia liczb {a} i {b} to {średnia}");
            }
            catch (Exception exc)
            {
                Console.Error.WriteLine("Wystąpił błąd: " + exc.Message);
            }
        }
    }
}