using ParaInt = TypOgólny2.Para<int, int>;
using ParaDouble = TypOgólny2.Para<double, double>;
using ParaString = TypOgólny2.Para<string, string>;
using ParaIntDouble = TypOgólny2.Para<int, double>;

namespace TypOgólny
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();

            //int
            ParaInt[] pi = new ParaInt[10];
            for (int i = 0; i < pi.Length; i++)
            {
                pi[i] = new ParaInt(r.Next(10), r.Next(10));
            }
            Console.WriteLine("ParaInt:");
            foreach (ParaInt para in pi) Console.WriteLine(para.ToString());
            Array.Sort(pi);
            Console.WriteLine("\nParaInt po sortowaniu:");
            foreach (ParaInt para in pi) Console.WriteLine(para.ToString());

            //double
            ParaDouble[] pd = new ParaDouble[10];
            for (int i = 0; i < pi.Length; i++)
            {
                pd[i] = new ParaDouble(r.NextDouble(), r.NextDouble());
            }
            Console.WriteLine("\nParaDouble:");
            foreach (ParaDouble para in pd) Console.WriteLine(para.ToString());
            Array.Sort(pd);
            Console.WriteLine("\nParaDouble po sortowaniu");
            foreach (ParaDouble para in pd) Console.WriteLine(para.ToString());

            //int-double
            ParaIntDouble[] p = new ParaIntDouble[10];
            for (int i = 0; i < pi.Length; i++)
            {
                p[i] = new ParaIntDouble(r.Next(10), r.NextDouble());
            }
            Console.WriteLine("\nPara<int, double>");
            foreach (ParaIntDouble para in p) Console.WriteLine(para.ToString());
            Array.Sort(p);
            Console.WriteLine("\nPara<int, double> po sortowaniu");
            foreach (ParaIntDouble para in p) Console.WriteLine(para.ToString());

            //string
            ParaString[] ps = new ParaString[12];
            ps[0] = new ParaString("Bester", "Alfred");
            ps[1] = new ParaString("Dick", "Philip");
            ps[2] = new ParaString("Tolkien", "John");
            ps[3] = new ParaString("Lem", "Stanisław");
            ps[4] = new ParaString("Anderson", "Poul");
            ps[5] = new ParaString("Pohl", "Frederik");
            ps[6] = new ParaString("Le Guin", "Ursula");
            ps[7] = new ParaString("Card", "Orson");
            ps[8] = new ParaString("Gibson", "William");
            ps[9] = new ParaString("Asimov", "Isaac");
            ps[10] = new ParaString("Niven", "Larry");
            ps[11] = new ParaString("Herbert", "Frank");
            Console.WriteLine("\nParaString:");
            foreach (ParaString para in ps) Console.WriteLine(para.ToString());
            Array.Sort(ps);
            Console.WriteLine("\nParaString po sortowaniu:");
            foreach (ParaString para in ps) Console.WriteLine(para.ToString());
        }
    }
}