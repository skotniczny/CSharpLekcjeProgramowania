namespace Konsola
{
    using Model;
    using Kontroler;

    class Program
    {
        private const string ścieżkaPliku = "ustawienia.json";

        static void Main(string[] args)
        {
            #region Inicjacja
            UstawieniaKonsoli model;
            try
            {
                model = Serializacja.CzytajJson(ścieżkaPliku);
            }
            catch (Exception exc)
            {
                model = PomocnikUstawieńKonsoli.UstawieniaDomyślne;
                Console.Error.WriteLine($"Błąd: {exc.Message}. Stosuję ustawienia domyślne");
            }
            #endregion

            Menu kontroler = new Menu(model);
            kontroler.Uruchom();

            model.ZapiszJson(ścieżkaPliku);
            Console.WriteLine($"Ustawiwania zapisane do pliku {ścieżkaPliku}");
        }
    }
}