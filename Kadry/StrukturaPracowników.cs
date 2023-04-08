namespace Kadry
{
    public interface IOdwiedzany
    {
        void PrzyjmijWizytę(IOdwiedzający odwiedzający);
    }

    public interface IOdwiedzający
    {
        void Odwiedź(IOdwiedzany pracownik);
    }
    public class Pracownik : IOdwiedzany
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

        public virtual void PrzyjmijWizytę(IOdwiedzający odwiedzający)
        {
            odwiedzający.Odwiedź(this);
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

        public override void PrzyjmijWizytę(IOdwiedzający odwiedzający)
        {
            base.PrzyjmijWizytę(odwiedzający);
            foreach (Pracownik podwładny in podwładni)
            {
                podwładny.PrzyjmijWizytę(odwiedzający);
            }
        }
    }
}
