namespace Konsola
{
    using Model;
    using Kontroler;

    class Program
    {
        private const string ścieżkaPliku = "ustawienia.xml";

        static void Main(string[] args)
        {
            UstawieniaKonsoli model = PomocnikUstawieńKonsoli.UstawieniaBieżące;

            Menu kontroler = new Menu(model);
            kontroler.Uruchom();

            model.Zapisz(ścieżkaPliku);
            Console.WriteLine($"Ustawiwania zapisane do pliku {ścieżkaPliku}");
        }
    }
}