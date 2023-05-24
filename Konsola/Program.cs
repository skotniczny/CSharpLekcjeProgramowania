namespace Konsola
{
    using Model;
    using Kontroler;

    class Program
    {
        static void Main(string[] args)
        {
            UstawieniaKonsoli model = PomocnikUstawieńKonsoli.UstawieniaBieżące;

            Menu kontroler = new Menu(model);
            kontroler.Uruchom();
        }
    }
}