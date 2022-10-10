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

            Ułamek um2 = new Ułamek(4, -2);
            um2.Uprość();
            Console.WriteLine(um2.ToString());

            Ułamek u12 = new Ułamek { Licznik = 1, Mianownik = 2 };
            Console.WriteLine(u12.ToString());

            Ułamek a = Ułamek.Połowa;
            Ułamek b = Ułamek.Ćwierć;

            Console.WriteLine("Operatory arytmetyczne:");
            Console.WriteLine((a + b).ToString());
            Console.WriteLine((a - b).ToString());
            Console.WriteLine((a * b).ToString());
            Console.WriteLine((a / b).ToString());

            Console.WriteLine("Operatory konwersji:");
            double r = (double)Ułamek.Połowa;
            Console.WriteLine(r.ToString());
            Ułamek c = 2;
            Console.WriteLine(c.ToString());

            Console.WriteLine("Odwrotność:");
            Console.WriteLine(Ułamek.Odwróć(Ułamek.Ćwierć));

            Ułamek u14 = Ułamek.Ćwierć;
            u14.Odwróć();
            Console.WriteLine(u14);

            Console.WriteLine(Ułamek.Ćwierć.Odwrócony());
            Console.WriteLine(Ułamek.Ćwierć.Odwrotność);

            Console.WriteLine("Operator potęgowania");
            Console.WriteLine(Ułamek.Połowa^3);
            Console.WriteLine(-Ułamek.Połowa ^3);
        }
    }
}