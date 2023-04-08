namespace Kadry
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Kierownik rektor = new Kierownik("Andrzej", "Nuter", "rektor", 10000);
            rektor.DodajPodwładnego(new Pracownik("Andrzej", "Tokala", "prorektor", 8000));
            rektor.DodajPodwładnego(new Pracownik("Beata", "Madorowska", "prorektor", 8000));
            Kierownik dziekan = new Kierownik("Włodzimierz", "Sokólski", "dziekan", 7000);
            rektor.DodajPodwładnego(dziekan);
            dziekan.DodajPodwładnego(new Pracownik("Anna", "Wartkiewicz", "prodziekan", 6000));
            Kierownik kierownikZakładu = new Kierownik("Michał", "Wieliński", "kierownik zakładu", 5000);
            dziekan.DodajPodwładnego(kierownikZakładu);
            kierownikZakładu.DodajPodwładnego(new Pracownik("Jacek", "Matulewski", "adiunkt", 4000));
            kierownikZakładu.DodajPodwładnego(new Pracownik("Karolina", "Skowronek", "asystent", 3000));

            OdwiedzającyWyświetlającyInformacje odwiedzającyWyświetlającyInformacje = new OdwiedzającyWyświetlającyInformacje();
            rektor.PrzyjmijWizytę(odwiedzającyWyświetlającyInformacje);
        }
    }
}