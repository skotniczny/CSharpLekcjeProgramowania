namespace Z1101
{
    internal class Program
    {
        public struct Wektor {
            public Wektor(double x, double y, double z)
            {
                X = x;
                Y = y;
                Z = z;
            }

            public double X;
            public double Y;
            public double Z;
        }
        static void Main(string[] args)
        {
            Wektor wektor1= new Wektor(1, 2, 3);
        }
    }
}