namespace Konsola
{
    using Model;
    using Kontroler;

    class Program
    {
        private const string ścieżkaPliku = "ustawienia.xml";

        static void Main(string[] args)
        {
            #region Inicjacja
            UstawieniaKonsoli model;
            try
            {
                model = PomocnikXml.Czytaj(ścieżkaPliku);
            }
            catch (Exception exc)
            {
                model = PomocnikUstawieńKonsoli.UstawieniaDomyślne;
                Console.Error.WriteLine($"Błąd: {exc.Message}. Stosuję ustawienia domyślne");
            }
            #endregion

            Menu kontroler = new Menu(model);
            kontroler.Uruchom();

            model.Zapisz(ścieżkaPliku);
            Console.WriteLine($"Ustawiwania zapisane do pliku {ścieżkaPliku}");
        }
    }
}