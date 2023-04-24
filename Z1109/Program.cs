namespace Z1109
{
    internal class Program
    {
        public struct Wektor : IComparable<Wektor>
        {
            public Wektor(double x, double y, double z)
            {
                X = x;
                Y = y;
                Z = z;
            }

            public double X;
            public double Y;
            public double Z;

            public double Długość
            {
                get
                {
                    return Math.Sqrt(X * X + Y * Y + Z * Z);
                }
            }

            public static Wektor operator +(Wektor w1, Wektor w2)
            {
                return new Wektor(w1.X + w2.X, w1.Y + w2.Y, w1.Z + w2.Z);
            }

            public static Wektor operator -(Wektor w1, Wektor w2)
            {
                return new Wektor(w1.X - w2.X, w1.Y - w2.Y, w1.Z - w2.Z);
            }

            public static Wektor operator +(Wektor w1)
            {
                return new Wektor(w1.X, w1.Y, w1.Z);
            }

            public static Wektor operator -(Wektor w1)
            {
                return new Wektor(-w1.X, -w1.Y, -w1.Z);
            }

            public static bool operator ==(Wektor w1, Wektor w2)
            {
                return (w1.X == w2.X && w1.Y == w2.Y && w1.Z == w2.Z);
            }

            public static bool operator !=(Wektor w1, Wektor w2)
            {
                return !(w1.X == w2.X && w1.Y == w2.Y && w1.Z == w2.Z);
            }

            public override bool Equals(object obj)
            {
                if (!(obj is Wektor)) return false;
                Wektor w = (Wektor)obj;
                return (this == w);
            }

            public override int GetHashCode()
            {
                return (X, Y, Z).GetHashCode();
            }

            public override string ToString()
            {
                return $"{{{X}, {Y}, {Z}}}";
            }

            public static double Dot(Wektor w1, Wektor w2)
            {
                return w1.X * w2.X + w1.Y * w2.Y + w1.Z * w2.Z;
            }

            public static Wektor Cross(Wektor w1, Wektor w2)
            {
                double x = w1.Y * w2.Z - w1.Z * w2.Y;
                double y = w1.Z * w2.X - w1.X * w2.Z;
                double z = w1.X * w2.Y - w1.Y * w2.X;
                return new Wektor(x, y, z);
            }

            public static double operator *(Wektor w1, Wektor w2)
            {
                return Dot(w1, w2);
            }

            public static Wektor operator *(Wektor w1, double d)
            {
                return new Wektor(w1.X * d, w1.Y * d, w1.Z * d);
            }

            public static Wektor operator *(double d, Wektor w1)
            {
                return w1 * d;
            }

            public static Wektor operator /(Wektor w1, double d)
            {
                return new Wektor(w1.X / d, w1.Y / d, w1.Z / d);
            }

            public static Wektor operator ^(Wektor w1, Wektor w2)
            {
                return Cross(w1, w2);
            }

            public static bool CzyProstopadłe(Wektor w1, Wektor w2)
            {
                if (w1.Długość == 0 || w2.Długość == 0) return false;
                return Wektor.Dot(w1, w2) == 0;
            }

            public int CompareTo(Wektor other)
            {
                double różnica = Długość - other.Długość;
                return Math.Sign(różnica);
            }

            public static Wektor SumaWażona((double, Wektor)[] tablica)
            {
                double x = 0;
                double y = 0;
                double z = 0;

                double m = 0;

                foreach (var element in  tablica)
                {
                    (double masa, Wektor wektor) = element;
                    x += masa * wektor.X;
                    y += masa * wektor.Y;
                    z += masa * wektor.Z;
                    m += masa;
                }
                if (m == 0) return new Wektor(0, 0, 0);
                
                return new Wektor(x / m, y / m, z / m);
            }
        }
        static void Main(string[] args)
        {
            Wektor wektor1 = new Wektor(1, 2, 3);
            Console.WriteLine(wektor1.Długość);
            Wektor wektor2 = new Wektor(1, 2, 3);

            Wektor sumaWektorów = wektor1 + wektor2;
            Wektor różnicaWektorów = wektor1 - wektor2;

            Console.WriteLine($"{wektor1.ToString()} + {wektor2.ToString()} = {sumaWektorów.ToString()}");
            Console.WriteLine($"{wektor1.ToString()} - {wektor2.ToString()} = {różnicaWektorów.ToString()}");

            Wektor minusWektor = -wektor1;
            Console.WriteLine($"-{wektor1.ToString()} = {minusWektor.ToString()}");
            Wektor plusWektor = +minusWektor;
            Console.WriteLine($"+{minusWektor} = {plusWektor.ToString()}");

            Console.WriteLine($"{wektor1.ToString()} == {wektor2.ToString()} => {wektor1 == wektor2}");
            Console.WriteLine($"{wektor1.ToString()} != {wektor2.ToString()} => {wektor1 != wektor2}");
            Console.WriteLine($"wektor1.Equals(wektor2) ==> {wektor1.Equals(wektor2)}");
            Console.WriteLine($"wektor1.GetHashCode() => {wektor1.GetHashCode()}");
            Console.WriteLine($"wektor2.GetHashCode() => {wektor2.GetHashCode()}");

            Console.WriteLine(Wektor.Dot(wektor1, wektor2));
            Console.WriteLine(wektor1 * wektor2);
            Console.WriteLine(Wektor.Cross(wektor1, new Wektor(1, 2.5, 3)));
            Console.WriteLine(wektor1 ^ new Wektor(1, 2.5, 3));

            Console.WriteLine(wektor1 * 3);
            Console.WriteLine(3 * wektor1);

            Console.WriteLine(wektor2 / 0.5);
            Console.WriteLine(wektor2 / 2);

            Console.WriteLine($"Czy prostopadłe {wektor1}, {wektor2}: {Wektor.CzyProstopadłe(wektor1, wektor2)}");

            Wektor wektor3 = new Wektor(2, 0, 0);
            Wektor wektor4 = new Wektor(0, 2, 0);
            Console.WriteLine($"Czy prostopadłe {wektor3}, {wektor4}: {Wektor.CzyProstopadłe(wektor3, wektor4)}");

            Wektor[] wektory = new Wektor[] {
                new Wektor(1, 23, 2),
                new Wektor(4, 2, 8),
                new Wektor(-8, 5, 6),
                new Wektor(1, 1, 1)
            };
            foreach (Wektor w in wektory) Console.WriteLine(w.Długość);
            Array.Sort(wektory);
            foreach (Wektor w in wektory) Console.WriteLine(w.Długość);

            (double, Wektor)[] tablicaKrotek = new[]
            {
                (2.0, wektor1),
                (3.5, wektor2),
                (9.0, wektor3)
            };

            Console.WriteLine(Wektor.SumaWażona(tablicaKrotek));
        }
    }
}