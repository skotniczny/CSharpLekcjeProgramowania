using System.Text;

namespace Tłumacz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedList<string, string> słownik = new SortedList<string, string>()
            {
                { "if", "jeżeli" },
                { "else", "gdy_nie" },
                { "for", "dla" },
                { "do", "rób" },
                { "while", "dopóki" },
                { "switch", "wybór" },
                { "case", "przypadek" },
                { "List", "Lista" },
                { "Random", "Losowy" },
                { "Queue", "Kolejka" },
                { "Stack", "Stos" }
            };

            string ścieżkaPliku = @"..\..\..\..\ZabawaKostkami\Program.cs";
            Console.WriteLine($"Czytam plik {ścieżkaPliku}...");
            string tekst = File.ReadAllText(ścieżkaPliku);

            //foreach (string słowo in słownik.Keys)
            //    tekst = tekst.Replace(słowo, słownik[słowo]);

            StringBuilder _tekst = new StringBuilder(tekst);
            foreach (string słowo in słownik.Keys)
                _tekst.Replace(słowo, słownik[słowo]);
            tekst = _tekst.ToString();

            string ścieżkaKatalogu = Path.GetDirectoryName(ścieżkaPliku);
            string nazwaPlikuBezRozszerzenia = Path.GetFileNameWithoutExtension(ścieżkaPliku);
            string rozszerzenie = Path.GetExtension(ścieżkaPliku);
            string nowaŚcieżkaPliku = Path.Combine(ścieżkaKatalogu,nazwaPlikuBezRozszerzenia + "_tłumaczenie" + rozszerzenie);
    
            //zachować rozszerzenie
            Console.WriteLine($"Zapisuję tłumaczenie do pliku {nowaŚcieżkaPliku}...");
            File.WriteAllText(nowaŚcieżkaPliku, tekst);
        }
    }
}