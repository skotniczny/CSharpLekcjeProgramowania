namespace Z1002
{
    using Czwórki = SortedList<(char stanGłowicy, char wartośćNaTaśmie), (char nowyStanGłowicy, char nowaWartośćNaTaśmie)>;
    internal class Program
    {
        #region Łańcuch opisujący stan maszyny
        static (char[] taśma, char stanGłowicy, int położenieGłowicy) analizujOpisStanuMaszyny(string łańcuchOpisującyStanMaszyny)
        {
            char początkowyStanGłowicy = ' ';
            int początkowePołożenieGłowicy = -1;
            for (int i = 0; i < łańcuchOpisującyStanMaszyny.Length; ++i)
            {
                char c = łańcuchOpisującyStanMaszyny[i];
                if (c == 'L' || c == 'R')
                    throw new Exception("Taśma nie może zawierać wartości L lub R");
                if (char.IsLower(c))
                {
                    if (początkowePołożenieGłowicy != -1)
                        throw new Exception(
                        "Znaleziono więcej niż jeden znak oznaczający głowicę");
                    początkowyStanGłowicy = c;
                    początkowePołożenieGłowicy = i;
                    łańcuchOpisującyStanMaszyny =
                    łańcuchOpisującyStanMaszyny.Remove(początkowePołożenieGłowicy, 1);
                }
                else
                {
                    if (c < 'A' || c > 'Z')
                        throw new Exception($"Niepoprawna wartość na taśmie ({c}) na pozycji {i}");
                }
            }
            if (początkowePołożenieGłowicy < 0)
                throw new Exception("Nie znaleziono znaku oznaczającego głowicę");
            return (łańcuchOpisującyStanMaszyny.ToCharArray(), początkowyStanGłowicy, początkowePołożenieGłowicy);
        }
        static string pobierzŁańcuchOpisującyStanMaszyny(
        (char[] taśma, char stanGłowicy, int położenieGłowicy) stanMaszyny)
        {
            string s = new string(stanMaszyny.taśma);
            s = s.Insert(stanMaszyny.położenieGłowicy, stanMaszyny.stanGłowicy.ToString());
            return s;
        }
        #endregion

        #region Parsowanie kodu programu
        static bool czyCzwórkaPoprawna(string linia)
        {
            Func<char, bool> isLowerLetter = (char c) => c >= 'a' && c <= 'z';
            Func<char, bool> isUpperLetter = (char c) => c >= 'A' && c <= 'Z';
            return isLowerLetter(linia[0]) && isUpperLetter(linia[1])
                && isUpperLetter(linia[2]) && isLowerLetter(linia[3]);
        }
        static Czwórki parsujProgram(string[] kodProgramu)
        {
            Czwórki czwórki = new Czwórki();
            foreach (string linia in kodProgramu)
            {
                if (string.IsNullOrWhiteSpace(linia)) continue;
                if (!czyCzwórkaPoprawna(linia)) throw new Exception($"Niepoprawna linia kodu ({linia})");
                (char, char) bieżącyStan = (linia[0], linia[1]);
                (char, char) nowyStan = (linia[3], linia[2]);
                if (czwórki.ContainsKey(bieżącyStan)) throw new Exception("Program nie może zawierać dwóch poleceń o takim stanie głowicy i wartości na taśmie");
                czwórki.Add(bieżącyStan, nowyStan);
            }
            return czwórki;
        }
        #endregion

        static (char nowyStanGłowicy, char nowaWartośćLubPolecenie)? znajdźPolecenie(char stanGłowicy, char wartośćNaTaśmie, Czwórki program)
        {
            (char stanGłowicy, char wartośćNaTaśmie) bieżącyStan = (stanGłowicy, wartośćNaTaśmie);
            if (program.ContainsKey(bieżącyStan)) return program[bieżącyStan];
            return null;
        }
        static List<string> wykonajProgram(
        (char[] taśma, char stanGłowicy, int położenieGłowicy) stanMaszyny, Czwórki program)
        {
            List<string> historia = new List<string>();
            (char nowyStanGłowicy, char nowaWartośćLubPolecenie)? polecenie;
            while ((polecenie = znajdźPolecenie(stanMaszyny.stanGłowicy, stanMaszyny.taśma[stanMaszyny.położenieGłowicy], program)) != null)
            {
                stanMaszyny.stanGłowicy = polecenie.Value.nowyStanGłowicy;
                switch (polecenie.Value.nowaWartośćLubPolecenie)
                {
                    case 'L':
                        stanMaszyny.położenieGłowicy--;
                        break;
                    case 'R':
                        stanMaszyny.położenieGłowicy++;
                        break;
                    default:
                        stanMaszyny.taśma[stanMaszyny.położenieGłowicy] = polecenie.Value.nowaWartośćLubPolecenie;
                        break;
                }
                string łańcuchOpisującyStanMaszyny = pobierzŁańcuchOpisującyStanMaszyny(stanMaszyny);
                historia.Add(łańcuchOpisującyStanMaszyny);

                if (historia.Count >= 4)
                {
                    string ostatni = historia[historia.Count - 1];
                    string przedostatni = historia[historia.Count - 2];
                    for (int i = historia.Count - 3; i > 1; i--)
                    {
                        if (historia[i] == ostatni && historia[i - 1] == przedostatni)
                        {
                            Console.Write("Wykryto zapętlenie. Czy wstrzymać wykonywanie? [Y] Tak [N] Nie ");
                            ConsoleKey key = Console.ReadKey().Key;
                            Console.WriteLine();
                            if (key == ConsoleKey.Y) throw new Exception("Wykryto zapętlenie!");
                            else break;
                        }
                    }
                }
            }
            return historia;
        }

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
                //analiza taśmy
                var stanMaszyny = analizujOpisStanuMaszyny(łańcuchOpisującyStanMaszyny);
                Console.WriteLine($"Stan głowicy: {stanMaszyny.stanGłowicy}");
                Console.WriteLine($"Położenie głowicy: {stanMaszyny.położenieGłowicy}");
                Console.WriteLine($"Taśma: {new string(stanMaszyny.taśma)}");

                //parsowanie programu
                Czwórki program = parsujProgram(kodProgramu);

                Console.WriteLine("\nUruchomienie programu...");
                List<string> historia = wykonajProgram(stanMaszyny, program);

                Console.WriteLine("\nEwolucja stanu maszyny:");
                foreach (string linia in historia)
                {
                    Console.WriteLine(linia);
                }
            }
            catch (Exception exc)
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Error.WriteLine($"Błąd: {exc.Message}");
                Console.ForegroundColor = color;
            }
        }
    }
}