using System.Diagnostics.Metrics;

namespace RejestrowanieNieprzewidzianychZdarzeń
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1
            Action akcja = async () =>
            {
                int licznik = 0;
                while (true)
                {
                    Log.Instancja.Dodaj("Licznik: " + licznik.ToString());
                    licznik++;
                    await Task.Delay(1000);
                }
            };
            Task.Run(akcja);

            //2
            Console.WriteLine("Wciskaj klawisze. Koniec - naciścięcie Escape");
            ConsoleKeyInfo cki;
            do
            {
                cki = Console.ReadKey(false);
                Log.Instancja.Dodaj("Naciśnięty klawisz: " + cki.Key.ToString());
            }
            while (cki.Key != ConsoleKey.Escape);
            Log.Instancja.Zapisz();
        }
    }
}