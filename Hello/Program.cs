namespace Hello
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Jak Ci na imię?");
            Console.Write("Napisz tutaj swoje imię: ");
            string imię = Console.ReadLine();
            if (imię.Length == 0)
            {
                Console.Error.WriteLine("\n\n\t*** Błąd: nie podano imienia!\n\n");
                return;
            }
            bool niewiasta = imię.ToLower()[imię.Length - 1] == 'a';
            if (imię == "Kuba" || imię == "Barnaba") niewiasta = false;
            Console.WriteLine(
            "Niech zgadnę, jesteś " + (niewiasta ? "dziewczyną" : "chłopakiem") + "!");
            Console.WriteLine("Naciśnij Enter...");
            Console.Read();
        }
    }
}