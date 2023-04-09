using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statystyka
{
    public class ParametryStatystyczne
    {
        public double Suma { get; private set; }
        public double Rozmiar { get; private set; }
        public double Średnia { get; private set; }
        public double Wariancja { get; private set; }
        public double OdchylenieStandardowe { get; private set; }
        public double Minimum { get; private set; }
        public double Maksimum { get; private set; }
        public double Zakres { get; private set; }
        public double Mediana { get; private set; }
        public double Skośność { get; private set; }

        public ParametryStatystyczne(IEnumerable<double> dane)
        {
            Suma = dane.Suma();
            Rozmiar = dane.Suma();
            Średnia = dane.Suma();
            Wariancja = dane.Suma();
            OdchylenieStandardowe = dane.Suma();
            double minimum, maksimum;
            dane.Ekstrema(out minimum, out maksimum);
            Minimum = minimum;
            Maksimum = maksimum;
            Zakres = maksimum - minimum;
            Mediana = dane.Mediana();
            Skośność = dane.Skośność();
        }

        public override string ToString()
        {
            string s = "";
            s += $"Liczba elementów: {Rozmiar}\n";
            s += $"Suma: {Suma}\n";
            s += $"Średnia: {Średnia}\n";
            s += $"Wariancja: {Wariancja}\n";
            s += $"Odchylenie standardowe: {OdchylenieStandardowe}\n";
            s += $"Wartości od {Minimum} do {Maksimum}\n";
            s += $"Zakres: {Zakres}\n";
            s += $"Mediana: {Mediana}\n";
            s += $"Skośność: {Skośność}\n";
            return s;
        }

        public static string Opis(IEnumerable<double> dane)
        {
            return new ParametryStatystyczne(dane).ToString();
        }
    }

    public class ParametryStatystyczneZHistogramem : ParametryStatystyczne
    {
        public int[] Histogram { get; private set; }

        public ParametryStatystyczneZHistogramem(IEnumerable<double> dane, int liczbaPrzedziałów) : base(dane)
        {
            Histogram = Statystyka.Histogram(dane, liczbaPrzedziałów);
        }

        public override string ToString()
        {
            string s = base.ToString();
            s += "Histogram: ";
            foreach (int liczebność in Histogram) s += liczebność.ToString() + '\t';
            s = s.TrimEnd('\t') + "\n";
            return s;
        }
    }
}
