namespace Kadry
{
    public interface IOdwiedzany
    {
        void PrzyjmijWizytę(IOdwiedzający odwiedzający, int głębokość);
    }

    public interface IOdwiedzający
    {
        void Odwiedź(IOdwiedzany pracownik, int głębokość);
    }
    public class Pracownik : IOdwiedzany
    {
        private string imię;
        private string nazwisko;
        private string stanowisko;
        private decimal pensja;

        protected internal bool odwiedzony = false;

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

        public virtual void PrzyjmijWizytę(IOdwiedzający odwiedzający, int głębokość)
        {
            odwiedzający.Odwiedź(this, głębokość);
            odwiedzony = true;
        }

        protected internal virtual void resetuj()
        {
            odwiedzony = false;
        }
    }

    public class Kierownik : Pracownik
    {
        public const decimal dodatekFunkcyjny = 300;

        private static int? głębokośćPierwszegoKierownika = null;

        public Kierownik(string imię, string nazwisko, string stanowisko, decimal pensjaPodstawowa) : base(imię, nazwisko, stanowisko, pensjaPodstawowa + dodatekFunkcyjny)
        {

        }

        private List<Pracownik> podwładni = new List<Pracownik>();

        public void DodajPodwładnego(Pracownik pracownik)
        {
            podwładni.Add(pracownik);
        }

        public override void PrzyjmijWizytę(IOdwiedzający odwiedzający, int głębokość = 0)
        {
            if (!głębokośćPierwszegoKierownika.HasValue)
            {
                głębokośćPierwszegoKierownika = głębokość;
            }
            base.PrzyjmijWizytę(odwiedzający, głębokość);
            foreach (Pracownik podwładny in podwładni)
            {
                if (!podwładny.odwiedzony)
                {
                    podwładny.PrzyjmijWizytę(odwiedzający, głębokość + 1);
                }
            }
            if (głębokość == głębokośćPierwszegoKierownika)
            {
                resetuj();
                głębokośćPierwszegoKierownika = null;
            }
        }

        protected internal override void resetuj()
        {
            base.resetuj();
            foreach (Pracownik podwładny in podwładni)
            {
                if (podwładny.odwiedzony)
                {
                    podwładny.resetuj();
                }
            }
        }
    }

    public class OdwiedzającyWyświetlającyInformacje : IOdwiedzający
    {
        private static string przygotujWcięcie(int głębokość)
        {
            string s = "";
            for (int i = 0; i < głębokość; ++i) s += " ";
            return s;
        }
        public void Odwiedź(IOdwiedzany pracownik, int głębokość)
        {
            Console.WriteLine(przygotujWcięcie(głębokość) + pracownik.ToString());
        }
    }
}
