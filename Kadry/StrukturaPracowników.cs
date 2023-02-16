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

    public class Kierownik : Pracownik
    {
        public const decimal dodatekFunkcyjny = 300;

        public Kierownik(string imię, string nazwisko, string stanowisko, decimal pensjaPodstawowa) : base(imię, nazwisko, stanowisko, pensjaPodstawowa + dodatekFunkcyjny)
        {

        }

        private List<Pracownik> podwładni = new List<Pracownik>();

        public void DodajPodwładnego(Pracownik pracownik)
        {
            podwładni.Add(pracownik);
        }

        public override string ToString()
        {
            string s = base.ToString();
            if (podwładni.Count > 0)
            {
                s += "\nPodwładni:";
                foreach (Pracownik podwładny in podwładni)
                {
                    s += $"\n {podwładny}";
                }
            }
            return s;
        }
    }
}
