﻿using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace Z1104
{
    internal class Program
    {
        public struct Wektor
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

            Console.WriteLine($"{wektor1.ToString()} == {wektor2.ToString()} => { wektor1 == wektor2}");
            Console.WriteLine($"{wektor1.ToString()} != {wektor2.ToString()} => { wektor1 != wektor2}");
            Console.WriteLine($"wektor1.Equals(wektor2) ==> {wektor1.Equals(wektor2)}");
            Console.WriteLine($"wektor1.GetHashCode() => {wektor1.GetHashCode()}");
            Console.WriteLine($"wektor2.GetHashCode() => {wektor2.GetHashCode()}");
        }
    }
}