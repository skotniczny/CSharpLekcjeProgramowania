namespace Kadry
{
    public class Pracownik
    {
        private string imię;
        private string nazwisko;
        private string stanowisko;
        private decimal pensja;

        public Pracownik(string imię, string nazwisko, string stanowisko, decimal pensja)
        {
            this.imię = imię;
            this.nazwisko = nazwisko;
            this.stanowisko = stanowisko;
            this.pensja = pensja;
        }

        public override string ToString()
        {
            return $"{imię} {nazwisko}, {stanowisko} ({pensja:C})";
        }
    }
}
