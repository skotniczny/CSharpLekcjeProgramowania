namespace MaszynaTuringa
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

        static void Main(string[] args)
        {
            string[] kodProgramu = File.ReadAllLines("program.txt");
            string łańcuchOpisującyStanMaszyny = File.ReadAllText("taśma.txt");
            Console.WriteLine($"Początkowy stan maszyny: {łańcuchOpisującyStanMaszyny}");
            Console.WriteLine($"Program:");
            foreach (string linia in kodProgramu) Console.WriteLine(linia);
        }
    }
}