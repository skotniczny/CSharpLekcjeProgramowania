namespace Konsola
{
    using Model;

    class Program
    {
        static void Main(string[] args)
        {
            UstawieniaKonsoli model = PomocnikUstawieńKonsoli.UstawieniaBieżące;
            Console.WriteLine(model.ToString());
        }
    }
}