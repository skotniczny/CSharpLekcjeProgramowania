using Turing;

namespace MaszynaTuringa2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.Error.WriteLine("Do uruchomienia program wymaga dwóch argumentów");
                return;
            }

            string ścieżkaPlikuProgramu = args[0];
            if (!File.Exists(ścieżkaPlikuProgramu))
            {
                Console.Error.WriteLine($"Brak pliku z kodem programu {ścieżkaPlikuProgramu}");
                return;
            }
            Console.WriteLine($"Pliki z kodem programu {ścieżkaPlikuProgramu}");
            string[] kodProgramu = File.ReadAllLines(ścieżkaPlikuProgramu);

            string ścieżkaPlikuTaśmy = args[1];
            if (!File.Exists(ścieżkaPlikuTaśmy))
            {
                Console.Error.WriteLine($"Brak pliku ze stanem maszyny {ścieżkaPlikuTaśmy}");
                return;
            }
            Console.WriteLine($"Plik ze stanem maszyny {ścieżkaPlikuTaśmy}");
            string łańcuchOpisującyStanMaszyny = File.ReadAllText("taśma.txt");

            Console.WriteLine($"Początkowy stan maszyny: {łańcuchOpisującyStanMaszyny}");
            Console.WriteLine($"Program:");
            foreach (string linia in kodProgramu) Console.WriteLine(linia);

            try
            {
                Turing.MaszynaTuringa maszyna = new Turing.MaszynaTuringa(łańcuchOpisującyStanMaszyny, kodProgramu);
                maszyna.StanZmieniony += Maszyna_StanZmieniony;
                string[] historia = maszyna.WykonajProgram();
            }
            catch (Exception exc)
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Error.WriteLine($"Błąd: {exc.Message}");
                Console.ForegroundColor = color;
            }
        }

        private static void Maszyna_StanZmieniony(object sender, Turing.MaszynaTuringa.StanZmienionyEventArgs e)
        {
            Console.WriteLine(e.ŁańcuchOpisującyNowyStan);
        }
    }
}