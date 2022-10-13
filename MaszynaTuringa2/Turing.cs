namespace MaszynaTuringa2
{
    struct Dwójka : IComparable<Dwójka>
    {
        public char StanGłowicy;
        public char WartośćLubPolecenieNaTaśmie;

        public int CompareTo(Dwójka other)
        {
            int wartosc = StanGłowicy.CompareTo(other.StanGłowicy);
            if (wartosc != 0) return wartosc;
            else return WartośćLubPolecenieNaTaśmie.CompareTo(other.WartośćLubPolecenieNaTaśmie);
        }
    }
    struct Czwórka
    {
        public Dwójka BieżącyStan, NowyStan;

        private static bool czyŁańcuchCzwórkiPoprawny(string linia)
        {
            Func<char, bool> isLowerLetter = (char c) => c >= 'a' && c <= 'z';
            Func<char, bool> isUpperLetter = (char c) => c >= 'A' && c <= 'Z';
            return isLowerLetter(linia[0]) && isUpperLetter(linia[1]) &&
                   isUpperLetter(linia[2]) && isLowerLetter(linia[3]);
        }

        public static Czwórka Parsuj(string linia)
        {
            if (string.IsNullOrEmpty(linia)) throw new Exception("Pusta linia kodu");
            if (!czyŁańcuchCzwórkiPoprawny(linia)) throw new Exception($"Niepoprawna linia kodu {linia}");
            Czwórka czwórka = new Czwórka()
            {
                BieżącyStan = new Dwójka()
                {
                    StanGłowicy = linia[0],
                    WartośćLubPolecenieNaTaśmie = linia[1]
                },
                NowyStan = new Dwójka()
                {
                    StanGłowicy = linia[3],
                    WartośćLubPolecenieNaTaśmie = linia[2]
                }
            };
            return czwórka;
        }
    }

    class Turing
    {
    }
}
