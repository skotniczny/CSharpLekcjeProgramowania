using System;
using System.Collections.Generic;
using System.Globalization;

namespace KursyWalut
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TabelaKursówNBP tabela = PomocnikNbp.PobierzAktualnąTabelęKursówWalutNBP();
                string s = "Tabela kursów walut";
                s += $"\n\nNumber tabeli: {tabela.NumerTabeli}";
                s += $"\nData notowania: {tabela.DataNotowania.ToLongDateString()}";
                s += $"\nData publikacji: {tabela.DataPublikacji.ToLongDateString()}";
                foreach (KeyValuePair<string, KursyWalutyNBP> pozycja in tabela.Pozycje)
                {
                    s += $"\n {pozycja.Value.ToString()}";
                }
                Console.WriteLine(s);
                Console.WriteLine($"EUR { tabela.Pozycje["EUR"].KursSprzedaży}");
            }
            catch (Exception exc)
            {
                Console.Error.WriteLine($"Błąd podczas pobierania kursów walut NBP: {exc.ToString()}");
            }
        }
    }
}