using System;

namespace Konsola.Kontroler
{
    using static Console;

    public static class Wejście
    {
        public static int PobierzOdUżytkownikaLiczbęCałkowitą(string zachęta, int wartośćMaksymalna, int wartośćMinimalna = 0)
        {
            int? liczba = null;
            do
            {
                try
                {
                    string s;
                    do
                    {
                        Write(zachęta);
                        s = ReadLine();
                    }
                    while (string.IsNullOrWhiteSpace(s));
                    liczba = int.Parse(s);
                    if (liczba < wartośćMinimalna || liczba > wartośćMaksymalna)
                    {
                        throw new Exception("Niepoprawna wartość liczby");
                    }
                }
                catch (Exception exc)
                {
                    WriteLine($"Błąd: {exc.Message}");
                    WriteLine($"Niepoprawna wartość. Spróbuj jeszcze raz");
                };
            }
            while (!liczba.HasValue);
            return liczba.Value;
        }

        public static ConsoleColor PobierzOdUżytkownikaKolor(string zachęta)
        {
            ConsoleColor? kolor = null;
            do
            {
                try
                {
                    string s;
                    do
                    {
                        Write(zachęta);
                        s = ReadLine();
                        s = char.ToUpper(s[0]) + s.ToLower().Substring(1);
                        if (s.StartsWith("Dark") && s.Length > 5)
                        {
                            s = "Dark" + char.ToUpper(s[4]) + s.ToLower().Substring(5);
                        }
                    }
                    while (string.IsNullOrWhiteSpace(s));
                    kolor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), s);
                }
                catch (Exception exc)
                {
                    WriteLine($"Błąd: {exc.Message}");
                    WriteLine("Niepoprawna nazwa koloru. Spróbuj jeszcze raz");
                };
            }
            while (!kolor.HasValue);
            return kolor.Value;
        }
    }
}
