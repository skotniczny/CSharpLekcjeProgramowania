namespace UłamekDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Ułamek.Info());

            Ułamek u13 = new Ułamek(1, 3);
            Ułamek u2 = new Ułamek(2);
            Ułamek u0 = Ułamek.Zero;
            Ułamek uP = Ułamek.Połowa;

            Console.WriteLine(u13.ToString());
            Console.WriteLine(u2.ToString());
            Console.WriteLine(u0.ToString());
            Console.WriteLine(uP.ToString());
        }
    }
}